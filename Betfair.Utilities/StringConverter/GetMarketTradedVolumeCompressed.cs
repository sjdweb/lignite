using System;
using Betfair.Collections;

namespace Betfair.Utilities.StringConverter
{
    public class GetMarketTradedVolumeCompressed
    {
        public SelectionList ConvertToObject(string tradedVolumeData)
        {
            if (tradedVolumeData == null)
            {
                return null;
            }
            //Step 1 - Create the response object
            var runnerList = new SelectionList();

            //Step 2 - Split the runners out
            var runnerStringArray = tradedVolumeData.Split(":".ToCharArray());

            //Step 3 - Loop through each runner
            for (var x = 0; x < runnerStringArray.Length; x++)
            {
                //Check that the array is not empty
                if (runnerStringArray[x].Length > 0)
                {
                    //Create the runner object
                    var runner = new Selection();

                    //Step 4 - Split out the runner object items
                    var tradedVolumeStringArray = runnerStringArray[x].Split("|".ToCharArray());

                    //Step 5 - Check that the array is equal or greater than 1
                    if (tradedVolumeStringArray.Length > 1)
                    {
                        //Step 6 - Populate the runner data
                        var runnerInfoStringArray = tradedVolumeStringArray[0].Split(("~").ToCharArray());

                        runner.selectionId = Convert.ToInt32(runnerInfoStringArray[0]);
                        runner.asianLineId = Convert.ToInt32(runnerInfoStringArray[1]);
                        runner.actualSPPrice = Convert.ToDouble(runnerInfoStringArray[2]);
                        //runner.totalBSPBackMatchedAmount = runnerInfoStringArray[3];
                        //runner.totalBSPLiabilityMatchedAmount = runnerInfoStringArray[4];

                        //Step 7 - Get all the traded increments
                        for (var count = 1; count < tradedVolumeStringArray.Length; count++)
                        {
                            if (!tradedVolumeStringArray[count].Contains("~")) continue;
                            var traded = new TradedVolume();
                            var runnerPricesStringArray =
                                tradedVolumeStringArray[count].Split(("~").ToCharArray());

                            traded.odds = Convert.ToDouble(runnerPricesStringArray[0]);
                            traded.totalMatchedAmount = Convert.ToDouble(runnerPricesStringArray[1]);
                            runner.tradedVolume.Add(traded);
                        }

                        //Step 8 - Sort the list items
                        runner.tradedVolume.Sort(new TradedVolumeDepthComparer());
                    }

                    runnerList.Add(runner);
                }
            }

            //Step 9 - Done
            return runnerList;
        }
    }
}