using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace VCCorp.ToolCrawlerNewsSeo.Core.Helper
{
    public class MySqlDbContext
    {
        internal MySqlConnection _connect;
        internal string _error;
        internal const string _myConnect = "server=10.3.49.43;uid=thuyetnd;pwd=0372392001;database=crawleralldb";
        //internal const string _myConnect = "Server=10.3.49.43;Database=crawleralldb;User ID=thuyet;Password=passthuyet;";

        public MySqlDbContext()
        {

        }
        //Mở kết nối
        public void OpenMySql()
        {
            _connect = new MySqlConnection(_myConnect);

            try
            {
                if (_connect.State == System.Data.ConnectionState.Closed || _connect.State == System.Data.ConnectionState.Broken)
                {
                    _connect.Open();
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
        }

        //Đóng kết nối
        public void Dispose()
        {
            if (_connect.State == System.Data.ConnectionState.Open)
            {
                _connect.Close();
                _connect.Dispose();
            }
            else
            {
                _connect.Dispose();
            }
        }

    }
}
