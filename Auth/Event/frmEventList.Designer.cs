namespace Auth.Event
{
    partial class frmEventList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventList));
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventStartingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventEndingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anyoneCanEnterDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventGroupIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnFilter = new MetroFramework.Controls.MetroButton();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtpCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.cbType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNewEvent = new MetroFramework.Controls.MetroButton();
            this.cbOnlyFuture = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.AllowUserToOrderColumns = true;
            this.dgvEvents.AutoGenerateColumns = false;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEvents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEvents.ColumnHeadersHeight = 35;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.eventNameDataGridViewTextBoxColumn,
            this.eventDescriptionDataGridViewTextBoxColumn,
            this.eventDateDataGridViewTextBoxColumn,
            this.eventStartingTimeDataGridViewTextBoxColumn,
            this.eventEndingTimeDataGridViewTextBoxColumn,
            this.anyoneCanEnterDataGridViewCheckBoxColumn,
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn,
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn,
            this.eventTypeIdDataGridViewTextBoxColumn,
            this.eventGroupIdDataGridViewTextBoxColumn,
            this.eventTypeDataGridViewTextBoxColumn,
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn,
            this.eventTypeStringDataGridViewTextBoxColumn});
            this.dgvEvents.DataSource = this.eventBindingSource;
            this.dgvEvents.Location = new System.Drawing.Point(23, 222);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(762, 304);
            this.dgvEvents.TabIndex = 0;
            this.dgvEvents.DoubleClick += new System.EventHandler(this.dgvEvents_DoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventNameDataGridViewTextBoxColumn
            // 
            this.eventNameDataGridViewTextBoxColumn.DataPropertyName = "EventName";
            this.eventNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.eventNameDataGridViewTextBoxColumn.Name = "eventNameDataGridViewTextBoxColumn";
            this.eventNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // eventDescriptionDataGridViewTextBoxColumn
            // 
            this.eventDescriptionDataGridViewTextBoxColumn.DataPropertyName = "EventDescription";
            this.eventDescriptionDataGridViewTextBoxColumn.HeaderText = "EventDescription";
            this.eventDescriptionDataGridViewTextBoxColumn.Name = "eventDescriptionDataGridViewTextBoxColumn";
            this.eventDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventDescriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventDateDataGridViewTextBoxColumn
            // 
            this.eventDateDataGridViewTextBoxColumn.DataPropertyName = "EventDate";
            this.eventDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.eventDateDataGridViewTextBoxColumn.Name = "eventDateDataGridViewTextBoxColumn";
            this.eventDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventStartingTimeDataGridViewTextBoxColumn
            // 
            this.eventStartingTimeDataGridViewTextBoxColumn.DataPropertyName = "EventStartingTime";
            this.eventStartingTimeDataGridViewTextBoxColumn.HeaderText = "Starting time";
            this.eventStartingTimeDataGridViewTextBoxColumn.Name = "eventStartingTimeDataGridViewTextBoxColumn";
            this.eventStartingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventEndingTimeDataGridViewTextBoxColumn
            // 
            this.eventEndingTimeDataGridViewTextBoxColumn.DataPropertyName = "EventEndingTime";
            this.eventEndingTimeDataGridViewTextBoxColumn.HeaderText = "Ending time";
            this.eventEndingTimeDataGridViewTextBoxColumn.Name = "eventEndingTimeDataGridViewTextBoxColumn";
            this.eventEndingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anyoneCanEnterDataGridViewCheckBoxColumn
            // 
            this.anyoneCanEnterDataGridViewCheckBoxColumn.DataPropertyName = "AnyoneCanEnter";
            this.anyoneCanEnterDataGridViewCheckBoxColumn.HeaderText = "AnyoneCanEnter";
            this.anyoneCanEnterDataGridViewCheckBoxColumn.Name = "anyoneCanEnterDataGridViewCheckBoxColumn";
            this.anyoneCanEnterDataGridViewCheckBoxColumn.ReadOnly = true;
            this.anyoneCanEnterDataGridViewCheckBoxColumn.Visible = false;
            // 
            // userCanEnterBeforeEventMiDataGridViewTextBoxColumn
            // 
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn.DataPropertyName = "UserCanEnterBeforeEventMi";
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn.HeaderText = "UserCanEnterBeforeEventMi";
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn.Name = "userCanEnterBeforeEventMiDataGridViewTextBoxColumn";
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn.ReadOnly = true;
            this.userCanEnterBeforeEventMiDataGridViewTextBoxColumn.Visible = false;
            // 
            // userCanEnterAfterEventStaDataGridViewTextBoxColumn
            // 
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn.DataPropertyName = "UserCanEnterAfterEventSta";
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn.HeaderText = "UserCanEnterAfterEventSta";
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn.Name = "userCanEnterAfterEventStaDataGridViewTextBoxColumn";
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn.ReadOnly = true;
            this.userCanEnterAfterEventStaDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventTypeIdDataGridViewTextBoxColumn
            // 
            this.eventTypeIdDataGridViewTextBoxColumn.DataPropertyName = "EventTypeId";
            this.eventTypeIdDataGridViewTextBoxColumn.HeaderText = "EventTypeId";
            this.eventTypeIdDataGridViewTextBoxColumn.Name = "eventTypeIdDataGridViewTextBoxColumn";
            this.eventTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventGroupIdDataGridViewTextBoxColumn
            // 
            this.eventGroupIdDataGridViewTextBoxColumn.DataPropertyName = "EventGroupId";
            this.eventGroupIdDataGridViewTextBoxColumn.HeaderText = "EventGroupId";
            this.eventGroupIdDataGridViewTextBoxColumn.Name = "eventGroupIdDataGridViewTextBoxColumn";
            this.eventGroupIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventGroupIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventTypeDataGridViewTextBoxColumn
            // 
            this.eventTypeDataGridViewTextBoxColumn.DataPropertyName = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.HeaderText = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.Name = "eventTypeDataGridViewTextBoxColumn";
            this.eventTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventStartingTimeShortStringDataGridViewTextBoxColumn
            // 
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn.DataPropertyName = "EventStartingTimeShortString";
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn.HeaderText = "EventStartingTimeShortString";
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn.Name = "eventStartingTimeShortStringDataGridViewTextBoxColumn";
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventStartingTimeShortStringDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventTypeStringDataGridViewTextBoxColumn
            // 
            this.eventTypeStringDataGridViewTextBoxColumn.DataPropertyName = "EventTypeString";
            this.eventTypeStringDataGridViewTextBoxColumn.HeaderText = "Type";
            this.eventTypeStringDataGridViewTextBoxColumn.Name = "eventTypeStringDataGridViewTextBoxColumn";
            this.eventTypeStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(Model.Event);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 70);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Name";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(23, 193);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(143, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Refresh";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(23, 92);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 29);
            this.txtName.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(23, 145);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(101, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 123);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(36, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Date";
            // 
            // dtpCheckBox
            // 
            this.dtpCheckBox.AutoSize = true;
            this.dtpCheckBox.Location = new System.Drawing.Point(130, 148);
            this.dtpCheckBox.Name = "dtpCheckBox";
            this.dtpCheckBox.Size = new System.Drawing.Size(68, 15);
            this.dtpCheckBox.TabIndex = 6;
            this.dtpCheckBox.Text = " Enabled";
            this.dtpCheckBox.UseVisualStyleBackColor = true;
            this.dtpCheckBox.CheckedChanged += new System.EventHandler(this.dtpCheckBox_CheckedChanged);
            // 
            // cbType
            // 
            this.cbType.DropDownWidth = 121;
            this.cbType.FormattingEnabled = true;
            this.cbType.ItemHeight = 23;
            this.cbType.Location = new System.Drawing.Point(150, 92);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 29);
            this.cbType.TabIndex = 7;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(150, 70);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(36, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Type";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(642, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnNewEvent
            // 
            this.btnNewEvent.Location = new System.Drawing.Point(642, 193);
            this.btnNewEvent.Name = "btnNewEvent";
            this.btnNewEvent.Size = new System.Drawing.Size(143, 23);
            this.btnNewEvent.Style = MetroFramework.MetroColorStyle.Green;
            this.btnNewEvent.TabIndex = 12;
            this.btnNewEvent.Text = "Add new event";
            this.btnNewEvent.Click += new System.EventHandler(this.btnNewEvent_Click);
            // 
            // cbOnlyFuture
            // 
            this.cbOnlyFuture.AutoSize = true;
            this.cbOnlyFuture.Checked = true;
            this.cbOnlyFuture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnlyFuture.Location = new System.Drawing.Point(23, 173);
            this.cbOnlyFuture.Name = "cbOnlyFuture";
            this.cbOnlyFuture.Size = new System.Drawing.Size(150, 15);
            this.cbOnlyFuture.TabIndex = 13;
            this.cbOnlyFuture.Text = "Show only future events";
            this.cbOnlyFuture.UseVisualStyleBackColor = true;
            // 
            // frmEventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 539);
            this.Controls.Add(this.cbOnlyFuture);
            this.Controls.Add(this.btnNewEvent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.dtpCheckBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dgvEvents);
            this.Name = "frmEventList";
            this.Text = "Events";
            this.Load += new System.EventHandler(this.frmEventList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvents;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnFilter;
        private MetroFramework.Controls.MetroTextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox dtpCheckBox;
        private MetroFramework.Controls.MetroComboBox cbType;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventStartingTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventEndingTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn anyoneCanEnterDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userCanEnterBeforeEventMiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userCanEnterAfterEventStaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventGroupIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventStartingTimeShortStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeStringDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroButton btnNewEvent;
        private MetroFramework.Controls.MetroCheckBox cbOnlyFuture;
    }
}