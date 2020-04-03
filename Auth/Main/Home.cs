using AuthoWeb;
using MetroFramework.Forms;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Auth
{
    public partial class Home : Form
    {
        public int userId { get; set; }
        public Model.AuthUser user { get; set; }
        public Model.AuthUserImage userImage { get; set; }
        APIService apiService_user  = new APIService("AuthUser");
        APIService apiService_userImage = new APIService("AuthUserImages");
        APIService apiService_events = new APIService("Event");
        APIService apiService_presence = new APIService("Presence");
        public Home(int userId)
        {
            InitializeComponent();
         
            this.userId = userId;

        }

        private void sidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Home_Load(object sender, EventArgs e)
        {
            // "HIDE" the form
            this.Opacity = 0;

            //making pb round
            //System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //gp.AddEllipse(0, 0, pbUserImage.Width - 3, pbUserImage.Height - 3);
            //Region rg = new Region(gp);
            //pbUserImage.Region = rg;


            //loading user from db
            user = await apiService_user.GetById<Model.AuthUser>(userId);

            //loading user image
            var userImageList = await apiService_userImage.Get<List<Model.AuthUserImage>>(new Model.SearchRequest.AuthUserFaceSearchRequest() { AuthUserId = userId });
            userImage = userImageList[0];
            pbUserImage.Image = ByteToImage(userImage.AuthUserImage1);

            //loading user full name
            lblUserName.Text = user.FirstName + " " + user.LastName;

            //report selected
            cbSearch.SelectedIndex = 0;

            // "SHOW" THE FORM
            this.Opacity = 100;
        }

        #region calling new forms
        private void btnEvents_Click(object sender, EventArgs e)
        {
            var frm = new Event.frmEventList();
            frm.Show();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new frmLogin();
            frm.Show();
        }
        #endregion calling new forms

        #region wat
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void logoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion wat

        #region move form
        //https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion move form

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var frm = new User.frmUserList();
            frm.Show();
        }


        #region converters
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
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

        private async void cbSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            //all events
            var events = await apiService_events.Get<List<Model.Event>>(new Model.SearchRequest.EventSearchRequest() { EventMasterId = userId });
            var presence = await apiService_presence.Get<List<Model.Presence>>(new Model.SearchRequest.PresenceSearchRequest() { EventMasterId = userId});

            #region char - event presence
            //chart - event presence 
            var groupedByPresence = presence.GroupBy(x => x.PresenceAttendingDateTime != null).ToList();
            this.chartPresence.Series["s1"].IsValueShownAsLabel = true;
            this.chartPresence.Series["s1"].Points.Clear();
            foreach (var group in groupedByPresence)
            {
                if (group.Key == true)
                {
                    this.chartPresence.Series["s1"].Points.AddXY("Attended", group.Count());
                }
                else
                {
                    this.chartPresence.Series["s1"].Points.AddXY("didn't attend", group.Count());
                }
            }

            #endregion char - event presence

            #region filtering data
            //comboBox possible values
            //All upcoming days
            //Upcoming 1 day
            //Upcoming 3 days
            //Upcoming 7 days
            //Upcoming 30 days
            //Upcoming 60 days
            var filterType = cbSearch.SelectedValue;
            var numberOfDays = 9999;
            switch (filterType)
            {
                case "Upcoming 1 day": { numberOfDays = 1; } break;
                case "Upcoming 3 days": { numberOfDays = 3; } break;
                case "Upcoming 7 days": { numberOfDays = 7; } break;
                case "Upcoming 30 days": { numberOfDays = 30; } break;
                case "Upcoming 60 days": { numberOfDays = 60; } break;

            }

            events = events.Where(x => x.EventDate >= DateTime.Now && x.EventDate <= DateTime.Now.AddDays(numberOfDays)).ToList();
            presence = presence.Where(x => x.Event.EventDate >= DateTime.Now && x.Event.EventDate <= DateTime.Now.AddDays(numberOfDays)).ToList();

            #endregion filtering data

            #region chart - events by week char
            //chart - events by week char
            var groupedByWeekDay = events.GroupBy(x => x.EventDate.DayOfWeek).ToList();
            var presenceGroupedByWeekDay = presence.GroupBy(x => x.Event.EventDate.DayOfWeek).ToList();
            this.chartEventsWeek.Series[0].Points.Clear();
            this.chartEventsWeek.Series[1].Points.Clear();
            foreach (var group in groupedByWeekDay)
            {
                Model.Event element = group.First();
                var key = group.Key.ToString();
                this.chartEventsWeek.Series[0].Points.AddXY(group.Key.ToString(), group.Count());
                foreach (var presenceGroup in presenceGroupedByWeekDay)
                    if (key == presenceGroup.Key.ToString())
                        this.chartEventsWeek.Series[1].Points.AddXY(presenceGroup.Key.ToString(), presenceGroup.Count());
            
            }
            #endregion chart - events by week char

            #region chart - events sorted by type
            //chart - events sorted by type
            var groupedByType = events.GroupBy(x => x.EventTypeId).ToList();
            this.charEventTypes.Series["s1"].IsValueShownAsLabel = true;
            this.charEventTypes.Series["s1"].Points.Clear();
            foreach (var group in groupedByType)
            {
                Model.Event element = group.First();
                this.charEventTypes.Series["s1"].Points.AddXY(element.EventType.Name.ToString(), group.Count());
            }
            #endregion chart - events sorted by type



        }

        private void chartEventsWeek_Click(object sender, EventArgs e)
        {

        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            var frm = new frmRoleDetailes();
            frm.Show();
        }

        private void btnEnterances_Click(object sender, EventArgs e)
        {
            var frm = new Event.frmEnteranceDetailes();
            frm.Show();
        }

        private void btnEventTypes_Click(object sender, EventArgs e)
        {
            var frm = new frmEventType();
            frm.Show();
        }
    }
}
