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
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        bool selesai = false;
        public bool Run(FrmConnection frm)
        {
            frm.ShowDialog();
            return selesai;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConnParameter.Server = txtServer.Text.Trim();
            ConnParameter.Database = txtDatabase.Text.Trim();
            ConnParameter.IntegratedSecurity = cboIntegrated.Checked;
            selesai = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnOK_Click(null, null);
        }
    }
}
