namespace Auth.Authentification
{
    partial class frmFaceRecognition
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
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.pbWebCam = new System.Windows.Forms.PictureBox();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.recognition_interval = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(508, 146);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(171, 150);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // pbWebCam
            // 
            this.pbWebCam.Location = new System.Drawing.Point(44, 88);
            this.pbWebCam.Name = "pbWebCam";
            this.pbWebCam.Size = new System.Drawing.Size(349, 247);
            this.pbWebCam.TabIndex = 1;
            this.pbWebCam.TabStop = false;
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Location = new System.Drawing.Point(508, 312);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(75, 23);
            this.btnStartCamera.TabIndex = 2;
            this.btnStartCamera.Text = "button1";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(508, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // recognition_interval
            // 
            this.recognition_interval.Interval = 250;
            this.recognition_interval.Tick += new System.EventHandler(this.recognition_interval_Tick);
            // 
            // frmFaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnStartCamera);
            this.Controls.Add(this.pbWebCam);
            this.Controls.Add(this.txtOutput);
            this.Name = "frmFaceRecognition";
            this.Text = "frmFaceRecognition";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFaceRecognition_FormClosed);
            this.Load += new System.EventHandler(this.frmFaceRecognition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.PictureBox pbWebCam;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer recognition_interval;
    }
}