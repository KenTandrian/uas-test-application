﻿namespace CBT_Application.View
{
    partial class FrmAdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblIPA = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblJava = new System.Windows.Forms.Label();
            this.lblCPP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStudents = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvListStudent = new System.Windows.Forms.DataGridView();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglDaftar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Topik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboYMD = new System.Windows.Forms.ComboBox();
            this.cboBasedOn = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvExamResult = new System.Windows.Forms.DataGridView();
            this.WktuUjian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Topik1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nilai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblYMD = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewStudent = new CBT_Application.Controls.RoundedButton();
            this.btnExport = new CBT_Application.Controls.RoundedButton();
            this.btnFilter = new CBT_Application.Controls.RoundedButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStudent)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamResult)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 119);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(995, 443);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddNewStudent);
            this.tabPage1.Controls.Add(this.lblIPA);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lblJava);
            this.tabPage1.Controls.Add(this.lblCPP);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblStudents);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblSubject);
            this.tabPage1.Controls.Add(this.lblTotalStudents);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dgvListStudent);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(987, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "   Students   ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblIPA
            // 
            this.lblIPA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIPA.AutoSize = true;
            this.lblIPA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIPA.Location = new System.Drawing.Point(861, 253);
            this.lblIPA.Name = "lblIPA";
            this.lblIPA.Size = new System.Drawing.Size(35, 19);
            this.lblIPA.TabIndex = 3;
            this.lblIPA.Text = "IPA";
            this.lblIPA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(782, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "IPA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJava
            // 
            this.lblJava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJava.AutoSize = true;
            this.lblJava.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJava.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblJava.Location = new System.Drawing.Point(861, 224);
            this.lblJava.Name = "lblJava";
            this.lblJava.Size = new System.Drawing.Size(43, 19);
            this.lblJava.TabIndex = 3;
            this.lblJava.Text = "Java";
            this.lblJava.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCPP
            // 
            this.lblCPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCPP.AutoSize = true;
            this.lblCPP.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCPP.Location = new System.Drawing.Point(861, 196);
            this.lblCPP.Name = "lblCPP";
            this.lblCPP.Size = new System.Drawing.Size(41, 19);
            this.lblCPP.TabIndex = 3;
            this.lblCPP.Text = "C++";
            this.lblCPP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(782, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Java";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStudents
            // 
            this.lblStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudents.AutoSize = true;
            this.lblStudents.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudents.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStudents.Location = new System.Drawing.Point(782, 123);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(106, 19);
            this.lblStudents.TabIndex = 3;
            this.lblStudents.Text = "{ x } Students";
            this.lblStudents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(782, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "C++";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSubject.Location = new System.Drawing.Point(782, 165);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(122, 19);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Exam Subject:";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalStudents.Location = new System.Drawing.Point(782, 93);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(129, 19);
            this.lblTotalStudents.TabIndex = 3;
            this.lblTotalStudents.Text = "Total Students:";
            this.lblTotalStudents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(18, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "List of Students";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(782, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Statistics";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvListStudent
            // 
            this.dgvListStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nama,
            this.NoHP,
            this.Email,
            this.TglDaftar,
            this.Topik});
            this.dgvListStudent.Location = new System.Drawing.Point(22, 49);
            this.dgvListStudent.Name = "dgvListStudent";
            this.dgvListStudent.RowHeadersWidth = 51;
            this.dgvListStudent.RowTemplate.Height = 24;
            this.dgvListStudent.Size = new System.Drawing.Size(738, 345);
            this.dgvListStudent.TabIndex = 0;
            // 
            // Nama
            // 
            this.Nama.HeaderText = "Name";
            this.Nama.MinimumWidth = 6;
            this.Nama.Name = "Nama";
            this.Nama.Width = 125;
            // 
            // NoHP
            // 
            this.NoHP.HeaderText = "Phone Num.";
            this.NoHP.MinimumWidth = 6;
            this.NoHP.Name = "NoHP";
            this.NoHP.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 60;
            this.Email.Name = "Email";
            this.Email.Width = 200;
            // 
            // TglDaftar
            // 
            this.TglDaftar.HeaderText = "Reg. Date";
            this.TglDaftar.MinimumWidth = 6;
            this.TglDaftar.Name = "TglDaftar";
            this.TglDaftar.Width = 125;
            // 
            // Topik
            // 
            this.Topik.HeaderText = "Subject";
            this.Topik.MinimumWidth = 40;
            this.Topik.Name = "Topik";
            this.Topik.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboYMD);
            this.tabPage2.Controls.Add(this.cboBasedOn);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dgvExamResult);
            this.tabPage2.Controls.Add(this.lblYMD);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Controls.Add(this.btnFilter);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(987, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "   Reports   ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboYMD
            // 
            this.cboYMD.FormattingEnabled = true;
            this.cboYMD.Location = new System.Drawing.Point(793, 188);
            this.cboYMD.Name = "cboYMD";
            this.cboYMD.Size = new System.Drawing.Size(172, 24);
            this.cboYMD.TabIndex = 5;
            // 
            // cboBasedOn
            // 
            this.cboBasedOn.FormattingEnabled = true;
            this.cboBasedOn.Items.AddRange(new object[] {
            "None",
            "Month",
            "Date",
            "Year"});
            this.cboBasedOn.Location = new System.Drawing.Point(793, 120);
            this.cboBasedOn.Name = "cboBasedOn";
            this.cboBasedOn.Size = new System.Drawing.Size(172, 24);
            this.cboBasedOn.TabIndex = 5;
            this.cboBasedOn.SelectedIndexChanged += new System.EventHandler(this.cboBasedOn_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(18, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 24);
            this.label10.TabIndex = 4;
            this.label10.Text = "List of Exam Results";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvExamResult
            // 
            this.dgvExamResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WktuUjian,
            this.Nama1,
            this.Topik1,
            this.Nilai,
            this.Status});
            this.dgvExamResult.Location = new System.Drawing.Point(22, 64);
            this.dgvExamResult.Name = "dgvExamResult";
            this.dgvExamResult.RowHeadersWidth = 51;
            this.dgvExamResult.RowTemplate.Height = 24;
            this.dgvExamResult.Size = new System.Drawing.Size(743, 331);
            this.dgvExamResult.TabIndex = 3;
            // 
            // WktuUjian
            // 
            this.WktuUjian.HeaderText = "Exam Time";
            this.WktuUjian.MinimumWidth = 6;
            this.WktuUjian.Name = "WktuUjian";
            this.WktuUjian.Width = 200;
            // 
            // Nama1
            // 
            this.Nama1.HeaderText = "Name";
            this.Nama1.MinimumWidth = 6;
            this.Nama1.Name = "Nama1";
            this.Nama1.Width = 125;
            // 
            // Topik1
            // 
            this.Topik1.HeaderText = "Subject";
            this.Topik1.MinimumWidth = 6;
            this.Topik1.Name = "Topik1";
            this.Topik1.Width = 125;
            // 
            // Nilai
            // 
            this.Nilai.HeaderText = "Score";
            this.Nilai.MinimumWidth = 6;
            this.Nilai.Name = "Nilai";
            this.Nilai.Width = 80;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 125;
            // 
            // lblYMD
            // 
            this.lblYMD.AutoSize = true;
            this.lblYMD.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYMD.Location = new System.Drawing.Point(793, 166);
            this.lblYMD.Name = "lblYMD";
            this.lblYMD.Size = new System.Drawing.Size(133, 17);
            this.lblYMD.TabIndex = 0;
            this.lblYMD.Text = "{ Year/Month/Date }";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(793, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Based on";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(793, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Filter Options";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 101);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(27, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome,";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(780, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "CBT APPLICATION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewStudent.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAddNewStudent.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAddNewStudent.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddNewStudent.BorderRadius = 7;
            this.btnAddNewStudent.BorderSize = 0;
            this.btnAddNewStudent.FlatAppearance.BorderSize = 0;
            this.btnAddNewStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddNewStudent.Location = new System.Drawing.Point(786, 354);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(172, 40);
            this.btnAddNewStudent.TabIndex = 1;
            this.btnAddNewStudent.Text = "Add New Student";
            this.btnAddNewStudent.TextColor = System.Drawing.Color.White;
            this.btnAddNewStudent.UseVisualStyleBackColor = false;
            this.btnAddNewStudent.Click += new System.EventHandler(this.btnAddNewStudent_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnExport.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnExport.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExport.BorderRadius = 7;
            this.btnExport.BorderSize = 0;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(793, 355);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(172, 40);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export as PDF";
            this.btnExport.TextColor = System.Drawing.Color.White;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnFilter.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnFilter.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFilter.BorderRadius = 7;
            this.btnFilter.BorderSize = 0;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(793, 305);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(172, 40);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter Now!";
            this.btnFilter.TextColor = System.Drawing.Color.White;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // FrmAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "FrmAdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.FrmAdminPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStudent)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamResult)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListStudent;
        private Controls.RoundedButton btnAddNewStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIPA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJava;
        private System.Windows.Forms.Label lblCPP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboYMD;
        private System.Windows.Forms.ComboBox cboBasedOn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvExamResult;
        private System.Windows.Forms.Label lblYMD;
        private Controls.RoundedButton btnExport;
        private Controls.RoundedButton btnFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglDaftar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topik;
        private System.Windows.Forms.DataGridViewTextBoxColumn WktuUjian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topik1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nilai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}