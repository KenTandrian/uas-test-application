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


namespace CBT_Application.View
{
    public partial class FrmInputEmail : Form
    {
        public FrmInputEmail(User pengguna)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi; 
            user = pengguna;
        }

        EmailCreds creds = new EmailCreds();
        User user = new User();

        public EmailCreds Run(FrmInputEmail frm)
        {
            frm.ShowDialog();
            return creds;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (txtSenderName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Sender Name should not be empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSender.Text.Trim().Equals(""))
            {
                MessageBox.Show("Sender Email should not be empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSenderPass.Text.Trim().Equals(""))
            {
                MessageBox.Show("Sender Password should not be empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtReceiverName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Receiver Name should not be empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtReceiver.Text.Trim().Equals(""))
            {
                MessageBox.Show("Receiver Email should not be empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                creds.SenderName = txtSenderName.Text.Trim();
                creds.SenderEmail = txtSender.Text.Trim();
                creds.SenderPass = txtSenderPass.Text.Trim();
                creds.ReceiverName = txtReceiverName.Text.Trim();
                creds.ReceiverEmail = txtReceiver.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void txtSenderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtSender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtSenderPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtReceiverName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtReceiver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSendEmail_Click(null, null);
        }

        private void txtSenderName_Enter(object sender, EventArgs e)
        {
            Helper.MakeHighlight(sender);
        }

        private void txtSenderName_Leave(object sender, EventArgs e)
        {
            Helper.RemoveHighlight(sender);
        }

        private void FrmInputEmail_Load(object sender, EventArgs e)
        {
            this.txtReceiverName.Text = user.Nama.Trim();
            this.txtReceiver.Text = user.Email.Trim();
        }
    }
}
