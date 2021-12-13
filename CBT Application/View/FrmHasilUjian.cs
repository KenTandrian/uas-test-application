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
using System.Runtime.InteropServices;
using CBT_Application.DAL;
using CBT_Application.Entity;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace CBT_Application.View
{
    public partial class FrmHasilUjian : Form
    {
        User pengguna = new User();
        public FrmHasilUjian(int nilai, User user)
        {
            InitializeComponent();
            btnCertificate.Enabled = false;
            btnSendMail.Enabled = false;
            lblNilai.Text = $"{nilai}";
            if (nilai >= 65)
            {
                lblLulus.Text = "Pass";
                btnCertificate.Enabled = true;
                btnSendMail.Enabled = true;
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

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            pengguna.ExamStatus = true;
            using (DALUser dal = new DALUser())
            {
                dal.UpdateExamStatus(pengguna);
            }
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
            lblStatus.Text = "Processing...";

            string nama = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.lblNama.Text.Trim());
            string templateCertificate = Path.Combine(currentPath, @"..\..\..\data\cert_uas_bap.xlsx");
            string folderPath = string.Empty;

            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        folderPath = fbd.SelectedPath;
                        this.btnCertificate.Enabled = false;

                        if (folderPath.Equals(string.Empty))
                            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        lblStatus.Text = "Generating File...";
                        Application.DoEvents();

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
                        lblStatus.Text = "Certificate Generated Successfully!";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        // bersihkan sisa - sisa object yg berhubungan dengan excel ini dari memory
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(sheet);
                        book.Close(false);
                        Marshal.ReleaseComObject(book);
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                        this.btnCertificate.Enabled = true;
                        lblStatus.Text = "Finishing...";
                    }
                }
            }
            lblStatus.Text = "Active";
        }

        private async void btnSendMail_Click(object sender, EventArgs e)
        {
            FrmInputEmail frm = new FrmInputEmail(pengguna);
            EmailCreds hasil = frm.Run(frm);
            if (hasil != null && frm.DialogResult == DialogResult.OK)
            {
                // object to work with excel
                Excel.Application app = default;
                Excel.Workbook book = default;
                Excel.Worksheet sheet = default;
                string currentPath = AppDomain.CurrentDomain.BaseDirectory;

                // Informasi Email Address pengurim dan penerima
                string senderEmail = hasil.SenderEmail;
                string senderPass = hasil.SenderPass;
                string receiverEmail = hasil.ReceiverEmail;
                string senderName = hasil.SenderName;
                string receiverName = hasil.ReceiverName;

                try
                {
                    string nama = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.lblNama.Text.Trim());
                    string templateCertificate = Path.Combine(currentPath, @"..\..\..\data\cert_uas_bap.xlsx");
                    string targetFileName = Path.Combine(currentPath, $@"..\..\..\Certificate_{nama}.pdf");

                    this.btnCertificate.Enabled = false;

                    // Create Object
                    app = new Excel.Application();
                    book = app.Workbooks.Open(templateCertificate);
                    sheet = book.ActiveSheet as Excel.Worksheet;
                    this.lblStatus.Text = "Processing...";

                    sheet.Range["A14"].Value = nama.ToUpper();
                    sheet.Range["A17"].Value = this.lblSubject.Text.Trim();
                    sheet.Range["A22"].Value = DateTime.Now.ToString("d/M/yyyy");

                    book.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, targetFileName);

                    this.lblStatus.Text = "Certificate Generated...";
                    Application.DoEvents();

                    if (File.Exists(targetFileName))
                    {
                        this.lblStatus.Text = "Creating e-mail...";
                        Application.DoEvents();

                        // Create Email with SMTPClient
                        using (var smtpClient = new SmtpClient())
                        {
                            smtpClient.Host = "smtp.gmail.com";
                            smtpClient.Port = 587;
                            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPass);
                            smtpClient.EnableSsl = true;

                            // Mail Message
                            using (var mailMsg = new MailMessage())
                            {
                                mailMsg.From = new MailAddress(senderEmail, $"{senderName}");
                                mailMsg.Subject = $"Sertifikat Ujian - {receiverName}";
                                mailMsg.Body = $"Dear {receiverName},\n\nDalam email ini, terlampir dokumen sertifikat ujian {pengguna.Topik} Anda.\n\nTerima Kasih.\n\nBest Regards,\n{senderName}";
                                mailMsg.IsBodyHtml = false;

                                this.lblStatus.Text = "Adding attachment to e-mail...";
                                Application.DoEvents();

                                // Add attachment
                                using (var attachment = new Attachment(targetFileName, MediaTypeNames.Application.Pdf))
                                {
                                    mailMsg.To.Add(new MailAddress(receiverEmail, $"{receiverName}"));
                                    mailMsg.Attachments.Add(attachment);

                                    // Let's send the email!
                                    this.lblStatus.Text = "Sending Email...";
                                    await smtpClient.SendMailAsync(mailMsg);
                                }

                                // delete file pdf cert hasil generate
                                File.Delete(targetFileName);

                                this.lblStatus.Text = "E-mail sent!";
                            }
                        }
                        MessageBox.Show("E-mail Sent Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    // bersihkan sisa - sisa object yg berhubungan dengan excel ini dari memory
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(sheet);
                    book.Close(false);
                    Marshal.ReleaseComObject(book);
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                    this.btnCertificate.Enabled = true;
                    this.lblStatus.Text = "Active";
                }
            }
        }
    }
}
