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

        public Soal GetItem(int nomorSoal, string topik)
        {
            Soal result = default;
            try
            {
                if (topik.Trim().Equals("C++"))
                {
                    result = conn.QueryFirstOrDefault<Soal>("Select noSoal, kalimatSoal, pilihanA, pilihanB, pilihanC, pilihanD, jawabanSoal From T_BankSoalCPP Where noSoal = @nomorSoal", new { nomorSoal });
                } else if (topik.Trim().Equals("Java"))
                {
                    result = conn.QueryFirstOrDefault<Soal>("Select noSoal, kalimatSoal, pilihanA, pilihanB, pilihanC, pilihanD, jawabanSoal From T_BankSoalJava Where noSoal = @nomorSoal", new { nomorSoal });
                } else if (topik.Trim().Equals("IPA"))
                {
                    result = conn.QueryFirstOrDefault<Soal>("Select noSoal, kalimatSoal, pilihanA, pilihanB, pilihanC, pilihanD, jawabanSoal From T_BankSoalIlmu Where noSoal = @nomorSoal", new { nomorSoal });
                }
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
