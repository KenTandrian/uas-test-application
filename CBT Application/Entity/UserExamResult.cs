using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBT_Application.Entity
{
    public class UserExamResult
    {
        public string Nama { get; set; }
        public string Topik { get; set; }
        public int Nilai { get; set; }
        public string Status { get; set; }
        public string TglUjian { get; set; }
    }
}
