using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBT_Application.DAL;
using CBT_Application.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace CBT_Application.View
{
    public partial class FrmAdminPanel : Form
    {
        public FrmAdminPanel()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            // Data Binding ke DGV List Student
            this.dgvListStudent.AutoGenerateColumns = false;
            this.dgvListStudent.Columns[0].DataPropertyName = nameof(User.Nama);
            this.dgvListStudent.Columns[1].DataPropertyName = nameof(User.NoHP);
            this.dgvListStudent.Columns[2].DataPropertyName = nameof(User.Email);
            this.dgvListStudent.Columns[3].DataPropertyName = nameof(User.TglDaftar);
            this.dgvListStudent.Columns[4].DataPropertyName = nameof(User.Topik);
            this.dgvListStudent.Columns[5].DataPropertyName = nameof(User.ExamStatusDesc);

            // Data Binding ke DGV Exam Results
            this.dgvExamResult.AutoGenerateColumns = false;
            this.dgvExamResult.Columns[1].DataPropertyName = nameof(UserExamResult.Nama);
            this.dgvExamResult.Columns[2].DataPropertyName = nameof(UserExamResult.Topik);
            this.dgvExamResult.Columns[3].DataPropertyName = nameof(UserExamResult.Nilai);
            this.dgvExamResult.Columns[4].DataPropertyName = nameof(UserExamResult.Status);
            this.dgvExamResult.Columns[0].DataPropertyName = nameof(UserExamResult.TglUjian);
        }

        public bool Run(FrmAdminPanel form)
        {
            form.ShowDialog();
            return true;
        }

        private void FrmAdminPanel_Load(object sender, EventArgs e)
        {
            LoadDataStudent();
            LoadDataExam();

            cboBasedOn.SelectedIndex = 0;
            lblYMD.Text = "Parameter";
            cboYMD.Enabled = false;
            cboYMD.Text = "Parameter not Set";
            dgvListStudent.Columns[4].Width = 100;
        }

        private async void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            // Buka Form Create New User
            View.FrmCreateNewUser form = new View.FrmCreateNewUser();
            (User, string, bool) hasilCreate = form.Run(form);
            if (hasilCreate.Item3 && form.DialogResult == DialogResult.OK)
            {
                this.btnAddNewStudent.Enabled = false;

                FrmInputEmail frm = new FrmInputEmail(hasilCreate.Item1);
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
                        string nama = hasilCreate.Item1.Nama.Trim();
                        string templateCertificate = Path.Combine(currentPath, @"..\..\..\data\template_new-student.xlsx");
                        string targetFileName = Path.Combine(currentPath, $@"..\..\..\ExamData-{nama}.pdf");

                        // Create Object
                        app = new Excel.Application();
                        book = app.Workbooks.Open(templateCertificate);
                        sheet = book.ActiveSheet as Excel.Worksheet;
                        this.lblStatus.Text = "Processing...";

                        sheet.Range["B7"].Value = nama;
                        sheet.Range["B8"].Value = $"'{hasilCreate.Item1.NoHP}";
                        sheet.Range["B9"].Value = hasilCreate.Item1.Email;
                        sheet.Range["B10"].Value = hasilCreate.Item1.TglDaftar;
                        sheet.Range["B11"].Value = hasilCreate.Item1.Topik;
                        sheet.Range["B15"].Value = hasilCreate.Item1.IDUser;
                        sheet.Range["B16"].Value = hasilCreate.Item2;

                        book.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, targetFileName);

                        this.lblStatus.Text = "Document Generated...";
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
                                    mailMsg.Subject = $"Data Ujian - {receiverName}";
                                    mailMsg.Body = $"Dear {receiverName},\n\nDalam email ini, terlampir data ujian {hasilCreate.Item1.Topik} Anda.\n\nTerima Kasih.\n\nBest Regards,\n{senderName}";
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
                        this.btnAddNewStudent.Enabled = true;
                        this.lblStatus.Text = "Active";
                    }
                }
                else
                {
                    this.btnAddNewStudent.Enabled = true;
                }
                LoadDataStudent();
            }
        }

        private void LoadDataStudent()
        {
            List<User> listStudent = default;
            using (DALUser dal = new DALUser())
            {
                listStudent = dal.GetAllUser().ToList();
            }
            foreach (User a in listStudent)
            {
                string[] pecahan = new string[3];
                pecahan = a.TglDaftar.Split(' ')[0].Split('/');
                a.TglDaftar = $"{pecahan[2]}-{pecahan[0]}-{pecahan[1]}";
                if (a.ExamStatus == true)
                {
                    a.ExamStatusDesc = "Done";
                } else
                {
                    a.ExamStatusDesc = "Not Done";
                }
            }
            if (listStudent != null && listStudent.Any())
            {
                dgvListStudent.DataSource = listStudent;
            }
            lblStudents.Text = $"{listStudent.Count.ToString()} Students.";
            lblCPP.Text = listStudent.Count(item => item.Topik.ToString() == "C++").ToString();
            lblJava.Text = listStudent.Count(item => item.Topik.ToString() == "Java").ToString();
            lblIPA.Text = listStudent.Count(item => item.Topik.ToString() == "IPA").ToString();
        }

        public List<string> semuaTgl = new List<string>();
        public List<string> semuaBln = new List<string>();
        public List<string> semuaThn = new List<string>();
        public List<UserExamResult> listExamResult = default;
        private void LoadDataExam()
        {
            using (DALUser dal = new DALUser())
            {
                listExamResult = dal.GetAllExamResults().ToList();
            }
            foreach (UserExamResult a in listExamResult)
            {
                a.Status = a.Nilai >= 65 ? "Pass" : "Fail";
            }

            foreach (UserExamResult a in listExamResult)
            {
                string[] pchnTgl = new string[3];
                pchnTgl = a.TglUjian.Split(' ')[0].Split('/');
                if (!semuaBln.Contains($"{pchnTgl[2]}-{pchnTgl[0]}")) semuaBln.Add($"{pchnTgl[2]}-{pchnTgl[0]}");
                if (!semuaThn.Contains(pchnTgl[2])) semuaThn.Add(pchnTgl[2]);
                if (!semuaTgl.Contains($"{pchnTgl[2]}-{pchnTgl[0]}-{pchnTgl[1]}")) semuaTgl.Add($"{pchnTgl[2]}-{pchnTgl[0]}-{pchnTgl[1]}");
                a.TglUjian = $"{pchnTgl[2]}-{pchnTgl[0]}-{pchnTgl[1]} {a.TglUjian.Split(' ')[1]}";
            }

            if (listExamResult != null && listExamResult.Any())
            {
                dgvExamResult.DataSource = listExamResult;
            }
        }

        private void cboBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBasedOn.SelectedIndex != 0)
            {
                lblYMD.Text = cboBasedOn.Text;

                // Populate Opsi ke ComboBox
                if (cboBasedOn.Text.Trim().Equals("Year"))
                {
                    cboYMD.Text = "";
                    cboYMD.Items.Clear();
                    LoadDataExam();
                    foreach (var item in semuaThn) cboYMD.Items.Add(item);
                }
                else if (cboBasedOn.Text.Trim().Equals("Month"))
                {
                    cboYMD.Text = ""; cboYMD.Items.Clear();
                    LoadDataExam();
                    foreach (var item in semuaBln) cboYMD.Items.Add(item);
                }
                else if (cboBasedOn.Text.Trim().Equals("Date"))
                {
                    cboYMD.Text = ""; cboYMD.Items.Clear();
                    LoadDataExam();
                    foreach (var item in semuaTgl) cboYMD.Items.Add(item);
                }
                cboYMD.SelectedIndex = 0;
                cboYMD.Enabled = true;
            }
            else
            {
                lblYMD.Text = "Parameter";
                cboYMD.Enabled = false;
                cboYMD.Items.Clear();
                cboYMD.Text = "Parameter not Set";
                LoadDataExam();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (DALUser dal = new DALUser())
            {
                listExamResult = dal.GetExamResults(lblYMD.Text.Trim(), cboYMD.Text.Trim()).ToList();
            }
            foreach (UserExamResult a in listExamResult)
            {
                a.Status = a.Nilai >= 65 ? "Pass" : "Fail";
            }
            foreach (UserExamResult a in listExamResult)
            {
                string[] pchnTgl = new string[3];
                pchnTgl = a.TglUjian.Split(' ')[0].Split('/');
                a.TglUjian = $"{pchnTgl[2]}-{pchnTgl[0]}-{pchnTgl[1]} {a.TglUjian.Split(' ')[1]}";
            }
            if (listExamResult != null && listExamResult.Any())
            {
                dgvExamResult.DataSource = listExamResult;
            }
            btnFilter.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = String.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF File (*.pdf) | *.pdf";
            sfd.FileName = cboYMD.Enabled ? $"Exam Data Report - {lblYMD.Text.Trim()} {cboYMD.Text.Trim()}.pdf" :
                    "Exam Data Report.pdf";
                       
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.btnExport.Enabled = false;
                filename = sfd.FileName;
                // object to work with excel
                Excel.Application app = null;
                Excel.Workbook book = null;
                Excel.Worksheet sheet = null;
                this.lblStatus.Text = "Processing...";

                try
                {
                    if (listExamResult != null && listExamResult.Any())
                    {

                        this.btnAddNewStudent.Enabled = false;
                        // create object-nya
                        app = new Excel.Application();
                        book = app.Workbooks.Add();
                        sheet = book.ActiveSheet as Excel.Worksheet;
                        this.lblStatus.Text = "Generating File...";

                        object[,] objData = new object[listExamResult.Count(), 5];

                        int idx = 0;

                        foreach (var item in listExamResult)
                        {
                            objData[idx, 0] = item.TglUjian;
                            objData[idx, 1] = item.Nama;
                            objData[idx, 2] = item.Topik;
                            objData[idx, 3] = item.Nilai;
                            objData[idx++, 4] = item.Status;
                        }

                        int barisHeader = 1;

                        // header
                        sheet.Cells[barisHeader++, 1] = "LAPORAN DATA PESERTA UJIAN";
                        sheet.Range[$"A{barisHeader-1}"].Font.Size = 14;
                        sheet.Range[$"A{barisHeader-1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"A{barisHeader - 1}:E{barisHeader - 1}"].Merge();

                        // Baris kedua
                        string teksFilter = cboYMD.Enabled ? $": {cboYMD.Text.Trim()}" : "";

                        sheet.Cells[barisHeader++, 1] = $"Filter by {cboBasedOn.Text.Trim()}{teksFilter}";
                        sheet.Range[$"A{barisHeader -1}"].Font.Size = 11;
                        sheet.Range[$"A{barisHeader -1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"A{barisHeader - 1}:E{barisHeader - 1}"].Merge();

                        barisHeader++;
                        sheet.Cells[barisHeader, 1] = "Tanggal Ujian";
                        sheet.Cells[barisHeader, 2] = "Nama";
                        sheet.Cells[barisHeader, 3] = "Topik";
                        sheet.Cells[barisHeader, 4] = "Nilai";
                        sheet.Cells[barisHeader, 5] = "Status";

                        int baris = barisHeader + 1;

                        // populate data to sheet
                        sheet.Range[$"A{baris}", $"E{baris + listExamResult.Count() - 1}"].Value = objData;

                        // format excel sheet: Header
                        sheet.Range["A1:E1"].MergeCells = true;
                        sheet.Range[$"A1:E{barisHeader}"].Font.Bold = true;

                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.Color = 16751001;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.TintAndShade = 0.599993896298105;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.PatternTintAndShade = 0;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        //Mengatur lebar kolom
                        sheet.Range[$"A:A"].ColumnWidth = 18.89;
                        sheet.Range[$"B:B"].ColumnWidth = 23.56;
                        sheet.Range[$"C:C"].ColumnWidth = 11.33;
                        sheet.Range[$"D:D"].ColumnWidth = 9.33;
                        sheet.Range[$"E:E"].ColumnWidth = 21.11;

                        // Tinggi Baris
                        sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].RowHeight = 19.80;
                        sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        sheet.Range[$"A1", $"E{baris + listExamResult.Count() - 1}"].Font.Name = "Arial";

                        //Mengatur Rata Tengah & Insert Indent
                        sheet.Range[$"A:A"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"B{baris}:B{baris + listExamResult.Count() - 1}"].InsertIndent(1);
                        sheet.Range[$"C:C"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"D:D"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"E:E"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        // Border
                        sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        app.ActiveWindow.DisplayGridlines = false;

                        // mengubah nama sheet
                        sheet.Name = "Menu";

                        // export object excel ini ke dalam format file pdf
                        this.lblStatus.Text = "Exporting to PDF...";
                        book.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, filename);

                        this.lblStatus.Text = "File Generated Successfully!";
                        MessageBox.Show("Generate File PDF Sukses.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    this.btnAddNewStudent.Enabled = true;
                    this.lblStatus.Text = "Active";
                    this.btnExport.Enabled = true;
                }
            } 
        }

        private async void btnSendMail_Click(object sender, EventArgs e)
        {
            FrmInputEmail frm = new FrmInputEmail(new User {Nama = "Administrator", Email = "admin.cbt@gmail.com"});
            EmailCreds hasil = frm.Run(frm);
            if (hasil != null && frm.DialogResult == DialogResult.OK)
            {
                this.btnSendMail.Enabled = false;
                // object to work with excel
                Excel.Application app = default;
                Excel.Workbook book = default;
                Excel.Worksheet sheet = default;
                string currentPath = AppDomain.CurrentDomain.BaseDirectory;
                string targetFileName = cboYMD.Enabled ? Path.Combine(currentPath, $@"..\..\..\data\Exam Data Report - {lblYMD.Text.Trim()} {cboYMD.Text.Trim()}.pdf") :
                    Path.Combine(currentPath, @"..\..\..\data\Exam Data Report.pdf");

                // Informasi Email Address pengurim dan penerima
                string senderEmail = hasil.SenderEmail;
                string senderPass = hasil.SenderPass;
                string receiverEmail = hasil.ReceiverEmail;
                string senderName = hasil.SenderName;
                string receiverName = hasil.ReceiverName;

                try
                {
                    if (listExamResult != null && listExamResult.Any())
                    {

                        this.btnSendMail.Enabled = false;

                        // create object-nya
                        app = new Excel.Application();
                        book = app.Workbooks.Add();
                        sheet = book.ActiveSheet as Excel.Worksheet;

                        object[,] objData = new object[listExamResult.Count(), 5];

                        int idx = 0;

                        foreach (var item in listExamResult)
                        {
                            objData[idx, 0] = item.TglUjian;
                            objData[idx, 1] = item.Nama;
                            objData[idx, 2] = item.Topik;
                            objData[idx, 3] = item.Nilai;
                            objData[idx++, 4] = item.Status;
                        }

                        int barisHeader = 1;

                        // header
                        sheet.Cells[barisHeader++, 1] = "LAPORAN DATA PESERTA UJIAN";
                        sheet.Range[$"A{barisHeader - 1}"].Font.Size = 14;
                        sheet.Range[$"A{barisHeader - 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"A{barisHeader - 1}:E{barisHeader - 1}"].Merge();

                        // Baris kedua
                        string teksFilter = cboYMD.Enabled ? $": {cboYMD.Text.Trim()}" : "";
                        sheet.Cells[barisHeader++, 1] = $"Filter by {cboBasedOn.Text.Trim()}{teksFilter}";
                        sheet.Range[$"A{barisHeader - 1}"].Font.Size = 11;
                        sheet.Range[$"A{barisHeader - 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"A{barisHeader - 1}:E{barisHeader - 1}"].Merge();

                        barisHeader++;
                        sheet.Cells[barisHeader, 1] = "Tanggal Ujian";
                        sheet.Cells[barisHeader, 2] = "Nama";
                        sheet.Cells[barisHeader, 3] = "Topik";
                        sheet.Cells[barisHeader, 4] = "Nilai";
                        sheet.Cells[barisHeader, 5] = "Status";

                        int baris = barisHeader + 1;

                        // populate data to sheet
                        sheet.Range[$"A{baris}", $"E{baris + listExamResult.Count() - 1}"].Value = objData;

                        // format excel sheet: Header
                        sheet.Range["A1:E1"].MergeCells = true;
                        sheet.Range[$"A1:E{barisHeader}"].Font.Bold = true;

                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.Color = 16751001;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.TintAndShade = 0.599993896298105;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.PatternTintAndShade = 0;
                        sheet.Range[$"A{barisHeader}:E{barisHeader}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        //Mengatur lebar kolom
                        sheet.Range[$"A:A"].ColumnWidth = 18.89;
                        sheet.Range[$"B:B"].ColumnWidth = 23.56;
                        sheet.Range[$"C:C"].ColumnWidth = 11.33;
                        sheet.Range[$"D:D"].ColumnWidth = 9.33;
                        sheet.Range[$"E:E"].ColumnWidth = 21.11;

                        // Tinggi Baris
                        sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].RowHeight = 19.80;
                        sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        sheet.Range[$"A1", $"E{baris + listExamResult.Count() - 1}"].Font.Name = "Arial";

                        //Mengatur Rata Tengah & Insert Indent
                        sheet.Range[$"A:A"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"B{baris}:B{baris + listExamResult.Count() - 1}"].InsertIndent(1);
                        sheet.Range[$"C:C"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"D:D"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Range[$"E:E"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        // Border
                        sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        app.ActiveWindow.DisplayGridlines = false;

                        // mengubah nama sheet
                        sheet.Name = "Menu";

                        // export object excel ini ke dalam format file pdf
                        book.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, targetFileName);

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
                                    mailMsg.Subject = $"Laporan Data Ujian - {receiverName}";
                                    if (lblYMD.Text.Trim().Equals("Parameter"))
                                    {
                                        mailMsg.Body = $"Dear {receiverName},\n\nDalam email ini, terlampir Laporan Data Ujian CBT secara keseluruhan.\n\n" +
                                            $"Terima Kasih.\n\nBest Regards,\n{senderName}";
                                    }
                                    else
                                    {
                                        mailMsg.Body = $"Dear {receiverName},\n\nDalam email ini, terlampir Laporan Data Ujian CBT dengan Hasil Filter " +
                                            $"{lblYMD.Text.Trim()} {cboYMD.Text.Trim()} yang Anda pilih.\n\nTerima Kasih.\n\nBest Regards,\n{senderName}";
                                    }
                                    
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
                    this.btnSendMail.Enabled = true;
                    this.lblStatus.Text = "Active";
                }
            }
        }

        private void cboYMD_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFilter.Enabled = true;
        }
    }
}
