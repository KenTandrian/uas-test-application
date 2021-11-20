﻿using System;
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
    public partial class FrmCreateNewUser : Form
    {
        public FrmCreateNewUser()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            if (txtNama.Text.Trim().Equals(""))
            {
                MessageBox.Show("Maaf, Nama User tidak boleh kosong!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNama.Focus();
            }
            else if (txtNoHP.Text.Trim().Equals(""))
            {
                MessageBox.Show("Maaf, No HP tidak boleh kosong!.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoHP.Focus();
            }
            else if (txtEmail.Text.Trim().Equals(""))
            {
                MessageBox.Show("Maaf, Email tidak boleh kosong!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (cboTopik.Text.Trim().Equals(""))
            {
                MessageBox.Show("Maaf, Topik tidak boleh kosong!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTopik.Focus();
            }
            else if(txtIDUser.Text.Trim().Equals(""))
            {
                MessageBox.Show("Maaf, ID User tidak boleh kosong!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDUser.Focus();
            }
            else if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Maaf, Password tidak boleh kosong!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    User user = new User()
                    {
                        Nama = txtNama.Text,
                        NoHP = txtNoHP.Text,
                        Email = txtEmail.Text,
                        Topik = cboTopik.Text,
                        TglDaftar = dtmTanggal.Value.ToString("yyyy-MM-dd"),
                        IDUser = txtIDUser.Text,
                        PassUser = Helper.GenerateHash256(txtPassword.Text)
                    };
                    using (var dal = new DALUser())
                    {
                        if (dal.CreateNew(user))
                        {
                            MessageBox.Show("Proses Create User Sukses.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNama.Clear();
                            txtNoHP.Clear();
                            txtEmail.Clear();
                            txtIDUser.Clear();
                            txtPassword.Clear();
                            txtNama.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIDUser.Focus();
                }
            }
        }

        private void FrmCreateNewUser_Load(object sender, EventArgs e)
        {
            cboTopik.SelectedIndex = 0;
            dtmTanggal.Value = DateTime.Today;
        }
    }
}
