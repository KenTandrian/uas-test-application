using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBT_Application.View
{
    public partial class FrmHasilUjian : Form
    {
        public FrmHasilUjian(int nilai)
        {
            InitializeComponent();
            lblNilai.Text = $"{nilai} / 100";
            if (nilai >= 65)
            {
                lblLulus.Text = "Lulus";
            } else
            {
                lblLulus.Text = "Tidak Lulus";
            }
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
    }
}
