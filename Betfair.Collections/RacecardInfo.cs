using System;

namespace Betfair.Collections
{
    [Serializable]
    public class RacecardInfo : IComparable
    {
        /// <summary>
        /// A relative URL to an image file corresponding to the jockey silk.
        /// This is the same image displayed on the Betfair.com website.
        /// You must add the value of this field to the base
        /// URL: http://content-cache.betfair.com/feeds_images/Horses/SilkColours/
        /// </summary>
        public string silksURL { get; set; }

        /// <summary>
        /// The textual description of the jokey silk
        /// </summary>
        public string silksText { get; set; }

        /// <summary>
        /// The name of the horse’s trainer
        /// </summary>
        public string trainerName { get; set; }

        /// <summary>
        /// The age and weight of the horse
        /// </summary>
        public string ageWeight { get; set; }

        /// <summary>
        /// The form identifier
        /// </summary>
        public string form { get; set; }

        /// <summary>
        /// The number of days since the horse’s last run
        /// </summary>
        public int daysSince { get; set; }

        /// <summary>
        /// The jockey’s claim
        /// </summary>
        public int jockeyClaim { get; set; }

        /// <summary>
        /// Any extra equipment the horse is wearing
        /// </summary>
        public string wearing { get; set; }

        /// <summary>
        /// The number on the saddle
        /// </summary>
        public int saddleCloth { get; set; }

        /// <summary>
        /// The stall number the horse is starting from
        /// </summary>
        public int stallDraw { get; set; }

        #region IComparable Members

        public int CompareTo(Object obj)
        {
            return trainerName.CompareTo(((RacecardInfo) obj).trainerName);
        }

        #endregion
    }
}