using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConcertTest.DataAccess
{
    public class DataConnection
    {
        public IDbConnection DapperConnection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ToString());
            }
        }
    }
}