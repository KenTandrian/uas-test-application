using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBT_Application.Entity;

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
                    DataSource = ConnParameter.Server,
                    InitialCatalog = ConnParameter.Database,
                    IntegratedSecurity = ConnParameter.IntegratedSecurity
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
