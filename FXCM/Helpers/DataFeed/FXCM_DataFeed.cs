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
        private O2GSessionStatusCode _sessionStatusCode = O2GSessionStatusCode.Unknown;
        #endregion

        private bool IsConnceted;
        private object _csSessionStatus = new object();
        private EventWaitHandle _syncSessionEvent;
        private EventWaitHandle _syncResponseEvent;

        public List<PriceUpdate> priceUpdates;

        public IEnumerable<string> symbolsInfo;

        public event EventHandler<TableUpdateInfoEventArgs> TableUpdateInfoEventArgs;

        #endregion

        #region Initialization
        public FxcmDataFeed()
        {
            _syncSessionEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            _syncResponseEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            priceUpdates = new List<PriceUpdate>();
            symbolsInfo = new List<string>();
        }
        #endregion

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

        private void Session_TablesUpdates(object sender, TablesUpdatesEventArgs e)
        {
            var responseFactory = _session.getResponseReaderFactory();
            var responsGTablesUpdatesReader = responseFactory.createTablesUpdatesReader(e.Response);
            for (int i = 0; i < responsGTablesUpdatesReader.Count; i++)
            {
                if (responsGTablesUpdatesReader.getUpdateTable(i) == O2GTableType.Offers && responsGTablesUpdatesReader.getUpdateType(i) == O2GTableUpdateType.Update)
                {
                    var offer = responsGTablesUpdatesReader.getOfferRow(i);

                    if (string.IsNullOrEmpty(offer.Instrument))
                        continue;
                    
                    var pu = new PriceUpdate
                    {
                        Symbol = offer.Instrument,
                        TradeDateTime = offer.Time,
                        Price = (offer.Bid + offer.Ask) / 2,
                        Volume = offer.Volume,
                        Bid = offer.Bid,
                        Ask = offer.Ask,
                        High = offer.High,
                        Low = offer.Low
                    };

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
            }
            _syncSessionEvent.Set();
        }

        private void OnRowCountChange()
        {
            symbolsInfo = priceUpdates.Select(s => s.Symbol);

            TableUpdateInfoEventArgs?.Invoke(this, new TableUpdateInfoEventArgs());
        }

        #endregion
    }
}
