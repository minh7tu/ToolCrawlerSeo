using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCCorp.ToolCrawlerNewsSeo.Core.DTO
{
    public class ResutlCrawlerDTO
    {     
        public string Title { get; set; }
        public string KeyWork { get; set; }
        public string Description { get; set; }
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string H3 { get; set; }
        public string CateName { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Context { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string DateCrawler { get; set; }
        public string DatePost { get; set; }
        public string Status { get; set; }
        public string PathFile { get; set; }
    }
}
