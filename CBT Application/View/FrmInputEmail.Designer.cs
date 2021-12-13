namespace CBT_Application.View
{
    partial class FrmInputEmail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.txtSenderPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.txtReceiverName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 70);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please Input Your Email";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Send to Email";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSenderName);
            this.groupBox1.Controls.Add(this.txtSender);
            this.groupBox1.Controls.Add(this.txtSenderPass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  For Dev Purpose Only  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sender Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sender Email";
            // 
            // txtSenderName
            // 
            this.txtSenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenderName.Location = new System.Drawing.Point(156, 30);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(267, 22);
            this.txtSenderName.TabIndex = 5;
            this.txtSenderName.Enter += new System.EventHandler(this.txtSenderName_Enter);
            this.txtSenderName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenderName_KeyDown);
            this.txtSenderName.Leave += new System.EventHandler(this.txtSenderName_Leave);
            // 
            // txtSender
            // 
            this.txtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSender.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtSender.Location = new System.Drawing.Point(156, 61);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(267, 22);
            this.txtSender.TabIndex = 6;
            this.txtSender.Enter += new System.EventHandler(this.txtSenderName_Enter);
            this.txtSender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSender_KeyDown);
            this.txtSender.Leave += new System.EventHandler(this.txtSenderName_Leave);
            // 
            // txtSenderPass
            // 
            this.txtSenderPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenderPass.Location = new System.Drawing.Point(156, 93);
            this.txtSenderPass.Name = "txtSenderPass";
            this.txtSenderPass.PasswordChar = '●';
            this.txtSenderPass.Size = new System.Drawing.Size(267, 22);
            this.txtSenderPass.TabIndex = 7;
            this.txtSenderPass.Enter += new System.EventHandler(this.txtSenderName_Enter);
            this.txtSenderPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenderPass_KeyDown);
            this.txtSenderPass.Leave += new System.EventHandler(this.txtSenderName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sender Password";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(321, 309);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(114, 31);
            this.btnSendEmail.TabIndex = 11;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // txtReceiver
            // 
            this.txtReceiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiver.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtReceiver.Location = new System.Drawing.Point(166, 268);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(267, 22);
            this.txtReceiver.TabIndex = 10;
            this.txtReceiver.Enter += new System.EventHandler(this.txtSenderName_Enter);
            this.txtReceiver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiver_KeyDown);
            this.txtReceiver.Leave += new System.EventHandler(this.txtSenderName_Leave);
            // 
            // txtReceiverName
            // 
            this.txtReceiverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiverName.Location = new System.Drawing.Point(166, 236);
            this.txtReceiverName.Name = "txtReceiverName";
            this.txtReceiverName.Size = new System.Drawing.Size(267, 22);
            this.txtReceiverName.TabIndex = 7;
            this.txtReceiverName.Enter += new System.EventHandler(this.txtSenderName_Enter);
            this.txtReceiverName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiverName_KeyDown);
            this.txtReceiverName.Leave += new System.EventHandler(this.txtSenderName_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Receiver Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Receiver Name";
            // 
            // FrmInputEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 362);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.txtReceiver);
            this.Controls.Add(this.txtReceiverName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Your Email";
            this.Load += new System.EventHandler(this.FrmInputEmail_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.TextBox txtSenderPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.TextBox txtReceiverName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}