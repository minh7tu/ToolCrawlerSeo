
namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    partial class frmCrawler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrawler));
            this.btnSEO = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCrawler = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtHistoryCrawler = new System.Windows.Forms.Button();
            this.btnAllData = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSEO
            // 
            this.btnSEO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSEO.Location = new System.Drawing.Point(945, 22);
            this.btnSEO.Name = "btnSEO";
            this.btnSEO.Size = new System.Drawing.Size(90, 25);
            this.btnSEO.TabIndex = 6;
            this.btnSEO.Text = "Tải bài viết";
            this.btnSEO.UseVisualStyleBackColor = true;
            this.btnSEO.Click += new System.EventHandler(this.btnSEO_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.Location = new System.Drawing.Point(12, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 25);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnForward.Location = new System.Drawing.Point(108, 22);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(90, 25);
            this.btnForward.TabIndex = 1;
            this.btnForward.Text = "Forward";
            this.btnForward.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(628, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Load";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCrawler
            // 
            this.btnCrawler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrawler.Location = new System.Drawing.Point(733, 22);
            this.btnCrawler.Name = "btnCrawler";
            this.btnCrawler.Size = new System.Drawing.Size(90, 25);
            this.btnCrawler.TabIndex = 4;
            this.btnCrawler.Text = "Lấy link";
            this.btnCrawler.UseVisualStyleBackColor = true;
            this.btnCrawler.Click += new System.EventHandler(this.btnCrawler_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(209, 25);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(400, 20);
            this.txtUrl.TabIndex = 2;
            // 
            // txtHistoryCrawler
            // 
            this.txtHistoryCrawler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistoryCrawler.Location = new System.Drawing.Point(1161, 22);
            this.txtHistoryCrawler.Name = "txtHistoryCrawler";
            this.txtHistoryCrawler.Size = new System.Drawing.Size(100, 25);
            this.txtHistoryCrawler.TabIndex = 7;
            this.txtHistoryCrawler.Text = "Lịch sử bóc tách";
            this.txtHistoryCrawler.UseVisualStyleBackColor = true;
            this.txtHistoryCrawler.Click += new System.EventHandler(this.txtHistoryCrawler_Click);
            // 
            // btnAllData
            // 
            this.btnAllData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllData.Enabled = false;
            this.btnAllData.Location = new System.Drawing.Point(1053, 22);
            this.btnAllData.Name = "btnAllData";
            this.btnAllData.Size = new System.Drawing.Size(100, 25);
            this.btnAllData.TabIndex = 6;
            this.btnAllData.Text = "Tải bộ tài nguyên";
            this.btnAllData.UseVisualStyleBackColor = true;
            this.btnAllData.Click += new System.EventHandler(this.btnAllData_Click);
            // 
            // btnLink
            // 
            this.btnLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLink.ForeColor = System.Drawing.Color.Red;
            this.btnLink.Location = new System.Drawing.Point(840, 22);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(90, 25);
            this.btnLink.TabIndex = 5;
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Visible = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 73);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(1264, 912);
            this.pnlBrowser.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtHistoryCrawler);
            this.panel1.Controls.Add(this.btnSEO);
            this.panel1.Controls.Add(this.btnAllData);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnForward);
            this.panel1.Controls.Add(this.btnLink);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnCrawler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 73);
            this.panel1.TabIndex = 2;
            // 
            // frmCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCrawler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCCorpBrowser-Tool Crawler News SEO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCrawler_FormClosed);
            this.Load += new System.EventHandler(this.frmCrawler_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCrawler;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.Button btnAllData;
        private System.Windows.Forms.Button txtHistoryCrawler;
        private System.Windows.Forms.Button btnSEO;
        private System.Windows.Forms.Panel panel1;
    }
}