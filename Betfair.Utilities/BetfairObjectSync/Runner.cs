using Betfair.Collections;

namespace Betfair.Utilities.BetfairObjectSync
{
    public class Runner
    {
        public SelectionList CompleteTradedVolumeToRunner(SelectionList runnersToUpdateTo, SelectionList runnersToUpdateFrom)
        {
            for (var x = 0; x < runnersToUpdateFrom.Count; x++)
            {
                if (!runnersToUpdateTo.Contains(runnersToUpdateFrom[x].selectionId))
                {
                    runnersToUpdateTo.Add(runnersToUpdateFrom[x]);
                }
                else
                {
                    var index = runnersToUpdateTo.GetRunnerIndexNoBySelectionId(runnersToUpdateFrom[x].selectionId);
                    if (index >= 0)
                    {
                        runnersToUpdateTo[index].tradedVolume = runnersToUpdateFrom[x].tradedVolume;
                        runnersToUpdateTo[index].actualSPPrice = runnersToUpdateFrom[x].actualSPPrice;
                    }
                }
            }

            if (runnersToUpdateFrom.Count < runnersToUpdateTo.Count)
            {
                for (var x = 0; x < runnersToUpdateTo.Count; x++)
                {
                    if (!runnersToUpdateFrom.Contains(runnersToUpdateTo[x].selectionId))
                    {
                        runnersToUpdateTo[x].tradedVolume = new TradedVolumeList();
                    }
                }
            }

            return runnersToUpdateTo;
        }
    }
}