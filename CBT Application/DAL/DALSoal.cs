using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using CBT_Application.Entity;

namespace CBT_Application.DAL
{
    internal class DALSoal : IDisposable
    {
        SqlConnection conn = null;

        public DALSoal() //constructor
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

        public Soal GetItem(int nomorSoal)
        {
            Soal result = default;
            try
            {
                result = conn.QueryFirstOrDefault<Soal>("Select noSoal, kalimatSoal, pilihanA, pilihanB, pilihanC, pilihanD, jawabanSoal From T_BankSoalCPP Where noSoal = @nomorSoal", new { nomorSoal });
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
