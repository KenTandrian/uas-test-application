using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBT_Application.Entity;
using CBT_Application.DAL;

namespace CBT_Application.View
{
    public partial class FrmInfoUjian : Form
    {
        String mrd = "";
        public FrmInfoUjian(String uid)
        {
            InitializeComponent();
            mrd = uid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        User pengguna = new User();
        private void FrmInfoUjian_Load(object sender, EventArgs e)
        {
            using (var dal = new DALUser())
            {
                pengguna = dal.GetItemNamaTopik(mrd);
            }
            lblMapel.Text = pengguna.Topik.Trim();
            lblNamaSiswa.Text = pengguna.Nama.Trim();
        }
    }
}
