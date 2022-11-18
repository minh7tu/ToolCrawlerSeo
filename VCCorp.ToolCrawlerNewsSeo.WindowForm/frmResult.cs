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
using CefSharp.WinForms;
using HtmlAgilityPack;
using VCCorp.CrawlerCore.DTO;
using VCCorp.ToolCrawlerNewsSeo.Core.Helper;
using System.Web.Script.Serialization;
using VCCorp.CrawlerCore.Common;
using VCCorp.CrawlerCore.BUS;
using System.Web;
using System.Net;


namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    public partial class frmResult : Form
    {
        public static List<string> listUrlCheck = new List<string>();
        public static int count1 = 0;
        public List<string> listUrlDetail = new List<string>();
        List<SiteDTO> _lisSite;
        public string urlLink;
        public  SiteDTO _siteSelected; //thông tin website, dùng nó để tìm bộ parser
        public  List<Pattern_KeyValueDTO> _lisPattern; // danh sách pattern của website này
        public static int pl = 0;
        List<string> listStatus = new List<string>();
        

        public frmResult()
        {
            InitializeComponent();
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            LoadData();
            //lblKeySearch.Text = "Kết quả tìm kiếm với từ khóa: "+frmCrawler.textKey;
            this.Text = "Kết quả tìm kiếm với từ khóa: " + frmCrawler.textKey;
            GetListSite();
        }

        private void GetListSite()
        {
            string pathFile = @"Data\listsite.txt";
            CrawlerCore.Common.FileReadWrite file = new CrawlerCore.Common.FileReadWrite(pathFile);

            List<string> listLine = file.GetListLine();

            if (listLine != null && listLine.Count > 0)
            {
                if (_lisSite == null)
                {
                    _lisSite = new List<SiteDTO>();

                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                _lisSite = jss.Deserialize<List<SiteDTO>>(listLine[0]);
            }
        }

        private void LoadData()
        {
            for (int i = 0; i < frmCrawler.count; i++)
            {
               
                    dtGVwResult.Rows.Add(i+1, frmCrawler.listTitle[i], frmCrawler.listLink[i]);
                
                
            }
        }

        //Bóc tách 1 số link theo lựa chọn
        private void btnCrawler_Click(object sender, EventArgs e)
        {
            rtxtResult.Clear();
            chkOptions.Visible = false;
            var list = listUrlCheck.Distinct();
            foreach (var item in list)
            {
                CrawlerData(item);
                rtxtResult.AppendText(Environment.NewLine + "------------------------" + Environment.NewLine);
            }
            chkOptions.Visible = true;
            MessageBox.Show("Bóc theo các lựa chọn thành công");
        }

        //Bóc tách tất cả link
        private void btnCrawlerAll_Click(object sender, EventArgs e)
        {
            chkOptions.Visible = false;
            rtxtResult.Clear();
            foreach (var item in frmCrawler.listLink)
            {
                CrawlerData(item);
                rtxtResult.AppendText(Environment.NewLine + "------------------------" + Environment.NewLine);
            }
            chkOptions.Visible = true;
            MessageBox.Show("Bóc tất cả thành công");
            //await Task.Delay(TimeSpan.FromMinutes(5));
        }

        private void dtGVwResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string url;

            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dtGVwResult.Rows[e.RowIndex];
                //Đưa dữ liệu vào url
                url = row.Cells[2].Value.ToString();

                if (e.ColumnIndex == 4)
                {
                    rtxtResult.Clear();
                    //Load dữ liệu lên rickbox
                    CrawlerData(url);
                    listUrlCheck.Clear();
                }
                else if (e.ColumnIndex == 3)
                {
                    //chkOptions.FalseValue = true;

                    listUrlCheck.Add(url);
                    count1 += 1;
                }
                else if(e.ColumnIndex == 2)
                {
                    frmCrawler frm = new frmCrawler(url);
                    frm.Show();
                }    
            }
        }

        //Xóa dữ liệu trên ricktextbox
        private void btnFresh_Click(object sender, EventArgs e)
        {
            dtGVwResult.Rows.Clear();
            rtxtResult.Clear();
            listUrlCheck.Clear();
            count1 = 0;
        }

        //Bóc tách dữ liệu
        public void CrawlerData(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            //WebClient wc = new WebClient();
            //var html = wc.DownloadString(url);

            var htmlDecode = DownloadHtml.GetContentHtml_NoHTMLDecode(url);
            Core.DTO.ResutlCrawlerDTO objResult = new Core.DTO.ResutlCrawlerDTO();
            List<Core.DTO.ResutlCrawlerDTO> listResult = new List<Core.DTO.ResutlCrawlerDTO>();
           
            try
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = htmlWeb.Load(url.ToString());
                            
                var itemTitle = htmlDocument.DocumentNode.SelectSingleNode("//head/title")?.InnerText ?? "";
                var itemKeyworks = htmlDocument.DocumentNode.SelectNodes("//meta[contains(@name,'keywords')]")?.ToList();
                var itemDescriptions = htmlDocument.DocumentNode.SelectNodes("//meta[contains(@name,'description')]")?.ToList();
                var itemH1 = htmlDocument.DocumentNode.SelectNodes("//h1")?.ToList();
                var itemH2 = htmlDocument.DocumentNode.SelectNodes("//h2")?.ToList();
                var itemH3 = htmlDocument.DocumentNode.SelectNodes("//h3")?.ToList();

                //var title = HttpUtility.HtmlDecode(itemTitle.ToString().Trim());
                objResult.Title = HttpUtility.HtmlDecode(itemTitle.ToString().Trim());
                //objResult.Title = VCCorp.CrawlerCore.BUS.(itemTitle.ToString().Trim());
                rtxtResult.AppendText(" Tiêu đề: " + objResult.Title.ToString().Trim() + Environment.NewLine + Environment.NewLine);               

                if (itemKeyworks != null)
                {
                    foreach (var items in itemKeyworks)
                    {
                        objResult.KeyWork = HttpUtility.HtmlDecode(items.Attributes["content"]?.Value)?.ToString()?.Trim() ?? "";
                        
                        if (objResult.KeyWork != null)
                        {                           
                            rtxtResult.AppendText(" \tMeta Keywork: " + objResult.KeyWork.ToString().Trim() + Environment.NewLine + Environment.NewLine);                          
                        }
                        else
                        {
                            objResult.KeyWork = " \tMeta Keywork: Không có từ khóa";
                            rtxtResult.AppendText(objResult.KeyWork.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }
                        
                    }
                }        

                if (itemDescriptions != null)
                {
                    foreach (var items in itemDescriptions)
                    {
                        objResult.Description = HttpUtility.HtmlDecode(items.Attributes["content"]?.Value).ToString().Trim() ?? "";
                        
                        if (objResult.Description != null)
                        {                        
                            rtxtResult.AppendText(" \tMeta Mô tả: " + objResult.Description.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                            
                        }
                        else
                        {
                            objResult.Description = " \tMeta Mô tả: Không có mô tả";
                            rtxtResult.AppendText(objResult.Description.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }
                       
                    }
                }

                if(itemH1 != null)
                {
                    foreach (var items in itemH1)
                    {
                        objResult.H1 = HttpUtility.HtmlDecode(items.InnerText).ToString().Trim() ?? "";
                        
                        if (objResult.H1 != null)
                        {                           
                            rtxtResult.AppendText(" \tThẻ H1: " + objResult.H1.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                            
                        }
                        else
                        {
                            objResult.H1 = " \tThẻ H1: Không có thẻ H1";
                            rtxtResult.AppendText(objResult.H1.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }
                       
                    }
                }   
                
                if(itemH2 != null)
                {
                    foreach (var items in itemH2)
                    {
                        objResult.H2 = HttpUtility.HtmlDecode(items.InnerText).ToString().Trim() ?? "";
                        
                        if (objResult.H2 != null)
                        {                           
                            rtxtResult.AppendText(" \tThẻ H2: " + objResult.H2.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                            
                        }
                        else
                        {
                            objResult.H2 = " \tThẻ H2: Không có thẻ H2";
                            rtxtResult.AppendText(objResult.H2.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }

                        
                    }
                }    

                if(itemH3 != null)
                {
                    foreach (var items in itemH3)
                    {
                        objResult.H3 = HttpUtility.HtmlDecode(items.InnerText).ToString().Trim() ?? "";
                        
                        if (objResult.H3 != null)
                        {                           
                            rtxtResult.AppendText(" \tThẻ H3: " + objResult.H3.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                            
                        }
                        else
                        {
                            objResult.H3 = " \tThẻ H3: Không có thẻ H3";
                            rtxtResult.AppendText(" Thẻ H3: Không có thẻ H3" + Environment.NewLine + Environment.NewLine);
                        }
                        
                    }
                }
              
                objResult.Url = url.ToString();

                //mở file lấy trên trùng với url
                SiteDTO site = new SiteDTO();

                string domain = Utilities.GetSourceFromUrl(url);

                if (!string.IsNullOrEmpty(domain) && _lisSite != null && _lisSite.Count > 0)
                {
                    site = _lisSite.Find(x => x.Domain.Contains(domain));
                }

                _siteSelected = new SiteDTO();
                
                string filename = @"Data\ParserAll\" + domain.Replace(".", "_") + "_parser.txt";
                CrawlerCore.Common.FileReadWrite fBll = new CrawlerCore.Common.FileReadWrite(filename);               

                // code đọc pattern từ file
                List<string> lisLine = fBll.GetListLine();
            
                //Pattern_KeyValueDTO obj = new Pattern_KeyValueDTO();
                _lisPattern = new List<Pattern_KeyValueDTO>();

                string status = null;

                if (lisLine != null)
                {
                    foreach (string line in lisLine) // lấy từng dòng
                    {
                        // chuyển nó từ json ra object
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        Pattern_KeyValueDTO patt = jss.Deserialize<Pattern_KeyValueDTO>(line);

                        if (patt != null)
                        {
                            int id = patt.Id;
                            int siteId = patt.SiteId;
                            int fieldId = patt.FieldId;

                            string restrict_Regex_1 = HttpUtility.UrlDecode(patt.Restrict_Regex_1);
                            string restrict_Regex_2 = HttpUtility.UrlDecode(patt.Restrict_Regex_2);
                            string removeTagNoUsed_Regex = HttpUtility.UrlDecode(patt.RemoveTagNoUsed_Regex);
                            string getListZone = HttpUtility.UrlDecode(patt.GetListZone);
                            string rule = HttpUtility.UrlDecode(patt.Rule);

                            if (id > 0 && siteId > 0 && fieldId > 0)
                            {
                                Pattern_KeyValueDTO objKeyValue = new Pattern_KeyValueDTO();

                                objKeyValue.Id = id;
                                objKeyValue.SiteId = siteId;
                                objKeyValue.FieldId = fieldId;
                                objKeyValue.Restrict_Regex_1 = restrict_Regex_1;
                                objKeyValue.Restrict_Regex_2 = restrict_Regex_2;
                                objKeyValue.RemoveTagNoUsed_Regex = removeTagNoUsed_Regex;
                                objKeyValue.GetListZone = getListZone;
                                objKeyValue.Rule = rule;
                                objKeyValue.PostDate = patt.PostDate;
                                objKeyValue.UserPost = "";
                                objKeyValue.Note = "";
                              
                                _lisPattern.Add(objKeyValue);                              
                            }
                            else
                            {
                                
                            }    

                        }
                        else
                        {
                           
                        }    
                    }
                }
                else
                {
                    
                    
                }    

                ParserArticleBUS arBll = new ParserArticleBUS();
                ArticleDTO objCrawled = arBll.AtPageDetail_GetContent(url, htmlDecode.Source , -1, _lisPattern, _siteSelected);
                

                objResult.CateName = objCrawled?.CateName.ToString().Trim();
                objResult.Author = objCrawled?.Author.ToString().Trim();
                objResult.Summary = objCrawled?.Summary.ToString().Trim();
                objResult.Context = objCrawled?.Content.ToString().Trim();
                objResult.Image = objCrawled?.ImageInArticle.ToString().Trim();
                objResult.DateCrawler = Convert.ToString(DateTime.Now);
                objResult.DatePost = objCrawled?.PostDate.ToString().Trim();


                //if (objResult.CateName == null || objResult.Author == null || objResult.Summary == null || objResult.Context == null || objResult.Image == null || objResult.DatePost == null)
                //{
                //    _countBad += 1;
                //}

                //if (objResult.CateName == null && objResult.Author == null && objResult.Summary == null && objResult.Context == null && objResult.Image == null && objResult.DatePost == null)
                //{
                    
                //}

                if (objResult.CateName != null && objResult.Author != null && objResult.Summary != null && objResult.Context != null && objResult.Image != null && objResult.DatePost != null)
                {
                    status = "Tốt";                                      
                }
                //else if (objResult.CateName != null || objResult.Author != null || objResult.Summary != null || objResult.Context != null || objResult.Image != null || objResult.DatePost != null)
                //{
                //    status = "Bóc chưa tốt";
                //}

                objResult.Status = status;

                //objResult.Url = objCrawled?.Url.ToString().Trim();

                rtxtResult.AppendText(" \tThể loại: " + objResult.CateName + Environment.NewLine + Environment.NewLine);
                rtxtResult.AppendText(" \tTác giả: " + objResult.Author + Environment.NewLine + Environment.NewLine);
                rtxtResult.AppendText(" \tTóm tắt: " + objResult.Summary + Environment.NewLine + Environment.NewLine);
                rtxtResult.AppendText(" \tNội dung: " + objResult.Context + Environment.NewLine + Environment.NewLine);
                rtxtResult.AppendText(" \tHình ảnh: " + objResult.Image + Environment.NewLine+ Environment.NewLine);
                rtxtResult.AppendText(" \tTrạng thái: " + objResult.Status + Environment.NewLine + Environment.NewLine);
                rtxtResult.AppendText(" \tUrl: " + objResult.Url + Environment.NewLine);
                rtxtResult.AppendText(Environment.NewLine + "------------------------" + Environment.NewLine);                          

                listResult.Add(objResult);

                JavaScriptSerializer jss1 = new JavaScriptSerializer();

                foreach (var resutl in listResult)
                {
                    //string pathFile = @"Data\Result\"+url.Replace("http://", "").Replace(".", "_").Replace("https://", "").Replace("www.", "").Replace("/", "--").ToString() + "\\"+ frmCrawler.textKey.ToString().Replace("- Tìm trên Google", "_").Replace(".", "").Replace(",", "").Replace(":", "").Trim() + pl.ToString() + ".txt";
                    string pathFile = @"Data\Result\" + url.Replace("http://", "").Replace(".", "_").Replace("https://", "").Replace("www.", "").Replace("/", "--").ToString() + pl.ToString() + ".txt";
                    CrawlerCore.Common.FileReadWrite fBll1 = new CrawlerCore.Common.FileReadWrite(pathFile);
                    fBll1.WriteLineToFile_Append(jss1.Serialize(resutl));
                    pl += 1;
                }

                //Lưu dữ liệu xuống file .txt
                //DialogResult dialogResult = MessageBox.Show("Đồng ý", "Bạn có muốn lưu trang: " + domain, MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    string pathFile = @"Data\Result\"+domain.Replace(".", "_") + ".txt";
                //    CrawlerCore.Common.FileReadWrite fBll1 = new CrawlerCore.Common.FileReadWrite(pathFile);

                //    foreach(var resutl in listUrlDetail)
                //    {
                //        fBll1.WriteLineToFile_Append(resutl + Environment.NewLine);
                //    }
                //    fBll1.WriteLineToFile_Append("\n----------------------------------\n");

                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    return;
                //}
                //JavaScriptSerializer jss1 = new JavaScriptSerializer();

                //string pathFile = @"Data\Result\" + frmCrawler.textKey.ToString() + ".txt";
                //CrawlerCore.Common.FileReadWrite fBll1 = new CrawlerCore.Common.FileReadWrite(pathFile);
                //foreach (var resutl in listResult)
                //{
                //    string pathFile = @"Data\Result\" + frmCrawler.textKey.ToString().Replace("- Tìm trên Google", "_").Replace(".","").Replace(",","").Replace(":","").Trim()+pl.ToString()+ ".txt";
                //    CrawlerCore.Common.FileReadWrite fBll1 = new CrawlerCore.Common.FileReadWrite(pathFile);
                //    fBll1.WriteLineToFile_Append(jss1.Serialize(resutl));
                //    pl += 1;
                //}
               

            }
            catch
            {
                rtxtResult.Text = " Hiện đang có sự cố trong link trang web này . Vui lòng thử lại sau";
               
            }

        }

        //Bóc dữ liệu 1
        public void CrawlerData1(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDecode = DownloadHtml.GetContentHtml_NoHTMLDecode(url);
            Core.DTO.ResutlCrawlerDTO objResult = new Core.DTO.ResutlCrawlerDTO();
            List<Core.DTO.ResutlCrawlerDTO> listResult = new List<Core.DTO.ResutlCrawlerDTO>();

            try
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = htmlWeb.Load(url.ToString());

                var itemTitle = htmlDocument.DocumentNode.SelectSingleNode("//head/title")?.InnerText ?? "";
                var itemKeyworks = htmlDocument.DocumentNode.SelectNodes("//meta[contains(@name,'keywords')]")?.ToList();
                var itemDescriptions = htmlDocument.DocumentNode.SelectNodes("//meta[contains(@name,'description')]")?.ToList();
                var itemH1 = htmlDocument.DocumentNode.SelectNodes("//h1")?.ToList();
                var itemH2 = htmlDocument.DocumentNode.SelectNodes("//h2")?.ToList();
                var itemH3 = htmlDocument.DocumentNode.SelectNodes("//h3")?.ToList();

                //var title = HttpUtility.HtmlDecode(itemTitle.ToString().Trim());
                objResult.Title = HttpUtility.HtmlDecode(itemTitle.ToString().Trim());
                //objResult.Title = VCCorp.CrawlerCore.BUS.(itemTitle.ToString().Trim());
                rtxtResult.AppendText(" Tiêu đề: " + objResult.Title.ToString().Trim() + Environment.NewLine + Environment.NewLine);                     

                if (itemKeyworks != null)
                {
                    foreach (var items in itemKeyworks)
                    {
                        objResult.KeyWork = HttpUtility.HtmlDecode(items.Attributes["content"]?.Value).ToString().Trim() ?? "Không có từ khóa";

                        if (objResult.KeyWork != null)
                        {
                            rtxtResult.AppendText(" \tMeta Keywork: " + objResult.KeyWork.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }
                        else
                        {
                            objResult.KeyWork = " \tMeta Description: Không có từ khóa";
                            rtxtResult.AppendText(objResult.KeyWork.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }

                    }
                }

                if (itemDescriptions != null)
                {
                    foreach (var items in itemDescriptions)
                    {
                        objResult.Description = HttpUtility.HtmlDecode(items.Attributes["content"]?.Value).ToString().Trim();

                        if (objResult.Description != null)
                        {
                            rtxtResult.AppendText(" \tMeta Mô tả: " + objResult.Description.ToString().Trim() + Environment.NewLine + Environment.NewLine);

                        }
                        else
                        {
                            objResult.Description = " \tMeta Mô tả: Không có mô tả";
                            rtxtResult.AppendText(objResult.Description.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }

                    }
                }

                if (itemH1 != null)
                {
                    foreach (var items in itemH1)
                    {
                        objResult.H1 = HttpUtility.HtmlDecode(items.InnerText).ToString().Trim();

                        if (objResult.H1 != null)
                        {
                            rtxtResult.AppendText(" \tThẻ H1: " + objResult.H1.ToString().Trim() + Environment.NewLine + Environment.NewLine);

                        }
                        else
                        {
                            objResult.H1 = " \tThẻ H1: Không có thẻ H1";
                            rtxtResult.AppendText(objResult.H1.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }

                    }
                }

                if (itemH2 != null)
                {
                    foreach (var items in itemH2)
                    {
                        objResult.H2 = HttpUtility.HtmlDecode(items.InnerText).ToString().Trim();

                        if (objResult.H2 != null)
                        {
                            rtxtResult.AppendText(" \tThẻ H2: " + objResult.H2.ToString().Trim() + Environment.NewLine + Environment.NewLine);

                        }
                        else
                        {
                            objResult.H2 = " \tThẻ H2: Không có thẻ H2";
                            rtxtResult.AppendText(objResult.H2.ToString().Trim() + Environment.NewLine + Environment.NewLine);
                        }


                    }
                }

                if (itemH3 != null)
                {
                    foreach (var items in itemH3)
                    {
                        objResult.H3 = HttpUtility.HtmlDecode(items.InnerText).ToString().Trim();

                        if (objResult.H3 != null)
                        {
                            rtxtResult.AppendText(" \tThẻ H3: " + objResult.H3.ToString().Trim() + Environment.NewLine + Environment.NewLine);

                        }
                        else
                        {
                            objResult.H3 = " \tThẻ H3: Không có thẻ H3";
                            rtxtResult.AppendText(" Thẻ H3: Không có thẻ H3" + Environment.NewLine + Environment.NewLine);
                        }

                    }
                }

                objResult.Url = url.ToString();

                //mở file lấy trên trùng với url
                SiteDTO site = new SiteDTO();

                string domain = Utilities.GetSourceFromUrl(url);

                if (!string.IsNullOrEmpty(domain) && _lisSite != null && _lisSite.Count > 0)
                {
                    site = _lisSite.Find(x => x.Domain.Contains(domain));
                }

                _siteSelected = new SiteDTO();

                string filename = @"Data\ParserAll\" + domain.Replace(".", "_") + "_parser.txt";
                CrawlerCore.Common.FileReadWrite fBll = new CrawlerCore.Common.FileReadWrite(filename);

                // code đọc pattern từ file
                List<string> lisLine = fBll.GetListLine();

                //Pattern_KeyValueDTO obj = new Pattern_KeyValueDTO();
                _lisPattern = new List<Pattern_KeyValueDTO>();

                string status = null;

                if (lisLine != null)
                {
                    foreach (string line in lisLine) // lấy từng dòng
                    {
                        // chuyển nó từ json ra object
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        Pattern_KeyValueDTO patt = jss.Deserialize<Pattern_KeyValueDTO>(line);

                        if (patt != null)
                        {
                            int id = patt.Id;
                            int siteId = patt.SiteId;
                            int fieldId = patt.FieldId;

                            string restrict_Regex_1 = HttpUtility.UrlDecode(patt.Restrict_Regex_1);
                            string restrict_Regex_2 = HttpUtility.UrlDecode(patt.Restrict_Regex_2);
                            string removeTagNoUsed_Regex = HttpUtility.UrlDecode(patt.RemoveTagNoUsed_Regex);
                            string getListZone = HttpUtility.UrlDecode(patt.GetListZone);
                            string rule = HttpUtility.UrlDecode(patt.Rule);

                            if (id > 0 && siteId > 0 && fieldId > 0)
                            {
                                Pattern_KeyValueDTO objKeyValue = new Pattern_KeyValueDTO();

                                objKeyValue.Id = id;
                                objKeyValue.SiteId = siteId;
                                objKeyValue.FieldId = fieldId;
                                objKeyValue.Restrict_Regex_1 = restrict_Regex_1;
                                objKeyValue.Restrict_Regex_2 = restrict_Regex_2;
                                objKeyValue.RemoveTagNoUsed_Regex = removeTagNoUsed_Regex;
                                objKeyValue.GetListZone = getListZone;
                                objKeyValue.Rule = rule;
                                objKeyValue.PostDate = patt.PostDate;
                                objKeyValue.UserPost = "";
                                objKeyValue.Note = "";

                                _lisPattern.Add(objKeyValue);
                            }
                            else
                            {

                            }

                        }
                        else
                        {

                        }
                    }
                }
                else
                {


                }

                ParserArticleBUS arBll = new ParserArticleBUS();
                ArticleDTO objCrawled = arBll.AtPageDetail_GetContent(url, htmlDecode.Source, -1, _lisPattern, _siteSelected);


                objResult.CateName = objCrawled?.CateName.ToString().Trim();
                objResult.Author = objCrawled?.Author.ToString().Trim();
                objResult.Summary = objCrawled?.Summary.ToString().Trim();
                objResult.Context = objCrawled?.Content.ToString().Trim();
                objResult.Image = objCrawled?.ImageInArticle.ToString().Trim();
                objResult.DateCrawler = Convert.ToString(DateTime.Now);
                objResult.DatePost = objCrawled?.PostDate.ToString().Trim();
                

                if (objResult.CateName == null || objResult.Author == null || objResult.Summary == null || objResult.Context == null || objResult.Image == null || objResult.DatePost == null)
                {
                    MessageBox.Show("Chưa có bộ parse cho địa chỉ trên. Vui lòng liên hệ bộ phận Crawler để khắc phục...", "Kết quả bóc bài viết");
                    
                }
               
                if (objResult.CateName != null && objResult.Author != null && objResult.Summary != null && objResult.Context != null && objResult.Image != null && objResult.DatePost != null)
                {
                    status = "Tốt";
                    MessageBox.Show("Lấy dữ liệu bài viết thành công. Bấm vào lịch sử bóc tách để xem", "Kết quả bóc bài viết");
                }              

                objResult.Status = status;



                listResult.Add(objResult);

                JavaScriptSerializer jss1 = new JavaScriptSerializer();

                foreach (var resutl in listResult)
                {
                    //string pathFile = @"Data\Result\" + url.Replace("http://", "").Replace(".", "_").Replace("https://", "").Replace("www.", "").Replace("/", "--").ToString() + "\\" + frmCrawler.textKey.ToString().Replace("- Tìm trên Google", "_").Replace(".", "").Replace(",", "").Replace(":", "").Trim() + pl.ToString() + ".txt";
                    string pathFile = @"Data\Result\" + url.Replace("http://", "").Replace(".", "_").Replace("https://", "").Replace("www.", "").Replace("/", "--").ToString() + "__"+pl.ToString() + ".txt";
                    
                    //listResult.Add(objResult);
                    CrawlerCore.Common.FileReadWrite fBll1 = new CrawlerCore.Common.FileReadWrite(pathFile);
                    fBll1.WriteLineToFile_Append(jss1.Serialize(resutl));
                    pl += 1;
                }
                //listResult.Add(objResult);
                ////Viết 1 vòng lặp lưu file txt -> để delete

                //JavaScriptSerializer jss1 = new JavaScriptSerializer();
                //foreach (var resutl in listResult)
                //{
                //    CrawlerCore.Common.FileReadWrite fBll1 = new CrawlerCore.Common.FileReadWrite(resutl.PathFile);
                //    fBll1.WriteLineToFile_Append(jss1.Serialize(resutl));
                //}

            }
            catch
            {               
                MessageBox.Show("Chưa có bộ parse cho địa chỉ trên. Vui lòng liên hệ bộ phận Crawler để khắc phục...","Kết quả bóc bài viết");
            }

        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            frmViewData frm = new frmViewData();
            frm.Show();
        }

        private void frmResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCrawler.count = 0;
            frmCrawler.listLink.Clear();
            frmCrawler.listTitle.Clear();
            pl = 0;
        }

        
    }
}

