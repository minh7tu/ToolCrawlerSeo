using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCCorp.ToolCrawlerNewsSeo.Core.DTO;
using VCCorp.ToolCrawlerNewsSeo.Core.Helper;

namespace VCCorp.ToolCrawlerNewsSeo.Core.DAO
{
    internal class SiteDAO
    {
        MySqlDbContext context = new MySqlDbContext();
        
        internal Dictionary<string, string> GetDicByDomain(string domain)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            try
            {
                context.OpenMySql();

                string conStr = "select Domain from site where (Domain like '%" + domain + "%')";

                MySqlCommand cmd = new MySqlCommand(conStr, context._connect);

                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    var url = Convert.ToString(read["Domain"]);

                    if (!dic.ContainsKey(url))
                    {
                        dic.Add(url, "");
                    }
                }

                context.Dispose();
            }
            catch 
            {
                // ghi lỗi xuống file
                //TraceLog.Write(_className, ex.Message);
            }

            return dic;
        }

        internal List<SiteDTO> GetAllById(string domain)
        {
            List<SiteDTO> lisSiteId = new List<SiteDTO>();

            try
            {
                context.OpenMySql();

                string conStr = "SELECT Id FROM crawleralldb.site where Domain='" + domain + "'";

                MySqlCommand cmd = new MySqlCommand(conStr, context._connect);

                MySqlDataReader data = cmd.ExecuteReader();

                while(data.Read())
                {
                    SiteDTO obj = new SiteDTO();

                    obj.Id = Convert.ToInt32(data["Id"]);

                    lisSiteId.Add(obj);
                }
            }
            catch
            {

            }

            return lisSiteId;
        }
    }
}
