using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace VCCorp.ToolCrawlerNewsSeo.WindowForm
{
    public partial class frmViewData : Form
    {
        List<string> _listFile = new List<string>();
        //List<string> _listPath = new List<string>();
        List<Core.DTO.ResutlCrawlerDTO> _listView = new List<Core.DTO.ResutlCrawlerDTO>();
        //List<Core.DTO.ResutlCrawlerDTO> _listViewGood = new List<Core.DTO.ResutlCrawlerDTO>();
        List<string> _listTmpFile = new List<string>();
        List<string> _listTmpFile1 = new List<string>();
        static int _count = 0;
       

        public frmViewData()
        {
            InitializeComponent();
        }

        public void ShowFile(string path)
        {
            if (File.Exists(path))
            {
                ProcessFile(path, "");//nếu file không tồn tại
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path); // nếu file tồn tại
            }
        }

        public void ProcessDirectory(string pathfile)
        {
            string[] fileList = Directory.GetFiles(pathfile);//lay danh sách file cho vao mảng
            string strFileName = "";
            //duyet mang file trong thư mục
            foreach (string fileName in fileList)
            {
                strFileName = "";
                strFileName = Path.GetFileName(fileName).Trim();
                ProcessFile(fileName, strFileName);

            }

            string[] directorylist = Directory.GetDirectories(pathfile);//lấy danh sách target file cho vào mảng

            //duyệt mảng target
            foreach (string directory in directorylist)
            {
                ProcessDirectory(directory);
            }
        }

        public void ProcessFile(string path, string strfileName)
        {
            
            //_listFile.Add(path.Replace("http://", "").Replace(".", "_").Replace("https://", "").Replace("www.", "").Replace("/", "--").ToString());
            _listFile.Add(strfileName);
        }

        private void frmViewData_Load(object sender, EventArgs e)
        {

            ShowData();          

        }

        private void dGVDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int stt;
            string urllink,pathFile;

            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dGVDetail.Rows[e.RowIndex];
                //Đưa dữ liệu vào stt
                stt = Convert.ToInt32(row.Cells[0].Value.ToString()) - 1;
                pathFile = row.Cells[6].Value.ToString();
                urllink = row.Cells[5].Value.ToString();
               

                if (e.ColumnIndex == 9)
                {
                    rtxtDetail.Clear();
                    for (int i = 0; i < _listView.Count; i++)
                    {
                        if (i == stt)
                        {
                            var title = _listView[i].Title ?? "";
                            var keyWork = _listView[i].KeyWork ?? "";
                            var description = _listView[i].Description ?? "";
                            var h1 = _listView[i].H1 ?? "";
                            var h2 = _listView[i].H2 ?? "";
                            var h3 = _listView[i].H3 ?? "";
                            var cateName = _listView[i].CateName ?? "";
                            var author = _listView[i].Author ?? "";
                            var summary = _listView[i].Summary ?? "";
                            var context = _listView[i].Context ?? "";
                            var datePost = _listView[i].DatePost ?? "";
                            var dateCrawler = _listView[i].DateCrawler ?? "";
                            var img = _listView[i].Image ?? "";      
                            var url = _listView[i].Url ?? "";
                            

                            rtxtDetail.AppendText(" Tiêu đề: " + title + "\n\n");
                            rtxtDetail.AppendText(" \tMeta Keywork: " + keyWork + "\n\n");
                            rtxtDetail.AppendText(" \tMeta Description: " + description + "\n\n");
                            rtxtDetail.AppendText(" \tH1: " + h1 + "\n\n");
                            rtxtDetail.AppendText(" \tH2: " + h2 + "\n\n");
                            rtxtDetail.AppendText(" \tH3: " + h3 + "\n\n");
                            rtxtDetail.AppendText(" \tThể loại: " + cateName + "\n\n");
                            rtxtDetail.AppendText(" \tTác giả: " + author + "\n\n");
                            rtxtDetail.AppendText(" \tTóm tắt: " + summary + "\n\n");
                            rtxtDetail.AppendText(" \tNội dung: " + context + "\n\n");
                            rtxtDetail.AppendText(" \tNgày đăng: " + datePost + "\n\n");
                            rtxtDetail.AppendText(" \tNgày bóc: " + dateCrawler + "\n\n");
                            rtxtDetail.AppendText(" \tẢnh: " + img + "\n\n");
                            rtxtDetail.AppendText(" \tUrl: " + url + "\n\n");

                        }

                    }

                }
                else if (e.ColumnIndex == 8)
                {
                    _listTmpFile1.Add(pathFile);                  
                }
                else if(e.ColumnIndex == 5)
                {
                    frmCrawler frm = new frmCrawler(urllink);
                    frm.Show();
                    lblMsg.Text = "Tổng số kết quả: 0";
                }    
            }

            
        }   

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Bạn chắc chắn muốn xóa tất cả", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(msg == DialogResult.OK)
            {
                dGVDetail.Rows.Clear();

                foreach (var fi in _listTmpFile)
                {
                    VCCorp.CrawlerCore.Common.FileReadWrite file = new CrawlerCore.Common.FileReadWrite(fi);
                    file.Delete();
                }

                MessageBox.Show("Đã xóa thành công tất cả. Hệ thống đang tiến hành cập nhập", "Hiển thị kết quả");
                this.Close();

                frmViewData frm = new frmViewData();
                frm.Show();
            }    
            else
            {

            }    
            
        }

        private void btnDeleteOptions_Click(object sender, EventArgs e)
        {            
            foreach (var fi in _listTmpFile1)
            {
                VCCorp.CrawlerCore.Common.FileReadWrite file = new CrawlerCore.Common.FileReadWrite(fi);
                file.Delete();
            }

            MessageBox.Show("Đã xóa thành công. Hệ thống đang tiến hành cập nhập", "Hiển thị kết quả");
            this.Close();

            frmViewData frm = new frmViewData();
            frm.Show();
        }

        public void ShowData()
        {
            ShowFile(@"Data\Result\");

            _count = 0;
            

            foreach (var item in _listFile)
            {

                string filename = @"Data\Result\" + item;
                CrawlerCore.Common.FileReadWrite fBll = new CrawlerCore.Common.FileReadWrite(filename);

                List<string> lisLine = fBll.GetListLine();

                if (lisLine != null)
                {
                    foreach (string line in lisLine) // lấy từng dòng
                    {
                        // chuyển nó từ json ra object
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        Core.DTO.ResutlCrawlerDTO patt = jss.Deserialize<Core.DTO.ResutlCrawlerDTO>(line);

                        _count += 1;

                        if (patt != null)
                        {

                            int stt = _count;
                            string title = patt.Title;
                            string description = patt.Description;
                            string datePost = patt.DatePost;
                            string dateCrawler = patt.DateCrawler;
                            string url = patt.Url;
                            string status = patt.Status;
                            string path = filename;

                            _listTmpFile.Add(path);//Thêm vào danh sách đường dẫn thư mục

                            dGVDetail.Rows.Add(stt, title, description, datePost, dateCrawler, url, path, status);
                            _listView.Add(patt);

                           
                        }

                    }
                    lblMsg.Text = "Tổng số kết quả: " + _count;
                   
                }
            }
        }
      
    }
}
