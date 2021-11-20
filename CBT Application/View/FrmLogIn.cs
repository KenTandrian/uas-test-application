﻿using System;
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

namespace CBT_Application
{
    public partial class FrmLogIn : Form
    {
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDUser.Text.Trim().Equals("")) throw new Exception("Maaf, ID User harus diisi!");
                if (txtPass.Text.Trim().Equals("")) throw new Exception("Maaf, Password harus diisi!");
                string uid = txtIDUser.Text;
                string passwd = txtPass.Text;
                using (var dal = new DALUser())
                {
                    if(dal.TryLogIn(uid, Helper.GenerateHash256(passwd)))
                    {
                        // Login Berhasil
                        var item = dal.GetItem(uid);
                        MessageBox.Show($"Login Succeed.\nWelcome, {item.Nama}!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIDUser.Clear();
                        txtPass.Clear();
                        //txtIDUser.Focus();

                        // Buka Form Ujian
                        FrmUjian form = new FrmUjian();
                        this.Hide();
                        form.Closed += (s, args) => this.Close();
                        form.ShowDialog();
                    } 
                    else
                    {
                        // Login Tidak Berhasil
                        MessageBox.Show("Login Failed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIDUser.Clear();
                        txtPass.Clear();
                        txtIDUser.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtIDUser.Text.Trim().Equals(""))
                {
                    txtIDUser.Focus();
                } else
                {
                    txtPass.Focus();
                }
            }
        }

        // Pengaturan Warna TextBox
        private void txtIDUser_Enter(object sender, EventArgs e)
        {
            var cont = sender as TextBox;
            cont.BackColor = Color.FromKnownColor(KnownColor.LightGray);
        }

        private void txtIDUser_Leave(object sender, EventArgs e)
        {
            var cont = sender as TextBox;
            cont.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            var cont = sender as TextBox;
            cont.BackColor = Color.FromKnownColor(KnownColor.LightGray);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            var cont = sender as TextBox;
            cont.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        private void txtIDUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogIn_Click(null, null);
        }
    }
}