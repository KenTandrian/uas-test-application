using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBT_Application.Entity
{
    public class User
    {
        public string Nama { get; set; }
        public string NoHP { get; set; }
        public string Email { get; set; }  
        public string TglDaftar { get; set; }
        public string Topik { get; set; }
        public string IDUser { get; set; }
        public string PassUser { get; set; }
        public int Score { get; set; }
        public int Attempt { get; set; }

        public bool Administrator { get; set; }
    }
}
