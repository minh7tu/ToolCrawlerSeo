using System;
using System.Collections.Generic;
using System.Text;

namespace VCCorp.ToolCrawlerNewsSeo.Core.DTO
{
    /// <summary>
    /// Entity site
    /// </summary>
    public class SiteDTO
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string UrlInit { get; set; }
        public string Note { get; set; }
        public int Ords { get; set; }
        public int IsDeleted { get; set; }
        public int IsBrowser { get; set; }
        public int IsAutoGetCategory { get; set; }
        public int IsLaunch { get; set; }
        public int IsSendData { get; set; }
        public DateTime LastCrawled { get; set; }
        public string Ip { get; set; }
        public int IsVCCorp { get; set; }
        public int IsProxy { get; set; }
        public string UrlArticleToTest { get; set; }
        public string UrlSearch { get; set; }
    }
}
