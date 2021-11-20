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
    internal class DALUser : IDisposable
    {
        SqlConnection conn = null;

        public DALUser() //constructor
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
        public User GetItem(string sql, User user)
        {
            User result = default;
            try
            {
                result = conn.QueryFirstOrDefault<User>(sql, user);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public User GetItem(string IDUser)
        {
            User result = default;
            try
            {
                result = conn.QueryFirstOrDefault<User>("Select IDUser, Nama From T_User Where IDUser = @IDUser", new { IDUser });
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public User GetItemNamaTopik(string IDUser)
        {
            User result = default;
            try
            {
                result = conn.QueryFirstOrDefault<User>("Select IDUser, Nama, Topik From T_User Where IDUser = @IDUser", new { IDUser });
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool TryLogIn(string userId, string pwd)
        {
            bool result = false;
            try
            {
                User item = GetItem("Select IDUser, PassUser From T_User Where IDUser = @IDUser", new User { IDUser = userId });
                result = item?.PassUser.Equals(pwd) ?? false;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool CreateNew(User user)
        {
            bool result = false;
            try
            {
                if (conn.Execute("Insert Into T_User Values (@Nama, @NoHP, @Email, @TglDaftar, @Topik, @IDUser, @Pass)", user) > 0)
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
