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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSymbols)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.dgvAllSymbols.Location = new System.Drawing.Point(0, 0);
            this.dgvAllSymbols.Name = "dgvAllSymbols";
            this.dgvAllSymbols.RowHeadersVisible = false;
            this.dgvAllSymbols.Size = new System.Drawing.Size(835, 413);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(843, 439);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvAllSymbols);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(835, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FXCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 462);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FXCM";
            this.Text = "FXCM_APP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSymbols)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllSymbols;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpenPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHighPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLowPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosePrice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

