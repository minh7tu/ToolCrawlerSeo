using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCCorp.ToolCrawlerNewsSeo.Core;
using VCCorp.ToolCrawlerNewsSeo.Core.DTO;
using VCCorp.ToolCrawlerNewsSeo.Core.Helper;

namespace VCCorp.ToolCrawlerNewsSeo.Core.DAO
{
    internal class PatternKeyValueDAO
    {
        MySqlDbContext context = new MySqlDbContext();

        internal List<PatternKeyValueDTO> GetAll(int SiteId)
        {
            List<PatternKeyValueDTO> lis = new List<PatternKeyValueDTO>();

            try
            {
                context.OpenMySql();

                string conStr = "select Id ,SiteId,FieldId,Restrict_Regex_1,Restrict_Regex_2,";
                conStr += "RemoveTagNoUsed_Regex,GetListZone,Rule,Note,PostDate,UserPost from pattern_keyvalue where Id="+ SiteId;

                MySqlCommand cmd = new MySqlCommand(conStr, context._connect);
                cmd.CommandTimeout = int.MaxValue;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    PatternKeyValueDTO obj = new PatternKeyValueDTO();

                    obj.Id = Convert.ToInt32(dataReader["Id"]);
                    obj.SiteId = Convert.ToInt32(dataReader["SiteId"]);
                    obj.FieldId = Convert.ToInt32(dataReader["FieldId"]);
                    obj.Restrict_Regex_1 = Convert.ToString(dataReader["Restrict_Regex_1"]);
                    obj.Restrict_Regex_2 = Convert.ToString(dataReader["Restrict_Regex_2"]);
                    obj.RemoveTagNoUsed_Regex = Convert.ToString(dataReader["RemoveTagNoUsed_Regex"]);
                    obj.GetListZone = Convert.ToString(dataReader["GetListZone"]);
                    obj.Rule = Convert.ToString(dataReader["Rule"]);
                    obj.Note = Convert.ToString(dataReader["Note"]);
                    obj.PostDate = Convert.ToDateTime(dataReader["PostDate"]);
                    obj.UserPost = Convert.ToString(dataReader["UserPost"]);
                    
                    lis.Add(obj);
                }

                context.Dispose();
            }
            catch 
            {
                // ghi lỗi xuống file
                //TraceLog.Write(_className, ex.Message);
            }

            return lis;
        }       

        
    }
}
