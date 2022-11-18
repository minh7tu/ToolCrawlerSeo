using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCCorp.ToolCrawlerNewsSeo.Core;
using VCCorp.ToolCrawlerNewsSeo.Core.Helper;

namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Thực hiện bóc tách và lấy dữ liệu
        private void btnCrawller_Click(object sender, EventArgs e)
        {
            
            frmCrawler frm = new frmCrawler();
            frm.Show();
            
        }

       
    }
}
