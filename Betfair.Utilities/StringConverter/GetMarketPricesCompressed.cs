using System;
using Betfair.Collections;

namespace Betfair.Utilities.StringConverter
{
    /// <summary>
    /// Convert complex Betfair response strings to objects
    /// </summary>
    public class GetMarketPricesCompressed
    {
        /// <summary>
        /// Extract the results of a Betfair GetMarketPricesCompressedresp.marketPrices string to a RunnerList object
        /// No prices get updated during suspend and closed market status state
        /// </summary>
        /// <param name="marketPrices"></param>
        /// <param name="exchangeId"></param>
        /// <returns></returns>
        public Market ConvertToObject(string marketPrices, int exchangeId)
        {
            return ConvertToObject(marketPrices, exchangeId, DateTime.Now);
        }

        /// <summary>
        /// Extract the results of a Betfair GetMarketPricesCompressedresp.marketPrices string to a RunnerList object
        /// No prices get updated during suspend and closed market status state
        /// </summary>
        /// <param name="marketPrices">The market prices.</param>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="pricesUpdateTime">The time to set the Market.lastRunnerPricesLoad value to</param>
        /// <returns></returns>
        public Market ConvertToObject(string marketPrices, int exchangeId, DateTime pricesUpdateTime)
        {
            try
            {
                if (marketPrices != null)
                {
                    //Step 1 - Clean up the break characters
                    marketPrices = HelperMethods.ProtectBreakChars(marketPrices);

                    //Step 2 - Split
                    string[] marketData = marketPrices.Split(":".ToCharArray());

                    //Step 3 - Clean before split (We don't use the SplitOptions because empty spaces serve a purpose)
                    marketData[0] = HelperMethods.RemoveTrailingTilde(marketData[0]);

                    //Step 4 - Create the response object
                    var market = new Market();

                    //Step 5 - Get the market data segment
                    string[] marketDataArray = marketData[0].Split("~".ToCharArray());

                    //Step 6 - Populate the response object
                    market.marketId = Convert.ToInt32(marketDataArray[0]);
                    market.exchangeId = exchangeId;
                    market.currency = marketDataArray[1];
                    market.status = (MarketStatus) Enum.Parse(typeof (MarketStatus), marketDataArray[2]);
                    market.betDelay = Convert.ToInt32(marketDataArray[3]);
                    market.numberOfWinners = Convert.ToInt32(marketDataArray[4]);
                    market.marketInformation = HelperMethods.RestoreBreakChars(marketDataArray[5]);
                    market.discountAllowed = Convert.ToBoolean(marketDataArray[6]);
                    market.marketBaseRate = Convert.ToDouble(marketDataArray[7]);
                    market.apiMarketDataLastRefresh = Convert.ToInt64(marketDataArray[8]);
                    string removedRunners = marketDataArray[9];
                    if (marketDataArray[10] == "Y")
                    {
                        market.bspMarket = true;
                    }
                    market.lastRunnerPricesLoad = pricesUpdateTime;
                    market.numberOfRunners = marketData.Length - 1; //The first row is market info

                    //Step 7 - Process the removed runner list
                    if (removedRunners.Length > 0)
                    {
                        if (removedRunners.Substring((removedRunners.Length - 1), 1) == ";")
                            removedRunners = removedRunners.Remove((removedRunners.Length - 1), 1);

                        string[] removedRunnersArray = removedRunners.Split(";".ToCharArray());
                        market.removedRunners = new RemovedRunner[removedRunnersArray.Length];

                        for (var x = 0; x < market.removedRunners.Length; x++)
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
                    for (var x = 1; x < marketData.Length; x++)
                    {
                        //Step 9 - Get the individual runners data from the string
                        string[] runnerDataArray = marketData[x].Split("|".ToCharArray());

                        //Step 10 - Create an data array for the 3 data objects
                        string[] runnerInfoArray =
                            HelperMethods.RemoveTrailingTilde(runnerDataArray[0]).Split("~".ToCharArray());
                        string[] runnerBackPricesArray =
                            HelperMethods.RemoveTrailingTilde(runnerDataArray[1]).Split("~".ToCharArray());
                        string[] runnerLayPricesArray =
                            HelperMethods.RemoveTrailingTilde(runnerDataArray[2]).Split("~".ToCharArray());

                        //Step 11 - Create the runner response object
                        var runner = new Selection
                                         {
                                             pricesToBack = new PriceList(),
                                             pricesToLay = new PriceList(),
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
                            runner.farSPPrice = Convert.ToDouble(runnerInfoArray[7]);

                        if (runnerInfoArray[8].Length > 0)
                            runner.nearSPPrice = Convert.ToDouble(runnerInfoArray[8]);

                        if (runnerInfoArray[9].Length > 0)
                            runner.actualSPPrice = Convert.ToDouble(runnerInfoArray[9]);

                        //Step 13 - Add the Back prices
                        if (runnerBackPricesArray.Length > 1)
                        {
                            int countPrice = 0;
                            while (countPrice < (runnerBackPricesArray.Length))
                            {
                                var price = new Price
                                                {
                                                    price = Convert.ToDouble(runnerBackPricesArray[0 + countPrice]),
                                                    amountAvailable =
                                                        Convert.ToDouble(runnerBackPricesArray[1 + countPrice]),
                                                    type = BetTypeOptions.L,
                                                    depth = Convert.ToInt32(runnerBackPricesArray[3 + countPrice])
                                                };

                                runner.pricesToBack.Add(price);
                                countPrice += 4;
                            }
                        }

                        //Step 14 - Add the Lay prices
                        if (runnerLayPricesArray.Length > 1)
                        {
                            int countPrice = 0;
                            while (countPrice < (runnerLayPricesArray.Length))
                            {
                                var price = new Price
                                                {
                                                    price = Convert.ToDouble(runnerLayPricesArray[0 + countPrice]),
                                                    amountAvailable =
                                                        Convert.ToDouble(runnerLayPricesArray[1 + countPrice]),
                                                    type = BetTypeOptions.B,
                                                    depth = Convert.ToInt32(runnerLayPricesArray[3 + countPrice])
                                                };

                                runner.pricesToLay.Add(price);
                                countPrice += 4;
                            }
                        }
                        market.runners.Add(runner);
                    }
                    return market;
                }
                return null;
            }
            catch
            {
                throw new Exception(marketPrices);
            }
        }
    }
}