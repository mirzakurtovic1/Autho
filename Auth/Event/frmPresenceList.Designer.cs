namespace Auth.Event
{
    partial class frmPresenceList
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
            this.btnFilter = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbRole = new MetroFramework.Controls.MetroComboBox();
            this.cbGroup = new MetroFramework.Controls.MetroComboBox();
            this.lblGroup = new MetroFramework.Controls.MetroLabel();
            this.cbMultiple = new MetroFramework.Controls.MetroCheckBox();
            this.txtFirstName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtUserName = new MetroFramework.Controls.MetroTextBox();
            this.dgvPresence = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendingEventDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.presenceBasicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblEventGroupId = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.panelMultipleDates = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cblDates = new System.Windows.Forms.CheckedListBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.presenceBasicBindingSource)).BeginInit();
            this.panelMultipleDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(23, 258);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(248, 29);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 97);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(35, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Role";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.ItemHeight = 23;
            this.cbRole.Location = new System.Drawing.Point(23, 121);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(121, 29);
            this.cbRole.TabIndex = 4;
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.ItemHeight = 23;
            this.cbGroup.Location = new System.Drawing.Point(150, 121);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(121, 29);
            this.cbGroup.TabIndex = 6;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(150, 97);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(46, 19);
            this.lblGroup.TabIndex = 5;
            this.lblGroup.Text = "Group";
            // 
            // cbMultiple
            // 
            this.cbMultiple.AutoSize = true;
            this.cbMultiple.Location = new System.Drawing.Point(23, 318);
            this.cbMultiple.Name = "cbMultiple";
            this.cbMultiple.Size = new System.Drawing.Size(362, 15);
            this.cbMultiple.TabIndex = 8;
            this.cbMultiple.Text = "Change presence on multiple events from the same event group";
            this.cbMultiple.UseVisualStyleBackColor = true;
            this.cbMultiple.CheckedChanged += new System.EventHandler(this.cbMultiple_CheckedChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(23, 173);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 23);
            this.txtFirstName.TabIndex = 9;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 151);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "First name";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(150, 151);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(150, 173);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 23);
            this.txtLastName.TabIndex = 11;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 197);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(72, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "User name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(23, 219);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 23);
            this.txtUserName.TabIndex = 13;
            // 
            // dgvPresence
            // 
            this.dgvPresence.AllowUserToAddRows = false;
            this.dgvPresence.AllowUserToDeleteRows = false;
            this.dgvPresence.AutoGenerateColumns = false;
            this.dgvPresence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresence.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.attendingEventDataGridViewCheckBoxColumn});
            this.dgvPresence.DataSource = this.presenceBasicBindingSource;
            this.dgvPresence.Location = new System.Drawing.Point(23, 337);
            this.dgvPresence.MultiSelect = false;
            this.dgvPresence.Name = "dgvPresence";
            this.dgvPresence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresence.Size = new System.Drawing.Size(557, 186);
            this.dgvPresence.TabIndex = 15;
            this.dgvPresence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresence_CellContentClick);
            this.dgvPresence.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresence_CellValueChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "First name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User name";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // attendingEventDataGridViewCheckBoxColumn
            // 
            this.attendingEventDataGridViewCheckBoxColumn.DataPropertyName = "AttendingEvent";
            this.attendingEventDataGridViewCheckBoxColumn.HeaderText = "Invited";
            this.attendingEventDataGridViewCheckBoxColumn.Name = "attendingEventDataGridViewCheckBoxColumn";
            // 
            // presenceBasicBindingSource
            // 
            this.presenceBasicBindingSource.DataSource = typeof(Model.presenceBasic);
            // 
            // lblEventGroupId
            // 
            this.lblEventGroupId.AutoSize = true;
            this.lblEventGroupId.Location = new System.Drawing.Point(116, 60);
            this.lblEventGroupId.Name = "lblEventGroupId";
            this.lblEventGroupId.Size = new System.Drawing.Size(15, 19);
            this.lblEventGroupId.TabIndex = 46;
            this.lblEventGroupId.Text = "-";
            this.lblEventGroupId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEventGroupId.Click += new System.EventHandler(this.metroLabel5_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 60);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(102, 19);
            this.metroLabel6.TabIndex = 45;
            this.metroLabel6.Text = "Event group Id: ";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel6.Click += new System.EventHandler(this.metroLabel6_Click);
            // 
            // panelMultipleDates
            // 
            this.panelMultipleDates.Controls.Add(this.label1);
            this.panelMultipleDates.Controls.Add(this.cblDates);
            this.panelMultipleDates.Controls.Add(this.metroLabel11);
            this.panelMultipleDates.Location = new System.Drawing.Point(325, 97);
            this.panelMultipleDates.Name = "panelMultipleDates";
            this.panelMultipleDates.Size = new System.Drawing.Size(255, 199);
            this.panelMultipleDates.TabIndex = 47;
            this.panelMultipleDates.Visible = false;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 53);
            this.label1.TabIndex = 39;
            this.label1.Text = "Changes to this event will be applied to all selected events(from same event grou" +
    "p)";
            // 
            // cblDates
            // 
            this.cblDates.FormattingEnabled = true;
            this.cblDates.Location = new System.Drawing.Point(7, 81);
            this.cblDates.Name = "cblDates";
            this.cblDates.Size = new System.Drawing.Size(215, 109);
            this.cblDates.TabIndex = 34;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(7, 59);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(75, 19);
            this.metroLabel11.TabIndex = 38;
            this.metroLabel11.Text = "Event dates";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPresenceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 532);
            this.Controls.Add(this.panelMultipleDates);
            this.Controls.Add(this.lblEventGroupId);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.dgvPresence);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.cbMultiple);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnFilter);
            this.Name = "frmPresenceList";
            this.Text = "Event presence";
            this.Load += new System.EventHandler(this.frmPresenceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.presenceBasicBindingSource)).EndInit();
            this.panelMultipleDates.ResumeLayout(false);
            this.panelMultipleDates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnFilter;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbRole;
        private MetroFramework.Controls.MetroComboBox cbGroup;
        private MetroFramework.Controls.MetroLabel lblGroup;
        private MetroFramework.Controls.MetroCheckBox cbMultiple;
        private MetroFramework.Controls.MetroTextBox txtFirstName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtUserName;
        private System.Windows.Forms.DataGridView dgvPresence;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn attendingEventDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource presenceBasicBindingSource;
        private MetroFramework.Controls.MetroLabel lblEventGroupId;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.Panel panelMultipleDates;
        private System.Windows.Forms.CheckedListBox cblDates;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private System.Windows.Forms.Label label1;
    }
}