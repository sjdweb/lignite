namespace Lignite.Configuration
{
    public class LoadDefaults
    {
        public Settings Load()
        {
            var settings = new Settings
                               {
                                   Betfair = GetBetfairConfiguration(),
                                   GetAllMarketsConfiguration = GetAllMarketsConfiguration(),
                                   StrategyLoadPaterns = GetStrategyLoadPaterns()
                               };

            return settings;
        }

        private static BetfairConfiguration GetBetfairConfiguration()
        {
            var betfair = new BetfairConfiguration {AutoKeepAliveFrequency = 1800000};

            var endpoints = new string[2];
            endpoints[0] = @"https://api.betfair.com/exchange/v5/BFExchangeService";
            endpoints[1] = @"https://api-au.betfair.com/exchange/v5/BFExchangeService";
            betfair.EndPointExchangeAPIs = endpoints;
            betfair.EndPointGlobalAPI = @"https://api.betfair.com/global/v3/BFGlobalService";
            betfair.Password = "YourBetfairPassword";
            betfair.ProductId = 26;
            betfair.Username = "YourBetfairUsername";
            betfair.VendorSoftwareId = 0;

            return betfair;
        }

        private static GetAllMarkets GetAllMarketsConfiguration()
        {
            var allMarkets = new GetAllMarkets();

            var Countries = new string[1];
            Countries[0] = "GBR";
            allMarkets.Countries = Countries;

            allMarkets.EventDateFrom = 0;
            allMarkets.EventDateTo = 36000000;

            var EventIds = new int?[2];
            EventIds[0] = 7;
            EventIds[1] = 13;
            allMarkets.EventIds = EventIds;

            var ExchangeIds = new int[1];
            ExchangeIds[0] = 1;
            allMarkets.ExchangeIds = ExchangeIds;

            allMarkets.RunMarketsQueryEvery = 900000;

            return allMarkets;
        }

        private static StrategyLoadPatern[] GetStrategyLoadPaterns()
        {
            var StrategyLoadPaterns = new StrategyLoadPatern[3];

            StrategyLoadPaterns[0] = new StrategyLoadPatern
                                         {
                                             CustomLibrary = null,
                                             DataLoadPaterns = GetDataLoadPaterns(),
                                             FilterGetAllMarketsResults = null,
                                             Key = "Default",
                                             Name = "Default",
                                             OnMarketLoadActions = new DataLoadActions
                                                                       {
                                                                           GetBets
                                                                               =
                                                                               true,
                                                                           GetCompleteMarketTradedVolume
                                                                               =
                                                                               false,
                                                                           GetExtendedRunnerInfo
                                                                               =
                                                                               false,
                                                                           GetMarketPrices
                                                                               =
                                                                               true,
                                                                           GetMarketPricesComplete
                                                                               =
                                                                               false,
                                                                           TerminateMarketThread
                                                                               =
                                                                               false
                                                                       },
                                             Version = "1.0.0.0"
                                         };

            StrategyLoadPaterns[1] = new StrategyLoadPatern
                                         {
                                             CustomLibrary = "ExampleStrategy.dll",
                                             DataLoadPaterns = GetDataLoadPaterns(),
                                             FilterGetAllMarketsResults = new GetAllMarketsResultsFilter[1]
                                         };
            StrategyLoadPaterns[1].FilterGetAllMarketsResults[0] = new GetAllMarketsResultsFilter("name",
                                                                                                  QueryOperator.CONTAINS,
                                                                                                  "Placed", null);
            StrategyLoadPaterns[1].Key = "GBPlaceMarketExample";
            StrategyLoadPaterns[1].Name = "GB Place Market Example";
            StrategyLoadPaterns[1].OnMarketLoadActions = new DataLoadActions
                                                             {
                                                                 GetBets = true,
                                                                 GetCompleteMarketTradedVolume = false,
                                                                 GetExtendedRunnerInfo = true,
                                                                 GetMarketPrices = true,
                                                                 GetMarketPricesComplete = false,
                                                                 TerminateMarketThread = false
                                                             };
            StrategyLoadPaterns[1].Version = "1.0.0.0";

            StrategyLoadPaterns[2] = new StrategyLoadPatern
                                         {
                                             CustomLibrary = "ExampleStrategy.dll",
                                             DataLoadPaterns = GetDataLoadPaterns(),
                                             FilterGetAllMarketsResults = new GetAllMarketsResultsFilter[1]
                                         };
            StrategyLoadPaterns[2].FilterGetAllMarketsResults[0] = new GetAllMarketsResultsFilter
                (
                "name",
                QueryOperator.NOT_CONTAINS,
                "Placed",
                /*AND*/
                new GetAllMarketsResultsFilter
                    (
                    "menuPath",
                    QueryOperator.NOT_CONTAINS,
                    "Win",
                    /*AND*/
                    new GetAllMarketsResultsFilter
                        (
                        "menuPath",
                        QueryOperator.NOT_CONTAINS,
                        "ANTEPOST",
                        /*AND*/
                        new GetAllMarketsResultsFilter
                            (
                            "menuPath",
                            QueryOperator.NOT_CONTAINS,
                            "RFC",
                            /*AND*/
                            new GetAllMarketsResultsFilter
                                (
                                "menuPath",
                                QueryOperator.NOT_CONTAINS,
                                "F/C",
                                /*AND*/
                                new GetAllMarketsResultsFilter
                                    (
                                    "menuPath",
                                    QueryOperator.NOT_CONTAINS,
                                    "AvB",
                                    /*AND*/
                                    new GetAllMarketsResultsFilter
                                        (
                                        "menuPath",
                                        QueryOperator.NOT_CONTAINS,
                                        "Without",
                                        /*AND*/
                                        new GetAllMarketsResultsFilter
                                            (
                                            "type",
                                            QueryOperator.EQUAL,
                                            "O",
                                            null
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
            StrategyLoadPaterns[2].Key = "GBWinMarketExample";
            StrategyLoadPaterns[2].Name = "GB Win Market Example";
            StrategyLoadPaterns[2].OnMarketLoadActions = new DataLoadActions
                                                             {
                                                                 GetBets = true,
                                                                 GetCompleteMarketTradedVolume = false,
                                                                 GetExtendedRunnerInfo = false,
                                                                 GetMarketPrices = true,
                                                                 GetMarketPricesComplete = false,
                                                                 TerminateMarketThread = false
                                                             };
            StrategyLoadPaterns[2].Version = "1.0.0.0";

            return StrategyLoadPaterns;
        }

        private static DataLoadPaterns GetDataLoadPaterns()
        {
            var DataLoadPaterns = new DataLoadPaterns
                                      {
                                          Default = GenerateDataLoadArray(),
                                          HasBets = GenerateDataLoadArray(),
                                          HasUnmatchedBets = GenerateDataLoadArray(),
                                          Inactive = GenerateDataLoadArray(),
                                          InPlay = GenerateDataLoadArray(),
                                          Suspended = GenerateDataLoadArray()
                                      };

            return DataLoadPaterns;
        }

        private static DataLoad[] GenerateDataLoadArray()
        {
            var response = new DataLoad[6];

            for (var x = 0; x < 6; x++)
            {
                var item = new DataLoad
                               {
                                   Actions = new DataLoadActions
                                                 {
                                                     GetBets = false,
                                                     GetCompleteMarketTradedVolume = false,
                                                     GetExtendedRunnerInfo = false,
                                                     GetMarketPrices = true,
                                                     GetMarketPricesComplete = false,
                                                     TerminateMarketThread = false
                                                 }
                               };

                if (x == 0)
                {
                    item.Frequency = 600000;
                    item.TimeBeforeOff = 18000000;
                }
                if (x == 1)
                {
                    item.Frequency = 300000;
                    item.TimeBeforeOff = 7200000;
                }
                if (x == 2)
                {
                    item.Frequency = 60000;
                    item.TimeBeforeOff = 3600000;
                }
                if (x == 3)
                {
                    item.Frequency = 10000;
                    item.TimeBeforeOff = 600000;
                }
                if (x == 4)
                {
                    item.Frequency = 1000;
                    item.TimeBeforeOff = 300000;
                }
                if (x == 5)
                {
                    item.Frequency = 900;
                    item.TimeBeforeOff = 60000;
                }

                response[x] = item;
            }

            return response;
        }
    }
}