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
                result = conn.QueryFirstOrDefault<User>("Select IDUser, Nama, Administrator, ExamStatus From T_User Where IDUser = @IDUser", new { IDUser });
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
                result = conn.QueryFirstOrDefault<User>("Select IDUser, Nama, Email, Topik From T_User Where IDUser = @IDUser", new { IDUser });
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<User> GetAllUser()
        {
            IEnumerable<User> result = default;
            try
            {
                result = conn.Query<User>("Select Nama, NoHP, Email, TglDaftar, Topik, ExamStatus From T_User where Administrator = 0 order by Nama");
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<UserExamResult> GetAllExamResults()
        {
            IEnumerable<UserExamResult> result = default;
            try
            {
                result = conn.Query<UserExamResult>("Select TU.Nama, TU.Topik, TL.Score as Nilai, TL.TanggalUjian as TglUjian " +
                    "From T_LogUjian TL left join T_User TU on TL.IDUser = TU.IDUser order by TglUjian");
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<UserExamResult> GetExamResults(string param, string value)
        {
            IEnumerable<UserExamResult> result = default;
            try
            {
                if (param == "Month")
                {
                    var mo = value.Split('-')[1];
                    var yr = value.Split('-')[0];
                    result = conn.Query<UserExamResult>("Select TU.Nama, TU.Topik, TL.Score as Nilai, TL.TanggalUjian as TglUjian " +
                    "From T_LogUjian TL left join T_User TU on TL.IDUser = TU.IDUser " +
                    "where DATEPART(m, TanggalUjian) = @mo AND DATEPART(yy, TanggalUjian) = @yr " +
                    "order by TglUjian", 
                    new { mo = mo, yr = yr });
                } 
                else if (param == "Year")
                {
                    result = conn.Query<UserExamResult>("Select TU.Nama, TU.Topik, TL.Score as Nilai, TL.TanggalUjian as TglUjian " +
                    "From T_LogUjian TL left join T_User TU on TL.IDUser = TU.IDUser " +
                    "where DATEPART(yy, TanggalUjian) = @value " +
                    "order by TglUjian", 
                    new { value = value });
                } 
                else if (param == "Date")
                {
                    result = conn.Query<UserExamResult>("Select TU.Nama, TU.Topik, TL.Score as Nilai, TL.TanggalUjian as TglUjian " +
                    "From T_LogUjian TL left join T_User TU on TL.IDUser = TU.IDUser " +
                    "where CONVERT(varchar(10), TanggalUjian, 23) = @value", 
                    new { value = value });
                }
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
                if (conn.Execute("Insert Into T_User Values (@Nama, @NoHP, @Email, @TglDaftar, @Topik, @IDUser, @PassUser, 0, 0)", user) > 0)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool UpdateExamStatus(User user)
        {
            bool result = false;
            try
            {
                if (conn.Execute("Update T_User set ExamStatus = 'true' where IDUser = @IDUser", user) > 0)
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
