using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CBT_Application.DAL;
using CBT_Application.Entity;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace CBT_Application.View
{
    public partial class FrmHasilUjian : Form
    {
        User pengguna = new User();
        public FrmHasilUjian(int nilai, User user)
        {
            InitializeComponent();
            btnCertificate.Enabled = false;
            lblNilai.Text = $"{nilai}";
            if (nilai >= 65)
            {
                lblLulus.Text = "Pass";
                btnCertificate.Enabled = true;
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

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            // object to work with excel
            Excel.Application app = default;
            Excel.Workbook book = default;
            Excel.Worksheet sheet = default;
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                string nama = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.lblNama.Text.Trim());
                string templateCertificate = Path.Combine(currentPath, @"..\..\..\data\cert_uas_bap.xlsx");
                string folderPath = string.Empty;

                using (var fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        folderPath = fbd.SelectedPath;

                        if (folderPath.Equals(string.Empty))
                            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        string targetNameFile = $@"{folderPath}\Certificate_{nama}.pdf";

                        app = new Excel.Application();
                        book = app.Workbooks.Open(templateCertificate);
                        sheet = book.ActiveSheet as Excel.Worksheet;

                        sheet.Range["A14"].Value = nama.ToUpper();
                        sheet.Range["A17"].Value = this.lblSubject.Text.Trim();
                        sheet.Range["A22"].Value = DateTime.Now.ToString("d/M/yyyy");

                        book.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, targetNameFile);

                        // Proses Selesai
                        MessageBox.Show($"Certificate has successfully generated\nSaved in {folderPath}.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {

            }
        }
    }
}
