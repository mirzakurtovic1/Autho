using AuthoWeb;
using MetroFramework.Forms;
using Model.InsertRequests;
using Model.SearchRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth.Event
{
    public partial class frmPresenceFinal : MetroForm
    {
        public int eventId { get; set; }
        public Model.Event userEvent { get; set; }
        private APIService apiService_presence = new APIService("presence");
        private APIService apiService_authUserFace = new APIService("authUserFaces");
        private APIService apiService_event = new APIService("event");
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();


        public frmPresenceFinal(int eventId = 2)
        {
            InitializeComponent();
            this.eventId = eventId;
        }

        private async void frmPresenceFinal_Load(object sender, EventArgs e)
        {
            this.Enabled = false;

            //filling comboboxes with data
            loadComboBoxes.loadGroups(cbGroup);
            loadComboBoxes.loadRoles(cbRole);
            userEvent = await apiService_event.GetById<Model.Event>(eventId);
            if (this.userEvent == null)
            {
                //MessageBox to explain
                this.Close();
            }
            this.Enabled = true;
            //filling data grid view with data based on filter data
            loadData();
        }

        private async void loadData()
        {
            var search = new Model.SearchRequest.PresenceSearchRequest() { EventId=eventId };
            var presenceList = await apiService_presence.Get<List<Model.Presence>>(search);

            List<Model.PresenceAdvenced> presenceAdvenced = new List<Model.PresenceAdvenced>();

            foreach (var presence in presenceList)
            {
                var p = new Model.PresenceAdvenced() {

                    FirstName = presence.User.FirstName,
                    LastName = presence.User.LastName,
                    UserName = presence.User.UserName,
                    AttendedEvent = presence.PresenceAttendingDateTime != null,
                    AttendedWholeEvent = presence.PresenceAttendingDateTime != null,
                    presenceId =presence.Id,
                    Id=presence.UserId,
                };
                p.HaNotes = presence.Notes != null ? presence.Notes.Length > 0 : false;
                p.ScannedFace = presence.Image.Length > 0 ? presence.Image : null;
                var userFacesList = await apiService_authUserFace.Get<List<Model.AuthUserFace>>(new AuthUserFaceSearchRequest() { AuthUserId=presence.UserId,onlyOne=true});
                if (userFacesList.Count > 0)
                {
                    var userFace = userFacesList[0];
                    p.Face = userFace.Face.Length > 0 ? userFace.Face : null;
                }
                presenceAdvenced.Add(p);
            
            }

            dgvPresence.DataSource = presenceAdvenced;
           
        }

        private async void dgvPresence_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPresence.Columns[6].Index && e.RowIndex != -1)
            {
                var row = dgvPresence.Rows[e.RowIndex];
                var userId = Convert.ToInt32(row.Cells[0].Value);
                var presenceId = Convert.ToBoolean(row.Cells[1].Value);
                var attendedEvent = Convert.ToBoolean(row.Cells[6].Value);

                var presence = await apiService_presence.GetById<Model.Presence>(presenceId);

                var presenceInsertRequest = new PresenceInsertRequest()
                {
                    EventId=presence.EventId,
                    UserId=presence.UserId,
                    FaceDetected=presence.FaceDetected,
                    Image=presence.Image,
                    Notes=presence.Notes,
                    FaceRecognized=presence.FaceRecognized,
                    //PresenceAttendingDateTime=presence.PresenceAttendingDateTime,
                    PresenceCreatingDateTime=presence.PresenceCreatingDateTime,
                    //PresenceLeavingDateTime=presence.PresenceLeavingDateTime,
                };
                if (attendedEvent == false)
                {
                    presenceInsertRequest.AttendedWholeEvent = false;
                    presenceInsertRequest.PresenceAttendingDateTime = null;
                    presenceInsertRequest.PresenceLeavingDateTime = null;
                }
                else
                {
                    presenceInsertRequest.AttendedWholeEvent = true;
                    presenceInsertRequest.PresenceAttendingDateTime = userEvent.EventStartingTime;
                    presenceInsertRequest.PresenceLeavingDateTime = null;
                }
                await apiService_presence.Update<Model.Presence>(presenceId, presenceInsertRequest);

                dgvPresence.EndEdit();
            }


            if (e.ColumnIndex == dgvPresence.Columns[4].Index && e.RowIndex != -1)
            {
                var row = dgvPresence.Rows[e.RowIndex];
                var userId = Convert.ToInt32(row.Cells[0].Value);
                var presenceId = Convert.ToBoolean(row.Cells[1].Value);
                var attendedEvent = Convert.ToBoolean(row.Cells[6].Value);

                dgvPresence.EndEdit();
            }

            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
