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
        #region variables
        //comunication with api
        private APIService apiService = new APIService("AuthUser");
        private APIService apiService_authUserImage = new APIService("AuthUserImages");
        private APIService apiService_authUserFace = new APIService("AuthUserFaces");
        //filling comboboxes
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        //form validation
        private Validation validation = new Validation();
        //face detection
        CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");
        //for qr code generator
        QRCodeHelper qRCodeHelper = new QRCodeHelper();
        
        //current user
        private int? userId = null;
        byte[] Img = null;
        Model.AuthUserImage authUserImage= new Model.AuthUserImage();
        Model.AuthUser authUser = null;

        public bool imageFaceFound { get; set; } = false;
        public bool imageUploaded { get; set; } = false;
        #endregion variables

        public frmUsers(int? userId = null)
        {
            InitializeComponent();

            this.userId = userId;
            if (userId != null)
                cbRole.Enabled = false;
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            loadComboBoxes.loadRoles(cbRole,false);
            if (cbRole.Items.Count <= 0)
            {
                //MessageBox.error.
                //this.Close();
            }
            if (userId != null)
            {
                authUser = await apiService.GetById<Model.AuthUser>(userId);
                writeFields(authUser);

                var userImageList = await apiService_authUserImage.Get<List<Model.AuthUserImage>>(new AuthUserFaceSearchRequest() { AuthUserId = (int)userId });
                if (userImageList.Count > 0)
                {
                    authUserImage = userImageList[0];
                    pbImage.Image = ByteToImage(authUserImage.AuthUserImage1);
                }
                pbQrCode.Image = ByteToImage(qRCodeHelper.GenerateQRCode(authUser.QrCode));
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren())
            {
                //reading fields from form
                var user = readFields();
                //updating existing user
                if (userId != null)
                {
                    //updating user
                    user.QrCode = authUser.QrCode;
                    await apiService.Update<Model.AuthUser>(userId, user);
                    //updating user image
                    if (!string.IsNullOrEmpty(txtImageSource.Text))
                    {
                        var result = await apiService_authUserImage.Get<List<Model.AuthUserImage>>(new AuthUserFaceSearchRequest() { AuthUserId = authUser.Id});
                        if (result.Count > 0)
                        {
                            var update = new Model.AuthUserImage() { AuthUserId = (int)userId, AuthUserImage1 = ImageToByte2(pbImage.Image) };
                            await apiService_authUserImage.Update<Model.AuthUserImage>(result[0].Id,update);
                        }
                    }
                }
                else
                {
                    //generating new qr code until its unique
                    var findNewCode = true;
                    do
                    {
                        var qrCodeText = qRCodeHelper.GenerateRandomString(15);
                        var userSearchRequest = new AuthUserSearchRequest() { qrCode = qrCodeText };
                        var qrResult = await apiService.Get<List<Model.AuthUser>>(userSearchRequest);
                        findNewCode = qrResult.Count > 0;
                        if (findNewCode == false)
                            user.QrCode = qrCodeText;
                    } while (findNewCode == true);
                    //inserting new user into db
                    var result = await apiService.Insert<Model.AuthUser>(user);
                    //inserting new user image
                    var insert = new Model.AuthUserImage() { AuthUserId = (int)result.Id, AuthUserImage1 = ImageToByte2(pbImage.Image) };
                    await apiService_authUserImage.Insert<Model.AuthUserImage>(insert);

                    //cutting and inserting face from image into db.
                    Image<Gray, byte> img1 = new Image<Gray, byte>((Bitmap)pbImage.Image);
                    var rect = detectFace(img1);
                    if (rect != null)
                    {
                        imageFaceFound = true;
                        var r = cutImage(img1, (Rectangle)rect);
                        Image<Gray, byte> img = r.Copy().Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        var insert1 = new Model.AuthUserFace() { AuthUserId = result.Id, Face = ImageToByte2(img.Bitmap) };
                        var r1 = await apiService_authUserFace.Insert<object>(insert1);
                    }



                }
                this.Close();
            }
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            var insert = new Model.AuthUserImage() {AuthUserImage1 = ImageToByte2(pbImage.Image),AuthUserId = 2020 };
            await apiService_authUserImage.Insert<Model.AuthUserImage>(insert);
        }

        #region read - write
        private void writeFields(Model.AuthUser authUser)
        {
            txtFirstName.Text = authUser.FirstName;
            txtLastName.Text = authUser.LastName;
            txtUserName.Text = authUser.UserName;
            dtpAccountCreationDate.Value = (DateTime)authUser.AccountCreatingDate;
            dtpBirthDate.Value = (DateTime)authUser.BirthDate;
            cbRole.SelectedValue = authUser.RoleId;
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
        #endregion read - write

        #region validation
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (validation.Required(sender, e, errorProvider1))
                if (validation.IsLetterOnly(sender, e, errorProvider1))
                     validation.MinMaxLength(sender, e, errorProvider1, 2, 30);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (validation.Required(sender, e, errorProvider1))
                if (validation.IsLetterOnly(sender, e, errorProvider1))
                    validation.MinMaxLength(sender, e, errorProvider1, 2, 30);
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (validation.Required(sender, e, errorProvider1))
                if (validation.IsLetterOnly(sender, e, errorProvider1))
                    validation.MinMaxLength(sender, e, errorProvider1, 5, 30);
        }

        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpBirthDate.Value >= DateTime.Now.AddDays(-1))
            {
                e.Cancel = true;
                //dtpBirthDate.Focus();
                errorProvider1.SetError(dtpBirthDate, "Date not valid!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dtpBirthDate, null);
            }
        }
        private void txtImageSource_Validating(object sender, CancelEventArgs e)
        {
            if (userId == null)
            {
                validation.Required(sender, e, errorProvider1);

                if (pbImage.Image != null)
                {
                    var image = (Bitmap)pbImage.Image;
                    Image<Gray, Byte> eImage = new Image<Gray, Byte>(image);
                    var result = detectFace(eImage);
                    if (result != null)
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(pbImage, null);
                    }
                    else
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(pbImage, "Face not found, please upload another image!");
                    }
                }
                else
                {
                    e.Cancel = true;
                    errorProvider1.SetError(pbImage, "User image required!");
                }
            }
            else
            {
                if (txtImageSource.Text != null & pbImage != null)
                {
                    var image = (Bitmap)pbImage.Image;
                    Image<Gray, Byte> eImage = new Image<Gray, Byte>(image);
                    var result = detectFace(eImage);
                    if (result != null)
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(pbImage, null);
                    }
                    else
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(pbImage, "Face not found, please upload another image!");
                    }
                }
            }
        }
        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        private void pbImage_Validating(object sender, CancelEventArgs e)
        {

        }
        #endregion validation

        #region helpers
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

                Bitmap image = (Bitmap)Image.FromFile(fileName);
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
            this.ValidateChildren();
            //need to validate only image stuff.. fix
        }
        #endregion helpers

    }
}
