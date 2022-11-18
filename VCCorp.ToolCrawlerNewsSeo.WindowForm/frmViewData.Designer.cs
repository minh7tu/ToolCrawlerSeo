
namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    partial class frmViewData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewData));
            this.dGVDetail = new System.Windows.Forms.DataGridView();
            this.rtxtDetail = new System.Windows.Forms.RichTextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDeleteOptions = new System.Windows.Forms.Button();
            this.txtSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDatePost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDateCrawler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnViewDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVDetail
            // 
            this.dGVDetail.AllowUserToAddRows = false;
            this.dGVDetail.AllowUserToDeleteRows = false;
            this.dGVDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVDetail.BackgroundColor = System.Drawing.Color.White;
            this.dGVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSTT,
            this.txtTitle,
            this.txtDesc,
            this.txtDatePost,
            this.txtDateCrawler,
            this.Link,
            this.txtPath,
            this.txtStatus,
            this.chkCheck,
            this.btnViewDetail});
            this.dGVDetail.Location = new System.Drawing.Point(24, 57);
            this.dGVDetail.Name = "dGVDetail";
            this.dGVDetail.Size = new System.Drawing.Size(1212, 461);
            this.dGVDetail.TabIndex = 0;
            this.dGVDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVDetail_CellClick);
            // 
            // rtxtDetail
            // 
            this.rtxtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtDetail.Location = new System.Drawing.Point(24, 524);
            this.rtxtDetail.Name = "rtxtDetail";
            this.rtxtDetail.Size = new System.Drawing.Size(1212, 449);
            this.rtxtDetail.TabIndex = 1;
            this.rtxtDetail.Text = "";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(24, 13);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(150, 22);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "Kết quả bóc tách:";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.Location = new System.Drawing.Point(1161, 13);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 3;
            this.btnDeleteAll.Text = "Xóa tất cả";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDeleteOptions
            // 
            this.btnDeleteOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOptions.Location = new System.Drawing.Point(1034, 13);
            this.btnDeleteOptions.Name = "btnDeleteOptions";
            this.btnDeleteOptions.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteOptions.TabIndex = 4;
            this.btnDeleteOptions.Text = "Xóa theo lựa chọn";
            this.btnDeleteOptions.UseVisualStyleBackColor = true;
            this.btnDeleteOptions.Click += new System.EventHandler(this.btnDeleteOptions_Click);
            // 
            // txtSTT
            // 
            this.txtSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtSTT.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtSTT.HeaderText = "STT";
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Width = 53;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtTitle.HeaderText = "Tiêu đề";
            this.txtTitle.Name = "txtTitle";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtDesc.HeaderText = "Mô tả";
            this.txtDesc.Name = "txtDesc";
            // 
            // txtDatePost
            // 
            this.txtDatePost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.txtDatePost.HeaderText = "Ngày đăng";
            this.txtDatePost.Name = "txtDatePost";
            this.txtDatePost.Width = 85;
            // 
            // txtDateCrawler
            // 
            this.txtDateCrawler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.txtDateCrawler.HeaderText = "Ngày bóc";
            this.txtDateCrawler.Name = "txtDateCrawler";
            this.txtDateCrawler.Width = 78;
            // 
            // Link
            // 
            this.Link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Link.HeaderText = "Link";
            this.Link.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Link.LinkColor = System.Drawing.Color.Black;
            this.Link.Name = "Link";
            this.Link.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Link.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // txtPath
            // 
            this.txtPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtPath.HeaderText = "Path File";
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtStatus.FillWeight = 50F;
            this.txtStatus.HeaderText = "Trạng thái bóc";
            this.txtStatus.Name = "txtStatus";
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.chkCheck.HeaderText = "Lựa chọn";
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkCheck.Width = 77;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnViewDetail.HeaderText = "";
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnViewDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnViewDetail.Text = "Xem chi tiết";
            this.btnViewDetail.UseColumnTextForButtonValue = true;
            // 
            // frmViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.btnDeleteOptions);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.rtxtDetail);
            this.Controls.Add(this.dGVDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử bóc tách";
            this.Load += new System.EventHandler(this.frmViewData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVDetail;
        private System.Windows.Forms.RichTextBox rtxtDetail;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDeleteOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDatePost;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDateCrawler;
        private System.Windows.Forms.DataGridViewLinkColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkCheck;
        private System.Windows.Forms.DataGridViewButtonColumn btnViewDetail;
    }
}