using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class Connection
    {

        public string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi503708_dbbohemi;User Id=dbi503708_dbbohemi;Password=db123;";

        public static SqlConnection connection;
        protected Connection()
        {
            connection = new SqlConnection(ConnectionString);
        }
    }
}
