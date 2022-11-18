using System;
using System.Collections.Generic;
using System.Text;

namespace VCCorp.ToolCrawlerNewsSeo.Core.DTO
{
    /// <summary>
    /// Entity pattern_keyvalue
    /// </summary>
    public class PatternKeyValueDTO
    {
        public int Id { get; set; }
        public int SiteId {get;set;}
        public int FieldId { get; set; }
        public string Restrict_Regex_1 { get; set; }
        public string Restrict_Regex_2{ get; set; }
        public string RemoveTagNoUsed_Regex { get; set; }
        public string GetListZone { get; set; }
        public string Rule { get; set; }
        public string Note { get; set; }
        public DateTime PostDate { get; set; }
        public string UserPost { get; set; }

    }
}
