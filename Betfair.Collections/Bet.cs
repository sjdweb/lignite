using System;
using System.Collections;

namespace Betfair.Collections
{
    [Serializable]
    public class BetList : CollectionBase
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
        public virtual Bet this[int Index]
        {
            get { return (Bet) List[Index]; }
        }

        /// <summary>
        /// Add a Price to the IList
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(Bet item)
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
        public bool Contains(Bet item)
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
    public class BetPriceComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((Bet) x).price.CompareTo(((Bet) y).price);
        }

        #endregion
    }

    [Serializable]
    public class Bet
    {
        /// <summary>
        /// The ID of the Asian Handicap market to place bets on. Set to 0 for non-Asian handicap Markets.
        /// </summary>
        public int asianLineId;

        /// <summary>
        /// Specify if the bet is an Exchange bet, Market on Close SP bet or Limit on Close SP bet. If you specify Limit on Close, specify the desired limit using the price field.
        /// </summary>
        public BetCategoryOptions betCategory;

        /// <summary>
        /// The unique identifier for the bet
        /// </summary>
        public long betId;

        /// <summary>
        /// Has the bet been fully matched
        /// </summary>
        public bool betIsFullyMatched;

        /// <summary>
        /// Specify what happens to an unmatched (or partially unmatched) exchange bet when the market turns in-play. For an SP bet, this must be set to NONE.
        /// </summary>
        public BetPersistenceOptions betPersistence;

        /// <summary>
        /// Has the bet been processed by the system
        /// </summary>
        public bool betRequestprocessed;

        /// <summary>
        /// Bet type (back, lay or equivalent Asian Handicap types)
        /// </summary>
        public BetTypeOptions betType;

        /// <summary>
        /// This is the maximum amount of money you want to risk for a BSP bet. The minimum amount for a back bet is £2 (or equivalent). The minimum amount for a lay bet is £10 (or For a back bet, this is equivalent to the stake on a normal exchange bet. 
        /// For a lay bet, this is the equivalent to the liability on a normal exchange bet. 
        /// If after the market is reconciled, the actual stake is calculated once the price is known.
        /// </summary>
        public double bspLiability;

        /// <summary>
        /// Custom field avaialable to tag a bet - NOT BETFAIR API RELATED
        /// </summary>
        public int customUserBetId;

        /// <summary>
        /// Custom field avaialable to tag a bet - NOT BETFAIR API RELATED
        /// </summary>
        public string customUserBetNote;

        /// <summary>
        /// The exchange Id for the market. 1 for the UK/Worldwide exchange, 2 for the Australian Exchange.
        /// </summary>
        public int exchangeId;

        private string m_betGuidString;

        /// <summary>
        /// The Market Id of the market. Note: This is unique to an exchange, but is not guaranteed to be unique between exchanges. Always check the ExchangeID of the market.
        /// </summary>
        public int marketId;

        /// <summary>
        /// The price (odds) you want to set for the bet. Valid values are 1.01 to 1000. 
        /// For a BSP Limit on Close bet, specify the desired price limit. For a Back bet, the minimum price you want. If the Starting Price is lower than this amount, then your bet is not matched. For a Lay bet, the maximum acceptable price. If the Starting Price is higher than this amount, then your bet is not matched.
        /// If the specified limit is equal to the starting price, then it may be matched, partially matched, or may not be matched at all, depending on how much is needed to balance all bets against each other (MOC, LOC and normal exchange bets).
        /// </summary>
        public double price;

        /// <summary>
        /// Runner Id
        /// </summary>
        public int selectionId;

        /// <summary>
        /// The stake (amount) for an exchange bet.
        /// </summary>
        public double size;

        /// <summary>
        /// Has the bet placement request succeeded
        /// </summary>
        public bool success;

        /// <summary>
        /// The date and time this bet was placed according to the local computer
        /// </summary>
        public DateTime systemBetCreateDate;

        /// <summary>
        /// Guid to uniquely identify this item
        /// </summary>
        public string betGuidString
        {
            get
            {
                if (m_betGuidString == null)
                    m_betGuidString = Guid.NewGuid().ToString();
                return m_betGuidString;
            }
        }
    }

    public enum BetTypeOptions
    {
        B,
        L
    }

    /// <summary>
    /// You can specify what happens to an Exchange bet that is unmatched when the market is reconciled and the starting price is calculated.
    /// - None (NONE) - The unmatched bet is cancelled when the market is reconciled and turned in-play.
    /// - IP (IN_PLAY_PERSISTENCE) - The unmatched bet stays as an unmatched bet when the market is turn in-play.
    /// - SP (UNMATCHED_FILL_WITH_SP) - The unmatched bet becomes a Market on Close bet and is matched at the starting price. 
    /// </summary>
    public enum BetPersistenceOptions
    {
        /// <summary>
        /// Normal exchange or SP bet. Unmatched exchange bets are lapsed when the market turns in-play.
        /// </summary>
        NONE,
        /// <summary>
        /// In Play persistence. Unmatched bets (or the unmatched portion of a bet) remain in the market when it turns in-play. The bet retains its place in the bet queue and retains the same betId.
        /// </summary>
        IN_PLAY_PERSISTENCE,
        /// <summary>
        /// MoC Starting Price. The Unmatched (or unmatched portion) bet is converted to a Market on Close Starting Price bet and matched at the reconciled starting price.
        /// </summary>
        UNMATCHED_FILL_WITH_SP
    }

    public enum BetCategoryOptions
    {
        /// <summary>
        /// Equivalent to Exchange. This may change in a future release.
        /// </summary>
        NONE,
        /// <summary>
        /// Normal exchange bet.
        /// </summary>
        EXCHANGE,
        /// <summary>
        /// Market on Close bet. The bet remains unmatched until the market is reconciled and a starting price is determined. If no starting price is available for the selection, the bet lapses.
        /// </summary>
        MARKET_ON_CLOSE,
        /// <summary>
        /// Limit on Close bet. The bet remains unmatched until the market is reconciled and a starting price is determined. If the starting price is better than the price specified, then the bet is matched. If no starting price is available for the selection, the bet lapses.
        /// </summary>
        LIMIT_ON_CLOSE
    }
}