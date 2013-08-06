using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Lignite.Plugin;

namespace Lignite.Configuration
{

    #region XmlFileOperations

    public class XmlFileOperations
    {
        public void Write(Object exportXmlData, string outputFileTo)
        {
            TextWriter writer = new StreamWriter(outputFileTo);
            try
            {
                var serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(writer, exportXmlData);
                writer.Close();
            }
            finally
            {
                writer.Close();
            }
        }

        public Settings Read(string fileToRead)
        {
            var fs = new FileStream(fileToRead, FileMode.Open);

            try
            {
                var serializer = new XmlSerializer(typeof (Settings));
                /* If the XML document has been altered with unknown 
                 * nodes or attributes, handle them with the 
                 * UnknownNode and UnknownAttribute events.*/
                serializer.UnknownNode += serializer_UnknownNode;
                serializer.UnknownAttribute += serializer_UnknownAttribute;

                var settings = (Settings) serializer.Deserialize(fs);
                fs.Close();
                return settings;
            }
            finally
            {
                fs.Close();
            }
        }

        private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        private static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
                              attr.Name + "='" + attr.Value + "'");
        }
    }

    #endregion

    #region Settings

    [Serializable]
    [XmlRoot("Lignite.Configuration", Namespace = "http://lignite.betfair.com", IsNullable = false)]
    public class Settings
    {
        /// <summary>
        /// Betfair configuration
        /// </summary>
        /// </summary>
        [XmlElement(IsNullable = false)]
        public BetfairConfiguration Betfair { get; set; }

        /// <summary>
        /// The default query values to be used to get all market before we further
        /// filter the results to match our strategy requirements
        /// </summary>
        [XmlElement(IsNullable = false)]
        public GetAllMarkets GetAllMarketsConfiguration { get; set; }

        /// <summary>
        /// The strategy configuration
        /// </summary>
        [XmlElement(IsNullable = false)]
        public StrategyLoadPatern[] StrategyLoadPaterns { get; set; }

        /// <summary>
        /// Get the default StrategyLoadPatern for the loaded instance
        /// </summary>
        /// <returns></returns>
        public StrategyLoadPatern GetDefaultStrategyLoadPatern()
        {
            return GetStrategyLoadPaternByKey("default");
        }

        /// <summary>
        /// Get the default StrategyLoadPatern for the loaded instance
        /// </summary>
        /// <returns></returns>
        public StrategyLoadPatern GetStrategyLoadPaternByKey(string key)
        {
            foreach (StrategyLoadPatern patern in StrategyLoadPaterns)
            {
                if (patern.Name.ToLower() == key)
                {
                    return patern;
                }
            }

            return null;
        }
    }

    #endregion

    #region BetfairConfiguration

    /// <summary>
    /// betfair specific settings
    /// </summary>
    [Serializable]
    public class BetfairConfiguration
    {
        /// <summary>
        /// Betfair username
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string Username { get; set; }

        /// <summary>
        /// betfair password
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string Password { get; set; }

        /// <summary>
        /// Betfair productId
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Betfair VendorSoftwareId
        /// </summary>
        public int VendorSoftwareId { get; set; }

        /// <summary>
        /// Betfair global API endpoint to use
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string EndPointGlobalAPI { get; set; }

        /// <summary>
        /// Betfair exchange API endpoints to use
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string[] EndPointExchangeAPIs { get; set; }

        /// <summary>
        /// Betfair session keep alive frequency in milliseconds
        /// </summary>
        public int AutoKeepAliveFrequency { get; set; }
    }

    #endregion

    #region GetAllMarkets
    [Serializable]
    public class GetAllMarkets
    {
        /// <summary>
        /// Look for new markets every so many milliseconds
        /// </summary>
        public double RunMarketsQueryEvery { get; set; }

        /// <summary>
        /// The event type IDs to query
        /// </summary>
        [XmlElement(IsNullable = true)]
        public int?[] EventIds { get; set; }

        /// <summary>
        /// The countries to query
        /// </summary>
        [XmlElement(IsNullable = true)]
        public string[] Countries { get; set; }

        /// <summary>
        /// Events starting on a date time greater equal to DateTime.Now.AddMilliseconds(EventDateFrom)
        /// </summary>
        [XmlElement(IsNullable = true)]
        public double? EventDateFrom { get; set; }

        /// <summary>
        /// Events starting not later than a date time greater equal to DateTime.Now.AddMilliseconds(EventDateFrom)
        /// </summary>
        [XmlElement(IsNullable = true)]
        public double? EventDateTo { get; set; }

        /// <summary>
        /// The exchanges to query against
        /// </summary>
        public int[] ExchangeIds { get; set; }
    }

    #endregion

    #region StrategyLoadPatern
    [Serializable]
    public class StrategyLoadPatern
    {
        /// <summary>
        /// This has to ba a unique identifier
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string Key { get; set; }

        /// <summary>
        /// The name of this strategy
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// Version number for your reference
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string Version { get; set; }

        /// <summary>
        /// Filter the get all markets result using these options to qualify the
        /// item as a valid match for this strategy
        /// </summary>
        [XmlArray("FilterGetAllMarketsResults", IsNullable = true)]
        public GetAllMarketsResultsFilter[] FilterGetAllMarketsResults { get; set; }

        /// <summary>
        /// Your custom library (dll) to load at run-time if the query conditions are met the thread got loaded
        /// </summary>
        [XmlElement(IsNullable = true)]
        public string CustomLibrary { get; set; }

        /// <summary>
        /// The configuration parameter for your custom library implementation.
        /// </summary>
        /// <value>The custom library config section.</value>
        [XmlIgnore]
        public PluginConfigurationBase CustomLibraryConfigSection { get; set; }

        [XmlElement(IsNullable = true)]
        public byte[] XMLCustomLibraryConfigSectionBytes
        {
            get
            {
                if (CustomLibraryConfigSection != null)
                {
                    var bytes = getByteArrayWithObject((CustomLibraryConfigSection));
                    return bytes;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    CustomLibraryConfigSection = ((PluginConfigurationBase) getObjectWithByteArray(value));
                }
            }
        }

        /// <summary>
        /// Action to perform when a new thread is started
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DataLoadActions OnMarketLoadActions { get; set; }

        /// <summary>
        /// The default frequency at which we retrieve new market prices, traded volume, bets etc
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataLoadPaterns DataLoadPaterns { get; set; }

        public byte[] getByteArrayWithObject(Object o)
        {
            var ms = new MemoryStream();
            var bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        public object getObjectWithByteArray(byte[] theByteArray)
        {
            var ms = new MemoryStream(theByteArray);
            var bf1 = new BinaryFormatter();
            ms.Position = 0;

            return bf1.Deserialize(ms);
        }
    }

    #endregion

    #region DataLoadPaterns
    [Serializable]
    public class DataLoadPaterns
    {
        /// <summary>
        /// The default frequency at which we retrieve new market prices, traded volume, bets etc
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DataLoad[] Default { get; set; }

        /// <summary>
        /// The frequency at which we retrieve new market prices, traded volume, bets etc
        ///  if the market has bets
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataLoad[] HasBets { get; set; }

        /// <summary>
        /// The frequency at which we retrieve new market prices, traded volume, bets etc
        ///  if the market has bets
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataLoad[] HasUnmatchedBets { get; set; }

        /// <summary>
        /// The frequency at which we retrieve new market prices, traded volume, bets etc
        ///  if the market has bets
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataLoad[] InPlay { get; set; }

        /// <summary>
        /// The frequency at which we retrieve new market prices, traded volume, bets etc
        ///  if the market has bets
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataLoad[] Suspended { get; set; }

        /// <summary>
        /// The frequency at which we retrieve new market prices, traded volume, bets etc
        ///  if the market has bets
        /// </summary>
        [XmlElement(IsNullable = true)]
        public DataLoad[] Inactive { get; set; }
    }

    #endregion

    #region GetAllMarketsResultsFilter
    [Serializable]
    public class GetAllMarketsResultsFilter
    {
        /// <summary>
        /// aditional filter criteria
        /// </summary>
        [XmlElement(IsNullable = true)] public GetAllMarketsResultsFilter And;

        public GetAllMarketsResultsFilter()
        {
        }

        public GetAllMarketsResultsFilter(string Field, QueryOperator Operator, string Value,
                                          GetAllMarketsResultsFilter And)
        {
            this.Field = Field;
            this.Operator = Operator;
            this.Value = Value;
            this.And = And;
        }

        /// <summary>
        /// The field to query.
        /// Options:
        /// marketId, name, type, status, eventDate, menuPath, eventHierarchy, 
        /// betDelay, exchangeId, country, numberOfRunners, numberOfWinners,
        /// totalAmountMatched, bspMarket
        /// </summary>
        [XmlElement(IsNullable = false)]
        public string Field { get; set; }

        /// <summary>
        /// Operator to use for validation
        /// </summary>
        [XmlElement(IsNullable = false)]
        public QueryOperator Operator { get; set; }

        /// <summary>
        /// Query value
        /// </summary>
        public string Value { get; set; }
    }

    #region QueryOperator

    public enum QueryOperator
    {
        EQUAL,
        NOT_EQUAL,
        CONTAINS,
        NOT_CONTAINS,
        GREATER_THAN,
        LESS_THAN,
        REGEX_IS_MATCH,
        REGEX_NOT_MATCH
    }

    #endregion

    #endregion

    #region DataLoad
    [Serializable]
    public class DataLoad
    {
        /// <summary>
        /// What data should be retrieved
        /// </summary>
        [XmlElement(IsNullable = false)]
        public DataLoadActions Actions { get; set; }

        /// <summary>
        /// The time in milliseconds before the published start of the race
        /// </summary>
        public double TimeBeforeOff { get; set; }

        /// <summary>
        /// Repeat this operation every so many milliseconds
        /// </summary>
        public double Frequency { get; set; }
    }

    #endregion

    #region DataLoadActions
    [Serializable]
    public class DataLoadActions
    {
        /// <summary>
        /// Should we load only the best 3 market prices on this run either side.
        /// If get_market_prices_complete is true it will override this option
        /// </summary>
        [XmlElement(IsNullable = false)]
        public bool GetMarketPrices { get; set; }

        /// <summary>
        /// Should we load the complete market prices on this run
        /// </summary>
        [XmlElement(IsNullable = false)]
        public bool GetMarketPricesComplete { get; set; }

        /// <summary>
        /// Should we retrieve the complete traded volume history
        /// </summary>
        [XmlElement(IsNullable = false)]
        public bool GetCompleteMarketTradedVolume { get; set; }

        /// <summary>
        /// Should we retrieve all bets on this market
        /// </summary>
        [XmlElement(IsNullable = false)]
        public bool GetBets { get; set; }

        /// <summary>
        /// Only valid for UK horseracing where silks are available
        /// </summary>
        [XmlElement(IsNullable = false)]
        public bool GetExtendedRunnerInfo { get; set; }

        /// <summary>
        /// Closes the market processor thread
        /// </summary>
        [XmlElement(IsNullable = false)]
        public bool TerminateMarketThread { get; set; }
    }

    #endregion
}