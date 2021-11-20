using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBT_Application.DAL
{
    internal class Connection
    {
        SqlConnectionStringBuilder connStringBuilder = default;

        public Connection()
        {
            try
            {
                connStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = @"LAPTOP-JFB3URLN",
                    InitialCatalog = "DB_CBTApp",
                    IntegratedSecurity = true
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlConnection CreateAndOpen()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStringBuilder.ToString());
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return conn;
        }
    }
}
