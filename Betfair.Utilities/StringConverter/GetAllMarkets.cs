using System;
using Betfair.Collections;
using Vossie.Utilities;

namespace Betfair.Utilities.StringConverter
{
    public class GetAllMarkets
    {
        /// <summary>
        /// Extract the results of a Betfair GetAllMarketsResp.data string to a MarketList object
        /// </summary>
        /// <param name="marketData"></param>
        /// <returns></returns>
        public MarketList ConvertToObject(string marketData)
        {
            if (marketData != null)
            {
                //Step 1 - Create the response object
                var marketList = new MarketList();

                //Step 2 - Clean up the break characters
                marketData = HelperMethods.ProtectBreakChars(marketData);

                //Step 3 - Split the markets out
                string[] marketStringArray = marketData.Split(":".ToCharArray());

                //Step 4 - Loop through the markets and split out the market items
                for (int x = 0; x < marketStringArray.Length; x++)
                {
                    //Check that the array is not empty
                    if (marketStringArray[x].Length > 0)
                    {
                        //Create the market object
                        var market = new Market();

                        //Step 5 - Split out the markets component items
                        string[] marketItemsStringArray = marketStringArray[x].Split("~".ToCharArray());

                        //Step 6 - Check that the array is equal or greater than 15
                        if (marketItemsStringArray.Length >= 15)
                        {
                            //Step 7 - Restore the break characters
                            for (int y = 0; y < marketItemsStringArray.Length; y++)
                            {
                                marketItemsStringArray[y] = HelperMethods.RestoreBreakChars(marketItemsStringArray[y]);
                            }

                            //Step 8 - Update the market values
                            market.marketId = Convert.ToInt32(marketItemsStringArray[0]);
                            market.name = marketItemsStringArray[1];
                            market.type = marketItemsStringArray[2];
                            market.status = (MarketStatus) Enum.Parse(typeof (MarketStatus), marketItemsStringArray[3]);
                            market.eventDate =
                                new DateTimeCalculations().UnixTimeStampToDateTime(
                                    Convert.ToDouble(marketItemsStringArray[4]));
                            market.menuPath = marketItemsStringArray[5];
                            market.eventHierarchy = HelperMethods.SplitToInt32Array("/", marketItemsStringArray[6]);
                            market.betDelay = Convert.ToInt32(marketItemsStringArray[7]);
                            market.exchangeId = Convert.ToInt32(marketItemsStringArray[8]);
                            market.country = marketItemsStringArray[9];
                            market.apiMarketDataLastRefresh = Convert.ToInt64(marketItemsStringArray[10]);
                            market.numberOfRunners = Convert.ToInt32(marketItemsStringArray[11]);
                            market.numberOfWinners = Convert.ToInt32(marketItemsStringArray[12]);
                            market.totalAmountMatched = Convert.ToDouble(marketItemsStringArray[13]);
                            if (marketItemsStringArray[14].ToLower() == "y") market.bspMarket = true;
                            if (marketItemsStringArray[15].ToLower() == "y") market.turningInPlay = true;

                            //Step 9 - Add the new market item to the response object
                            marketList.Add(market);
                        }
                    }
                }

                //Step 10 - Sort the list items
                marketList.Sort(new MarketDateComparer());

                //Step 11 - Done
                return marketList;
            }
            return null;
        }
    }
}