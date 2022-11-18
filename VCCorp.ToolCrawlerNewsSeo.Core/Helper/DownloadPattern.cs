using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;
using VCCorp.ToolCrawlerNewsSeo.Core.DTO;
using System.Web;
using VCCorp.CrawlerCore.DTO;
using SiteDTO = VCCorp.CrawlerCore.DTO.SiteDTO;

namespace VCCorp.ToolCrawlerNewsSeo.Core.Helper
{
    public class DownloadPattern
    {
        internal List<Pattern_KeyValueDTO> pattern = new List<Pattern_KeyValueDTO>();
        internal List<string> lisDomain = new List<string>();
        internal List<CrawlerCore.DTO.SiteDTO> listSite = new List<CrawlerCore.DTO.SiteDTO>();
        
        internal static string _folderPattern;
        MySqlDbContext context = new MySqlDbContext();

        public DownloadPattern()
        {
            _folderPattern = @"Data\ParserAll\";           
        }

        //Lấy ra danh sách Domain có trong csdl
        public void GetDomain()
        {         
            string domain = "select Domain from site";

            MySqlCommand cmd = new MySqlCommand(domain, context._connect);

            MySqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                var url = Convert.ToString(data["Domain"]);
                lisDomain.Add(url);
            }
        }

        //Lấy pattern theo idSite
        public void GetPattern(int idSite)
        {
            context.OpenMySql();

            string conStr = "select * from pattern_keyvalue where siteId='"+ idSite + "'";

            MySqlCommand cmd = new MySqlCommand(conStr, context._connect);

            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Pattern_KeyValueDTO obj = new Pattern_KeyValueDTO();

                obj.Id = Convert.ToInt32(read["Id"]);
                obj.SiteId = Convert.ToInt32(read["SiteId"]);
                obj.FieldId = Convert.ToInt32(read["FieldId"]);
                obj.Restrict_Regex_1 = HttpUtility.UrlEncode(Convert.ToString(read["Restrict_Regex_1"]));
                obj.Restrict_Regex_2 = HttpUtility.UrlEncode(Convert.ToString(read["Restrict_Regex_2"]));
                obj.RemoveTagNoUsed_Regex = HttpUtility.UrlEncode(Convert.ToString(read["RemoveTagNoUsed_Regex"]));
                obj.GetListZone = HttpUtility.UrlEncode(Convert.ToString(read["GetListZone"]));
                obj.Rule = HttpUtility.UrlEncode(Convert.ToString(read["Rule"]));
                obj.Note = HttpUtility.UrlEncode(Convert.ToString(read["Note"]));
                obj.PostDate = Convert.ToDateTime(read["PostDate"]);
                obj.UserPost = Convert.ToString(read["UserPost"]);

                pattern.Add(obj );               
            }

            context.Dispose();
        }

        public void GetPatternDetail()
        {
            context.OpenMySql();
            GetDomain();
            context.Dispose();
           
            foreach (var item in lisDomain)
            {
                context.OpenMySql();
                string patternFile = _folderPattern  +item.Replace("http://", "").Replace(".","_").Replace("https://", "").Replace("www.","").Replace("/","")+ "_parser.txt";
                string id = "select Id from site where Domain='" + item + "'";

                MySqlCommand cmd1 = new MySqlCommand(id, context._connect);

                MySqlDataReader data1 = cmd1.ExecuteReader();
                
                int idSite = 0; 
                
                while (data1.Read())
                {
                    idSite = Convert.ToInt32(data1["Id"]);
                }
                context.Dispose();

                GetPattern(idSite);
           
                JavaScriptSerializer jss = new JavaScriptSerializer();
                FileReadWrite file = new FileReadWrite(patternFile);
                foreach (var item1 in pattern)
                {                   
                    file.WriteLineToFile_Append(jss.Serialize(item1));
                }
                
                pattern.Clear();
            }

            
        }

        //DownSite
        public void GetListSite()
        {
            try
            {
                context.OpenMySql();

                string conStr = "SELECT Id , Domain , UrlInit FROM site";

                MySqlCommand cmd = new MySqlCommand(conStr, context._connect);

                MySqlDataReader data = cmd.ExecuteReader();

                SiteDTO obj = new SiteDTO();

                while(data.Read())
                {
                    obj.Id = Convert.ToInt32(data["Id"]);
                    obj.Domain = Convert.ToString(data["Domain"]);
                    obj.UrlInit = Convert.ToString(data["UrlInit"]);

                    listSite.Add(obj);
                }
            }
            catch
            {
          
            }

            string patternFile = @"Data/listsite.txt";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            FileReadWrite file = new FileReadWrite(patternFile);

            foreach (var item1 in listSite)
            {
                file.WriteLineToFile_Append(jss.Serialize(item1));
            }
        }
    }
}
