using System.Collections;
using System;

namespace Betfair.Collections
{
    [Serializable]
    public class SelectionList : CollectionBase
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
        /// Get the Runner at IList[Index]
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public virtual Selection this[int Index]
        {
            get { return (Selection) List[Index]; }
            set
            {
                lock (List.SyncRoot)
                {
                    List[Index] = value;
                }
            }
        }

        /// <summary>
        /// Add a Runner to the IList
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(Selection item)
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
        public bool Contains(Selection item)
        {
            lock (List.SyncRoot)
            {
                return List.Contains(item);
            }
        }

        /// <summary>
        /// Does the list contain the following runner
        /// </summary>
        /// <param name="selectionId">The selection id.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified selection id]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(int selectionId)
        {
            lock (List.SyncRoot)
            {
                bool resp = false;
                foreach (Selection runner in List)
                {
                    if (runner.selectionId == selectionId)
                    {
                        resp = true;
                        break;
                    }
                }
                return resp;
            }
        }

        /// <summary>
        /// Does the list contain the following MarketItem
        /// </summary>
        /// <param name="selectionId">The selection id.</param>
        /// <returns></returns>
        public virtual Selection GetRunnerBySelectionId(int selectionId)
        {
            lock (List.SyncRoot)
            {
                foreach (Selection runner in List)
                {
                    if (runner.selectionId == selectionId)
                    {
                        return runner;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Does the list contain the following selection id
        /// </summary>
        /// <param name="selectionId">The selection id.</param>
        /// <returns></returns>
        public virtual int GetRunnerIndexNoBySelectionId(int selectionId)
        {
            lock (List.SyncRoot)
            {
                var count = 0;
                foreach (Selection runner in List)
                {
                    if (runner.selectionId == selectionId)
                    {
                        return count;
                    }
                    count++;
                }
                return -1;
            }
        }


        /// <summary>
        /// Sort the collection
        /// Example: item.Sort(new RunnerOrderIndexComparer());
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
    /// Order the runners by orderIndex
    /// </summary>
    public class RunnerOrderIndexComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((Selection) x).orderIndex.CompareTo(((Selection) y).orderIndex);
        }

        #endregion
    }

    [Serializable]
    public class Selection
    {
        /// <summary>
        /// The actual Betfair Starting Price. Before the starting price is determined, this field contains zero
        /// </summary>
        public double actualSPPrice { get; set; }

        /// <summary>
        /// Id of the selection (this will be the same for the same selection across markets)
        /// </summary>
        public int asianLineId { get; set; }

        /// <summary>
        /// Bets placed on this runner
        /// </summary>
        public BetList bets { get; set; }

        /// <summary>
        /// A prediction of the eventual starting price. The Far Price, which only takes into account the SP bets that have been made. The Far Price is not as complicated but not as accurate and only accounts for money on the exchange at SP
        /// </summary>
        public double farSPPrice { get; set; }

        /// <summary>
        /// Handicap of the market (applicable to Asian handicap markets)
        /// </summary>
        public double handiCap { get; set; }

        /// <summary>
        /// The last price at which a selection was matched
        /// </summary>
        public double lastPriceMatched { get; set; }

        /// <summary>
        /// Runner name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// A prediction of the eventual starting price. The Near Price is based on money currently on the site at SP as well as unmatched money on the same selection in the exchange
        /// </summary>
        public double nearSPPrice { get; set; }

        /// <summary>
        /// The order in which the items are displayed on Betfair
        /// </summary>
        public int orderIndex { get; set; }

        private PriceList m_pricesToBack;

        /// <summary>
        /// For Back prices, this will always be L as the prices available to back are made up of the existing Lay bets already on the Exchange
        /// </summary>
        public PriceList pricesToBack
        {
            get
            {
                if(m_pricesToBack==null) m_pricesToBack = new PriceList();

                return m_pricesToBack;
            }
            set { m_pricesToBack = value; }
        }

        private PriceList m_pricesToLay;

        /// <summary>
        /// For Lay prices, this will always be B as the prices available to lay are made up of the existing Back bets already on the Exchange
        /// </summary>
        public PriceList pricesToLay
        {
            get
            {
                if(m_pricesToLay==null) m_pricesToLay = new PriceList();

                return m_pricesToLay;
            }
            set { m_pricesToLay = value; }
        }

        /// <summary>
        /// Reduction in the odds that applies in case this runner does not participate
        /// </summary>
        public double reductionFactor { get; set; }

        /// <summary>
        /// The API GetSilks service allows you to retrieve a relative URL to the jockey silk 
        /// image and data about each selection including:
        /// Silks description, Trainer name, Age and Weight, Form, Days since last run,
        /// Jockey claimWearing text, Saddle cloth, Stall draw
        /// </summary>
        public RacecardInfo runnerDisplayDetail { get; set; }

        /// <summary>
        /// Runner Id
        /// </summary>
        public int selectionId { get; set; }

        /// <summary>
        /// The total amount matched on this selection (regardless of price)
        /// </summary>
        public double totalAmountMatched { get; set; }

        private TradedVolumeList m_tradedVolume;

        /// <summary>
        /// TradedVolume stroes the current price (odds) and matched amounts at each price on all of the runners in a particular market.
        /// </summary>
        public TradedVolumeList tradedVolume
        {
            get
            {
                if(m_tradedVolume==null) m_tradedVolume = new TradedVolumeList();

                return m_tradedVolume;
            }
            set { m_tradedVolume = value; }
        }

        /// <summary>
        /// Used to indicate a Vacant Trap for withdrawn runners in Greyhound markets
        /// </summary>
        public bool vacant { get; set; }

        public bool HasBets
        {
            get
            {
                if (bets == null) return false;
                if (bets.Count > 0) return true;

                return false;
            }
        }
    }
}