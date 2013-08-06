namespace Betfair.Utilities
{
    /// <summary>
    /// Odds market price incrementer
    /// </summary>
    public class PriceIncrements
    {
        /// <summary>
        /// Odds market price incrementer
        /// </summary>
        public PriceIncrements()
        {
            _OddsMarketPricesArray = new decimal[0];
            SetpriceArray();
        }

        private decimal[] _OddsMarketPricesArray { get; set; }

        /// <summary>
        /// Decimal array with all the valid prices
        /// </summary>
        public decimal[] OddsMarketPricesArray
        {
            get
            {
                if (_OddsMarketPricesArray.Length <= 0)
                {
                    SetpriceArray();
                }
                return _OddsMarketPricesArray;
            }
        }

        /// <summary>
        /// Returns the nearest valid betfair price for any submitted value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="roundUp"></param>
        /// <returns></returns>
        public decimal GetValidPriceValue(decimal value, bool roundUp)
        {
            return OddsMarketPricesArray[GetValidPriceValueIndexNumber(value, roundUp)];
        }

        /// <summary>
        /// Returns a price one tick higher than the submitted value
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public decimal GetHigherPriceValue(decimal value)
        {
            var index = GetValidPriceValueIndexNumber(value, null);

            if (index >= 0)
            {
                if (index > 0 && index < 349)
                {
                    index++;
                }
                return OddsMarketPricesArray[index];
            }
            return -1;
        }


        /// <summary>
        /// Returns a price one tick lower than the submitted value
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public decimal GetLowerPriceValue(decimal value)
        {
            var index = GetValidPriceValueIndexNumber(value, null);

            if (index >= 0)
            {
                if (index > 0 && index < 349)
                {
                    index += (-1);
                }
                return OddsMarketPricesArray[index];
            }
            return -1;
        }

        /// <summary>
        /// All prices are stored in a zero rated index from 0 to 349
        /// If roundUp is set to null, and the submitted price is invalid the reult will be = -1
        /// If roundUp = true and the distance from submitted value to the nearest valid price in equal direction
        /// then the system will return the higher of the 2, if roundUp = false the lower will be returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="roundUp"></param>
        /// <returns></returns>
        public int GetValidPriceValueIndexNumber(decimal value, bool? roundUp)
        {
            if (value == 1.01m)
            {
                return 0;
            }
            if (value < 1.01m && roundUp == null)
            {
                return -1;
            }
            if (value < 1.01m && roundUp != null)
            {
                return 0;
            }

            if (value == 1000m)
            {
                return 349;
            }
            if (value > 1000m && roundUp == null)
            {
                return -1;
            }
            if (value > 1000m && roundUp != null)
            {
                return 349;
            }
            
            // None of the above so lets continue

            for (int x = 0; x < 349; x++)
            {
                if (OddsMarketPricesArray[x] == value)
                {
                    return x;
                }
                if (roundUp != null)
                {
                    if (OddsMarketPricesArray[x] < value && OddsMarketPricesArray[x + 1] > value)
                    {
                        decimal distanceToLower = (value - OddsMarketPricesArray[x]);
                        decimal distanceToHigher = (OddsMarketPricesArray[x + 1] - value);

                        // Submitted values weighting is to the left
                        if (distanceToLower > distanceToHigher)
                        {
                            return x + 1;
                        }
                            // Submitted values weighting is smack bang in the middle
                        if (distanceToLower == distanceToHigher)
                        {
                            if ((bool) roundUp)
                            {
                                return x + 1;
                            }
                            return x;
                        }
                            // Submitted values weighting is to the right
                        if (distanceToLower < distanceToHigher)
                        {
                            return x;
                        }
                    }
                }
            }
            return -1;
        }

        #region SetpriceArray

        /// <summary>
        /// Set the prices array.
        /// </summary>
        private void SetpriceArray()
        {
            var priceValueIndex = new decimal[350];
            decimal currentPriceValue = 1m;

            for (int x = 0; x < 350; x++)
            {
                // Current Price
                if (currentPriceValue >= 0m && currentPriceValue < 2m)
                {
                    //1.01 → 2 	0.01
                    currentPriceValue = currentPriceValue + 0.01m;
                }
                else if (currentPriceValue >= 2m && currentPriceValue < 3m)
                {
                    //2 → 3 	0.02
                    currentPriceValue = currentPriceValue + 0.02m;
                }
                else if (currentPriceValue >= 3m && currentPriceValue < 4m)
                {
                    //3 → 4 	0.05
                    currentPriceValue = currentPriceValue + 0.05m;
                }
                else if (currentPriceValue >= 4m && currentPriceValue < 6m)
                {
                    //4 → 6 	0.1
                    currentPriceValue = currentPriceValue + 0.1m;
                }
                else if (currentPriceValue >= 6m && currentPriceValue < 10m)
                {
                    //6 → 10 	0.2
                    currentPriceValue = currentPriceValue + 0.2m;
                }
                else if (currentPriceValue >= 10m && currentPriceValue < 20m)
                {
                    //10 → 20	0.5
                    currentPriceValue = currentPriceValue + 0.5m;
                }
                else if (currentPriceValue >= 20m && currentPriceValue < 30m)
                {
                    //20 → 30 	1
                    currentPriceValue = currentPriceValue + 1m;
                }
                else if (currentPriceValue >= 30m && currentPriceValue < 50m)
                {
                    //30 → 50	2
                    currentPriceValue = currentPriceValue + 2m;
                }
                else if (currentPriceValue >= 50m && currentPriceValue < 100m)
                {
                    //50 → 100	5
                    currentPriceValue = currentPriceValue + 5m;
                }
                else if (currentPriceValue >= 100m && currentPriceValue < 1001m)
                {
                    //100 → 1000	10
                    currentPriceValue = currentPriceValue + 10m;
                }

                if (currentPriceValue <= 1000m)
                {
                    priceValueIndex[x] = currentPriceValue;
                }
            }

            _OddsMarketPricesArray = priceValueIndex;
        }

        #endregion
    }
}