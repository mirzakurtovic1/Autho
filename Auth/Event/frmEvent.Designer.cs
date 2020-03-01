namespace Auth.Event
{
    partial class frmEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvent));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartingTime = new System.Windows.Forms.DateTimePicker();
            this.numUserCanEnterBefore = new System.Windows.Forms.NumericUpDown();
            this.numUserCanEnterAfter = new System.Windows.Forms.NumericUpDown();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.cbEveryoneCanEnter = new MetroFramework.Controls.MetroCheckBox();
            this.btnSumbit = new MetroFramework.Controls.MetroButton();
            this.btnViewAttendees = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbEventMaster = new MetroFramework.Controls.MetroComboBox();
            this.btnViewQRCode = new MetroFramework.Controls.MetroButton();
            this.cbEventType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.dtpEndingTime = new System.Windows.Forms.DateTimePicker();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnStartEvent = new MetroFramework.Controls.MetroButton();
            this.btnEnforceFaceDetection = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUserCanEnterBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUserCanEnterAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(23, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(23, 139);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(322, 88);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "Event description";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 117);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Description";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(26, 338);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(36, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Date";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(26, 381);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(85, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Starting time";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(26, 512);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(253, 19);
            this.metroLabel8.TabIndex = 12;
            this.metroLabel8.Text = "minutes user can enter before event starts";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(27, 360);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(155, 20);
            this.dtpDate.TabIndex = 13;
            // 
            // dtpStartingTime
            // 
            this.dtpStartingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartingTime.Location = new System.Drawing.Point(27, 403);
            this.dtpStartingTime.Name = "dtpStartingTime";
            this.dtpStartingTime.ShowUpDown = true;
            this.dtpStartingTime.Size = new System.Drawing.Size(155, 20);
            this.dtpStartingTime.TabIndex = 14;
            // 
            // numUserCanEnterBefore
            // 
            this.numUserCanEnterBefore.Location = new System.Drawing.Point(27, 534);
            this.numUserCanEnterBefore.Name = "numUserCanEnterBefore";
            this.numUserCanEnterBefore.Size = new System.Drawing.Size(155, 20);
            this.numUserCanEnterBefore.TabIndex = 15;
            // 
            // numUserCanEnterAfter
            // 
            this.numUserCanEnterAfter.Location = new System.Drawing.Point(27, 578);
            this.numUserCanEnterAfter.Name = "numUserCanEnterAfter";
            this.numUserCanEnterAfter.Size = new System.Drawing.Size(155, 20);
            this.numUserCanEnterAfter.TabIndex = 17;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(26, 556);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(241, 19);
            this.metroLabel9.TabIndex = 16;
            this.metroLabel9.Text = "minutes user can enter after event starts";
            // 
            // cbEveryoneCanEnter
            // 
            this.cbEveryoneCanEnter.AutoSize = true;
            this.cbEveryoneCanEnter.Location = new System.Drawing.Point(27, 474);
            this.cbEveryoneCanEnter.Name = "cbEveryoneCanEnter";
            this.cbEveryoneCanEnter.Size = new System.Drawing.Size(123, 15);
            this.cbEveryoneCanEnter.TabIndex = 18;
            this.cbEveryoneCanEnter.Text = "Everyone can enter";
            this.cbEveryoneCanEnter.UseVisualStyleBackColor = true;
            // 
            // btnSumbit
            // 
            this.btnSumbit.Location = new System.Drawing.Point(26, 604);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(156, 29);
            this.btnSumbit.TabIndex = 20;
            this.btnSumbit.Text = "Submit changes";
            this.btnSumbit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // btnViewAttendees
            // 
            this.btnViewAttendees.Location = new System.Drawing.Point(188, 604);
            this.btnViewAttendees.Name = "btnViewAttendees";
            this.btnViewAttendees.Size = new System.Drawing.Size(156, 29);
            this.btnViewAttendees.TabIndex = 21;
            this.btnViewAttendees.Text = "view/add attendees";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(373, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 271);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(24, 233);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(84, 19);
            this.metroLabel5.TabIndex = 23;
            this.metroLabel5.Text = "Event master";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEventMaster
            // 
            this.cbEventMaster.FormattingEnabled = true;
            this.cbEventMaster.ItemHeight = 23;
            this.cbEventMaster.Location = new System.Drawing.Point(24, 255);
            this.cbEventMaster.Name = "cbEventMaster";
            this.cbEventMaster.Size = new System.Drawing.Size(158, 29);
            this.cbEventMaster.TabIndex = 24;
            this.cbEventMaster.SelectedIndexChanged += new System.EventHandler(this.cbEventMaster_SelectedIndexChanged);
            // 
            // btnViewQRCode
            // 
            this.btnViewQRCode.Location = new System.Drawing.Point(188, 639);
            this.btnViewQRCode.Name = "btnViewQRCode";
            this.btnViewQRCode.Size = new System.Drawing.Size(156, 29);
            this.btnViewQRCode.TabIndex = 25;
            this.btnViewQRCode.Text = "view qr code";
            // 
            // cbEventType
            // 
            this.cbEventType.FormattingEnabled = true;
            this.cbEventType.ItemHeight = 23;
            this.cbEventType.Location = new System.Drawing.Point(23, 307);
            this.cbEventType.Name = "cbEventType";
            this.cbEventType.Size = new System.Drawing.Size(159, 29);
            this.cbEventType.TabIndex = 27;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(26, 285);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(69, 19);
            this.metroLabel7.TabIndex = 26;
            this.metroLabel7.Text = "Event type";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEndingTime
            // 
            this.dtpEndingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndingTime.Location = new System.Drawing.Point(27, 448);
            this.dtpEndingTime.Name = "dtpEndingTime";
            this.dtpEndingTime.ShowUpDown = true;
            this.dtpEndingTime.Size = new System.Drawing.Size(155, 20);
            this.dtpEndingTime.TabIndex = 29;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(26, 426);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(79, 19);
            this.metroLabel6.TabIndex = 28;
            this.metroLabel6.Text = "Ending time";
            // 
            // btnStartEvent
            // 
            this.btnStartEvent.Location = new System.Drawing.Point(26, 639);
            this.btnStartEvent.Name = "btnStartEvent";
            this.btnStartEvent.Size = new System.Drawing.Size(156, 29);
            this.btnStartEvent.TabIndex = 30;
            this.btnStartEvent.Text = "Start event";
            this.btnStartEvent.Click += new System.EventHandler(this.btnStartEvent_Click);
            // 
            // btnEnforceFaceDetection
            // 
            this.btnEnforceFaceDetection.AutoSize = true;
            this.btnEnforceFaceDetection.Location = new System.Drawing.Point(27, 495);
            this.btnEnforceFaceDetection.Name = "btnEnforceFaceDetection";
            this.btnEnforceFaceDetection.Size = new System.Drawing.Size(141, 15);
            this.btnEnforceFaceDetection.TabIndex = 31;
            this.btnEnforceFaceDetection.Text = "Enforce face detection";
            this.btnEnforceFaceDetection.UseVisualStyleBackColor = true;
            // 
            // frmEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 711);
            this.Controls.Add(this.btnEnforceFaceDetection);
            this.Controls.Add(this.btnStartEvent);
            this.Controls.Add(this.dtpEndingTime);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cbEventType);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.btnViewQRCode);
            this.Controls.Add(this.cbEventMaster);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnViewAttendees);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.cbEveryoneCanEnter);
            this.Controls.Add(this.numUserCanEnterAfter);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.numUserCanEnterBefore);
            this.Controls.Add(this.dtpStartingTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmEvent";
            this.Text = "Event detailes";
            this.Load += new System.EventHandler(this.frmEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUserCanEnterBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUserCanEnterAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpStartingTime;
        private System.Windows.Forms.NumericUpDown numUserCanEnterBefore;
        private System.Windows.Forms.NumericUpDown numUserCanEnterAfter;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroCheckBox cbEveryoneCanEnter;
        private MetroFramework.Controls.MetroButton btnSumbit;
        private MetroFramework.Controls.MetroButton btnViewAttendees;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbEventMaster;
        private MetroFramework.Controls.MetroButton btnViewQRCode;
        private MetroFramework.Controls.MetroComboBox cbEventType;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.DateTimePicker dtpEndingTime;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btnStartEvent;
        private MetroFramework.Controls.MetroCheckBox btnEnforceFaceDetection;
    }
}