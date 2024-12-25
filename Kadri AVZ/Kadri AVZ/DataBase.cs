using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadri_AVZ
{
    internal class DataBase
    {
        SqlConnection connect = new SqlConnection(@"Data Source=510-013;Initial Catalog=KadriAVZ;Integrated Security=True;");

        public void openConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        public void closeConnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }

        public SqlConnection getConnect()
        {
            return connect;
        }

    }
}
