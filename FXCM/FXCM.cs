using System;
using System.Drawing;
using System.Windows.Forms;
using FXCM.Helpers;

namespace FXCM
{
    public partial class FXCM : Form
    {
        private FxcmDataFeed m_fxcm;
        private Login m_login;

        public FXCM()
        {
            m_fxcm = new FxcmDataFeed();
            m_fxcm.TableUpdateInfoEventArgs += FXCM_TableUpdateInfo;
            InitializeComponent();

            LoginToDataFeed();
        }

        private async void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_login.ShowDialog() == DialogResult.OK)
            {
                if (await m_fxcm.ConnectToDataFeedAsync(m_login.UserName, m_login.Passsword, m_login.ConnectionAccount))
                {
                    lbStatusFXCM.Text = m_fxcm.Status.ToString();
                }
                else
                {
                    MessageBox.Show("None wrong credentials");
                }
            }
        }

        private void dgvAllSymbols_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= m_fxcm.priceUpdates.Count && e.RowIndex < 0)
                return;

            var pu = m_fxcm.priceUpdates[e.RowIndex];

            if (e.ColumnIndex == colTime.Index)
            {
                e.Value = pu.TradeDateTime;
            }
            else if(e.ColumnIndex == colSymbol.Index)
            {
                e.Value = pu.Symbol;
            }
            else if (e.ColumnIndex == colPrice.Index)
            {
                e.Value = pu.Price;
            }
            else if (e.ColumnIndex == colAsk.Index)
            {
                e.Value = pu.Ask;
            }
            else if (e.ColumnIndex == colBid.Index)
            {
                e.Value = pu.Bid;
            }
            else
            {
                System.Diagnostics.Debug.Assert(false);
            }
        }

        private void FXCM_TableUpdateInfo(object sender, Helpers.Helpers.TableUpdateInfoEventArgs e)
        {
            if(dgvAllSymbols.InvokeRequired)
            {
                dgvAllSymbols.BeginInvoke(new Action(()=>
                {
                    if (!dgvAllSymbols.IsDisposed)
                    {
                        RefreshDataGridViewAllSymbols();
                    }
                }));
            }
            else
            {
                RefreshDataGridViewAllSymbols();
            }
        }

        private void RefreshDataGridViewAllSymbols()
        {
            if (dgvAllSymbols.RowCount != m_fxcm.priceUpdates.Count)
                dgvAllSymbols.RowCount = m_fxcm.priceUpdates.Count;

            dgvAllSymbols.Refresh();
        }

        private async void LoginToDataFeed()
        {
            m_login = new Login();
            if (await m_fxcm.ConnectToDataFeedAsync(m_login.UserName, m_login.Passsword, m_login.ConnectionAccount))
            {
                lbStatusFXCM.Text = m_fxcm.Status.ToString();
                lbStatusFXCM.ForeColor = Color.Green;
            }
            else
            {
                lbStatusFXCM.Text = m_fxcm.Status.ToString();
                lbStatusFXCM.ForeColor = Color.Red;
                MessageBox.Show("None wrong credentials");
            }
        }

        private void dgvAllSymbols_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var pu = m_fxcm.priceUpdates[e.RowIndex];

            if (e.ColumnIndex == colPrice.Index && pu.PrevPrice > 0 )
            {
                var color = pu.PrevPrice > pu.Price ? Color.Red : pu.PrevPrice == pu.Price ? Color.FromArgb(0, 0, 0, 0) : Color.Green;
                if (color != e.CellStyle.ForeColor)
                {
                    e.CellStyle.ForeColor = color;
                }
                
            }
        }
    }
}
