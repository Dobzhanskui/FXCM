namespace FXCM
{
    partial class FXCM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FXCM));
            this.dgvAllSymbols = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbRealTimeSymbols = new System.Windows.Forms.TabPage();
            this.tbCurrentSymbol = new System.Windows.Forms.TabPage();
            this.dgvSymbol = new System.Windows.Forms.DataGridView();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbStatusFXCM = new System.Windows.Forms.Label();
            this.lbDBStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSymbols)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbRealTimeSymbols.SuspendLayout();
            this.tbCurrentSymbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbol)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllSymbols
            // 
            this.dgvAllSymbols.AllowUserToAddRows = false;
            this.dgvAllSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllSymbols.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllSymbols.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAllSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colSymbol,
            this.colPrice,
            this.colAsk,
            this.colBid});
            this.dgvAllSymbols.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllSymbols.Location = new System.Drawing.Point(8, 4);
            this.dgvAllSymbols.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAllSymbols.Name = "dgvAllSymbols";
            this.dgvAllSymbols.ReadOnly = true;
            this.dgvAllSymbols.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAllSymbols.RowHeadersVisible = false;
            this.dgvAllSymbols.RowHeadersWidth = 51;
            this.dgvAllSymbols.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAllSymbols.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllSymbols.Size = new System.Drawing.Size(1016, 469);
            this.dgvAllSymbols.TabIndex = 0;
            this.dgvAllSymbols.VirtualMode = true;
            this.dgvAllSymbols.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvAllSymbols_CellValueNeeded);
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colSymbol
            // 
            this.colSymbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.MinimumWidth = 6;
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colAsk
            // 
            this.colAsk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAsk.HeaderText = "Ask";
            this.colAsk.MinimumWidth = 6;
            this.colAsk.Name = "colAsk";
            this.colAsk.ReadOnly = true;
            // 
            // colBid
            // 
            this.colBid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBid.HeaderText = "Bid";
            this.colBid.MinimumWidth = 6;
            this.colBid.Name = "colBid";
            this.colBid.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbRealTimeSymbols);
            this.tabControl1.Controls.Add(this.tbCurrentSymbol);
            this.tabControl1.Location = new System.Drawing.Point(-5, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1040, 510);
            this.tabControl1.TabIndex = 1;
            // 
            // tbRealTimeSymbols
            // 
            this.tbRealTimeSymbols.Controls.Add(this.dgvAllSymbols);
            this.tbRealTimeSymbols.Location = new System.Drawing.Point(4, 25);
            this.tbRealTimeSymbols.Margin = new System.Windows.Forms.Padding(4);
            this.tbRealTimeSymbols.Name = "tbRealTimeSymbols";
            this.tbRealTimeSymbols.Padding = new System.Windows.Forms.Padding(4);
            this.tbRealTimeSymbols.Size = new System.Drawing.Size(1032, 481);
            this.tbRealTimeSymbols.TabIndex = 0;
            this.tbRealTimeSymbols.Text = "Real Time Symbols";
            this.tbRealTimeSymbols.UseVisualStyleBackColor = true;
            // 
            // tbCurrentSymbol
            // 
            this.tbCurrentSymbol.Controls.Add(this.dgvSymbol);
            this.tbCurrentSymbol.Controls.Add(this.label1);
            this.tbCurrentSymbol.Controls.Add(this.comboBox1);
            this.tbCurrentSymbol.Location = new System.Drawing.Point(4, 25);
            this.tbCurrentSymbol.Margin = new System.Windows.Forms.Padding(4);
            this.tbCurrentSymbol.Name = "tbCurrentSymbol";
            this.tbCurrentSymbol.Padding = new System.Windows.Forms.Padding(4);
            this.tbCurrentSymbol.Size = new System.Drawing.Size(1032, 481);
            this.tbCurrentSymbol.TabIndex = 1;
            this.tbCurrentSymbol.Text = "Current Symbol";
            this.tbCurrentSymbol.UseVisualStyleBackColor = true;
            // 
            // dgvSymbol
            // 
            this.dgvSymbol.AllowUserToAddRows = false;
            this.dgvSymbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTime,
            this.colRealSymbol,
            this.colRealAsk,
            this.colRealBid});
            this.dgvSymbol.Location = new System.Drawing.Point(4, 41);
            this.dgvSymbol.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSymbol.Name = "dgvSymbol";
            this.dgvSymbol.ReadOnly = true;
            this.dgvSymbol.RowHeadersVisible = false;
            this.dgvSymbol.RowHeadersWidth = 51;
            this.dgvSymbol.Size = new System.Drawing.Size(1020, 433);
            this.dgvSymbol.TabIndex = 2;
            this.dgvSymbol.VirtualMode = true;
            // 
            // colDateTime
            // 
            this.colDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateTime.HeaderText = "Date Time";
            this.colDateTime.MinimumWidth = 6;
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            // 
            // colRealSymbol
            // 
            this.colRealSymbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRealSymbol.HeaderText = "Real Symbol";
            this.colRealSymbol.MinimumWidth = 6;
            this.colRealSymbol.Name = "colRealSymbol";
            this.colRealSymbol.ReadOnly = true;
            // 
            // colRealAsk
            // 
            this.colRealAsk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRealAsk.HeaderText = "Real Ask";
            this.colRealAsk.MinimumWidth = 6;
            this.colRealAsk.Name = "colRealAsk";
            this.colRealAsk.ReadOnly = true;
            // 
            // colRealBid
            // 
            this.colRealBid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRealBid.HeaderText = "Real Bid";
            this.colRealBid.MinimumWidth = 6;
            this.colRealBid.Name = "colRealBid";
            this.colRealBid.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Symbol";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(81, 7);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // lbStatusFXCM
            // 
            this.lbStatusFXCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStatusFXCM.AutoSize = true;
            this.lbStatusFXCM.Location = new System.Drawing.Point(6, 542);
            this.lbStatusFXCM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStatusFXCM.Name = "lbStatusFXCM";
            this.lbStatusFXCM.Size = new System.Drawing.Size(97, 17);
            this.lbStatusFXCM.TabIndex = 2;
            this.lbStatusFXCM.Text = "Status FXCM :";
            // 
            // lbDBStatus
            // 
            this.lbDBStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDBStatus.AutoSize = true;
            this.lbDBStatus.Location = new System.Drawing.Point(904, 538);
            this.lbDBStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDBStatus.Name = "lbDBStatus";
            this.lbDBStatus.Size = new System.Drawing.Size(75, 17);
            this.lbDBStatus.TabIndex = 3;
            this.lbDBStatus.Text = "Status DB:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // FXCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(580, 400);
            this.ClientSize = new System.Drawing.Size(1052, 573);
            this.Controls.Add(this.lbDBStatus);
            this.Controls.Add(this.lbStatusFXCM);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1070, 620);
            this.Name = "FXCM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FXCM APP";
            this.Load += new System.EventHandler(this.FXCM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSymbols)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbRealTimeSymbols.ResumeLayout(false);
            this.tbCurrentSymbol.ResumeLayout(false);
            this.tbCurrentSymbol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbol)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllSymbols;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbRealTimeSymbols;
        private System.Windows.Forms.TabPage tbCurrentSymbol;
        private System.Windows.Forms.Label lbStatusFXCM;
        private System.Windows.Forms.Label lbDBStatus;
        private System.Windows.Forms.DataGridView dgvSymbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBid;
    }
}

