using System;
using System.Collections.Generic;
using Betfair.Collections;

namespace Betfair.Utilities.StringConverter
{
    public class GetCompleteMarketPricesCompressed
    {
        /// <summary>
        /// Extract the results of a Betfair GetMarketPricesCompressedresp.marketPrices string to a response object
        /// No prices get updated during suspend and closed market status state.
        /// </summary>
        /// <param name="completeMarketPrices">The complete market prices.</param>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="status">The status.</param>
        /// <param name="currency">The currency.</param>
        /// <returns></returns>
        public Market ConvertToObject(string completeMarketPrices, int exchangeId, MarketStatus status, string currency)
        {
            return ConvertToObject(completeMarketPrices, exchangeId, status, currency, DateTime.Now);
        }

        /// <summary>
        /// Extract the results of a Betfair GetMarketPricesCompressedresp.marketPrices string to a response object
        /// No prices get updated during suspend and closed market status state.
        /// The following values get updated during a normal update:
        /// </summary>
        /// <param name="completeMarketPrices">The complete market prices.</param>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="status">The status.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="pricesUpdateTime">The time to set the Market.lastRunnerPricesLoad value to</param>
        /// <returns></returns>
        public Market ConvertToObject(string completeMarketPrices, int exchangeId, MarketStatus status, string currency,
                                      DateTime pricesUpdateTime)
        {
            if (completeMarketPrices != null && status == MarketStatus.ACTIVE)
            {
                //Step 1 - Create the response object
                var market = new Market {status = status};

                //Step 2 - Clean up the break characters
                completeMarketPrices = HelperMethods.ProtectBreakChars(completeMarketPrices);

                //Step 3 - Split
                string[] marketData = completeMarketPrices.Split(":".ToCharArray());

                //Step 4 - Clean before split
                marketData[0] = HelperMethods.RemoveTrailingTilde(marketData[0]);

                //Step 5 - Get the market data segment
                string[] marketDataArray = marketData[0].Split("~".ToCharArray());

                //Step 6 - Populate the response object
                market.marketId = Convert.ToInt32(marketDataArray[0]);
                market.betDelay = Convert.ToInt32(marketDataArray[1]);
                market.currency = currency;
                market.lastRunnerPricesLoad = pricesUpdateTime;

                market.exchangeId = exchangeId;

                string removedRunners = "";
                if (marketDataArray.Length > 2)
                {
                    removedRunners = marketDataArray[2];
                }

                //Step 7 - Process the removed runner list
                if (removedRunners.Length > 0)
                {
                    if (removedRunners.Substring((removedRunners.Length - 1), 1) == ";")
                        removedRunners = removedRunners.Remove((removedRunners.Length - 1), 1);

                    string[] removedRunnersArray = removedRunners.Split(";".ToCharArray());
                    market.removedRunners = new RemovedRunner[removedRunnersArray.Length];

                    for (int x = 0; x < market.removedRunners.Length; x++)
                    {
                        string[] removedRunnerItems = removedRunnersArray[x].Split(",".ToCharArray());
                        var r = new RemovedRunner
                                    {
                                        name = removedRunnerItems[0],
                                        removedDate = removedRunnerItems[1],
                                        adjustmentFactor = Convert.ToDouble(removedRunnerItems[2])
                                    };
                        market.removedRunners[x] = r;
                    }
                }

                //Step 8 - Loop through the runners
                market.runners = new SelectionList();

                for (int x = 1; x < marketData.Length; x++)
                {
                    //Step 9 - Get the individual runners data from the string
                    string[] runnerDataArray = marketData[x].Split("|".ToCharArray());

                    //Step 10 - Create an data array for the 3 data objects
                    string[] runnerInfoArray =
                        HelperMethods.RemoveTrailingTilde(runnerDataArray[0]).Split("~".ToCharArray());
                    string[] runnerPricesArray =
                        HelperMethods.RemoveTrailingTilde(runnerDataArray[1]).Split("~".ToCharArray());

                    //Step 11 - Create the runner response object
                    var runner = new Selection
                                     {
                                         selectionId = Convert.ToInt32(runnerInfoArray[0])
                                     };

                    //Step 12 - Populate the data

                    if (runnerInfoArray[1].Length > 0)
                        runner.orderIndex = Convert.ToInt32(runnerInfoArray[1]);

                    if (runnerInfoArray[2].Length > 0)
                        runner.totalAmountMatched = Convert.ToDouble(runnerInfoArray[2]);

                    if (runnerInfoArray[3].Length > 0)
                        runner.lastPriceMatched = Convert.ToDouble(runnerInfoArray[3]);

                    if (runnerInfoArray[4].Length > 0)
                        runner.handiCap = Convert.ToDouble(runnerInfoArray[4]);

                    if (runnerInfoArray[5].Length > 0)
                        runner.reductionFactor = Convert.ToDouble(runnerInfoArray[5]);

                    if (runnerInfoArray[6].Length > 0)
                        runner.vacant = Convert.ToBoolean(runnerInfoArray[6]);

                    if (runnerInfoArray[7].Length > 0)
                        runner.asianLineId = Convert.ToInt32(runnerInfoArray[7]);

                    if (runnerInfoArray[8].Length > 0)
                        runner.farSPPrice = Convert.ToDouble(runnerInfoArray[8]);

                    if (runnerInfoArray[9].Length > 0)
                        runner.nearSPPrice = Convert.ToDouble(runnerInfoArray[9]);

                    if (runnerInfoArray[10].Length > 0)
                        runner.actualSPPrice = Convert.ToDouble(runnerInfoArray[10]);

                    //Step 13 - Add the prices
                    if (runnerPricesArray.Length > 1)
                    {
                        int countPrice = 0;
                        while (countPrice < (runnerPricesArray.Length))
                        {
                            if (runner.pricesToBack == null)
                                runner.pricesToBack = new PriceList();

                            if (Convert.ToDouble(runnerPricesArray[1 + countPrice]) > 0)
                            {
                                var backPrice = new Price
                                                    {
                                                        price = Convert.ToDouble(runnerPricesArray[0 + countPrice]),
                                                        amountAvailable =
                                                            Convert.ToDouble(runnerPricesArray[1 + countPrice]),
                                                        type = BetTypeOptions.L
                                                    };
                                runner.pricesToBack.Add(backPrice);
                            }

                            if (runner.pricesToLay == null)
                                runner.pricesToLay = new PriceList();

                            if (Convert.ToDouble(runnerPricesArray[2 + countPrice]) > 0)
                            {
                                var layPrice = new Price
                                                   {
                                                       price = Convert.ToDouble(runnerPricesArray[0 + countPrice]),
                                                       amountAvailable =
                                                           Convert.ToDouble(runnerPricesArray[2 + countPrice]),
                                                       type = BetTypeOptions.B
                                                   };
                                runner.pricesToLay.Add(layPrice);
                            }
                            countPrice += 5;
                        }


                        //Add the price depth and organize the data
                        runner.pricesToBack.Sort(new PriceDepthComparerReverse());
                        for (int depth = 0; depth < runner.pricesToBack.Count; depth++)
                            runner.pricesToBack[depth].depth = (depth + 1);

                        runner.pricesToLay.Sort(new PriceDepthComparer());
                        for (int depth = 0; depth < runner.pricesToLay.Count; depth++)
                            runner.pricesToLay[depth].depth = (depth + 1);
                    }
                    market.runners.Add(runner);
                }
                return market;
            }
            return null;
        }
    }
}