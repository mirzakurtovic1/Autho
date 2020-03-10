namespace Auth.Event
{
    partial class frmPresenceFinal
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
            this.lblEventGroupId = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtUserName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtFirstName = new MetroFramework.Controls.MetroTextBox();
            this.cbGroup = new MetroFramework.Controls.MetroComboBox();
            this.lblGroup = new MetroFramework.Controls.MetroLabel();
            this.cbRole = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnFilter = new MetroFramework.Controls.MetroButton();
            this.dgvPresence = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresence)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEventGroupId
            // 
            this.lblEventGroupId.AutoSize = true;
            this.lblEventGroupId.Location = new System.Drawing.Point(116, 60);
            this.lblEventGroupId.Name = "lblEventGroupId";
            this.lblEventGroupId.Size = new System.Drawing.Size(15, 19);
            this.lblEventGroupId.TabIndex = 59;
            this.lblEventGroupId.Text = "-";
            this.lblEventGroupId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 60);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(102, 19);
            this.metroLabel6.TabIndex = 58;
            this.metroLabel6.Text = "Event group Id: ";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 197);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(72, 19);
            this.metroLabel4.TabIndex = 57;
            this.metroLabel4.Text = "User name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(23, 219);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 23);
            this.txtUserName.TabIndex = 56;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(150, 151);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 55;
            this.metroLabel3.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(150, 173);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 23);
            this.txtLastName.TabIndex = 54;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 151);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 19);
            this.metroLabel2.TabIndex = 53;
            this.metroLabel2.Text = "First name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(23, 173);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 23);
            this.txtFirstName.TabIndex = 52;
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.ItemHeight = 23;
            this.cbGroup.Location = new System.Drawing.Point(150, 121);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(121, 29);
            this.cbGroup.TabIndex = 51;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(150, 97);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(46, 19);
            this.lblGroup.TabIndex = 50;
            this.lblGroup.Text = "Group";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.ItemHeight = 23;
            this.cbRole.Location = new System.Drawing.Point(23, 121);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(121, 29);
            this.cbRole.TabIndex = 49;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 97);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(35, 19);
            this.metroLabel1.TabIndex = 48;
            this.metroLabel1.Text = "Role";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(23, 258);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(248, 29);
            this.btnFilter.TabIndex = 47;
            this.btnFilter.Text = "Filter";
            // 
            // dgvPresence
            // 
            this.dgvPresence.AllowUserToAddRows = false;
            this.dgvPresence.AllowUserToDeleteRows = false;
            this.dgvPresence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresence.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresence.Location = new System.Drawing.Point(23, 321);
            this.dgvPresence.MultiSelect = false;
            this.dgvPresence.Name = "dgvPresence";
            this.dgvPresence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresence.Size = new System.Drawing.Size(737, 254);
            this.dgvPresence.TabIndex = 60;
            // 
            // frmPresenceFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 598);
            this.Controls.Add(this.dgvPresence);
            this.Controls.Add(this.lblEventGroupId);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnFilter);
            this.Name = "frmPresenceFinal";
            this.Text = "Event presence";
            this.Load += new System.EventHandler(this.frmPresenceFinal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblEventGroupId;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtUserName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtFirstName;
        private MetroFramework.Controls.MetroComboBox cbGroup;
        private MetroFramework.Controls.MetroLabel lblGroup;
        private MetroFramework.Controls.MetroComboBox cbRole;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnFilter;
        private System.Windows.Forms.DataGridView dgvPresence;
    }
}