namespace Auth
{
    partial class frmUsers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.txtFirstName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtUserName = new MetroFramework.Controls.MetroTextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.dtpAccountCreationDate = new System.Windows.Forms.DateTimePicker();
            this.cbRole = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.txtImageSource = new MetroFramework.Controls.MetroTextBox();
            this.btnUploadImage = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.btnChangePassword = new MetroFramework.Controls.MetroButton();
            this.btnGeneratePassword = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbQrCode = new System.Windows.Forms.PictureBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(23, 84);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(135, 23);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 62);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(70, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "First name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 108);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(23, 130);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(135, 23);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 154);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "User name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(23, 176);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(135, 23);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(23, 221);
            this.dtpBirthDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpBirthDate.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(135, 20);
            this.dtpBirthDate.TabIndex = 6;
            this.dtpBirthDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBirthDate_Validating);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(21, 199);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(67, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Birth date";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(21, 242);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(137, 19);
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Account creation date";
            // 
            // dtpAccountCreationDate
            // 
            this.dtpAccountCreationDate.Enabled = false;
            this.dtpAccountCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccountCreationDate.Location = new System.Drawing.Point(23, 264);
            this.dtpAccountCreationDate.Name = "dtpAccountCreationDate";
            this.dtpAccountCreationDate.Size = new System.Drawing.Size(135, 20);
            this.dtpAccountCreationDate.TabIndex = 8;
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.ItemHeight = 23;
            this.cbRole.Location = new System.Drawing.Point(23, 353);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(135, 29);
            this.cbRole.TabIndex = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 331);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(35, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "Role";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(23, 388);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(137, 31);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit changes";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pbImage
            // 
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(221, 84);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(128, 128);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 14;
            this.pbImage.TabStop = false;
            this.pbImage.Validating += new System.ComponentModel.CancelEventHandler(this.pbImage_Validating);
            // 
            // txtImageSource
            // 
            this.txtImageSource.Location = new System.Drawing.Point(221, 218);
            this.txtImageSource.Name = "txtImageSource";
            this.txtImageSource.ReadOnly = true;
            this.txtImageSource.Size = new System.Drawing.Size(128, 23);
            this.txtImageSource.TabIndex = 15;
            this.txtImageSource.Validating += new System.ComponentModel.CancelEventHandler(this.txtImageSource_Validating);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(221, 247);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(128, 27);
            this.btnUploadImage.TabIndex = 16;
            this.btnUploadImage.Text = "Upload image";
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(23, 286);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(63, 19);
            this.metroLabel8.TabIndex = 19;
            this.metroLabel8.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(23, 308);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(135, 23);
            this.txtPassword.TabIndex = 18;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Enabled = false;
            this.btnChangePassword.Location = new System.Drawing.Point(283, 308);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(113, 23);
            this.btnChangePassword.TabIndex = 23;
            this.btnChangePassword.Text = "change password";
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Enabled = false;
            this.btnGeneratePassword.Location = new System.Drawing.Point(164, 308);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(113, 23);
            this.btnGeneratePassword.TabIndex = 24;
            this.btnGeneratePassword.Text = "generate password";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbQrCode
            // 
            this.pbQrCode.Image = ((System.Drawing.Image)(resources.GetObject("pbQrCode.Image")));
            this.pbQrCode.Location = new System.Drawing.Point(366, 63);
            this.pbQrCode.Name = "pbQrCode";
            this.pbQrCode.Size = new System.Drawing.Size(170, 170);
            this.pbQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQrCode.TabIndex = 25;
            this.pbQrCode.TabStop = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(388, 214);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(55, 19);
            this.metroLabel7.TabIndex = 26;
            this.metroLabel7.Text = "qr code";
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(559, 434);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.pbQrCode);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.txtImageSource);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.dtpAccountCreationDate);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtFirstName);
            this.Name = "frmUsers";
            this.Text = "User detailes";
            this.TransparencyKey = System.Drawing.Color.Lavender;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsers_FormClosing);
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtFirstName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtUserName;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.DateTimePicker dtpAccountCreationDate;
        private MetroFramework.Controls.MetroComboBox cbRole;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btnSubmit;
        private System.Windows.Forms.PictureBox pbImage;
        private MetroFramework.Controls.MetroTextBox txtImageSource;
        private MetroFramework.Controls.MetroButton btnUploadImage;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroButton btnChangePassword;
        private MetroFramework.Controls.MetroButton btnGeneratePassword;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbQrCode;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}