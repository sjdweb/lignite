using System.Collections.Generic;
using Betfair.Collections;

namespace Betfair.Utilities.BetfairObjectSync
{
    public class RunnerDisplayDetail
    {
        public SelectionList DictionaryToRunnerList(SelectionList runnersToUpdateTo,
                                                 Dictionary<int, Collections.RacecardInfo> updateFrom)
        {
            foreach (var selectionId in updateFrom.Keys)
            {
                if (!runnersToUpdateTo.Contains(selectionId)) continue;
                var index = runnersToUpdateTo.GetRunnerIndexNoBySelectionId(selectionId);
                if (index >= 0)
                {
                    runnersToUpdateTo[index].runnerDisplayDetail = updateFrom[selectionId];
                }
            }

            return Helper.CheckForEmtyRunnerInstances(runnersToUpdateTo);
        }
    }
}