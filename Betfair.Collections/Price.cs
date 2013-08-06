using System.Collections;
using System;

namespace Betfair.Collections
{
    [Serializable]
    public class PriceList : CollectionBase
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
        public virtual Price this[int Index]
        {
            get { return (Price) List[Index]; }
        }

        /// <summary>
        /// Add a Price to the IList
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(Price item)
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
        public bool Contains(Price item)
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
    }

    /// <summary>
    /// Order the prices by Price.price
    /// </summary>
    public class PriceDepthComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((Price) x).price.CompareTo(((Price) y).price);
        }

        #endregion
    }

    public class PriceDepthComparerReverse : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((Price) x).price.CompareTo(((Price) y).price)*(-1);
        }

        #endregion
    }

    [Serializable]
    public class Price
    {
        /// <summary>
        /// Amount available at the odds specified
        /// </summary>
        public double amountAvailable;

        /// <summary>
        /// The order, from best to worst, of the price ('1' is best available)
        /// </summary>
        public int depth;

        /// <summary>
        /// Odds
        /// </summary>
        public double price;

        /// <summary>
        /// For Back prices, this will always be L as the prices available to back are made 
        /// up of the existing Lay bets already on the Exchange
        /// </summary>
        public BetTypeOptions type;
    }
}