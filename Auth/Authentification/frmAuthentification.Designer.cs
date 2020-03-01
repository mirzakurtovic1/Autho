namespace Auth.Authentification
{
    partial class frmAuthentification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthentification));
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtUser = new MetroFramework.Controls.MetroTextBox();
            this.btnCameraStart = new MetroFramework.Controls.MetroButton();
            this.btnAddTrainingData = new MetroFramework.Controls.MetroButton();
            this.btnStartRecognition = new MetroFramework.Controls.MetroButton();
            this.pbNewUser = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCamera
            // 
            this.pbCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbCamera.Location = new System.Drawing.Point(8, 63);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(407, 331);
            this.pbCamera.TabIndex = 0;
            this.pbCamera.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(421, 253);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(35, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(421, 275);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(127, 23);
            this.txtUser.TabIndex = 2;
            // 
            // btnCameraStart
            // 
            this.btnCameraStart.Location = new System.Drawing.Point(421, 63);
            this.btnCameraStart.Name = "btnCameraStart";
            this.btnCameraStart.Size = new System.Drawing.Size(126, 23);
            this.btnCameraStart.TabIndex = 3;
            this.btnCameraStart.Text = "camera start/stop";
            this.btnCameraStart.Click += new System.EventHandler(this.btnCameraStart_Click);
            // 
            // btnAddTrainingData
            // 
            this.btnAddTrainingData.Location = new System.Drawing.Point(421, 92);
            this.btnAddTrainingData.Name = "btnAddTrainingData";
            this.btnAddTrainingData.Size = new System.Drawing.Size(126, 23);
            this.btnAddTrainingData.TabIndex = 4;
            this.btnAddTrainingData.Text = "add training/data";
            // 
            // btnStartRecognition
            // 
            this.btnStartRecognition.Location = new System.Drawing.Point(421, 121);
            this.btnStartRecognition.Name = "btnStartRecognition";
            this.btnStartRecognition.Size = new System.Drawing.Size(126, 23);
            this.btnStartRecognition.TabIndex = 5;
            this.btnStartRecognition.Text = "start face recognition";
            // 
            // pbNewUser
            // 
            this.pbNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbNewUser.Image = ((System.Drawing.Image)(resources.GetObject("pbNewUser.Image")));
            this.pbNewUser.Location = new System.Drawing.Point(421, 150);
            this.pbNewUser.Name = "pbNewUser";
            this.pbNewUser.Size = new System.Drawing.Size(107, 101);
            this.pbNewUser.TabIndex = 7;
            this.pbNewUser.TabStop = false;
            // 
            // frmAuthentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 406);
            this.Controls.Add(this.pbNewUser);
            this.Controls.Add(this.btnStartRecognition);
            this.Controls.Add(this.btnAddTrainingData);
            this.Controls.Add(this.btnCameraStart);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pbCamera);
            this.Name = "frmAuthentification";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.frmAuthorization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCamera;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtUser;
        private MetroFramework.Controls.MetroButton btnCameraStart;
        private MetroFramework.Controls.MetroButton btnAddTrainingData;
        private MetroFramework.Controls.MetroButton btnStartRecognition;
        private System.Windows.Forms.PictureBox pbNewUser;
    }
}