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
        User pengguna = new User();
        public FrmInfoUjian(User user)
        {
            InitializeComponent();
            pengguna = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmInfoUjian_Load(object sender, EventArgs e)
        {
            lblMapel.Text = pengguna.Topik.Trim();
            lblNamaSiswa.Text = pengguna.Nama.Trim();
        }
    }
}
