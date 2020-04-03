namespace Auth
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pbUserImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQRCode = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnEnterances = new System.Windows.Forms.Button();
            this.btnEventTypes = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.Events = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.chartEventsWeek = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cbSearch = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.chartPresence = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.charEventTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEventsWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPresence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charEventTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.sidePanel.Controls.Add(this.lblUserName);
            this.sidePanel.Controls.Add(this.pbUserImage);
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Controls.Add(this.btnQRCode);
            this.sidePanel.Controls.Add(this.btnLogOut);
            this.sidePanel.Controls.Add(this.btnEnterances);
            this.sidePanel.Controls.Add(this.btnEventTypes);
            this.sidePanel.Controls.Add(this.btnEvents);
            this.sidePanel.Controls.Add(this.btnRoles);
            this.sidePanel.Controls.Add(this.btnUsers);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 646);
            this.sidePanel.TabIndex = 0;
            this.sidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sidePanel_Paint);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(50, 119);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(102, 15);
            this.lblUserName.TabIndex = 12;
            this.lblUserName.Text = "Mirza Kurtovic";
            // 
            // pbUserImage
            // 
            this.pbUserImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.pbUserImage.Image = ((System.Drawing.Image)(resources.GetObject("pbUserImage.Image")));
            this.pbUserImage.Location = new System.Drawing.Point(50, 12);
            this.pbUserImage.Name = "pbUserImage";
            this.pbUserImage.Size = new System.Drawing.Size(100, 100);
            this.pbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserImage.TabIndex = 11;
            this.pbUserImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 52);
            this.button1.TabIndex = 10;
            this.button1.Text = "Face recognition setup";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnQRCode
            // 
            this.btnQRCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnQRCode.FlatAppearance.BorderSize = 0;
            this.btnQRCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQRCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnQRCode.ForeColor = System.Drawing.Color.White;
            this.btnQRCode.Location = new System.Drawing.Point(0, 441);
            this.btnQRCode.Name = "btnQRCode";
            this.btnQRCode.Size = new System.Drawing.Size(200, 52);
            this.btnQRCode.TabIndex = 9;
            this.btnQRCode.Text = "QR code setup";
            this.btnQRCode.UseVisualStyleBackColor = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(0, 594);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(200, 52);
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // btnEnterances
            // 
            this.btnEnterances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEnterances.FlatAppearance.BorderSize = 0;
            this.btnEnterances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterances.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEnterances.ForeColor = System.Drawing.Color.White;
            this.btnEnterances.Location = new System.Drawing.Point(0, 383);
            this.btnEnterances.Name = "btnEnterances";
            this.btnEnterances.Size = new System.Drawing.Size(200, 52);
            this.btnEnterances.TabIndex = 7;
            this.btnEnterances.Text = "Enterances";
            this.btnEnterances.UseVisualStyleBackColor = false;
            this.btnEnterances.Click += new System.EventHandler(this.btnEnterances_Click);
            // 
            // btnEventTypes
            // 
            this.btnEventTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEventTypes.FlatAppearance.BorderSize = 0;
            this.btnEventTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventTypes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEventTypes.ForeColor = System.Drawing.Color.White;
            this.btnEventTypes.Location = new System.Drawing.Point(0, 267);
            this.btnEventTypes.Name = "btnEventTypes";
            this.btnEventTypes.Size = new System.Drawing.Size(200, 52);
            this.btnEventTypes.TabIndex = 6;
            this.btnEventTypes.Text = "Event types";
            this.btnEventTypes.UseVisualStyleBackColor = false;
            this.btnEventTypes.Click += new System.EventHandler(this.btnEventTypes_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnEvents.FlatAppearance.BorderSize = 0;
            this.btnEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvents.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEvents.ForeColor = System.Drawing.Color.White;
            this.btnEvents.Location = new System.Drawing.Point(0, 151);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(200, 52);
            this.btnEvents.TabIndex = 5;
            this.btnEvents.Text = "Events";
            this.btnEvents.UseVisualStyleBackColor = false;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRoles.ForeColor = System.Drawing.Color.White;
            this.btnRoles.Location = new System.Drawing.Point(0, 325);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(200, 52);
            this.btnRoles.TabIndex = 4;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(0, 209);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(200, 52);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // Events
            // 
            this.Events.AutoSize = true;
            this.Events.Location = new System.Drawing.Point(249, -399);
            this.Events.Name = "Events";
            this.Events.Size = new System.Drawing.Size(45, 19);
            this.Events.TabIndex = 2;
            this.Events.Text = "Events";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(249, -551);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Attenddes";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(198, -518);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(16, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "5";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(272, -518);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(16, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "5";
            // 
            // chartEventsWeek
            // 
            chartArea4.Name = "ChartArea1";
            this.chartEventsWeek.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartEventsWeek.Legends.Add(legend4);
            this.chartEventsWeek.Location = new System.Drawing.Point(206, 413);
            this.chartEventsWeek.Name = "chartEventsWeek";
            this.chartEventsWeek.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Events";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Attendes";
            this.chartEventsWeek.Series.Add(series5);
            this.chartEventsWeek.Series.Add(series6);
            this.chartEventsWeek.Size = new System.Drawing.Size(786, 221);
            this.chartEventsWeek.TabIndex = 7;
            this.chartEventsWeek.Text = "chart2";
            this.chartEventsWeek.Click += new System.EventHandler(this.chartEventsWeek_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(236, 391);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(190, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "events sorted by weekdays";
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.ItemHeight = 23;
            this.cbSearch.Items.AddRange(new object[] {
            "All upcoming days",
            "Upcoming 1 day",
            "Upcoming 3 days",
            "Upcoming 7 days",
            "Upcoming 30 days",
            "Upcoming 60 days"});
            this.cbSearch.Location = new System.Drawing.Point(230, 65);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(173, 29);
            this.cbSearch.TabIndex = 10;
            this.cbSearch.SelectedValueChanged += new System.EventHandler(this.cbSearch_SelectedValueChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(230, 43);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(94, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "Show events in";
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(957, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 18;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(998, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(230, 101);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(101, 19);
            this.metroLabel7.TabIndex = 24;
            this.metroLabel7.Text = "user presence";
            // 
            // chartPresence
            // 
            chartArea5.Name = "ChartArea1";
            this.chartPresence.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartPresence.Legends.Add(legend5);
            this.chartPresence.Location = new System.Drawing.Point(230, 128);
            this.chartPresence.Name = "chartPresence";
            this.chartPresence.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(145)))), ((int)(((byte)(82))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))))};
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series7.Legend = "Legend1";
            series7.Name = "s1";
            this.chartPresence.Series.Add(series7);
            this.chartPresence.Size = new System.Drawing.Size(381, 220);
            this.chartPresence.TabIndex = 23;
            this.chartPresence.Text = "chart3";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(617, 101);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(154, 19);
            this.metroLabel5.TabIndex = 22;
            this.metroLabel5.Text = "events sorted by type";
            // 
            // charEventTypes
            // 
            chartArea6.Name = "ChartArea1";
            this.charEventTypes.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.charEventTypes.Legends.Add(legend6);
            this.charEventTypes.Location = new System.Drawing.Point(617, 128);
            this.charEventTypes.Name = "charEventTypes";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series8.Legend = "Legend1";
            series8.Name = "s1";
            this.charEventTypes.Series.Add(series8);
            this.charEventTypes.Size = new System.Drawing.Size(407, 220);
            this.charEventTypes.TabIndex = 21;
            this.charEventTypes.Text = "chart1";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 646);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.chartPresence);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.charEventTypes);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.chartEventsWeek);
            this.Controls.Add(this.Events);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Home_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Home_MouseDown);
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEventsWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPresence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charEventTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnRoles;
        private MetroFramework.Controls.MetroLabel Events;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Button btnEnterances;
        private System.Windows.Forms.Button btnEventTypes;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnQRCode;
        private System.Windows.Forms.PictureBox pbUserImage;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEventsWeek;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cbSearch;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPresence;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart charEventTypes;
    }
}

