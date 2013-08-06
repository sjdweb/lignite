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
using Betfair.Collections;

namespace Betfair.Utilities.BetfairObjectSync
{
    public class Market
    {
        #region BetfairAPIGetMarketRespToMarket

        public Collections.Market BetfairAPIGetMarketRespToMarket(Collections.Market marketToUpdateTo,
                                                                  Collections.Market marketToUpdateFrom)
        {
            if (marketToUpdateFrom == null)
                return null;
            if (marketToUpdateTo == null)
            {
                marketToUpdateTo = new Collections.Market();
            }
            marketToUpdateTo.apiMarketDataLastRefresh = marketToUpdateFrom.apiMarketDataLastRefresh;
            marketToUpdateTo.bspMarket = marketToUpdateFrom.bspMarket;
            marketToUpdateTo.country = marketToUpdateFrom.country;
            marketToUpdateTo.currency = marketToUpdateFrom.currency;
            marketToUpdateTo.discountAllowed = marketToUpdateFrom.discountAllowed;
            marketToUpdateTo.eventDate = marketToUpdateFrom.eventDate;
            marketToUpdateTo.eventHierarchy = marketToUpdateFrom.eventHierarchy;
            marketToUpdateTo.eventTypeId = marketToUpdateFrom.eventTypeId;
            marketToUpdateTo.exchangeId = marketToUpdateFrom.exchangeId;
            marketToUpdateTo.lastMarketInfoLoad = DateTime.Now;
            marketToUpdateTo.marketBaseRate = marketToUpdateFrom.marketBaseRate;
            marketToUpdateTo.marketId = marketToUpdateFrom.marketId;
            marketToUpdateTo.marketInformation = marketToUpdateFrom.marketInformation;
            marketToUpdateTo.name = marketToUpdateFrom.name;
            marketToUpdateTo.numberOfRunners = marketToUpdateFrom.numberOfRunners;
            marketToUpdateTo.numberOfWinners = marketToUpdateFrom.numberOfWinners;
            marketToUpdateTo.runnersMayBeAdded = marketToUpdateFrom.runnersMayBeAdded;
            marketToUpdateTo.status = marketToUpdateFrom.status;
            marketToUpdateTo.type = marketToUpdateFrom.type;
            marketToUpdateTo.menuPath = marketToUpdateFrom.menuPath;

            if (marketToUpdateTo.runners == null)
            {
                marketToUpdateTo.runners = new SelectionList();
            }

            foreach (Collections.Selection runner in marketToUpdateFrom.runners)
            {
                int indexNo = marketToUpdateTo.runners.GetRunnerIndexNoBySelectionId(runner.selectionId);

                if (indexNo < 0)
                {
                    var r = new Collections.Selection
                                {
                                    asianLineId = runner.asianLineId,
                                    handiCap = runner.handiCap,
                                    name = runner.name,
                                    selectionId = runner.selectionId,
                                    actualSPPrice = runner.actualSPPrice,
                                    farSPPrice = runner.farSPPrice,
                                    nearSPPrice = runner.nearSPPrice
                                };
                    marketToUpdateTo.runners.Add(r);
                }
                else
                {
                    Collections.Selection r = marketToUpdateTo.runners[indexNo];
                    r.asianLineId = runner.asianLineId;
                    r.handiCap = runner.handiCap;
                    r.name = runner.name;
                    r.selectionId = runner.selectionId;
                    r.actualSPPrice = runner.actualSPPrice;
                    r.farSPPrice = runner.farSPPrice;
                    r.nearSPPrice = runner.nearSPPrice;
                    marketToUpdateTo.runners[indexNo] = r;
                }
            }

            return Helper.CheckForEmtyRunnerInstances(marketToUpdateTo);
        }

        #endregion

        #region MarketPricessCompressedToMarket

        public Collections.Market MarketPricessCompressedToMarket(
            Collections.Market marketToUpdateTo,
            Collections.Market marketToUpdateFrom)
        {
            if (marketToUpdateTo == null) return Helper.CheckForEmtyRunnerInstances(marketToUpdateFrom);

            marketToUpdateTo.marketId = marketToUpdateFrom.marketId;
            marketToUpdateTo.exchangeId = marketToUpdateFrom.exchangeId;
            marketToUpdateTo.currency = marketToUpdateFrom.currency;
            marketToUpdateTo.status = marketToUpdateFrom.status;
            marketToUpdateTo.betDelay = marketToUpdateFrom.betDelay;
            marketToUpdateTo.numberOfWinners = marketToUpdateFrom.numberOfWinners;
            marketToUpdateTo.marketInformation = marketToUpdateFrom.marketInformation;
            marketToUpdateTo.discountAllowed = marketToUpdateFrom.discountAllowed;
            marketToUpdateTo.marketBaseRate = marketToUpdateFrom.marketBaseRate;
            marketToUpdateTo.apiMarketDataLastRefresh = marketToUpdateFrom.apiMarketDataLastRefresh;
            marketToUpdateTo.bspMarket = marketToUpdateFrom.bspMarket;
            marketToUpdateTo.lastRunnerPricesLoad = marketToUpdateFrom.lastRunnerPricesLoad;
            marketToUpdateTo.numberOfRunners = marketToUpdateFrom.numberOfRunners;
            marketToUpdateTo.removedRunners = marketToUpdateFrom.removedRunners;

            if (marketToUpdateTo.runners == null)
                marketToUpdateTo.runners = new SelectionList();

            for (var x = 0; x < marketToUpdateFrom.runners.Count; x++)
            {
                var runnerIndexNo = marketToUpdateTo.runners.GetRunnerIndexNoBySelectionId(marketToUpdateFrom.runners[x].selectionId);
                
                if (runnerIndexNo >= 0)
                {
                    marketToUpdateFrom.runners[x].asianLineId = marketToUpdateTo.runners[runnerIndexNo].asianLineId;
                    marketToUpdateFrom.runners[x].name = marketToUpdateTo.runners[runnerIndexNo].name;
                    marketToUpdateFrom.runners[x].runnerDisplayDetail =
                        marketToUpdateTo.runners[runnerIndexNo].runnerDisplayDetail;
                }
            }

            marketToUpdateTo.runners = marketToUpdateFrom.runners;

            return Helper.CheckForEmtyRunnerInstances(marketToUpdateTo);
        }

        #endregion

        #region CompleteMarketPricessCompressedToMarket

        public Collections.Market CompleteMarketPricessCompressedToMarket(
            Collections.Market marketToUpdateTo,
            Collections.Market marketToUpdateFrom)
        {
            if (marketToUpdateTo == null)
            {
                return Helper.CheckForEmtyRunnerInstances(marketToUpdateFrom);
            }
            marketToUpdateTo.marketId = marketToUpdateFrom.marketId;
            marketToUpdateTo.exchangeId = marketToUpdateFrom.exchangeId;
            marketToUpdateTo.currency = marketToUpdateFrom.currency;
            marketToUpdateTo.status = marketToUpdateFrom.status;
            marketToUpdateTo.betDelay = marketToUpdateFrom.betDelay;
            marketToUpdateTo.numberOfWinners = marketToUpdateFrom.numberOfWinners;
            marketToUpdateTo.marketInformation = marketToUpdateFrom.marketInformation;
            marketToUpdateTo.discountAllowed = marketToUpdateFrom.discountAllowed;
            marketToUpdateTo.marketBaseRate = marketToUpdateFrom.marketBaseRate;
            marketToUpdateTo.apiMarketDataLastRefresh = marketToUpdateFrom.apiMarketDataLastRefresh;
            marketToUpdateTo.bspMarket = marketToUpdateFrom.bspMarket;
            marketToUpdateTo.lastRunnerPricesLoad = marketToUpdateFrom.lastRunnerPricesLoad;
            marketToUpdateTo.numberOfRunners = marketToUpdateFrom.numberOfRunners;
            marketToUpdateTo.removedRunners = marketToUpdateFrom.removedRunners;

            for (var x = 0; x < marketToUpdateFrom.runners.Count; x++)
            {
                var runnerIndexNo = marketToUpdateTo.runners.GetRunnerIndexNoBySelectionId(marketToUpdateFrom.runners[x].selectionId);

                if (runnerIndexNo >= 0)
                {
                    marketToUpdateFrom.runners[x].asianLineId = marketToUpdateTo.runners[runnerIndexNo].asianLineId;
                    marketToUpdateFrom.runners[x].name = marketToUpdateTo.runners[runnerIndexNo].name;
                    marketToUpdateFrom.runners[x].runnerDisplayDetail =
                        marketToUpdateTo.runners[runnerIndexNo].runnerDisplayDetail;
                }
            }

            marketToUpdateTo.runners = marketToUpdateFrom.runners;

            return Helper.CheckForEmtyRunnerInstances(marketToUpdateTo);
        }

        #endregion
    }
}