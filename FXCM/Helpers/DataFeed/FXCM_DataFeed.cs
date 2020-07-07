using fxcore2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXCM.Helpers
{
    public class FxcmDataFeed
    {
        #region Members

        private const string HelpersLink = "http://www.fxcorporate.com/Hosts.jsp";

        #region fxcore2

        private O2GSession _session;
        private O2GResponseReaderFactory _factory;
        private O2GSessionStatusCode _sessionStatusCode = O2GSessionStatusCode.Unknown;
        private O2GMarketDataSnapshotResponseReader _marketDataSnapshotResponse;

        #endregion // fxcore2

        private bool IsConnceted;
        private object _csSessionStatus = new object();
        private EventWaitHandle _syncSessionEvent;
        private EventWaitHandle _syncResponseEvent;
        private EventWaitHandle _syncHistoryEvent;

        public List<PriceUpdate> priceUpdates;

        public IEnumerable<string> symbolsInfo;
        private object priceUpdateObject;

        public event EventHandler<TableUpdateInfoEventArgs> TableUpdateInfoEventArgs;

        #endregion // Members

        #region Initialization

        public FxcmDataFeed()
        {
            _syncSessionEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            _syncResponseEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            _syncHistoryEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            priceUpdates = new List<PriceUpdate>();
            symbolsInfo = new List<string>();
            priceUpdateObject = new object();
        }

        #endregion // Initialization

        #region Connect/Disconnect

        public async Task<bool> ConnectToDataFeedAsync(string username, string password, Connection connection)
        {
            return await Task.Run(() =>
            {
                IsConnceted = false;
                try
                {
                    _session = O2GTransport.createSession();

                    _session.LoginFailed += Session_LoginFailed;
                    _session.SessionStatusChanged += Session_SessionStatusChanged;

                    IsConnceted = Login(username, password, connection.ToString());

                    _session.RequestCompleted += Session_RequestCompleted;
                    _session.RequestFailed += Session_RequestFailed;
                    _session.TablesUpdates += Session_TablesUpdates;

                    _factory = _session.getResponseReaderFactory();
                }
                catch (Exception ex)
                {
                    Stop();
                    MessageBox.Show(ex.Message);
                    IsConnceted = false;
                }

                return IsConnceted;
            });
        }

        public O2GSessionStatusCode Status
        {
            get
            {
                O2GSessionStatusCode status;
                lock (_csSessionStatus)
                {
                    status = _sessionStatusCode;
                }
                return status;
            }
            private set
            {
                lock (_csSessionStatus)
                {
                    _sessionStatusCode = value;
                }
            }
        }

        private bool Login(string username, string password, string connection)
        {
            _session.useTableManager(O2GTableManagerMode.Yes, null);
            _session.login(username, password, HelpersLink, connection);

            int countWait = 6;
            while (_sessionStatusCode != O2GSessionStatusCode.Connected && countWait != 0)
            {
                _syncSessionEvent.WaitOne(10000);
                countWait--;
            }


            return _sessionStatusCode == O2GSessionStatusCode.Connected;
        }

        private void Stop()
        {
            if (_session != null)
            {
                _session.logout();
                _syncSessionEvent.WaitOne(5000);

                _session.RequestCompleted -= Session_RequestCompleted;
                _session.RequestFailed -= Session_RequestFailed;
                _session.TablesUpdates -= Session_TablesUpdates;
                _session.LoginFailed -= Session_LoginFailed;
                _session.SessionStatusChanged -= Session_SessionStatusChanged;

                _sessionStatusCode = O2GSessionStatusCode.Disconnected;

                _session.Dispose();
            }
        }

        #endregion // Connect/Disconnect

        #region History Request/Response

        public async Task<IEnumerable<HistoricalData>> GetHistoricalDataAsync(string symbol)
        {
            return await Task.Run(() =>
            {
                var factory = _session.getRequestFactory();
                var timeframes = factory.Timeframes;
                var timeframe = timeframes["m1"];
                var request = factory.createMarketDataSnapshotRequestInstrument(symbol, timeframe, 300);

                var timeFrom = DateTime.Now.AddDays(-1);
                var timeTo = DateTime.Now;

                factory.fillMarketDataSnapshotRequestTime(request, timeFrom, timeTo, false);

                _session.sendRequest(request);

                _syncHistoryEvent.WaitOne(30000);

                var historyData = new List<HistoricalData>();
                for (int i = 0; i < _marketDataSnapshotResponse.Count; i++)
                {
                    historyData.Add(new HistoricalData
                    {
                        Date = _marketDataSnapshotResponse.getDate(i),
                        Open = GetPrice(_marketDataSnapshotResponse.getAskOpen(i), _marketDataSnapshotResponse.getBidOpen(i)),
                        High = GetPrice(_marketDataSnapshotResponse.getAskHigh(i), _marketDataSnapshotResponse.getBidHigh(i)),
                        Low = GetPrice(_marketDataSnapshotResponse.getAskLow(i), _marketDataSnapshotResponse.getBidLow(i)),
                        Close = GetPrice(_marketDataSnapshotResponse.getAskLow(i), _marketDataSnapshotResponse.getBidLow(i)),
                        Volume = _marketDataSnapshotResponse.getVolume(i)
                    });
                }

                return historyData;
            });
        }

        #endregion // History Request/Response

        #region Events

        private void Session_RequestCompleted(object sender, RequestCompletedEventArgs e)
        {
            switch (e.Response.Type)
            {
                case O2GResponseType.GetLastOrderUpdate:
                    break;
                case O2GResponseType.MarginRequirementsResponse:
                    break;
                case O2GResponseType.CommandResponse:
                    break;
                case O2GResponseType.GetSystemProperties:
                    break;
                case O2GResponseType.CreateOrderResponse:
                    break;
                case O2GResponseType.GetMessages:
                    break;
                case O2GResponseType.GetClosedTrades:
                    break;
                case O2GResponseType.GetTrades:
                    break;
                case O2GResponseType.GetOrders:
                    break;
                case O2GResponseType.GetOffers:
                    break;
                case O2GResponseType.GetAccounts:
                    var accountsReader = _factory.createAccountsTableReader(e.Response);
                    //_accountRow = GetAccountRow(accountsReader);
                    _syncResponseEvent.Set();
                    break;
                case O2GResponseType.MarketDataSnapshot:
                    var readerFactory = _session.getResponseReaderFactory();
                    _marketDataSnapshotResponse = _factory.createMarketDataSnapshotReader(e.Response);
                    _syncHistoryEvent.Set();
                    break;
                case O2GResponseType.TablesUpdates:
                    _session.TablesUpdates += Session_TablesUpdates;
                    break;
                case O2GResponseType.ResponseUnknown:
                    Stop();
                    break;
            }
        }

        private void Session_TablesUpdates(object sender, TablesUpdatesEventArgs e)
        {
            var responseTablesUpdatesReader = _factory.createTablesUpdatesReader(e.Response);
            Parallel.For(0, responseTablesUpdatesReader.Count, i =>
            {
                if (responseTablesUpdatesReader.getUpdateTable(i) == O2GTableType.Offers && responseTablesUpdatesReader.getUpdateType(i) == O2GTableUpdateType.Update)
                {
                    var offer = responseTablesUpdatesReader.getOfferRow(i);

                    if (!string.IsNullOrEmpty(offer.Instrument))
                    {
                        var pu = new PriceUpdate
                        {
                            Symbol = offer.Instrument,
                            TradeDateTime = offer.Time,
                            Price = GetPrice(offer.Bid, offer.Ask),
                            Volume = offer.Volume,
                            Bid = offer.Bid,
                            Ask = offer.Ask,
                            High = offer.High,
                            Low = offer.Low
                        };

                        lock(priceUpdateObject)
                        {
                            var firstPriceUpdate = priceUpdates.FirstOrDefault(f => f.Symbol.Equals(pu.Symbol));
                            if (firstPriceUpdate != null)
                            {
                                firstPriceUpdate.Ask = pu.Ask;
                                firstPriceUpdate.Bid = pu.Bid;
                                firstPriceUpdate.Volume = pu.Volume;
                                firstPriceUpdate.PrevPrice = firstPriceUpdate.Price;
                                firstPriceUpdate.Price = pu.Price;
                                firstPriceUpdate.TradeDateTime = pu.TradeDateTime;
                            }
                            else
                            {
                                priceUpdates.Add(pu);
                            }
                        }
                    }
                }
            });
            
            OnRowCountChange();
        }

        private void Session_RequestFailed(object sender, RequestFailedEventArgs e)
        {
            lock (_csSessionStatus)
            {
                _sessionStatusCode = O2GSessionStatusCode.Disconnected;
            }
            _syncSessionEvent.Set();
        }

        private void Session_SessionStatusChanged(object sender, SessionStatusEventArgs e)
        {
            _sessionStatusCode = e.SessionStatus;
            switch (e.SessionStatus)
            {
                case O2GSessionStatusCode.Unknown:
                    break;
                case O2GSessionStatusCode.PriceSessionReconnecting:
                    break;
                case O2GSessionStatusCode.SessionLost:
                    break;
                case O2GSessionStatusCode.Disconnecting:
                    break;
                case O2GSessionStatusCode.Reconnecting:
                    O2GTransport.setNumberOfReconnections(1);
                    break;
                case O2GSessionStatusCode.Connected:
                    _syncSessionEvent.Set();
                    break;
                case O2GSessionStatusCode.TradingSessionRequested:
                    O2GSessionDescriptorCollection descriptors = _session.getTradingSessionDescriptors();
                    O2GSessionDescriptor descriptor = descriptors[0];
                    _session.setTradingSession(descriptor.Id, "");
                    break;
                case O2GSessionStatusCode.Connecting:
                case O2GSessionStatusCode.Disconnected:
                    _syncSessionEvent.Set();
                    break;
            }
        }

        private void Session_LoginFailed(object sender, LoginFailedEventArgs e)
        {
            lock (_csSessionStatus)
            {
                _sessionStatusCode = O2GSessionStatusCode.Disconnected;
            }
            _syncSessionEvent.Set();
        }

        private void OnRowCountChange()
        {
            symbolsInfo = priceUpdates.Select(s => s.Symbol);

            TableUpdateInfoEventArgs?.Invoke(this, new TableUpdateInfoEventArgs());
        }

        #endregion // Events

        #region Helpers

        private double GetPrice(double ask, double bid) =>
            (ask + bid) / 2;

        #endregion // Helpers
    }
}
