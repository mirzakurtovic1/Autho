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

namespace Auth.Authentification
{
    enum action { idle,qr_recognition,face_detection,face_recognition,saving};


    public partial class frmAuth : MetroForm
    {
        #region variables
        private Model.Event Event = null;
        private int? eventId = null;
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        private QRCodeHelper QRCodeHelper = new QRCodeHelper();
        private action act= action.idle;
        APIService apiService_AuthUser = new APIService("AuthUser");
        APIService apiService_Event = new APIService("Event");
        APIService apiService_Presence = new APIService("Presence");
        CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");
        //current user
        Model.AuthUser user = null;


        //debug
        int numberBefore = 0;
        int numberAfter = 0;
        int ticks = 0;
        #endregion variables


        public frmAuth(int? eventId = null)
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
            #endregion initialization

        }

        #region stuff
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


        #region scaning interval

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
                        lblLastUser.Text = user.FirstName + " " + user.LastName;
                        ticks += 1;
                        lblTicks.Text = ticks.ToString();
                        act = action.face_detection;
                        lblAction.Text = act.ToString();
                        scaning_Interval.Dispose();
                        face_recognition.Start();
                    }
                }
            
                //if (act == action.face_detection)
                //{
                //    Image<Gray, Byte> frameGray = new Image<Gray, Byte>(frame);
                //    var rect = detectFace(frameGray);
                //    //face not found
                //    if (rect == null)
                //        return;
                //    else
                //    {
                //        //face found
                //        Image<Bgr, Byte> frameBgr = new Image<Bgr, Byte>(frame);
                //        var userImage = cutImage(frameBgr,(Rectangle)rect);
                //        var bitmapUserImage = userImage.Bitmap;
                //        pbUser.Image = bitmapUserImage;
                //        act = action.face_recognition;
                //        lblAction.Text = act.ToString();
                //        scaning_Interval.Dispose();
                //        scaning_Interval.Start();
                //    }
                //}
                //if (act == action.face_recognition)
                //{
                //    //not implemented
                //    act = action.saving;
                //    lblAction.Text = act.ToString();
                //}
                //if (act == action.saving)
                //{
                //    if (savingActive == true)//FIXXXXXXXX
                //    {
                //        //saving started
                //        savingActive = true;
                //        //Get existing presence based on event and user
                //        var presenceSearchRequest = new PresenceSearchRequest() { UserId = user.Id,EventId = eventId};
                //        var presenceList = await apiService_Presence.Get<List<Model.Presence>>(presenceSearchRequest);
                //        var presence = presenceList[0];
                //        //Update existing presence
                //        presence.PresenceAttendingDateTime = DateTime.Now;
                //        var result = await apiService_Presence.Update<Model.Presence>(presence.Id,presence);

                //        //Saving is done
                //        savingActive = false;
                //        lblAction.Text = act.ToString();
                //    }
                //    act = action.idle;
                //    scaning_Interval.Dispose();
                //    scaning_Interval.Start();
                //}
            }
            numberAfter++;
            lblAfter.Text = numberAfter.ToString();
        }



        #endregion scaning interval



        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public Image<Bgr, Byte> cutImage(Image<Bgr, Byte> image, Rectangle rectangle)
        {
            image.ROI = rectangle;
            var cutImage = image.Copy();
            image.ROI = Rectangle.Empty;

            return cutImage;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (scaning_Interval.Enabled == false)
                scaning_Interval.Enabled = true;
        }

        private void face_recognition_Tick(object sender, EventArgs e)
        {
            Bitmap frame = pbCamera.Image.Clone() as Bitmap;

            if (act == action.face_detection)
            {
                Image<Gray, Byte> frameGray = new Image<Gray, Byte>(frame);
                var rect = detectFace(frameGray);
                //face not found
                if (rect == null)
                    return;
                else
                {
                    //face found
                    Image<Bgr, Byte> frameBgr = new Image<Bgr, Byte>(frame);
                    var userImage = cutImage(frameBgr, (Rectangle)rect);
                    var bitmapUserImage = userImage.Bitmap;
                    pbUser.Image = bitmapUserImage;
                    act = action.idle;
                    lblAction.Text = act.ToString();
                    face_recognition.Dispose();
                }
            }
        }
    }
}
