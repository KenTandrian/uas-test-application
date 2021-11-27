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

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            // Buka Form Create New User
            View.FrmCreateNewUser form = new View.FrmCreateNewUser();
            bool jalan = form.Run(form);
            if (jalan)
            {
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
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // object to work with excel

            Excel.Application app = null;
            Excel.Workbook book = null;
            Excel.Worksheet sheet = null;

            try
            {
                if (listExamResult != null && listExamResult.Any())
                {

                    this.btnAddNewStudent.Enabled = false;
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

                    sheet.Cells[barisHeader++, 1] = "DATA PESERTA UJIAN";

                    sheet.Cells[barisHeader, 1] = "Tanggal Ujian";
                    sheet.Cells[barisHeader, 2] = "Nama";
                    sheet.Cells[barisHeader, 3] = "Topik";
                    sheet.Cells[barisHeader, 4] = "Nilai";
                    sheet.Cells[barisHeader, 5] = "Status";

                    int baris = barisHeader + 1;

                    // populate data to sheet
                    sheet.Range[$"A{baris}", $"E{baris + listExamResult.Count() - 1}"].Value = objData;

                    // format excel sheet
                    sheet.Range["A1:E1"].MergeCells = true;
                    sheet.Range[$"A1:E{barisHeader}"].Font.Bold = true;

                    sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                    sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                    sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
                    sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.TintAndShade = 0.599993896298105;
                    sheet.Range[$"A{barisHeader}:E{barisHeader}"].Interior.PatternTintAndShade = 0;
                    //sheet.Range[$"A{barisHeader}:E{barisHeader}"].ColumnWidth = 15;

                    sheet.Range[$"A{barisHeader}", $"E{baris + listExamResult.Count() - 1}"].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    app.ActiveWindow.DisplayGridlines = false;

                    sheet.Range["A:E"].EntireColumn.AutoFit();

                    // mengubah nama sheet
                    sheet.Name = "Menu";

                    // export object excel ini ke dalam format file pdf
                    book.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Data_Peserta.pdf");

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
            }
        }
    }
}
