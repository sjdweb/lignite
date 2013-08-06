using System;
using System.Collections;

namespace Betfair.Collections
{
    [Serializable]
    public class TradedVolumeList : CollectionBase
    {
        /* Note on: lock (this.List.SyncRoot) usage.
         * While the Synchronized wrappers may improve performance by virtue of the fact that they 
         * contain internal knowledge of the container’s implementation, they can only guarantee the 
         * atomicity of individual methods. Therefore, if a reader thread iterates over a container 
         * while a writer thread adds or removes items from it, the container’s content is changing 
         * during the reader’s iteration. This can cause confusion and could be undesirable because 
         * it might show a non-stable view of the object. If we really want groups of operations to 
         * be taken atomically, then we are back at our first solution: placing those operations 
         * within a monitor’s protection. However, instead of directly locking the container, 
         * lock the SyncRoot property of the container, which gives the proper behavior regardless 
         * of what you pass to it: an unsynchronized container instance or a wrapped instance 
         * obtained by using the Synchronized static method. What we are trying to avoid here is to 
         * have double synchronization which could hurt performance unnecessarily; this could happen 
         * if we are using a synchronized wrapper for those places where method atomicity is sufficient, 
         * but would like to use a monitor for making sets of operations atomic. The SyncRoot 
         * property is able to do this because it will always return the raw container object.
         */

        /// <summary>
        /// Get the Price at IList[Index]
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public virtual TradedVolume this[int Index]
        {
            get { return (TradedVolume) List[Index]; }
        }

        /// <summary>
        /// Add a Price to the IList
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(TradedVolume item)
        {
            lock (List.SyncRoot)
            {
                //forward our Add method on to 
                //CollectionBase.IList.Add
                List.Add(item);
            }
        }

        /// <summary>
        /// Does the list contain the following Runner
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TradedVolume item)
        {
            lock (List.SyncRoot)
            {
                return List.Contains(item);
            }
        }

        /// <summary>
        /// Sort the collection
        /// Example: item.Sort(new PriceDepthComparer());
        /// </summary>
        /// <param name="Comparer"></param>
        public void Sort(IComparer Comparer)
        {
            lock (List.SyncRoot)
            {
                InnerList.Sort(Comparer);
            }
        }

        public double GetWeightedAveragePrice()
        {
            lock (List.SyncRoot)
            {
                double totalBetSize = 0;
                double sumAvgPriceByBetSize = 0;
                foreach (TradedVolume val in List)
                {
                    sumAvgPriceByBetSize += val.odds*val.totalMatchedAmount;
                    totalBetSize += val.totalMatchedAmount;
                }
                return sumAvgPriceByBetSize/totalBetSize;
            }
        }
    }

    /// <summary>
    /// Order the prices by Price.price
    /// </summary>
    public class TradedVolumeDepthComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((TradedVolume) x).odds.CompareTo(((TradedVolume) y).odds);
        }

        #endregion
    }

    public class TradedVolumeDepthComparerReverse : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((TradedVolume) x).odds.CompareTo(((TradedVolume) y).odds)*(-1);
        }

        #endregion
    }

    [Serializable]
    public class TradedVolume
    {
        /// <summary>
        /// The odds for this traded amount
        /// </summary>
        public double odds;

        /// <summary>
        /// The total amount matched for the given odds
        /// </summary>
        public double totalMatchedAmount;
    }
}