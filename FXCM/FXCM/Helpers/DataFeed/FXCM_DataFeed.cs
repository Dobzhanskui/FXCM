using fxcore2;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace FXCM.Helpers
{
    public class FxcmDataFeed
    {
        #region Members

        #region fxcore2
        private O2GSession _session;
        private O2GSessionStatusCode _sessionStatusCode = O2GSessionStatusCode.Unknown;
        #endregion

        private bool IsConnceted;
        private object _csSessionStatus = new object();
        private EventWaitHandle _syncSessionEvent;
        private EventWaitHandle _syncResponseEvent;

        public List<PriceUpdate> priceUpdates = new List<PriceUpdate>();

        #endregion

        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public string HelpersLink => "http://www.fxcorporate.com/Hosts.jsp";
        public string ErrorInfo { get; set; }

        #endregion
        
        #region Initialization
        public FxcmDataFeed()
        {
            _syncSessionEvent = new EventWaitHandle(false,EventResetMode.AutoReset);
            _syncResponseEvent = new EventWaitHandle(false,EventResetMode.AutoReset);
        }
        #endregion
        
        #region Connect/Disconnect

        public bool ConnectToDataFeed(string username, string password, Connection connection)
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
            }
            catch (Exception ex)
            {
                Stop();
                MessageBox.Show(ex.Message);
                IsConnceted = false;
            }

            return IsConnceted;
        }

        private void Session_TablesUpdates(object sender, TablesUpdatesEventArgs e)
        {
            var responseFactory = _session.getResponseReaderFactory();
            var responsGTablesUpdatesReader = responseFactory.createTablesUpdatesReader(e.Response);
            for (int i = 0; i < responsGTablesUpdatesReader.Count; i++)
            {
                if (responsGTablesUpdatesReader.getUpdateTable(i) == O2GTableType.Offers)
                {
                    if (responsGTablesUpdatesReader.getUpdateType(i) == O2GTableUpdateType.Update)
                    {
                        O2GOfferRow offer = responsGTablesUpdatesReader.getOfferRow(i);
                        var _offerID = offer.OfferID;
                        var _currentSymbol = offer.Instrument;

                        PriceUpdate pu = new PriceUpdate
                        {
                            Symbol = offer.Instrument,
                            TradeDateTime = offer.Time,
                            Price = (offer.Bid + offer.Ask) / 2,
                            Volume = offer.Volume,
                            Bid = offer.Bid,
                            Ask = offer.Ask
                        };
                        priceUpdates.Add(pu);
                    }
                }
            }
        }

        private void Session_RequestFailed(object sender, RequestFailedEventArgs e)
        {
            lock (_csSessionStatus)
            {
                _sessionStatusCode = O2GSessionStatusCode.Disconnected;
            }
            _syncSessionEvent.Set();
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

        private void Session_RequestCompleted(object sender, RequestCompletedEventArgs e)
        {
            var factory = _session.getResponseReaderFactory();
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
                    var accountsReader = factory.createAccountsTableReader(e.Response);
                    //_accountRow = GetAccountRow(accountsReader);
                    _syncResponseEvent.Set();
                    break;
                case O2GResponseType.MarketDataSnapshot:
                    //_marketDataSnapshotResponse = _responceReaderFactory.createMarketDataSnapshotReader(e.Response);
                    //_historyLoadAutoResetEvent.Set();
                    break;
                case O2GResponseType.TablesUpdates:
                    _session.TablesUpdates += Session_TablesUpdates;
                    break;
                case O2GResponseType.ResponseUnknown:
                    Stop();
                    break;
            }
        }

        private bool Login(string username, string password, string connection)
        {
            _session.useTableManager(O2GTableManagerMode.Yes, null);
            _session.login(username, password, HelpersLink, connection);

            if (_sessionStatusCode != O2GSessionStatusCode.Connected)
            {
                _syncSessionEvent.WaitOne(5000);
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
            }
        }

        #endregion

        #region Events

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
                ErrorInfo = e.Error;
            }
            _syncSessionEvent.Set();
        }

        #endregion
    }

    public class PriceUpdate
    {
        public DateTime TradeDateTime { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public long Volume { get; set; }
        public double Bid { get; set; }
        public long BidSize { get; set; }
        public double Ask { get; set; }
        public long AskSize { get; set; }
        public bool SystemWatch { get; set; }
    }
}
