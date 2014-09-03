namespace MASSync
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboFrequency = new System.Windows.Forms.ComboBox();
            this.txtFTP = new System.Windows.Forms.TextBox();
            this.txtTenantID = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFtpUserPwd = new System.Windows.Forms.TextBox();
            this.txtFtpUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtLive = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbrand = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvTen = new System.Windows.Forms.DataGridView();
            this.txtTerminalID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTen)).BeginInit();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(361, 473);
            this.btOk.Margin = new System.Windows.Forms.Padding(2);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(67, 25);
            this.btOk.TabIndex = 14;
            this.btOk.Text = "&Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(431, 473);
            this.btCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(61, 25);
            this.btCancel.TabIndex = 15;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ODBC DSN ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 246);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 272);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Password ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Frequency ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ftp ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 219);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tenant ID ";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(348, 242);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.MaxLength = 40;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(144, 21);
            this.txtUserName.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(97, 267);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 40;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(144, 21);
            this.txtPassword.TabIndex = 10;
            // 
            // cboFrequency
            // 
            this.cboFrequency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFrequency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFrequency.FormattingEnabled = true;
            this.cboFrequency.Items.AddRange(new object[] {
            "Every 15 Minutes",
            "Every 30 Minutes",
            "Every 1 Hour",
            "Every 2 Hour",
            "Every 4 Hour",
            "End of Day"});
            this.cboFrequency.Location = new System.Drawing.Point(229, 71);
            this.cboFrequency.Margin = new System.Windows.Forms.Padding(2);
            this.cboFrequency.Name = "cboFrequency";
            this.cboFrequency.Size = new System.Drawing.Size(213, 21);
            this.cboFrequency.TabIndex = 1;
            // 
            // txtFTP
            // 
            this.txtFTP.Location = new System.Drawing.Point(229, 96);
            this.txtFTP.Margin = new System.Windows.Forms.Padding(2);
            this.txtFTP.MaxLength = 100;
            this.txtFTP.Name = "txtFTP";
            this.txtFTP.Size = new System.Drawing.Size(212, 21);
            this.txtFTP.TabIndex = 2;
            // 
            // txtTenantID
            // 
            this.txtTenantID.Location = new System.Drawing.Point(97, 216);
            this.txtTenantID.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenantID.MaxLength = 0;
            this.txtTenantID.Name = "txtTenantID";
            this.txtTenantID.Size = new System.Drawing.Size(144, 21);
            this.txtTenantID.TabIndex = 6;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(97, 242);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.txtDatabase.MaxLength = 40;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(144, 21);
            this.txtDatabase.TabIndex = 8;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(193, 49);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtServerName.MaxLength = 40;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(213, 21);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Server Name ";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(106, 172);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Live from";
            // 
            // txtFtpUserPwd
            // 
            this.txtFtpUserPwd.Location = new System.Drawing.Point(229, 143);
            this.txtFtpUserPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtFtpUserPwd.MaxLength = 40;
            this.txtFtpUserPwd.Name = "txtFtpUserPwd";
            this.txtFtpUserPwd.PasswordChar = '*';
            this.txtFtpUserPwd.Size = new System.Drawing.Size(144, 21);
            this.txtFtpUserPwd.TabIndex = 4;
            // 
            // txtFtpUserName
            // 
            this.txtFtpUserName.Location = new System.Drawing.Point(229, 119);
            this.txtFtpUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFtpUserName.MaxLength = 40;
            this.txtFtpUserName.Name = "txtFtpUserName";
            this.txtFtpUserName.Size = new System.Drawing.Size(144, 21);
            this.txtFtpUserName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(106, 147);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Ftp Password ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(106, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Ftp User Name ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(64, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 32);
            this.label13.TabIndex = 18;
            this.label13.Text = "ADSR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 61);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // dtLive
            // 
            this.dtLive.CustomFormat = "dd/MMM/yyyy";
            this.dtLive.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtLive.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLive.Location = new System.Drawing.Point(229, 168);
            this.dtLive.Margin = new System.Windows.Forms.Padding(2);
            this.dtLive.Name = "dtLive";
            this.dtLive.Size = new System.Drawing.Size(113, 21);
            this.dtLive.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(15, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 266);
            this.label1.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.Location = new System.Drawing.Point(21, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 14);
            this.label14.TabIndex = 20;
            this.label14.Text = "Tenant and DB Info";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(260, 219);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Brand";
            // 
            // txtbrand
            // 
            this.txtbrand.Location = new System.Drawing.Point(348, 216);
            this.txtbrand.Name = "txtbrand";
            this.txtbrand.Size = new System.Drawing.Size(144, 21);
            this.txtbrand.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Perpetua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(421, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 21);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTen
            // 
            this.dgvTen.AllowUserToAddRows = false;
            this.dgvTen.AllowUserToDeleteRows = false;
            this.dgvTen.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvTen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTen.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvTen.EnableHeadersVisualStyles = false;
            this.dgvTen.Location = new System.Drawing.Point(24, 327);
            this.dgvTen.Name = "dgvTen";
            this.dgvTen.ReadOnly = true;
            this.dgvTen.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTen.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvTen.RowHeadersVisible = false;
            this.dgvTen.Size = new System.Drawing.Size(468, 128);
            this.dgvTen.TabIndex = 13;
            this.dgvTen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTen_CellDoubleClick);
            // 
            // txtTerminalID
            // 
            this.txtTerminalID.Location = new System.Drawing.Point(348, 269);
            this.txtTerminalID.Margin = new System.Windows.Forms.Padding(2);
            this.txtTerminalID.MaxLength = 0;
            this.txtTerminalID.Name = "txtTerminalID";
            this.txtTerminalID.Size = new System.Drawing.Size(144, 21);
            this.txtTerminalID.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(260, 272);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Branch ID";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(523, 503);
            this.Controls.Add(this.txtTerminalID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvTen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbrand);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtLive);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFtpUserPwd);
            this.Controls.Add(this.txtFtpUserName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtTenantID);
            this.Controls.Add(this.txtFTP);
            this.Controls.Add(this.cboFrequency);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XtreMe Integra Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboFrequency;
        private System.Windows.Forms.TextBox txtFTP;
        private System.Windows.Forms.TextBox txtTenantID;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFtpUserPwd;
        private System.Windows.Forms.TextBox txtFtpUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtLive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtbrand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvTen;
        private System.Windows.Forms.TextBox txtTerminalID;
        private System.Windows.Forms.Label label12;
    }
}

