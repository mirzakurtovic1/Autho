using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AuthoWeb;
using Emgu.CV.Structure;
using Emgu.CV;
using System.IO;
using Model.SearchRequest;
using Emgu.CV.Face;
using Model.InsertRequests;

namespace Auth.Authentification
{
    enum action { idle,qr_recognition,face_detection,face_recognition,saving};


    public partial class frmAuth : MetroForm
    {
        #region variables
        //current event
        private Model.Event Event = null;
        private int? eventId = null;
        //camera stuff
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        //qr code coder-decoder
        private QRCodeHelper QRCodeHelper = new QRCodeHelper();
        //current form action
        private action act = action.idle;
        //api services
        APIService apiService_AuthUser = new APIService("AuthUser");
        APIService apiService_Event = new APIService("Event");
        APIService apiService_Presence = new APIService("Presence");
        APIService apiService_AuthUserFace = new APIService("AuthUserFaces");
        //face detection
        CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");
        //eigenface recognition
        public EigenFaceRecognizer FaceRecognition { get; set; }
        //face detection
        public CascadeClassifier FaceDetection { get; set; }
        //current video frame for face detection-recognition
        public Mat Frame { get; set; }
        //list of faces for eigen training
        public List<Image<Gray, byte>> Faces;
        //list of Ids for eigen training
        public List<int> IDs { get; set; }
        //Number of images requiered
        public int NumberOfTestImages { get; set; } = 21;
        public int NumberOfUserImages { get; set; } = 10;
        public bool AddedCurrentUserImages { get; set; } = false;
        //wanted image height and width
        public const int ProcessedImageWidth = 100;
        public const int ProcessedImageHeight = 100;
        //current user
        Model.AuthUser user = null;
        //current user presence
        Model.Presence presence = null;
        //unknown images file path
        public string YMLPath { get; set; } = @"../../data/trainingData.yml";
        //debug
        int numberBefore = 0;
        int numberAfter = 0;
        int ticks = 0;
        //face recognition timer
        public bool EigenTrained { get; set; } = false;
        public int FaceRecognitionTicks { get; set; } = 0;
        public int FaceRecognitionTotalTicks { get; set; } = 0;
        public int TimerCounter { get; set; } = 0;
        public int TimerLimit { get; set; } = 0;
        public Timer Timer { get; set; }
        public bool FaceSquare { get; set; } = true;
        public bool EyeSquare { get; set; } = false;
        #endregion variables


        public frmAuth(int? eventId = 20)
        {
            InitializeComponent();

            #region camera
            pbCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                cbCamera.Items.Add(Device.Name);
            }
            #endregion camera

            #region initialization
            if (eventId != null)
                this.eventId = eventId;

            //FaceDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Authentification/data/haarcascade_frontalface_default.xml"));
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

            var arrayLength = Faces.Count;
            NumberOfTestImages = arrayLength;
            Mat[] mats = new Mat[Faces.Count];
            int[] newIds = new int[Faces.Count];
            for (int i = 0; i < Faces.Count; i++)
            {
                mats[i] = Faces[i].Mat;
                newIds[i] = IDs[i];
            }
            //FaceRecognition.Train(mats, newIds);
            //var result = FaceRecognition.Predict(mats[0]);
            #endregion eigen_list

        }

        private async void frmAuth_Load(object sender, EventArgs e)
        {
            if (this.eventId != null)
            {
                this.Event = await apiService_Event.GetById<Model.Event>(eventId);
                lblEvent.Text = Event.EventName;
            }
            else
                lblEvent.Text = "None";
        }

        #region stuff

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }
        #endregion stuff

        #region camera start stop
        private void btnCameraStart_Click(object sender, EventArgs e)
        {
            if (cbCamera.Items.Count > 0)
            {
                if (cbCamera.SelectedIndex >= 0)
                {
                    FinalFrame = new VideoCaptureDevice(CaptureDevice[cbCamera.SelectedIndex].MonikerString);
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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (FinalFrame != null)
                if (FinalFrame.IsRunning == true)
                    FinalFrame.Stop();
        }

        private void frmAuth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame != null)
                if (FinalFrame.IsRunning == true)
                    FinalFrame.Stop();
        }










        #endregion camera start stop

        #region camera new frame
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var videoFrame = eventArgs.Frame.Clone() as Bitmap;
            pbCamera.Image = videoFrame;


        }
        #endregion camera new frame

        #region qr code recognition
        private async Task<Model.AuthUser> readQR(Image img,APIService apiService)
        {
            var result = QRCodeHelper.DecodeQRCode(img);

            if (result != string.Empty)
            {
                var search = new Model.SearchRequest.AuthUserSearchRequest() { qrCode = result };
                var user = await apiService.Get<List<Model.AuthUser>>(search);
                if(user.Count>0)
                return user[0];
            }
            return null;
        }
        #endregion qr code recognition

        #region face detection

        private Rectangle? detectFace(Image<Gray, Byte> img)
        {

            Rectangle[] facesDetected = face.DetectMultiScale(
            img,
            1.2,
            10,
            new Size(20, 20));

            if(facesDetected.Length > 0)
                return facesDetected[0];
            return null;
        }

        #endregion face detection

        #region face recognition

        //private async Task<int?> recognizeFace(Image<Gray, Byte> img,int AuthUserId)
        //{
            
        //    if (AddedCurrentUserImages == false)
        //    {
        //        AddedCurrentUserImages = true;
        //        var search = new AuthUserFaceSearchRequest() { AuthUserId = AuthUserId };
        //        var AuthUserFaces = await apiService_AuthUserFace.Get<List<Model.AuthUserFace>>(search);
        //        int counter=0;
        //        int totalImages = Faces.Count + AuthUserFaces.Count;
        //        Mat[] mats = new Mat[totalImages];
        //        int[] newIds = new int[totalImages];
        //        for (int i = 0; i < NumberOfTestImages; i++)
        //        {
        //            mats[i] = Faces[i].Mat;
        //            newIds[i] = IDs[i];
        //            counter+=1;
        //        }
        //        foreach (var face in AuthUserFaces)
        //        {
        //            //byte[] depthPixelData = new byte[ProcessedImageHeight * ProcessedImageWidth]; // your data
        //            //Image<Gray, byte> depthImage = new Image<Gray, byte>(ProcessedImageHeight, ProcessedImageWidth);
        //            //depthImage.Bytes = face.Face;

        //            var r = new Image<Gray,byte>(ByteToImage(face.Face));
        //            Image<Gray, byte> re = r.Copy().Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
        //            mats[counter] = re.Mat;
        //            newIds[counter] =(int)face.AuthUserId;
        //            counter++;


        //        }
        //        FaceRecognition.Train(mats, newIds);
        //        AddedCurrentUserImages = true;
        //        EigenTrained = true;

          
        //    }

        //    if (EigenTrained == true)
        //    {
        //        var result = FaceRecognition.Predict(img.Mat);
        //        return (int)result.Label;
        //    }
        //    return 0;
        //}


        private async Task<bool> trainRecognizer(int AuthUserId)
        {
            var search = new AuthUserFaceSearchRequest() { AuthUserId = AuthUserId };
            var AuthUserFaces = await apiService_AuthUserFace.Get<List<Model.AuthUserFace>>(search);
            int counter = 0;
            int totalImages = Faces.Count + AuthUserFaces.Count;
            Mat[] mats = new Mat[totalImages];
            int[] newIds = new int[totalImages];
            for (int i = 0; i < NumberOfTestImages; i++)
            {
                mats[i] = Faces[i].Mat;
                newIds[i] = IDs[i];
                counter += 1;
            }
            foreach (var face in AuthUserFaces)
            {
                var r = new Image<Gray, byte>(ByteToImage(face.Face));
                Image<Gray, byte> re = r.Copy().Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                mats[counter] = re.Mat;
                newIds[counter] = (int)face.AuthUserId;
                counter++;
            }
            FaceRecognition.Train(mats, newIds);

            return true;
        }

        #endregion face recognition

        #region scaning interval qr code
        private async void scaning_Interval_Tick(object sender, EventArgs e)
        {
            numberBefore++;
            lblBefore.Text = numberBefore.ToString();
            //taking frame from picturebox pbCamera
            Bitmap frame = pbCamera.Image.Clone() as Bitmap;
            bool savingActive = false;
            //convert frame to grayscale maybe... 
            //readQR returns null if user with given qr code does not exist
            if (frame != null)
            {
                if (act == action.idle || act == action.qr_recognition)
                {
                    act = action.qr_recognition;
                    lblAction.Text = act.ToString();
                    user = await readQR(frame, apiService_AuthUser);
                    if (user == null)
                        return;
                    else
                    {
                        act = action.face_recognition;
                        lblAction.Text = act.ToString();
                        lblLastUser.Text = user.FirstName + " " + user.LastName;
                        ticks += 1;
                        lblTicks.Text = ticks.ToString();
                        scaning_Interval.Dispose();
                        scaning_Interval.Stop();

                        if (act == action.face_recognition)
                        {
                            await trainRecognizer(user.Id);
                            var search = new Model.SearchRequest.PresenceSearchRequest() { EventId = (int)eventId, UserId = user.Id };
                            var presenceList = await apiService_Presence.Get<List<Model.Presence>>(search);
                            presence = presenceList[0];
                            face_recognition.Start();
                        }
                        //scaning_Interval.Container.Dispose();
                        //act = action.face_detection;
                        //lblAction.Text = act.ToString();
                        //scaning_Interval.Dispose();
                        //face_recognition.Start();
                    }
                    numberAfter++;
                    lblAfter.Text = numberAfter.ToString();
                }
            }
        }
        #endregion scaning interval qr code

        #region converters
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public Image<Gray, Byte> cutImage(Image<Gray, Byte> image, Rectangle rectangle)
        {
            image.ROI = rectangle;
            var cutImage = image.Copy();
            image.ROI = Rectangle.Empty;

            return cutImage;
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        #endregion converters

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (scaning_Interval.Enabled == false)
                scaning_Interval.Enabled = true;
        }

        private async void face_recognition_Tick(object sender, EventArgs e)
        {
            Bitmap frame = pbCamera.Image.Clone() as Bitmap;

            Image<Gray, Byte> frameGray = new Image<Gray, Byte>(frame);
            //detecting face
            var rect = detectFace(frameGray);
            //face not found
            if (rect == null)
                return;
            else
            {
                //face found
                var userImage = cutImage(frameGray, (Rectangle)rect);
                //replacing pbImage
                var bitmapUserImage = userImage.Bitmap;
                pbUser.Image = bitmapUserImage;
                //scaling image to 100x100 so face can be recognized
                Image<Gray, byte> result = userImage.Copy().Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                //predicting user based on picture...
                var predictResult = FaceRecognition.Predict(result.Mat);
                var id = (int)predictResult.Label;
                if ((int)id > 0)
                {
                    FaceRecognitionTicks = 0;
                    FaceRecognitionTotalTicks = 0;
                    act = action.idle;
                    lblAction.Text = act.ToString();
                    face_recognition.Dispose();


                    var presenceInsertRequest = new PresenceInsertRequest()
                    {
                        AttendedWholeEvent = true,
                        EventId = Event.Id,
                        UserId = user.Id,
                        Image = ImageToByte2(result.Bitmap),
                        Notes = "",
                        PresenceAttendingDateTime = DateTime.Now,
                        PresenceCreatingDateTime = presence.PresenceCreatingDateTime,
                        PresenceLeavingDateTime = null,
                        FaceDetected = true,
                        FaceRecognized = true
                    };
                    await apiService_Presence.Update<Model.Presence>(presence.Id,presenceInsertRequest);


                }
                else
                {
                    FaceRecognitionTicks += 1;
                    if (FaceRecognitionTicks >= 10)
                    {
                        //save user to prisustvo...
                        FaceRecognitionTicks = 0;
                        FaceRecognitionTotalTicks = 0;
                        act = action.idle;
                        lblAction.Text = act.ToString();
                        face_recognition.Dispose();
                        face_recognition.Stop();
                        var presenceInsertRequest = new PresenceInsertRequest()
                        {
                            AttendedWholeEvent = true,
                            EventId = Event.Id,
                            UserId = user.Id,
                            Image = ImageToByte2(result.Bitmap),
                            Notes = "",
                            PresenceAttendingDateTime = DateTime.Now,
                            PresenceCreatingDateTime = presence.PresenceCreatingDateTime,
                            PresenceLeavingDateTime = null,
                            FaceDetected = true,
                            FaceRecognized = false
                        };
                        await apiService_Presence.Update<Model.Presence>(presence.Id, presenceInsertRequest);


                    }
                }
            }
            FaceRecognitionTotalTicks += 1;
            if (FaceRecognitionTotalTicks >= 20)
            {
                FaceRecognitionTicks = 0;
                FaceRecognitionTotalTicks = 0;
                act = action.idle;
                lblAction.Text = act.ToString();
                face_recognition.Dispose();

                var presenceInsertRequest = new PresenceInsertRequest()
                {
                    AttendedWholeEvent = null,
                    EventId = Event.Id,
                    UserId = user.Id,
                    Image = null,
                    Notes = "",
                    PresenceAttendingDateTime = DateTime.Now,
                    PresenceCreatingDateTime = presence.PresenceCreatingDateTime,
                    PresenceLeavingDateTime = null,
                    FaceDetected = false,
                    FaceRecognized = false
                };
                await apiService_Presence.Update<Model.Presence>(presence.Id, presenceInsertRequest);


            }
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {

            Image ig = pbUser.Image;
            var r = ImageToByte2(ig);


            var insert1 = new Model.AuthUserFace() { AuthUserId = user.Id, Face = r };
            var r11 = await apiService_AuthUserFace.Insert<object>(insert1);
        }
    }
}
