using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBT_Application.DAL;
using CBT_Application.Entity;

namespace CBT_Application.View
{
    public partial class FrmHasilUjian : Form
    {
        User pengguna = new User();
        public FrmHasilUjian(int nilai, User user)
        {
            InitializeComponent();
            lblNilai.Text = $"{nilai}";
            if (nilai >= 65)
            {
                lblLulus.Text = "Pass";
            } else
            {
                lblLulus.Text = "Fail";
            }
            lblNama.Text = user.Nama.Trim();
            lblSubject.Text = user.Topik.Trim();
            if (nilai < 65 && user.Attempt < 2)
            {
                btnRetake.Enabled = true;
            } else
            {
                btnRetake.Enabled = false;
            }
            pengguna = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FrmLogIn form2 = new FrmLogIn())
            {
                this.Hide();
                form2.Closed += (s, args) => this.Close();
                form2.ShowDialog();
            }
        }

        private void btnRetake_Click(object sender, EventArgs e)
        {
            using (FrmUjian form3 = new FrmUjian(pengguna))
            {
                this.Hide();
                form3.Closed += (s, args) => this.Close();
                form3.ShowDialog();
            }
        }
    }
}
