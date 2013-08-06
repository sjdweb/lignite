using System;
using Betfair.Collections;

namespace Betfair.Utilities
{
    public class Calculations
    {
        /// <summary>
        /// Overround is calculated as ((result to 1 decimal point) = ((for each runner odds) += (1 / price)).
        /// If 1 or more runners in the list do not have a price the result will be calculated as 0 (zero).
        /// </summary>
        /// <param name="runners"></param>
        /// <param name="numberOfRunners"></param>
        /// <param name="isBackSide"></param>
        /// <returns></returns>
        public double CalculateOverround(SelectionList runners, int numberOfRunners, bool isBackSide)
        {
            double result = 0;
            double odds = 0;

            if (runners.Count == numberOfRunners)
            {
                foreach (Selection r in runners)
                {
                    // Back side
                    if (isBackSide && r.pricesToBack != null)
                    {
                        if (r.pricesToBack.Count > 0 && result > -1 && r.pricesToBack != null)
                        {
                            odds += (1/r.pricesToBack[0].price);
                        }
                        else
                        {
                            result = -1;
                            break;
                        }
                    }
                    else if (!isBackSide && r.pricesToLay != null)
                    {
                        if (r.pricesToLay.Count > 0 && result > -1)
                        {
                            odds += (1/r.pricesToLay[0].price);
                        }
                        else
                        {
                            result = -1;
                            break;
                        }
                    }
                }

                if (odds > 0)
                {
                    result = Math.Round(odds*100, 1);
                }
                else if (result < 0)
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Get the difference in milliseconds.
        /// Calculated as ((current time) - (time stamp) = result)
        /// </summary>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns></returns>
        public double GetTimeDifferenceMilliseconds(DateTime timeStamp)
        {
            var span = DateTime.Now - timeStamp;
            return span.TotalMilliseconds;
        }
    }
}