/* @name Lignite For Betfair Project
 * @author Carel Vosloo
 * @author Betfair Developers Program (http://bdp.betfair.com)
 * @copyright Copyright (C) 2008 Betfair Ltd. All rights reserved.
 * @license This file is part of the Lignite For Betfair Project.
 * The BetfairAPIFramework is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The "Lignite For Betfair Project" is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the "Lignite For Betfair Project".  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Timers;
using Betfair.API;
using Betfair.Collections;
using Lignite.Configuration;
using Lignite.Engine.Events;

namespace Lignite.Engine
{
    public class AutoMarketLoader
    {
        #region Variables

        private readonly GetAllMarkets getAllMarkets;
        private readonly StrategyLoadPatern[] strategies;
        private DateTime wakeUpTime;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; private set; }

        #endregion

        #region Initialize

        internal AutoMarketLoader()
        {
        }

        internal AutoMarketLoader(string sessionToken, GetAllMarkets getAllMarkets, StrategyLoadPatern[] strategies)
        {
            Core.betfairAPI = new BetfairAPI(sessionToken);
            this.getAllMarkets = getAllMarkets;
            this.strategies = strategies;
        }

        #endregion

        #region OnTimedEvent

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now < wakeUpTime || !IsRunning) return;
            SendMessage("AutoMarketLoader: Waking up");
            LoadMarkets();
        }

        #endregion

        #region Start/Stop

        internal void Start()
        {
            Core.TimerTick += OnTimedEvent;
            Core.SystemShutdown += Stop;

            IsRunning = true;
            LoadMarkets();
        }

        internal void Stop(object sender, EventArgs args)
        {
            Stop();
        }

        internal void Stop()
        {
            IsRunning = false;
            Core.TimerTick -= OnTimedEvent;
            Core.SystemShutdown -= Stop;
        }

        #endregion

        #region SendMessage

        private void SendMessage(string message)
        {
            Broker.Execute(EventNames.MarketProcessorMessage, this, new NewMessageEventArgs(message));
        }

        #endregion

        #region Clean-up MarketsLoadedList

        /// <summary>
        /// Cleans up markets loaded list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        private static IDictionary<string, Market> CleanUpMarketsLoadedList(IDictionary<string, Market> list)
        {
            var toBeRemoved = new List<string>();

            foreach (var m in list)
            {
                var span = m.Value.eventDate - DateTime.Now.ToUniversalTime();
                if (span.TotalMilliseconds < 100) toBeRemoved.Add(m.Key);
            }

            foreach (var s in toBeRemoved)
            {
                list.Remove(s);
            }

            return list;
        }

        #endregion

        #region GetObjectValues

        /// <summary>
        /// Gets the object values.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        private static Dictionary<string, object> GetObjectValues(object source)
        {
            var valueCollection = new Dictionary<string, object>();

            if (source == null) return valueCollection;

            foreach (var property in source.GetType().GetProperties())
            {
                if(property == null) continue;

                var val = property.GetValue(source, null);
                valueCollection.Add(property.Name.ToLower(), val);
            }

            return valueCollection;
        }

        #endregion

        #region LoadMarkets

        private MarketList marketList;
        private Dictionary<String, Market> marketsLoaded;

        /// <summary>
        /// Loads the markets.
        /// </summary>
        private void LoadMarkets()
        {
            if (marketsLoaded == null) marketsLoaded = new Dictionary<String, Market>();
            if (marketList == null) marketList = new MarketList();
            if (!IsRunning) return;
            IsRunning = false;

            try
            {
                // Remove markets that have expired
                marketsLoaded = (Dictionary<String, Market>)CleanUpMarketsLoadedList(marketsLoaded);
                
                // Notify the user
                SendMessage("AutoMarketLoader: Market loader looking for new markets.");

                foreach (var exchangeId in getAllMarkets.ExchangeIds)
                {
                    marketList = null;
                    marketList = Core.betfairAPI.GetAllMarketsObject(exchangeId, getAllMarkets.Countries,
                                                                     getAllMarkets.EventIds,
                                                                     Convert.ToInt32(getAllMarkets.EventDateTo),
                                                                     Convert.ToInt32(getAllMarkets.EventDateFrom));

                    if (marketList == null) continue;

                    SendMessage("AutoMarketLoader: " + marketList.Count + " potensial markets found.");

                    foreach (Market market in marketList)
                    {
                        if (marketsLoaded.ContainsKey((market.exchangeId + ":" + market.marketId)) ||
                            market.status != MarketStatus.ACTIVE) continue;

                        var marketProperties = GetObjectValues(market);

                        foreach (var strategy in strategies)
                        {
                            if (strategy.FilterGetAllMarketsResults == null) continue;

                            var loadMarket = new bool[strategy.FilterGetAllMarketsResults.Length];
                                    
                            for (var x = 0; x < strategy.FilterGetAllMarketsResults.Length; x++)
                            {
                                var endReached = false;
                                loadMarket[x] = true;
                                var query = strategy.FilterGetAllMarketsResults[x];

                                while (!endReached)
                                {
                                    string propertyValue;
                                    if (!marketProperties.ContainsKey(query.Field.ToLower()))
                                    {
                                        loadMarket[x] = false;
                                    }
                                    else
                                    {
                                        propertyValue =
                                            (marketProperties[query.Field.ToLower()].ToString()).ToLower
                                                ();

                                        switch (query.Operator)
                                        {
                                            case QueryOperator.CONTAINS:
                                                if (!propertyValue.Contains(query.Value.ToLower()))
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.NOT_CONTAINS:
                                                if (propertyValue.Contains(query.Value.ToLower()))
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.EQUAL:
                                                if (propertyValue != query.Value.ToLower())
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.NOT_EQUAL:
                                                if (propertyValue == query.Value.ToLower())
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.GREATER_THAN:
                                                if (Convert.ToDouble(propertyValue) >
                                                    Convert.ToDouble(query.Value))
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.LESS_THAN:
                                                if (Convert.ToDouble(propertyValue) <
                                                    Convert.ToDouble(query.Value))
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.REGEX_IS_MATCH:
                                                if (
                                                    !Regex.IsMatch(
                                                         (marketProperties[query.Field.ToLower()].ToString()),
                                                         query.Value))
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                            case QueryOperator.REGEX_NOT_MATCH:
                                                if (
                                                    Regex.IsMatch(
                                                        (marketProperties[query.Field.ToLower()].ToString()),
                                                        query.Value))
                                                {
                                                    loadMarket[x] = false;
                                                }
                                                break;
                                        }
                                    }

                                    if (query.And != null)
                                    {
                                        query = query.And;
                                    }
                                    else
                                    {
                                        endReached = true;
                                    }
                                }
                            }

                            for (var x = 0; x < loadMarket.Length; x++)
                            {
                                if (!loadMarket[x]) continue;

                                marketsLoaded.Add((market.exchangeId + ":" + market.marketId),
                                                  market);
                                Broker.Execute(EventNames.LoadNewMarketAction, this,
                                               new NewMarketEventArgs(exchangeId, market.marketId,
                                                                      strategy));
                                continue;
                            }
                        }
                    }
                }

                wakeUpTime = DateTime.Now.AddMilliseconds(getAllMarkets.RunMarketsQueryEvery);
                SendMessage("AutoMarketLoader: Going to sleep until " + wakeUpTime);
            }
            catch (Exception ex)
            {
                SendMessage("EXCEPTION: AutoMarketLoader: Message:" + ex.Message);
                SendMessage("EXCEPTION: AutoMarketLoader: Stack Trace:" + ex);
            }

            IsRunning = true;
        }

        #endregion
    }
}