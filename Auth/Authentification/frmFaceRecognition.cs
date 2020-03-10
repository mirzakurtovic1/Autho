using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth.Authentification
{
    //https://www.youtube.com/watch?v=1xcYl44q110
    public partial class frmFaceRecognition : Form
    {

        private FilterInfoCollection CaptureDevice { get; set; }
        private VideoCaptureDevice FinalFrame { get; set; }


        public VideoCapture WebCam { get; set; }
        public EigenFaceRecognizer FaceRecognition { get; set; }
        public CascadeClassifier FaceDetection { get; set; }
        public CascadeClassifier EyeDetection { get; set; }

        public Mat Frame { get; set; }

        public List<Image<Gray, byte>> Faces; 
        public List<int> IDs { get; set; }
        public int NumberOfTestImages { get; set; } = 0;
        public int NumberOfUserImages { get; set; } = 0;
        public const int ProcessedImageWidth = 100;
        public const int ProcessedImageHeight = 100;
        

        public int TimerCounter { get; set; } = 0;
        public int TimerLimit { get; set; } = 0;

        public string YMLPath { get; set; } = @"../../data/trainingData.yml";

        public Timer Timer { get; set; }
        public bool FaceSquare { get; set; } = true;
        public bool EyeSquare { get; set; } = false;

        public frmFaceRecognition()
        {
            InitializeComponent();
            WebCam = new VideoCapture(2);
            #region camera
            pbWebCam.SizeMode = PictureBoxSizeMode.StretchImage;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            #endregion camera
            #region initialization
            FaceDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Authentification/data/haarcascade_frontalface_default.xml"));
            EyeDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Authentification/data/haarcascade_eye.xml"));
            FaceRecognition = new EigenFaceRecognizer();
            Frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            IDs = new List<int>();
            #endregion initialization


            #region eigen_list
            try
            {
                //Loading previously added images(negativ results)
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                var labels = Labelsinfo.Split('%');
                foreach (string label in labels)
                    IDs.Add(Convert.ToInt32(label));
                IDs.RemoveAt(0);
                NumberOfTestImages = Convert.ToInt16(labels[0]);

                string faceString = "";
                for (int i = 1; i < NumberOfTestImages + 1; i++)
                {
                    faceString = "face" + i + ".bmp";
                    Faces.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + faceString));
                }

            }
            catch (Exception e)
            {             
                MessageBox.Show("Error with loading data static data", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            //FaceRecognition = new EigenFaceRecognizer(
            //    Faces.ToArray(),
            //    IDs.ToArray(),
            //    3000,
            //    double.PositiveInfinity
            //    );
      

                var arrayLength = Faces.Count;

            //Image<Gray, byte>[] facesArray = Faces.ToArray();
            //int[] IDsArray = IDs.ToArray();


            Mat[] mats = new Mat[Faces.Count];
            int[] newIds = new int[Faces.Count];
            for (int i = 0; i < Faces.Count; i++)
            {
                mats[i] = Faces[i].Mat;
                newIds[i] = IDs[i];
            }

            FaceRecognition.Train(mats, newIds);
            var result = FaceRecognition.Predict(mats[0]);
            


            #endregion eigen_list



            StartCamera();
        }

        private void StartCamera()
        {
            if (WebCam == null)
                WebCam = new VideoCapture();

            WebCam.ImageGrabbed += WebCam_ImageGrabbed;
            WebCam.Start();

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                if (comboBox1.SelectedIndex >= 0)
                {
                    FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
                    FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                    FinalFrame.Start();
                }
                else
                    MessageBox.Show("Camera required!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //beep if possible.//change message if possible
            }
            else
                MessageBox.Show("Camera required!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //beep if possible.//change message if possible



            txtOutput.AppendText("Webcam started \n\t");
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var videoFrame = eventArgs.Frame.Clone() as Bitmap;
            

            var Analyzeframe =new Image<Bgr, byte>(videoFrame);

            if (Analyzeframe != null)
            {
                var grayFrame = Analyzeframe.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);
                var eyes = EyeDetection.DetectMultiScale(grayFrame, 1.1, 5);

                if (FaceSquare == true)
                    foreach (var face in faces)
                        Analyzeframe.Draw(face, new Bgr(Color.Red), 3);

                if (EyeSquare == true)
                    foreach (var eye in eyes)
                        Analyzeframe.Draw(eye, new Bgr(Color.Blue), 3);

                pbWebCam.Image = Analyzeframe.ToBitmap();
            }
        }
        private void WebCam_ImageGrabbed(object sender, EventArgs e)
        {

        }

        private void frmFaceRecognition_Load(object sender, EventArgs e)
        {

        }

        private void frmFaceRecognition_FormClosed(object sender, FormClosedEventArgs e)
        {
            FinalFrame.Stop();
            FinalFrame = null;
        }

        private void recognition_interval_Tick(object sender, EventArgs e)
        {

        }
    }
}
