using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using CBT_Application.Entity;

namespace CBT_Application.DAL
{
    internal class DALTestLog : IDisposable
    {
        SqlConnection conn = null;

        public DALTestLog() //constructor
        {
            try
            {
                conn = new Connection().CreateAndOpen();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CreateNewLog(User user, int score)
        {
            bool result = false;
            string skrg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); //SQL DateTime: YYYY-MM-DD hh:mm:ss
            try
            {
                if (conn.Execute("Insert Into T_LogUjian Values (@IDUser, @Score, @Tgl)", new {IDUser = user.IDUser, Score = score, Tgl = skrg}) > 0)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public void Dispose()
        {
            if (conn != null) conn.Close();
        }
    }
}
