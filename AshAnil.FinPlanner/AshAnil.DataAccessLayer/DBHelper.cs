using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshAnil.DataAccessLayer
{
    public sealed class DBHelper
    {
        public static IDbConnection GetSQLConnection()
        {
            return new SqlConnection();
        }

        public static IDbCommand GetSQLCommand()
        {
            return new SqlCommand();
        }

        public static IDbDataAdapter GetSQLDataAdapter()
        {
            return new SqlDataAdapter();
        }
    }
}
