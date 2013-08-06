using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betfair.Utilities.BetfairObjectSync
{
    public abstract class Helper
    {


        #region CheckForEmtyRunnerInstances

        /// <summary>
        /// Checks for emty runner instances.
        /// </summary>
        /// <param name="market">The market.</param>
        /// <returns></returns>
        public static Collections.Market CheckForEmtyRunnerInstances(Collections.Market market)
        {
            if (market == null || market.runners == null) return market;

            int removeAt = -1;

            for (int x = 0; x < market.runners.Count; x++)
            {
                if (market.runners[x].selectionId <= 0) removeAt = x;
            }

            if (removeAt > -1) market.runners.RemoveAt(removeAt);

            market.numberOfRunners = market.runners.Count;

            return market;
        }

        /// <summary>
        /// Checks for emty runner instances.
        /// </summary>
        /// <param name="runners">The runners.</param>
        /// <returns></returns>
        public static Collections.SelectionList CheckForEmtyRunnerInstances(Collections.SelectionList runners)
        {
            if (runners == null) return runners;

            int removeAt = -1;

            for (int x = 0; x < runners.Count; x++)
            {
                if (runners[x].selectionId <= 0) removeAt = x;
            }

            if (removeAt > -1) runners.RemoveAt(removeAt);

            return runners;
        }

        #endregion
    }
}
