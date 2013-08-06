/* @name Lignite For Betfair Project
 * @author Carel Vosloo
 * @author Betfair Developers Program (http://bdp.betfair.com)
 * @copyright Copyright (C) 2008 Betfair Ltd. All rights reserved.
 * @license This file is part of the Lignite For Betfair Project.
 * The BetfairAPIFramework is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The "Lignite For Betfair Project" is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the "Lignite For Betfair Project".  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Threading;
using Betfair.API.BetfairExchangeAPI;
using Betfair.API.BetfairGlobalAPI;
using Betfair.Collections;
using Betfair.Utilities.StringConverter;
using APIRequestHeader=Betfair.API.BetfairGlobalAPI.APIRequestHeader;
using Bet=Betfair.Collections.Bet;
using Market=Betfair.Collections.Market;

namespace Betfair.API
{
    /// <summary>
    /// This exposes the Betfair API functions.
    /// </summary>
    public class BetfairAPI
    {
        #region Variables

        private static string _username { get; set; }
        private static string _password { get; set; }
        private static int _productId { get; set; }
        private static int _vendorSoftwareId { get; set; }
        private static string _sessionToken { get; set; }
        private static BFGlobalService _bfGlobalService { get; set; }
        private static BFExchangeService[] _bfExchangeService { get; set; }
        private static int _autoKeepAliveSleepTime { get; set; }
        private static Thread _autoKeepAliveThread { get; set; }

        private static string _currency { get; set; }

        #endregion

        #region Initialize

        /// <summary>
        /// Initialize the Betfair API class
        /// </summary>
        /// <param name="sessionToken"></param>
        public BetfairAPI(string sessionToken)
        {
            Console.WriteLine("{0}$ MESSAGE: Initializing BetfairAPI", DateTime.Now);
            _sessionToken = sessionToken;
            SessionKeepAlive(false);
        }

        /// <summary>
        /// Initialize the Betfair API class
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="productId"></param>
        /// <param name="vendorSoftwareId"></param>
        /// <param name="globalEndPoint"></param>
        /// <param name="exchangeUKEndPoint"></param>
        /// <param name="exchangeAUEndPoint"></param>
        public BetfairAPI(
            string username,
            string password,
            int productId,
            int vendorSoftwareId,
            string globalEndPoint,
            string exchangeUKEndPoint,
            string exchangeAUEndPoint)
        {
            Initialize(username, password, productId, vendorSoftwareId, globalEndPoint, exchangeUKEndPoint,
                       exchangeAUEndPoint, 0);
        }

        /// <summary>
        /// Initialize the Betfair API class
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="productId"></param>
        /// <param name="vendorSoftwareId"></param>
        /// <param name="globalEndPoint"></param>
        /// <param name="exchangeUKEndPoint"></param>
        /// <param name="exchangeAUEndPoint"></param>
        /// <param name="keepAlive"></param>
        public BetfairAPI(
            string username,
            string password,
            int productId,
            int vendorSoftwareId,
            string globalEndPoint,
            string exchangeUKEndPoint,
            string exchangeAUEndPoint,
            int keepAlive)
        {
            Initialize(username, password, productId, vendorSoftwareId, globalEndPoint, exchangeUKEndPoint,
                       exchangeAUEndPoint, keepAlive);
        }

        private static void Initialize(
            string username,
            string password,
            int productId,
            int vendorSoftwareId,
            string globalEndPoint,
            string exchangeUKEndPoint,
            string exchangeAUEndPoint,
            int keepAlive)
        {
            Console.WriteLine("{0}$ MESSAGE: Initializing BetfairAPI", DateTime.Now);

            _bfGlobalService = new BFGlobalService {Url = globalEndPoint};

            _bfExchangeService = new BFExchangeService[3];
            _bfExchangeService[0] = null;

            _bfExchangeService[1] = new BFExchangeService {Url = exchangeUKEndPoint};

            _bfExchangeService[2] = new BFExchangeService {Url = exchangeAUEndPoint};

            _username = username;
            _password = password;
            _productId = productId;
            _vendorSoftwareId = vendorSoftwareId;

            _autoKeepAliveSleepTime = keepAlive;

            // Create the session
            Login();

            // Set the auto session manager
            ThreadStart threadDelegate = AutoKeepAlive;
            _autoKeepAliveThread = new Thread(threadDelegate);
            _autoKeepAliveThread.Start();
        }

        #endregion

        #region SubscribeToAsyncCompletedEvents

        //private void SubscribeToAsyncCompletedEvents()
        //{
        //    /*** Global API ***/
        //    _bfGlobalService.keepAliveCompleted += new Betfair.API.BetfairGlobalAPI.keepAliveCompletedEventHandler(OnAsyncCallBackComplete);

        //    /*** Exchange API ***/
        //    for (int x = 1; x < _bfExchangeService.Length; x++)
        //    {
        //        _bfExchangeService[x].getAllMarketsCompleted += new Betfair.API.BetfairExchangeAPI.getAllMarketsCompletedEventHandler(OnAsyncCallBackComplete);
        //        _bfExchangeService[x].getMarketCompleted += new Betfair.API.BetfairExchangeAPI.getMarketCompletedEventHandler(OnAsyncCallBackComplete);
        //        _bfExchangeService[x].getAllMarketsCompleted += new Betfair.API.BetfairExchangeAPI.getAllMarketsCompletedEventHandler(OnAsyncCallBackComplete);
        //        _bfExchangeService[x].getMarketPricesCompressedCompleted += new Betfair.API.BetfairExchangeAPI.getMarketPricesCompressedCompletedEventHandler(OnAsyncCallBackComplete);
        //        _bfExchangeService[x].getCompleteMarketPricesCompressedCompleted += new Betfair.API.BetfairExchangeAPI.getCompleteMarketPricesCompressedCompletedEventHandler(OnAsyncCallBackComplete);
        //        _bfExchangeService[x].getMarketTradedVolumeCompressedCompleted += new Betfair.API.BetfairExchangeAPI.getMarketTradedVolumeCompressedCompletedEventHandler(OnAsyncCallBackComplete);
        //        _bfExchangeService[x].getSilksCompleted += new Betfair.API.BetfairExchangeAPI.getSilksCompletedEventHandler(OnAsyncCallBackComplete);
        //    }
        //}

        #endregion

        #region GetHeader

        /// <summary>
        /// Returns Betfair.API.BetfairGlobalAPI.APIRequestHeader if isGlobal = true
        /// else Betfair.API.BetfairExchangeAPI.APIRequestHeader
        /// </summary>
        /// <param name="isGlobal"></param>
        /// <returns></returns>
        private static object GetHeader(bool isGlobal)
        {
            if (isGlobal)
            {
                var header = new APIRequestHeader {sessionToken = _sessionToken};
                return header;
            }
            else
            {
                var header = new BetfairExchangeAPI.APIRequestHeader {sessionToken = _sessionToken};
                return header;
            }
        }

        #endregion

        #region Login

        /// <summary>
        /// The API Login service enables customers to log in to the API 
        /// service and initiates a secure session for the user. 
        /// Users can have multiple sessions 'alive' at any point in time.
        /// </summary>
        private static void Login()
        {
            const string serviceName = "Login";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);
            var request = new LoginReq {username = _username, password = _password, productId = _productId};

            if (_vendorSoftwareId == 0 && _productId > 0)
            {
                // Used for Lignite
                _vendorSoftwareId = 1342;
            }
            request.vendorSoftwareId = _vendorSoftwareId;
            LoginResp response = _bfGlobalService.login(request);

            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            _currency = response.currency;
        }

        #endregion

        #region Logout

        /// <summary>
        /// The API Login service enables customers to log in to the API 
        /// service and initiates a secure session for the user. 
        /// Users can have multiple sessions 'alive' at any point in time.
        /// </summary>
        public void Logout()
        {
            try
            {
                const string serviceName = "Logout";
                Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);
                var request = new LogoutReq();
                if (_bfGlobalService != null) _bfGlobalService.logout(request);
            }
            finally
            {
                if (_autoKeepAliveThread != null)
                {
                    _autoKeepAliveThread.Abort();
                }
            }
        }

        #endregion

        #region SessionKeepAlive

        /// <summary>
        /// The keep alive service can be used to stop a session timing out.
        /// Every call to the Betfair API returns a token, in the sessionToken
        /// field, that identifies a login session. Every time your 
        /// application calls the Betfair API and is returned a sessionToken,
        /// the session timeout is reset to approximately 20 minutes.
        /// After the timeout has passed, the session is expired and you need to login again.
        /// </summary>
        private static void SessionKeepAlive(bool async)
        {
            const string serviceName = "SessionKeepAlive";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);
            var request = new KeepAliveReq {header = ((APIRequestHeader) GetHeader(true))};

            if (async)
            {
                _bfGlobalService.keepAliveAsync(request);
            }
            else
            {
                KeepAliveResp response = _bfGlobalService.keepAlive(request);
                ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                    response.header.sessionToken);
            }
        }

        #endregion

        #region CheckForEmtyRunnerInstances

        /// <summary>
        /// Checks for emty runner instances.
        /// </summary>
        /// <param name="market">The market.</param>
        /// <returns></returns>
        private static Market CheckForEmtyRunnerInstances(Market market)
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

        #endregion

        #region GetMarket

        /// <summary>
        /// The API GetMarket service allows the customer to input a
        /// Market ID and retrieve all static market data for the
        /// market requested. To get a Market ID for the betting
        /// market associated with an event you are interested in,
        /// use the GetEvents command.
        /// </summary>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="marketId">The market id.</param>
        /// <returns></returns>
        public Market GetMarketObject(int exchangeId, int marketId)
        {
            BetfairExchangeAPI.Market bfMarket = GetMarket(exchangeId, marketId);
            var marketToUpdate = new Market();
            if (bfMarket != null)
            {
                marketToUpdate.apiMarketDataLastRefresh = bfMarket.lastRefresh;
                marketToUpdate.bspMarket = bfMarket.bspMarket;
                marketToUpdate.country = bfMarket.countryISO3;
                marketToUpdate.currency = _currency;
                marketToUpdate.discountAllowed = bfMarket.discountAllowed;
                marketToUpdate.eventDate = bfMarket.marketTime;
                marketToUpdate.eventHierarchy = bfMarket.eventHierarchy;
                marketToUpdate.eventTypeId = bfMarket.eventTypeId;
                marketToUpdate.exchangeId = exchangeId;
                marketToUpdate.lastMarketInfoLoad = DateTime.Now;
                marketToUpdate.marketBaseRate = bfMarket.marketBaseRate;
                marketToUpdate.marketId = marketId;
                marketToUpdate.marketInformation = bfMarket.marketDescription;
                marketToUpdate.name = bfMarket.name;
                marketToUpdate.numberOfRunners = bfMarket.runners.Length;
                marketToUpdate.numberOfWinners = bfMarket.numberOfWinners;
                marketToUpdate.runnersMayBeAdded = bfMarket.runnersMayBeAdded;
                marketToUpdate.status =
                    (MarketStatus) Enum.Parse(typeof (MarketStatus), bfMarket.marketStatus.ToString());
                marketToUpdate.type = bfMarket.marketType.ToString();
                marketToUpdate.menuPath = bfMarket.menuPath;

                if (marketToUpdate.runners == null)
                {
                    marketToUpdate.runners = new SelectionList();
                }

                foreach (var runner in bfMarket.runners)
                {
                    var indexNo = marketToUpdate.runners.GetRunnerIndexNoBySelectionId(runner.selectionId);

                    if (indexNo < 0)
                    {
                        var r = new Collections.Selection
                                    {
                                        asianLineId = runner.asianLineId,
                                        handiCap = runner.handicap,
                                        name = runner.name,
                                        selectionId = runner.selectionId
                                    };
                        marketToUpdate.runners.Add(r);
                    }
                    else
                    {
                        Collections.Selection r = marketToUpdate.runners[indexNo];
                        r.asianLineId = runner.asianLineId;
                        r.handiCap = runner.handicap;
                        r.name = runner.name;
                        r.selectionId = runner.selectionId;
                        marketToUpdate.runners[indexNo] = r;
                    }
                }

                return CheckForEmtyRunnerInstances(marketToUpdate);
            }
            return null;
        }

        /// <summary>
        /// The API GetMarket service allows the customer to input a 
        /// Market ID and retrieve all static market data for the 
        /// market requested. To get a Market ID for the betting 
        /// market associated with an event you are interested in, 
        /// use the GetEvents command.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public BetfairExchangeAPI.Market GetMarket(int exchangeId, int marketId)
        {
            const string serviceName = "GetMarket";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var request = new GetMarketReq
                              {
                                  includeCouponLinks = false,
                                  marketId = marketId,
                                  header = ((BetfairExchangeAPI.APIRequestHeader) GetHeader(false))
                              };

            GetMarketResp response = _bfExchangeService[exchangeId].getMarket(request);
            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            return response.market;
        }

        #endregion

        #region GetAllMarkets

        /// <summary>
        /// The API GetAllMarkets service allows you to retrieve information about all
        /// of the markets that are currently active or suspended on the
        /// given exchange. You can use this service to quickly analyse the
        /// available markets on the exchange, or use the response to build a local
        /// copy of the Betfair.com navigation menu. You can limit the response to
        /// a particular time period, country where the event is taking place, and
        /// event type. Otherwise, the service returns all active and suspended markets.
        /// </summary>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="countries">The countries.</param>
        /// <param name="eventTypeIds">The event type ids.</param>
        /// <param name="DateToMilliseconds">The date to milliseconds.</param>
        /// <param name="DateFromMilliseconds">The date from milliseconds.</param>
        /// <returns></returns>
        public MarketList GetAllMarketsObject(int exchangeId, string[] countries, int?[] eventTypeIds,
                                              int DateToMilliseconds, int DateFromMilliseconds)
        {
            string result = GetAllMarkets(exchangeId, countries, eventTypeIds, DateToMilliseconds, DateFromMilliseconds);
            if (result != null)
            {
                return new GetAllMarkets().ConvertToObject(result);
            }
            return null;
        }

        /// <summary>
        /// The API GetAllMarkets service allows you to retrieve information about all 
        /// of the markets that are currently active or suspended on the 
        /// given exchange. You can use this service to quickly analyse the 
        /// available markets on the exchange, or use the response to build a local 
        /// copy of the Betfair.com navigation menu. You can limit the response to 
        /// a particular time period, country where the event is taking place, and 
        /// event type. Otherwise, the service returns all active and suspended markets.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="countries"></param>
        /// <param name="eventTypeIds"></param>
        /// <param name="DateToMilliseconds"></param>
        /// <param name="DateFromMilliseconds"></param>
        /// <returns></returns>
        public string GetAllMarkets(int exchangeId, string[] countries, int?[] eventTypeIds, int DateToMilliseconds,
                                    int DateFromMilliseconds)
        {
            const string serviceName = "GetAllMarkets";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var request = new GetAllMarketsReq {countries = countries};
            if (eventTypeIds != null)
            {
                request.eventTypeIds = new int?[eventTypeIds.Length];
                int count = 0;
                foreach (var i in eventTypeIds)
                {
                    request.eventTypeIds[count] = (int) i;
                    count++;
                }
            }
            request.fromDate = DateTime.Now.AddMilliseconds(DateFromMilliseconds);
            request.toDate = DateTime.Now.AddMilliseconds(DateToMilliseconds);
            request.header = (BetfairExchangeAPI.APIRequestHeader) GetHeader(false);

            GetAllMarketsResp response = _bfExchangeService[exchangeId].getAllMarkets(request);
            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            return response.marketData;
        }

        #endregion

        #region GetMarketPricesCompressed

        /// <summary>
        /// The API GetMarketPricesCompressed service allows you to
        /// retrieve dynamic market data for a given Market ID in a
        /// compressed format. This service returns the same information
        /// as the Get Market Prices service but returns it in a ~ (tilde)
        /// delimited String.
        /// </summary>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="marketId">The market id.</param>
        /// <returns></returns>
        public Market GetMarketPricesCompressedObject(int exchangeId, int marketId)
        {
            string result = GetMarketPricesCompressed(exchangeId, marketId);
            if (result != null)
            {
                return new GetMarketPricesCompressed().ConvertToObject(result, exchangeId);
            }
            return null;
        }

        /// <summary>
        /// The API GetMarketPricesCompressed service allows you to 
        /// retrieve dynamic market data for a given Market ID in a 
        /// compressed format. This service returns the same information 
        /// as the Get Market Prices service but returns it in a ~ (tilde) 
        /// delimited String.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public string GetMarketPricesCompressed(int exchangeId, int marketId)
        {
            const string serviceName = "GetMarketPricesCompressed";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var request = new GetMarketPricesCompressedReq
                              {
                                  currencyCode = _currency,
                                  marketId = marketId,
                                  header = ((BetfairExchangeAPI.APIRequestHeader) GetHeader(false))
                              };

            GetMarketPricesCompressedResp response = _bfExchangeService[exchangeId].getMarketPricesCompressed(request);
            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            return response.marketPrices;
        }

        #endregion

        #region GetCompleteMarketPricesCompressed

        /// <summary>
        /// The API GetCompleteMarketPricesCompressed service allows you to
        /// retrieve all back and lay stakes for each price on the exchange
        /// for a given Market ID in a compressed format. The information
        /// returned is similar to the GetDetailAvailableMarketDepth,
        /// except it returns the data for an entire market, rather than
        /// just one selection.
        /// </summary>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="marketId">The market id.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public Market GetCompleteMarketPricesCompressedObject(int exchangeId, int marketId, MarketStatus status)
        {
            string result = GetCompleteMarketPricesCompressed(exchangeId, marketId, status);
            if (result != null)
            {
                return new GetCompleteMarketPricesCompressed().ConvertToObject(result, exchangeId, status, _currency,
                                                                               DateTime.Now);
            }
            return null;
        }

        /// <summary>
        /// The API GetCompleteMarketPricesCompressed service allows you to
        /// retrieve all back and lay stakes for each price on the exchange
        /// for a given Market ID in a compressed format. The information
        /// returned is similar to the GetDetailAvailableMarketDepth,
        /// except it returns the data for an entire market, rather than
        /// just one selection.
        /// </summary>
        /// <param name="exchangeId">The exchange id.</param>
        /// <param name="marketId">The market id.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public string GetCompleteMarketPricesCompressed(int exchangeId, int marketId, MarketStatus status)
        {
            const string serviceName = "GetCompleteMarketPricesCompressed";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var request = new GetCompleteMarketPricesCompressedReq
                              {
                                  currencyCode = _currency,
                                  marketId = marketId,
                                  header = ((BetfairExchangeAPI.APIRequestHeader) GetHeader(false))
                              };

            GetCompleteMarketPricesCompressedResp response =
                _bfExchangeService[exchangeId].getCompleteMarketPricesCompressed(request);
            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            return response.completeMarketPrices;
        }

        #endregion

        #region GetMarketTradedVolumeCompressed

        /// <summary>
        /// The API GetMarketTradedVolumeCompressed service allows 
        /// you to obtain the current price (odds) and matched 
        /// amounts at each price on all of the runners in a 
        /// particular market.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public SelectionList GetMarketTradedVolumeCompressedObject(int exchangeId, int marketId)
        {
            string result = GetMarketTradedVolumeCompressed(exchangeId, marketId);
            if (result != null)
            {
                return new GetMarketTradedVolumeCompressed().ConvertToObject(result);
            }
            return null;
        }

        /// <summary>
        /// The API GetMarketTradedVolumeCompressed service allows 
        /// you to obtain the current price (odds) and matched 
        /// amounts at each price on all of the runners in a 
        /// particular market.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public string GetMarketTradedVolumeCompressed(int exchangeId, int marketId)
        {
            const string serviceName = "GetCompleteMarketTradedVolume";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var request = new GetMarketTradedVolumeCompressedReq
                              {
                                  currencyCode = _currency,
                                  marketId = marketId,
                                  header = ((BetfairExchangeAPI.APIRequestHeader) GetHeader(false))
                              };

            GetMarketTradedVolumeCompressedResp response =
                _bfExchangeService[exchangeId].getMarketTradedVolumeCompressed(request);
            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            return response.tradedVolume;
        }

        #endregion

        #region GetSilks

        /// <summary>
        /// The API GetSilks service allows you to retrieve a relative URL to the jockey silk image and data about each selection including:
        /// Silks description, Trainer name, Age and Weight, Form,
        /// Days since last run, Jockey claim, Wearing text, Saddle cloth, Stall draw.
        /// Note: The URL returned in the response is relative to a base URL.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns>System.Collections.Generic.SynchronizedKeyedCollection<int, Collections.RunnerDisplayDetail></returns>
        public Dictionary<int, RacecardInfo> GetSilksObject(int exchangeId, int marketId)
        {
            GetSilksResp getSilksResp = GetSilks(exchangeId, marketId);

            if (getSilksResp != null &&
                getSilksResp.marketDisplayDetails != null &&
                getSilksResp.marketDisplayDetails.Length > 0)
            {
                if (getSilksResp.marketDisplayDetails[0].errorCode == MarketDisplayErrorEnum.OK)
                {
                    var detailResponse = new Dictionary<int, RacecardInfo>();
                    for (int x = 0; x < getSilksResp.marketDisplayDetails[0].racingSilks.Length; x++)
                    {
                        var item = new RacecardInfo
                                       {
                                           ageWeight = getSilksResp.marketDisplayDetails[0].racingSilks[x].ageWeight,
                                           daysSince = getSilksResp.marketDisplayDetails[0].racingSilks[x].daysSince,
                                           form = getSilksResp.marketDisplayDetails[0].racingSilks[x].form,
                                           jockeyClaim = getSilksResp.marketDisplayDetails[0].racingSilks[x].jockeyClaim,
                                           saddleCloth = getSilksResp.marketDisplayDetails[0].racingSilks[x].saddleCloth,
                                           silksText = getSilksResp.marketDisplayDetails[0].racingSilks[x].silksText,
                                           silksURL = getSilksResp.marketDisplayDetails[0].racingSilks[x].silksURL,
                                           stallDraw = getSilksResp.marketDisplayDetails[0].racingSilks[x].stallDraw,
                                           trainerName = getSilksResp.marketDisplayDetails[0].racingSilks[x].trainerName,
                                           wearing = getSilksResp.marketDisplayDetails[0].racingSilks[x].wearing
                                       };

                        detailResponse.Add(getSilksResp.marketDisplayDetails[0].racingSilks[x].selectionId, item);
                    }

                    return detailResponse;
                }
            }

            return null;
        }

        /// <summary>
        /// The API GetSilks service allows you to retrieve a relative URL to the jockey silk image and data about each selection including:
        /// Silks description, Trainer name, Age and Weight, Form,
        /// Days since last run, Jockey claim, Wearing text, Saddle cloth, Stall draw.
        /// Note: The URL returned in the response is relative to a base URL. 
        /// The base URL for the silks image is:
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public GetSilksResp GetSilks(int exchangeId, int marketId)
        {
            var marketIdArray = new int?[1];
            marketIdArray[0] = marketId;
            return GetSilks(exchangeId, marketIdArray);
        }

        /// <summary>
        /// The API GetSilks service allows you to retrieve a relative URL to the jockey silk image and data about each selection including:
        /// Silks description, Trainer name, Age and Weight, Form,
        /// Days since last run, Jockey claim, Wearing text, Saddle cloth, Stall draw.
        /// Note: The URL returned in the response is relative to a base URL. 
        /// The base URL for the silks image is:
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public GetSilksResp GetSilks(int exchangeId, int?[] marketId)
        {
            const string serviceName = "GetSilks";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var request = new GetSilksReq
                              {
                                  header = ((BetfairExchangeAPI.APIRequestHeader) GetHeader(false)),
                                  markets = marketId
                              };

            var response = _bfExchangeService[exchangeId].getSilks(request);
            ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                Convert.ToString(response.errorCode), response.header.sessionToken);

            return response;
        }

        #endregion

        #region ValidateAPIResponse

        /// <summary>
        /// Throw exception on fatal API response
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="HeaderErrorCode"></param>
        /// <param name="sessionToken"></param>
        private static void ValidateAPIResponse(string serviceName, string HeaderErrorCode, string sessionToken)
        {
            ValidateAPIResponse(serviceName, HeaderErrorCode, null, sessionToken);
        }

        /// <summary>
        /// Throw exception on fatal API response
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="HeaderErrorCode"></param>
        /// <param name="BodyErrorCode"></param>
        /// <param name="sessionToken"></param>
        private static void ValidateAPIResponse(string serviceName, string HeaderErrorCode, string BodyErrorCode,
                                         string sessionToken)
        {
            if (string.IsNullOrEmpty(sessionToken))
            {
            }
            else
            {
                _sessionToken = sessionToken;
            }

            bool throwException = false;

            switch (HeaderErrorCode)
            {
                    // APIErrorEnum
                case "INTERNAL_ERROR":
                    {
                        throwException = true;
                        break;
                    }
                case "EXCEEDED_THROTTLE":
                    {
                        throwException = true;
                        break;
                    }
                case "USER_NOT_SUBSCRIBED_TO_PRODUCT":
                    {
                        throwException = true;
                        break;
                    }
                case "SUBSCRIPTION_INACTIVE_OR_SUSPENDED":
                    {
                        throwException = true;
                        break;
                    }
                case "VENDOR_SOFTWARE_INACTIVE":
                    {
                        throwException = true;
                        break;
                    }
                case "VENDOR_SOFTWARE_INVALID":
                    {
                        throwException = true;
                        break;
                    }
                case "SERVICE_NOT_AVAILABLE_IN_PRODUCT":
                    {
                        throwException = true;
                        break;
                    }
                case "NO_SESSION":
                    {
                        throwException = true;
                        break;
                    }
                case "TOO_MANY_REQUESTS":
                    {
                        throwException = true;
                        break;
                    }
                case "PRODUCT_REQUIRES_FUNDED_ACCOUNT":
                    {
                        throwException = true;
                        break;
                    }
                case "SERVICE_NOT_AVAILABLE_FOR_LOGIN_STATUS":
                    {
                        throwException = true;
                        break;
                    }
            }

            switch (BodyErrorCode)
            {
                    // LoginErrorEnum
                case "ACCOUNT_CLOSED":
                    {
                        throwException = true;
                        break;
                    }
                case "ACCOUNT_SUSPENDED":
                    {
                        throwException = true;
                        break;
                    }
                case "API_ERROR":
                    {
                        throwException = true;
                        break;
                    }
                case "FAILED_MESSAGE":
                    {
                        throwException = true;
                        break;
                    }
                case "INVALID_LOCATION":
                    {
                        throwException = true;
                        break;
                    }
                case "INVALID_PRODUCT":
                    {
                        throwException = true;
                        break;
                    }
                case "INVALID_USERNAME_OR_PASSWORD":
                    {
                        throwException = true;
                        break;
                    }
                case "INVALID_VENDOR_SOFTWARE_ID":
                    {
                        throwException = true;
                        break;
                    }
                case "LOGIN_FAILED_ACCOUNT_LOCKED":
                    {
                        throwException = true;
                        break;
                    }
                case "LOGIN_REQUIRE_TERMS_AND_CONDITIONS_ACCEPTANCE":
                    {
                        throwException = true;
                        break;
                    }
                case "LOGIN_RESTRICTED_LOCATION":
                    {
                        throwException = true;
                        break;
                    }
                case "LOGIN_UNAUTHORIZED":
                    {
                        throwException = true;
                        break;
                    }
                case "POKER_T_AND_C_ACCEPTANCE_REQUIRED":
                    {
                        throwException = true;
                        break;
                    }
                case "T_AND_C_ACCEPTANCE_REQUIRED":
                    {
                        throwException = true;
                        break;
                    }
                case "USER_NOT_ACCOUNT_OWNER":
                    {
                        throwException = true;
                        break;
                    }

                    // GetAllMarketsErrorEnum
                case "INVALID_COUNTRY_CODE":
                    {
                        throwException = true;
                        break;
                    }
                case "INVALID_EVENT_TYPE_ID":
                    {
                        throwException = true;
                        break;
                    }
                case "INVALID_LOCALE":
                    {
                        throwException = true;
                        break;
                    }

                    // PlaceBetsErrorEnum
                case "AUTHORISATION_PENDING":
                    {
                        throwException = true;
                        break;
                    }
                case "BACK_LAY_COMBINATION":
                    {
                        throwException = true;
                        break;
                    }
                case "BBM_DAEMON_NOT_AVAILABLE":
                    {
                        throwException = true;
                        break;
                    }
                case "BET_IN_PROGRESS":
                    {
                        throwException = false;
                        break;
                    }
                case "BETWEEN_1_AND_60_BETS_REQUIRED":
                    {
                        throwException = true;
                        break;
                    }
                case "BSP_BETTING_NOT_SUPPORTED":
                    {
                        throwException = true;
                        break;
                    }
                case "EVENT_CLOSED":
                    {
                        throwException = true;
                        break;
                    }
                case "EVENT_INACTIVE":
                    {
                        throwException = true;
                        break;
                    }
                case "EVENT_SUSPENDED":
                    {
                        throwException = true;
                        break;
                    }
                case "FROM_COUNTRY_FORBIDDEN":
                    {
                        throwException = true;
                        break;
                    }
                case "MARKET_TYPE_NOT_SUPPORTED":
                    {
                        throwException = true;
                        break;
                    }
                case "SITE_UPGRADE":
                    {
                        throwException = true;
                        break;
                    }
            }

            Console.WriteLine("{0}$ API_SERVICE {1}:HEADER_ERROR={2}:BODY_ERROR={3}", DateTime.Now, serviceName,
                              HeaderErrorCode, BodyErrorCode);

            if (throwException)
                throw new Exception(String.Format("{0}$ API_SERVICE {1}:HEADER_ERROR={2}:BODY_ERROR={3}", DateTime.Now,
                                                  serviceName, HeaderErrorCode, BodyErrorCode));
        }

        #endregion

        #region AutoKeepAlive

        /// <summary>
        /// This a threaded operation started from initialize
        /// </summary>
        private static void AutoKeepAlive()
        {
            while (_autoKeepAliveSleepTime > 0 && _sessionToken != null)
            {
                Thread.Sleep(_autoKeepAliveSleepTime);
                SessionKeepAlive(true);
            }
        }

        #endregion

        #region GetSessionToken

        /// <summary>
        /// Gets the session token.
        /// </summary>
        /// <returns></returns>
        public string GetSessionToken()
        {
            return _sessionToken;
        }

        #endregion

        #region PlaceBets

        /// <summary>
        /// The API PlaceBets service allows you to place multiple (1 to 60) bets on 
        /// a single Market. There is an instance of PlaceBetsResp returned in the 
        /// output for each instance of PlaceBets in the input. The success or failure 
        /// of the individual bet placement operation is indicated by the Success Boolean.
        /// Note: To bet on an event, you need to have sufficient funds available 
        /// in the relevant local wallet to cover your entire liability. If you want 
        /// to bet on the Australian exchange server and you do not have sufficient funds 
        /// in your Australian wallet to cover the liability, you must first transfer funds 
        /// into that wallet from your UK wallet by using the transferFunds service 
        /// (see Chapter 56). Also, your wallet must be active 
        /// (and not, for example, suspended for any reason) at the time you place the bet.
        /// </summary>
        /// <param name="bets">The bets.</param>
        /// <returns></returns>
        public List<Bet> PlaceBets(List<Bet> bets)
        {
            const string serviceName = "PlaceBets";
            Console.WriteLine("{0}$ API_SERVICE {1}", DateTime.Now, serviceName);

            var errorMessages = new List<string>();

            for (int x = 0; x < bets.Count; x++)
            {
                if (!bets[x].betRequestprocessed && bets[x].betId == 0)
                {
                    Bet bet = bets[x];
                    var request = new PlaceBetsReq
                                      {
                                          header = ((BetfairExchangeAPI.APIRequestHeader) GetHeader(false)),
                                          bets = new PlaceBets[1]
                                      };

                    request.bets[0] = new PlaceBets();

                    bets[x].betRequestprocessed = true;

                    request.bets[0].asianLineId = bet.asianLineId;

                    switch (bet.betCategory)
                    {
                        case BetCategoryOptions.EXCHANGE:
                            request.bets[0].betCategoryType = BetCategoryTypeEnum.E;
                            break;
                        case BetCategoryOptions.LIMIT_ON_CLOSE:
                            request.bets[0].betCategoryType = BetCategoryTypeEnum.L;
                            break;
                        default:
                            request.bets[0].betCategoryType = bet.betCategory == BetCategoryOptions.MARKET_ON_CLOSE ? BetCategoryTypeEnum.M : BetCategoryTypeEnum.NONE;
                            break;
                    }

                    switch (bet.betPersistence)
                    {
                        case BetPersistenceOptions.IN_PLAY_PERSISTENCE:
                            request.bets[0].betPersistenceType = BetPersistenceTypeEnum.IP;
                            break;
                        case BetPersistenceOptions.UNMATCHED_FILL_WITH_SP:
                            request.bets[0].betPersistenceType = BetPersistenceTypeEnum.SP;
                            break;
                        default:
                            request.bets[0].betPersistenceType = BetPersistenceTypeEnum.NONE;
                            break;
                    }

                    request.bets[0].betType = bet.betType == BetTypeOptions.L ? BetTypeEnum.L : BetTypeEnum.B;

                    request.bets[0].bspLiability = bet.bspLiability;
                    request.bets[0].marketId = bet.marketId;
                    request.bets[0].price = bet.price;
                    request.bets[0].selectionId = bet.selectionId;
                    request.bets[0].size = bet.size;

                    var response = _bfExchangeService[bet.exchangeId].placeBets(request);

                    if (response.betResults[0] != null && response.betResults[0].betId > 0)
                        bets[x].betId = response.betResults[0].betId;

                    try
                    {
                        bets[x].success = response.betResults[0].success;
                        bets[x].systemBetCreateDate = DateTime.Now.ToUniversalTime();

                        ValidateAPIResponse(serviceName, Convert.ToString(response.header.errorCode),
                                            Convert.ToString(response.errorCode), response.header.sessionToken);

                        if (response.betResults[0].sizeMatched > 0)
                            bets[x].size = response.betResults[0].sizeMatched;

                        bets[x].customUserBetNote = response.betResults[0].resultCode.ToString();
                    }
                    catch (Exception ex)
                    {
                        errorMessages.Add(ex.Message);
                    }
                }
            }

            foreach (string message in errorMessages)
                Console.WriteLine("{0}$ API_SERVICE {1} :{2} ", DateTime.Now, serviceName, message);

            return bets;
        }

        #endregion
    }
}