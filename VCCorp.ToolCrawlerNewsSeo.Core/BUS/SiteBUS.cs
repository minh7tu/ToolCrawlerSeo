using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCCorp.ToolCrawlerNewsSeo.Core.DAO;

namespace VCCorp.ToolCrawlerNewsSeo.Core.BUS
{
    public class SiteBUS
    {
        SiteDAO _dao;

        public SiteBUS()
        {
            _dao = new SiteDAO();
        }
    }
}
