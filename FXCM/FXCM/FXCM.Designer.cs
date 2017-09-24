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
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpenPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHighPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLowPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbAllSymbols = new System.Windows.Forms.TabPage();
            this.tbCurrentSymbol = new System.Windows.Forms.TabPage();
            this.lbStatusFXCM = new System.Windows.Forms.Label();
            this.lbDBStatus = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSymbol = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSymbols)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbAllSymbols.SuspendLayout();
            this.tbCurrentSymbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbol)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllSymbols
            // 
            this.dgvAllSymbols.AllowUserToAddRows = false;
            this.dgvAllSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSymbol,
            this.colOpenPrice,
            this.colHighPrice,
            this.colLowPrice,
            this.colClosePrice});
            this.dgvAllSymbols.Location = new System.Drawing.Point(-4, 3);
            this.dgvAllSymbols.Name = "dgvAllSymbols";
            this.dgvAllSymbols.RowHeadersVisible = false;
            this.dgvAllSymbols.Size = new System.Drawing.Size(846, 382);
            this.dgvAllSymbols.TabIndex = 0;
            // 
            // colSymbol
            // 
            this.colSymbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            // 
            // colOpenPrice
            // 
            this.colOpenPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOpenPrice.HeaderText = "Open Price";
            this.colOpenPrice.Name = "colOpenPrice";
            // 
            // colHighPrice
            // 
            this.colHighPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHighPrice.HeaderText = "High Price";
            this.colHighPrice.Name = "colHighPrice";
            // 
            // colLowPrice
            // 
            this.colLowPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLowPrice.HeaderText = "Low Price";
            this.colLowPrice.Name = "colLowPrice";
            // 
            // colClosePrice
            // 
            this.colClosePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClosePrice.HeaderText = "Close Price";
            this.colClosePrice.Name = "colClosePrice";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbAllSymbols);
            this.tabControl1.Controls.Add(this.tbCurrentSymbol);
            this.tabControl1.Location = new System.Drawing.Point(-4, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 411);
            this.tabControl1.TabIndex = 1;
            // 
            // tbAllSymbols
            // 
            this.tbAllSymbols.Controls.Add(this.dgvAllSymbols);
            this.tbAllSymbols.Location = new System.Drawing.Point(4, 22);
            this.tbAllSymbols.Name = "tbAllSymbols";
            this.tbAllSymbols.Padding = new System.Windows.Forms.Padding(3);
            this.tbAllSymbols.Size = new System.Drawing.Size(842, 385);
            this.tbAllSymbols.TabIndex = 0;
            this.tbAllSymbols.Text = "All Symbols";
            this.tbAllSymbols.UseVisualStyleBackColor = true;
            // 
            // tbCurrentSymbol
            // 
            this.tbCurrentSymbol.Controls.Add(this.dgvSymbol);
            this.tbCurrentSymbol.Controls.Add(this.label1);
            this.tbCurrentSymbol.Controls.Add(this.comboBox1);
            this.tbCurrentSymbol.Location = new System.Drawing.Point(4, 22);
            this.tbCurrentSymbol.Name = "tbCurrentSymbol";
            this.tbCurrentSymbol.Padding = new System.Windows.Forms.Padding(3);
            this.tbCurrentSymbol.Size = new System.Drawing.Size(842, 385);
            this.tbCurrentSymbol.TabIndex = 1;
            this.tbCurrentSymbol.Text = "Current Symbol";
            this.tbCurrentSymbol.UseVisualStyleBackColor = true;
            // 
            // lbStatusFXCM
            // 
            this.lbStatusFXCM.AutoSize = true;
            this.lbStatusFXCM.Location = new System.Drawing.Point(2, 440);
            this.lbStatusFXCM.Name = "lbStatusFXCM";
            this.lbStatusFXCM.Size = new System.Drawing.Size(75, 13);
            this.lbStatusFXCM.TabIndex = 2;
            this.lbStatusFXCM.Text = "Status FXCM :";
            // 
            // lbDBStatus
            // 
            this.lbDBStatus.AutoSize = true;
            this.lbDBStatus.Location = new System.Drawing.Point(684, 437);
            this.lbDBStatus.Name = "lbDBStatus";
            this.lbDBStatus.Size = new System.Drawing.Size(58, 13);
            this.lbDBStatus.TabIndex = 3;
            this.lbDBStatus.Text = "Status DB:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(61, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Symbol";
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
            this.dgvSymbol.Location = new System.Drawing.Point(0, 33);
            this.dgvSymbol.Name = "dgvSymbol";
            this.dgvSymbol.RowHeadersVisible = false;
            this.dgvSymbol.Size = new System.Drawing.Size(842, 352);
            this.dgvSymbol.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
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
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // colDateTime
            // 
            this.colDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateTime.HeaderText = "Date Time";
            this.colDateTime.Name = "colDateTime";
            // 
            // colRealSymbol
            // 
            this.colRealSymbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRealSymbol.HeaderText = "Real Symbol";
            this.colRealSymbol.Name = "colRealSymbol";
            // 
            // colRealAsk
            // 
            this.colRealAsk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRealAsk.HeaderText = "Real Ask";
            this.colRealAsk.Name = "colRealAsk";
            // 
            // colRealBid
            // 
            this.colRealBid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRealBid.HeaderText = "Real Bid";
            this.colRealBid.Name = "colRealBid";
            // 
            // FXCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 462);
            this.Controls.Add(this.lbDBStatus);
            this.Controls.Add(this.lbStatusFXCM);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FXCM";
            this.Text = "FXCM_APP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSymbols)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbAllSymbols.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpenPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHighPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLowPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosePrice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbAllSymbols;
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
    }
}

