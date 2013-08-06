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
using System.Collections;
using System.Collections.Generic;

namespace Betfair.Collections
{

    #region MarketList

    /// <summary>
    /// Collection of Market items
    /// </summary>
    [Serializable]
    public class MarketList : CollectionBase
    {
        /* Note on: lock (this.List.SyncRoot) usage.
         * While the Synchronized wrappers may improve performance by virtue of the fact that they 
         * contain internal knowledge of the container’s implementation, they can only guarantee the 
         * atomicity of individual methods. Therefore, if a reader thread iterates over a container 
         * while a writer thread adds or removes items from it, the container’s content is changing 
         * during the reader’s iteration. This can cause confusion and could be undesirable because 
         * it might show a non-stable view of the object. If we really want groups of operations to 
         * be taken atomically, then we are back at our first solution: placing those operations 
         * within a monitor’s protection. However, instead of directly locking the container, 
         * lock the SyncRoot property of the container, which gives the proper behavior regardless 
         * of what you pass to it: an unsynchronized container instance or a wrapped instance 
         * obtained by using the Synchronized static method. What we are trying to avoid here is to 
         * have double synchronization which could hurt performance unnecessarily; this could happen 
         * if we are using a synchronized wrapper for those places where method atomicity is sufficient, 
         * but would like to use a monitor for making sets of operations atomic. The SyncRoot 
         * property is able to do this because it will always return the raw container object.
         */

        /// <summary>
        /// Get the Market at IList[Index]
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public virtual Market this[int Index]
        {
            get { return (Market) List[Index]; }
        }

        /// <summary>
        /// Add a MarketItem to the IList
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(Market item)
        {
            lock (List.SyncRoot)
            {
                //forward our Add method on to 
                //CollectionBase.IList.Add
                List.Add(item);
            }
        }

        /// <summary>
        /// Does the list contain the following MarketItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Market item)
        {
            lock (List.SyncRoot)
            {
                return List.Contains(item);
            }
        }

        /// <summary>
        /// Does the list contain the following Market
        /// </summary>
        /// <param name="marketId">The market id.</param>
        /// <param name="exchangeId">The exchange id.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified market id]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(int marketId, int exchangeId)
        {
            lock (List.SyncRoot)
            {
                bool resp = false;
                foreach (Market market in List)
                {
                    if (market.marketId == marketId && market.exchangeId == exchangeId)
                    {
                        resp = true;
                        break;
                    }
                }
                return resp;
            }
        }

        /// <summary>
        /// Is their runners in this list with bets
        /// </summary>
        /// <returns></returns>
        public List<Market> HasBets()
        {
            lock (List.SyncRoot)
            {
                var response = new List<Market>();

                foreach (Market market in List)
                {
                    if (market.runnersWithBets.Count > 0)
                    {
                        response.Add(market);
                    }
                }
                return response;
            }
        }

        /// <summary>
        /// Does the list contain the following MarketItem
        /// </summary>
        /// <param name="marketId">The market id.</param>
        /// <param name="exchangeId">The exchange id.</param>
        /// <returns></returns>
        public virtual Market GetMarketByMarketId(int marketId, int exchangeId)
        {
            lock (List.SyncRoot)
            {
                foreach (Market market in List)
                {
                    if (market.marketId == marketId)
                    {
                        return market;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Does the list contain the following MarketItem
        /// </summary>
        /// <param name="marketId">The market id.</param>
        /// <param name="exchangeId">The exchange id.</param>
        /// <returns></returns>
        public virtual int GetMarketIndexNoByMarketId(int marketId, int exchangeId)
        {
            lock (List.SyncRoot)
            {
                int count = 0;
                foreach (Market market in List)
                {
                    if (market.marketId == marketId && market.exchangeId == exchangeId)
                    {
                        return count;
                    }
                    count++;
                }
                return -1;
            }
        }

        /// <summary>
        /// Sort the collection
        /// Example: item.Sort(new MarketItemsDateComparer());
        /// </summary>
        /// <param name="Comparer"></param>
        public void Sort(IComparer Comparer)
        {
            lock (List.SyncRoot)
            {
                InnerList.Sort(Comparer);
            }
        }
    }

    /// <summary>
    /// Order MarketItems by date and time
    /// </summary>
    public class MarketDateComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((Market) x).eventDate.CompareTo(((Market) y).eventDate);
        }

        #endregion
    }

    #endregion

    #region Market

    /// <summary>
    /// Market items collection
    /// </summary>
    [Serializable]
    public class Market
    {
        private double _totalAmountMatched;

        /// <summary>
        /// The Market Id of the market. Note: This is unique to an exchange, but is not guaranteed to be unique between exchanges. Always check the ExchangeID of the market.
        /// </summary>
        public int marketId { get; set; }

        /// <summary>
        /// The displayed name of the market. The name is returned in the account’s default locale or in the locale specified in the request.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Returns the last level of the menu path + the market name. If the menupath is not available only the market name gets returned
        /// </summary>
        public string partialFullName
        {
            get
            {
                if (menuPath != null)
                {
                    string[] menuPathItems = menuPath.Split("\\".ToCharArray());
                    if (menuPathItems.Length > 0)
                    {
                        return String.Format("{0} \\ {1}", menuPathItems[menuPathItems.Length - 1], name);
                    }
                }

                return String.Format("{0}", name);
            }
        }

        /// <summary>
        /// Returns the Market name + the entire menu path
        /// </summary>
        public string fullName
        {
            get { return String.Format("{0}\\ {1}", menuPath, name); }
        }

        /// <summary>
        /// The type of the market.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The current status of the market (i.e., active, suspended or closed).
        /// </summary>
        public MarketStatus status { get; set; }

        /// <summary>
        /// Does user commission discount count against Market Base Rate?
        /// </summary>
        public bool discountAllowed { get; set; }

        /// <summary>
        /// Base rate of commission on market
        /// </summary>
        public double marketBaseRate { get; set; }

        /// <summary>
        /// The time this API server updated its cache. The cache is updated whenever the server notices that the exchange data has changed. NOTE: This field does not indicate the age of the data. You should use the timestamp field in the API Response Header to determine the age of the response
        /// The time (in milliseconds since January 1 1970 00:00:00 GMT) since the cached market data was last refreshed from the exchange database.
        /// </summary>
        public long apiMarketDataLastRefresh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string marketInformation { get; set; }

        /// <summary>
        /// The date and time the event starts (in milliseconds since January 1 1970 00:00:00 GMT)
        /// </summary>
        public DateTime eventDate { get; set; }

        /// <summary>
        /// The textual menu path for the market, not including the Market name at the end. The path is returned in the account’s default locale or in the locale specified in the request.
        /// </summary>
        public string menuPath { get; set; }

        /// <summary>
        /// The event type id of the market (previously sportId). Not currently used.
        /// </summary>
        public int eventTypeId { get; set; }

        /// <summary>
        /// The full hierarchy of Event IDs leading to the specified market, including the final Market Id.
        /// </summary>
        public int?[] eventHierarchy { get; set; }

        /// <summary>
        /// The current bet delay. This will be non-zero when the market is in-play. Note: If you want to determine the moment a market turns in-play, you should use getMarketPricesCompressed instead.
        /// </summary>
        public int betDelay { get; set; }

        /// <summary>
        /// Determine if the market is in play
        /// Returns true if the betDelay is greater than 0
        /// </summary>
        public bool inPlay
        {
            get
            {
                return betDelay > 0;
            }
        }

        /// <summary>
        /// The exchange Id for the market. 1 for the UK/Worldwide exchange, 2 for the Australian Exchange.
        /// </summary>
        public int exchangeId { get; set; }

        /// <summary>
        /// The ISO3 Country Code for the event. An empty field indicates an international market that takes place in multiple countries.
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// The ISO3 Currency Code for the market.
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// The number of runners in the market
        /// </summary>
        public int numberOfRunners { get; set; }

        /// <summary>
        /// Market overround
        /// </summary>
        public double overRoundBackSide
        {
            get
            {
                if (runners == null) return 0;

                double temp = 0;
                bool notEnoughData = false;
                foreach (Selection runner in runners)
                {
                    if (runner.pricesToBack != null)
                    {
                        if (runner.pricesToBack.Count >= 1)
                        {
                            temp += (100/runner.pricesToBack[0].price);
                        }
                        else
                        {
                            notEnoughData = true;
                        }
                    }
                    else
                    {
                        notEnoughData = true;
                    }
                }

                return notEnoughData ? 0 : temp;
            }
        }

        /// <summary>
        /// Market overround
        /// </summary>
        public double overRoundLaySide
        {
            get
            {
                if (runners == null) return 0;

                double temp = 0;
                bool notEnoughData = false;
                foreach (Selection runner in runners)
                {
                    if (runner.pricesToLay != null)
                    {
                        if (runner.pricesToLay.Count >= 1)
                        {
                            temp += (100/runner.pricesToLay[0].price);
                        }
                        else
                        {
                            notEnoughData = true;
                        }
                    }
                    else
                    {
                        notEnoughData = true;
                    }
                }

                return notEnoughData ? 0 : temp;
            }
        }

        /// <summary>
        /// List runners in this race
        /// </summary>
        public SelectionList runners { get; set; }

        /// <summary>
        /// Returns a list of runners with bets
        /// </summary>
        public List<Selection> runnersWithBets
        {
            get
            {
                var response = new List<Selection>();

                if (runners == null) return response;

                lock (runners)
                {
                    foreach (Selection runner in runners)
                    {
                        if (runner.bets != null && runner.bets.Count > 0)
                        {
                            response.Add(runner);
                        }
                    }
                }

                return response;
            }
        }

        /// <summary>
        /// The number of possible winners in the market
        /// </summary>
        public int numberOfWinners { get; set; }

        /// <summary>
        /// Runners removed from this race
        /// </summary>
        public RemovedRunner[] removedRunners { get; set; }

        /// <summary>
        /// True if and only if new runners may be subsequently added to the market
        /// </summary>
        public bool runnersMayBeAdded { get; set; }

        /// <summary>
        /// The total amount of money in GBP that have been matched on the specified market.
        /// </summary>
        public double totalAmountMatched
        {
            get
            {
                _totalAmountMatched = 0;

                if (runners == null) return _totalAmountMatched;

                foreach (Selection runner in runners)
                {
                    _totalAmountMatched += runner.totalAmountMatched;
                }
                return _totalAmountMatched;
            }
            set { _totalAmountMatched = value; }
        }

        /// <summary>
        /// Does this market support Betfair starting prices
        /// </summary>
        public bool bspMarket { get; set; }

        /// <summary>
        /// When last was the market detail updated from the Betfair API
        /// </summary>
        public DateTime lastMarketInfoLoad { get; set; }

        /// <summary>
        /// When last was the runner prices updated from the Betfair API
        /// </summary>
        public DateTime lastRunnerPricesLoad { get; set; }

        /// <summary>
        /// If true, indicates that the market is scheduled to be turned in-play
        /// </summary>
        public bool turningInPlay { get; set; }
    }

    public class RemovedRunner
    {
        /// <summary>
        /// The name of the removed runner
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The date the runner was removed
        /// </summary>
        public string removedDate { get; set; }

        /// <summary>
        /// The adjustment factor applied to the remaining runners
        /// </summary>
        public double adjustmentFactor { get; set; }
    }

    public enum MarketStatus
    {
        ACTIVE,
        INACTIVE,
        CLOSED,
        SUSPENDED
    }

    #endregion
}