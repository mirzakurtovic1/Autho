using AuthoWeb;
using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Forms;
using Model.SearchRequest;
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

namespace Auth
{
    public partial class frmUsers : MetroForm
    {
        private APIService apiService = new APIService("AuthUser");
        private APIService apiService_authUserImage = new APIService("AuthUserImages");
        private APIService apiService_authUserFace = new APIService("AuthUserFaces");
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");
        private int? userId = null;
        byte[] Img = null;
        Model.AuthUserImage authUserImage= new Model.AuthUserImage();
        bool imageFaceFound = false;
        bool imageUploaded = false;
        public frmUsers(int? userId = null)
        {
            this.userId = userId;


            InitializeComponent();
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            loadComboBoxes.loadRoles(cbRole);

            if (userId != null)
            {
                var user = await apiService.GetById<Model.AuthUser>(userId);
                writeFields(user);

                var userImageList = await apiService_authUserImage.Get<List<Model.AuthUserImage>>(new AuthUserFaceSearchRequest() { AuthUserId = (int)userId });
                if (userImageList.Count > 0)
                {
                    authUserImage = userImageList[0];
                    pbImage.Image = ByteToImage(authUserImage.AuthUserImage1);
                }
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var user = readFields();



            if (userId != null)
            {
                await apiService.Update<Model.AuthUser>(userId, user);

            }
            else
            {
                var result = await apiService.Insert<Model.AuthUser>(user);
                var insert = new Model.AuthUserImage() { AuthUserId = result.Id, AuthUserImage1 = authUserImage.AuthUserImage1 };
                await apiService_authUserImage.Insert<Model.AuthUserImage>(insert);


                Image<Gray, byte> img1 = new Image<Gray, byte>((Bitmap)pbImage.Image);
                var rect = detectFace(img1);
                if (rect != null)
                {
                    imageFaceFound = true;
                    var r = cutImage(img1, (Rectangle)rect);
                    Image<Gray, byte> img = r.Copy().Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                    var insert1 = new Model.AuthUserImage() { AuthUserId = result.Id, AuthUserImage1 = ImageToByte2(img.Bitmap)};
                    var r1 = await apiService_authUserFace.Insert<object>(insert1);
                }



            }
            this.Close();

        }

        private void writeFields(Model.AuthUser authUser)
        {
            txtFirstName.Text = authUser.FirstName;
            txtLastName.Text = authUser.LastName;
            txtUserName.Text = authUser.UserName;
            dtpAccountCreationDate.Value =(DateTime)authUser.AccountCreatingDate;
            dtpBirthDate.Value = (DateTime)authUser.BirthDate;
            cbRole.SelectedValue = authUser.RoleId;

            //image stuff...
            if (pbImage.Image != null)
            { 
            
            }
        }
        private Model.InsertRequests.AuthUserInsertRequest readFields()
        {
            Model.InsertRequests.AuthUserInsertRequest newUser = new Model.InsertRequests.AuthUserInsertRequest()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                UserName = txtUserName.Text,
                AccountCreatingDate = dtpAccountCreationDate.Value,
                BirthDate = dtpBirthDate.Value,
                RoleId = (int)cbRole.SelectedValue
            };

            return newUser;
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            var open = openFileDialog1;
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png)|*.jpg; *.jpeg; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);
                Img = file;

                txtImageSource.Text = fileName;

                Bitmap image =(Bitmap)Image.FromFile(fileName);
                pbImage.Image = image;
                imageUploaded = true;
                authUserImage.AuthUserImage1 = file;
                Image<Gray, Byte> eImage = new Image<Gray, Byte>(image);
                var result = detectFace(eImage);
                if (result != null)
                {
                    imageFaceFound = true;
                }
            }
        }
        //https://stackoverflow.com/questions/9576868/how-to-put-image-in-a-picture-box-from-a-byte-in-c-sharp
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private Rectangle? detectFace(Image<Gray, Byte> img)
        {

            Rectangle[] facesDetected = face.DetectMultiScale(
            img,
            1.2,
            10,
            new Size(20, 20));

            if (facesDetected.Length > 0)
                return facesDetected[0];
            return null;
        }

        public Image<Gray, Byte> cutImage(Image<Gray, Byte> image, Rectangle rectangle)
        {
            image.ROI = rectangle;
            var cutImage = image.Copy();
            image.ROI = Rectangle.Empty;

            return cutImage;
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            var insert = new Model.AuthUserImage() {AuthUserImage1 = ImageToByte2(pbImage.Image),AuthUserId = 2020 };
            await apiService_authUserImage.Insert<Model.AuthUserImage>(insert);
        }
    }
}
