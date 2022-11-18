
namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    partial class frmResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResult));
            this.dtGVwResult = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTitile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPath = new System.Windows.Forms.DataGridViewLinkColumn();
            this.chkOptions = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCrawler = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCrawlerAll = new System.Windows.Forms.Button();
            this.btnCrawler = new System.Windows.Forms.Button();
            this.lblKeySearch = new System.Windows.Forms.Label();
            this.rtxtResult = new System.Windows.Forms.RichTextBox();
            this.btnViewData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVwResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGVwResult
            // 
            this.dtGVwResult.AllowUserToAddRows = false;
            this.dtGVwResult.AllowUserToDeleteRows = false;
            this.dtGVwResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVwResult.BackgroundColor = System.Drawing.Color.White;
            this.dtGVwResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVwResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVwResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtID,
            this.txtTitile,
            this.txtPath,
            this.chkOptions,
            this.txtCrawler});
            this.dtGVwResult.Location = new System.Drawing.Point(29, 87);
            this.dtGVwResult.Name = "dtGVwResult";
            this.dtGVwResult.Size = new System.Drawing.Size(1223, 409);
            this.dtGVwResult.TabIndex = 0;
            this.dtGVwResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVwResult_CellClick);
            // 
            // txtID
            // 
            this.txtID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtID.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtID.FillWeight = 10F;
            this.txtID.HeaderText = "STT";
            this.txtID.Name = "txtID";
            this.txtID.Width = 53;
            // 
            // txtTitile
            // 
            this.txtTitile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtTitile.HeaderText = "Tiêu đề";
            this.txtTitile.Name = "txtTitile";
            // 
            // txtPath
            // 
            this.txtPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtPath.HeaderText = "Đường dẫn";
            this.txtPath.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.txtPath.LinkColor = System.Drawing.Color.Black;
            this.txtPath.Name = "txtPath";
            this.txtPath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtPath.Text = "";
            this.txtPath.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // chkOptions
            // 
            this.chkOptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.chkOptions.HeaderText = "Lựa chọn";
            this.chkOptions.Name = "chkOptions";
            this.chkOptions.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkOptions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkOptions.Width = 77;
            // 
            // txtCrawler
            // 
            this.txtCrawler.HeaderText = "";
            this.txtCrawler.Name = "txtCrawler";
            this.txtCrawler.ReadOnly = true;
            this.txtCrawler.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtCrawler.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtCrawler.Text = "Bóc tách";
            this.txtCrawler.UseColumnTextForButtonValue = true;
            // 
            // btnCrawlerAll
            // 
            this.btnCrawlerAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCrawlerAll.Location = new System.Drawing.Point(1016, 30);
            this.btnCrawlerAll.Name = "btnCrawlerAll";
            this.btnCrawlerAll.Size = new System.Drawing.Size(78, 33);
            this.btnCrawlerAll.TabIndex = 1;
            this.btnCrawlerAll.Text = "Bóc tất cả";
            this.btnCrawlerAll.UseVisualStyleBackColor = true;
            this.btnCrawlerAll.Click += new System.EventHandler(this.btnCrawlerAll_Click);
            // 
            // btnCrawler
            // 
            this.btnCrawler.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCrawler.Location = new System.Drawing.Point(872, 30);
            this.btnCrawler.Name = "btnCrawler";
            this.btnCrawler.Size = new System.Drawing.Size(110, 33);
            this.btnCrawler.TabIndex = 2;
            this.btnCrawler.Text = "Bóc theo lựa chọn";
            this.btnCrawler.UseVisualStyleBackColor = true;
            this.btnCrawler.Click += new System.EventHandler(this.btnCrawler_Click);
            // 
            // lblKeySearch
            // 
            this.lblKeySearch.AutoSize = true;
            this.lblKeySearch.Location = new System.Drawing.Point(29, 13);
            this.lblKeySearch.Name = "lblKeySearch";
            this.lblKeySearch.Size = new System.Drawing.Size(0, 13);
            this.lblKeySearch.TabIndex = 3;
            // 
            // rtxtResult
            // 
            this.rtxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtResult.Location = new System.Drawing.Point(29, 537);
            this.rtxtResult.Name = "rtxtResult";
            this.rtxtResult.Size = new System.Drawing.Size(1223, 436);
            this.rtxtResult.TabIndex = 4;
            this.rtxtResult.Text = "";
            // 
            // btnViewData
            // 
            this.btnViewData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnViewData.Location = new System.Drawing.Point(1129, 30);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(100, 33);
            this.btnViewData.TabIndex = 6;
            this.btnViewData.Text = "Lịch sử bóc tách";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "DANH SÁCH KẾT QUẢ TÌM KIẾM";
            // 
            // frmResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewData);
            this.Controls.Add(this.rtxtResult);
            this.Controls.Add(this.lblKeySearch);
            this.Controls.Add(this.btnCrawler);
            this.Controls.Add(this.btnCrawlerAll);
            this.Controls.Add(this.dtGVwResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách kết quả tìm kiếm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmResult_FormClosed);
            this.Load += new System.EventHandler(this.frmResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVwResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGVwResult;
        private System.Windows.Forms.Button btnCrawlerAll;
        private System.Windows.Forms.Button btnCrawler;
        private System.Windows.Forms.Label lblKeySearch;
        private System.Windows.Forms.RichTextBox rtxtResult;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTitile;
        private System.Windows.Forms.DataGridViewLinkColumn txtPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkOptions;
        private System.Windows.Forms.DataGridViewButtonColumn txtCrawler;
        private System.Windows.Forms.Label label1;
    }
}