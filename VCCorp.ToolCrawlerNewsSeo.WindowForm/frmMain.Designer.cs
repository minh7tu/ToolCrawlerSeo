
namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnCrawller = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrawller
            // 
            this.btnCrawller.Location = new System.Drawing.Point(12, 12);
            this.btnCrawller.Name = "btnCrawller";
            this.btnCrawller.Size = new System.Drawing.Size(131, 37);
            this.btnCrawller.TabIndex = 0;
            this.btnCrawller.Text = "Bóc tách";
            this.btnCrawller.UseVisualStyleBackColor = true;
            this.btnCrawller.Click += new System.EventHandler(this.btnCrawller_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCrawller);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCCorp-Tool Crawler News SEO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrawller;
    }
}

