using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.MinimalExample.WinForms.Controls;
using CefSharp.WinForms;
using HtmlAgilityPack;
using VCCorp.ToolCrawlerNewsSeo.Core.Helper;
using VCCorp.CrawlerCore.BUS;
using VCCorp.CrawlerCore.DTO;
using System.Web.Script.Serialization;

namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    public partial class frmCrawler : Form
    {
        public ChromiumWebBrowser browser;
        public static List<string> listLink = new List<string>();//Tất cả link
        public static List<string> listTitle = new List<string>();
        public static List<string> listDatePost = new List<string>();
        public static List<string> listDateCrawler = new List<string>();
        public static int count = 0;
        public static string textKey = null ;
        public static string urlText;

        public frmCrawler()
        {
            InitializeComponent();
            InitBrowser();
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.TitleChanged += OnBrowserTitleChanged;
        }

        private void frmCrawler_Load(object sender, EventArgs e)
        {
            count = 0;
        }

        //Khởi tạo cefsharp
        public void InitBrowser()
        {
            CefSettings cefSettings = new CefSettings();
          
            //Cef.Initialize(cefSettings);
            browser = new ChromiumWebBrowser("https://www.google.com/");
            
            pnlBrowser.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
                    
        }

        public frmCrawler(string url)
        {
            InitializeComponent();
            InitBrowser1(url);
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.TitleChanged += OnBrowserTitleChanged;
        }

        public void InitBrowser1(string url)
        {
            CefSettings cefSettings = new CefSettings();

            //Cef.Initialize(cefSettings);
            browser = new ChromiumWebBrowser(url);

            pnlBrowser.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        //Load dữ liệu trang web
        private void btnSearch_Click(object sender, EventArgs e)
        {          
            LoadUrl(txtUrl.Text);
           
        }

        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }

            
        }

        private void UrlTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            LoadUrl(txtUrl.Text);
        }

        //Thực hiện lấy link
        private async void btnCrawler_Click(object sender, EventArgs e)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

            //Thực thi js lấy html
            JavascriptResponse response = await browser.EvaluateScriptAsync("document.getElementsByTagName('html')[0].innerHTML");
            string html = response.Result.ToString();

            htmlDocument.LoadHtml(html);

            var items = htmlDocument.DocumentNode.SelectNodes("//div[@class='yuRUbf']")?.ToList();
            
            if (items != null)
            {
                foreach (var item in items)
                {
                    var link = item.SelectSingleNode("./a").Attributes["href"].Value ?? "No URL";
                    var title = item.SelectSingleNode("./a/h3").InnerText ?? "No Title";

                    listLink.Add(link);
                    
                    listTitle.Add(title);

                    count += 1;

                }
            }
            btnLink.Text = count.ToString() + " link";

            btnLink.Visible = true;

            if(count == 0)
            {
                MessageBox.Show("Không lấy được link","Kết quả lấy link");
            }
            else
            {
                MessageBox.Show("Đã lấy được: " + count + " link. Bấm vào nút hiển thị số link để thực hiện thao tác", "Kết quả lấy link");
            }

           
        }

        //Chuyển hướng sang form danh sách kết quả link
        private void btnLink_Click(object sender, EventArgs e)
        {           
            frmResult frm = new frmResult();
            frm.Show();
            btnLink.Visible = false;
        }

        //Cập nhập địa chỉ giống khung tìm kiếm
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => txtUrl.Text = args.Address);
            urlText = txtUrl.Text;
        }

        //Thực hiện lấy từ khóa từ người dùng
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            textKey = args.Title;
        }

        //Giải phóng bộ nhớ
        private void frmCrawler_FormClosed(object sender, FormClosedEventArgs e)
        {
            //count = 0;
            //listLink.Clear();
            //listTitle.Clear();
            
        }

        private void btnAllData_Click(object sender, EventArgs e)
        {
            DownloadPattern pattern = new DownloadPattern();
            
            try
            {
                pattern.GetPatternDetail();

                SiteBUS sBus = new SiteBUS();
                
                List<SiteDTO> lis = sBus.GetLisAll();
                
                if(lis != null && lis.Count > 0)
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();

                    string json = jss.Serialize(lis);

                    string pathFile = @"Data\listsite.txt";

                    FileReadWrite file = new FileReadWrite(pathFile);

                    file.WriteLineToFile_Append(json);
                }    

                //pattern.GetListSite();
                MessageBox.Show("Tải tài nguyên thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtHistoryCrawler_Click(object sender, EventArgs e)
        {
            frmViewData frm = new frmViewData();
            frm.Show();
        }

        //Tải bài viết
        private void btnSEO_Click(object sender, EventArgs e)
        {
            frmResult frm = new frmResult();
            frm.CrawlerData1(urlText);
        }



        //private void btnSearch_Click_1(object sender, EventArgs e)
        //{
        //    LoadUrl(txtUrl.Text);
        //}
    }
}
