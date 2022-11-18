using System;
using System.Collections.Generic;
using System.Text;

namespace VCCorp.ToolCrawlerNewsSeo.Core.DTO
{
    /// <summary>
    /// Entity pattern_field
    /// </summary>
    public class PatternFieldDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagField { get; set; }
        public string Note { get; set; }
        public int Ords { get; set; }
        public int GroupId { get; set; }
    }
}
