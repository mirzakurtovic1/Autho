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
        public bool setup { get; set; } = true;
        public Model.Event userEvent { get; set; }
        private APIService apiService_presence = new APIService("presence");
        private APIService apiService_authUserFace = new APIService("authUserFaces");
        private APIService apiService_event = new APIService("event");
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();


        public frmPresenceFinal(int eventId)
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
            //filling data grid view with data based on filter data
            loadData();
            setup = false;
            this.Enabled = true;
        }

        private async void loadData()
        {
            var search = new Model.SearchRequest.PresenceSearchRequest() { EventId=eventId };
            var presenceList = await apiService_presence.Get<List<Model.Presence>>(search);

            List<Model.PresenceAdvenced> presenceAdvenced = new List<Model.PresenceAdvenced>();

            foreach (var presence in presenceList)
            {
                var p = new Model.PresenceAdvenced()
                {

                    FirstName = presence.User.FirstName,
                    LastName = presence.User.LastName,
                    UserName = presence.User.UserName,
                    AttendedEvent = presence.PresenceAttendingDateTime != null,
                    AttendedWholeEvent = presence.PresenceAttendingDateTime != null,
                    presenceId = presence.Id,
                    Id=presence.UserId,
                    FaceDetected=presence.FaceDetected,
                    FaceRecognized = presence.FaceRecognized
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

            foreach (DataGridViewRow row in dgvPresence.Rows)
            {
                //face detected
                if (Convert.ToBoolean(row.Cells[9].Value) == true)
                {
                    //face recognized
                    if (Convert.ToBoolean(row.Cells[10].Value) == false)
                    {
                        row.Cells[13].ReadOnly = true;
                    }
                }
                else
                {
                    row.Cells[10].ReadOnly = true;
                    row.Cells[13].ReadOnly = true;
                }


                var userId = Convert.ToInt32(row.Cells[0].Value);
                var presenceId = Convert.ToInt32(row.Cells[1].Value);
                var presence = await apiService_presence.GetById<Model.Presence>(presenceId);
                var useAsTrainingData = Convert.ToBoolean(row.Cells[13].Value);


                    var trainingSearch = new Model.SearchRequest.AuthUserFaceSearchRequest()
                    {
                        AuthUserId = userId,
                        PresenceId = presenceId,
                    };
                    var result = await apiService_authUserFace.Get<List<Model.AuthUserFace>>(trainingSearch);
                    if (result.Count > 0)
                    {
                        row.Cells[14].Value = result[0].Id;
                        row.Cells[13].Value = true;
                    }
                    else
                    {
                        row.Cells[14].Value = 0;
                        row.Cells[13].Value = false;
                    }


            }
        }

        private async void dgvPresence_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (setup == false)
            {
                //checkbox AttendedEvent
                if (e.ColumnIndex == dgvPresence.Columns[6].Index && e.RowIndex != -1)
                {
                    var row = dgvPresence.Rows[e.RowIndex];
                    var userId = Convert.ToInt32(row.Cells[0].Value);
                    var presenceId = Convert.ToInt32(row.Cells[1].Value);
                    var attendedEvent = Convert.ToBoolean(row.Cells[6].Value);
                    if (attendedEvent == false)
                    {
                        //row.Cells[7].Value = false;
                        row.Cells[7].ReadOnly = true;
                    }
                    else
                    {
                        row.Cells[7].ReadOnly = false;
                    }
                    var presence = await apiService_presence.GetById<Model.Presence>(presenceId);

                    var presenceInsertRequest = new PresenceInsertRequest()
                    {
                        EventId = presence.EventId,
                        UserId = presence.UserId,
                        FaceDetected = presence.FaceDetected,
                        Image = presence.Image,
                        Notes = presence.Notes,
                        FaceRecognized = presence.FaceRecognized,
                        //PresenceAttendingDateTime=presence.PresenceAttendingDateTime,
                        PresenceCreatingDateTime = presence.PresenceCreatingDateTime,
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
                        presenceInsertRequest.PresenceAttendingDateTime = presence.PresenceAttendingDateTime;
                        presenceInsertRequest.PresenceLeavingDateTime = null;
                    }
                    await apiService_presence.Update<Model.Presence>(presenceId, presenceInsertRequest);

                    dgvPresence.EndEdit();
                }
                //checkbox attended whole event
                if (e.ColumnIndex == dgvPresence.Columns[7].Index && e.RowIndex != -1)
                {
                    var row = dgvPresence.Rows[e.RowIndex];
                    var userId = Convert.ToInt32(row.Cells[0].Value);
                    var presenceId = Convert.ToInt32(row.Cells[1].Value);
                    var attendedEvent = Convert.ToBoolean(row.Cells[6].Value);
                    var attendedWholeEvent = Convert.ToBoolean(row.Cells[7].Value);


                    var presence = await apiService_presence.GetById<Model.Presence>(presenceId);

                    var presenceInsertRequest = new PresenceInsertRequest()
                    {
                        EventId = presence.EventId,
                        UserId = presence.UserId,
                        FaceDetected = presence.FaceDetected,
                        Image = presence.Image,
                        Notes = presence.Notes,
                        FaceRecognized = presence.FaceRecognized,
                        //PresenceAttendingDateTime=presence.PresenceAttendingDateTime,
                        PresenceCreatingDateTime = presence.PresenceCreatingDateTime,
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
                        presenceInsertRequest.PresenceAttendingDateTime = (DateTime)presence.PresenceAttendingDateTime;
                        presenceInsertRequest.PresenceLeavingDateTime = DateTime.Now;
                    }
                    await apiService_presence.Update<Model.Presence>(presenceId, presenceInsertRequest);
                    dgvPresence.EndEdit();
                }
                //checkbox face recognized
                if (e.ColumnIndex == dgvPresence.Columns[10].Index && e.RowIndex != -1)
                {
                    var row = dgvPresence.Rows[e.RowIndex];
                    var userId = Convert.ToInt32(row.Cells[0].Value);
                    var presenceId = Convert.ToInt32(row.Cells[1].Value);
                    var faceRecognized = Convert.ToBoolean(row.Cells[10].Value);

                    var presence = await apiService_presence.GetById<Model.Presence>(presenceId);

                    var presenceInsertRequest = new PresenceInsertRequest()
                    {
                        EventId = presence.EventId,
                        UserId = presence.UserId,
                        FaceDetected = presence.FaceDetected,
                        Image = presence.Image,
                        Notes = presence.Notes,
                        FaceRecognized = faceRecognized,
                        PresenceAttendingDateTime = presence.PresenceAttendingDateTime,
                        PresenceCreatingDateTime = presence.PresenceCreatingDateTime,
                        PresenceLeavingDateTime = presence.PresenceLeavingDateTime,
                        AttendedWholeEvent = presence.AttendedWholeEvent,
                        AttendedEvent = Convert.ToBoolean(row.Cells[6].Value)
                    };
                    await apiService_presence.Update<Model.Presence>(presenceId, presenceInsertRequest);

                    if (faceRecognized == true)
                        row.Cells[13].ReadOnly = true;
                    else
                        row.Cells[13].ReadOnly = false;



                    dgvPresence.EndEdit();
                }
                //checkbox use as training data
                if (e.ColumnIndex == dgvPresence.Columns[13].Index && e.RowIndex != -1)
                {
                    var row = dgvPresence.Rows[e.RowIndex];
                    var userId = Convert.ToInt32(row.Cells[0].Value);
                    var presenceId = Convert.ToInt32(row.Cells[1].Value);
                    var presence = await apiService_presence.GetById<Model.Presence>(presenceId);
                    var useAsTrainingData = Convert.ToBoolean(row.Cells[13].Value);

                    if (useAsTrainingData == true)
                    {
                        Model.AuthUserFace trainingData = new Model.AuthUserFace()
                        {
                            AuthUserId = userId,
                            PresenceId = presenceId,
                            Face = presence.Image
                        };
                        await apiService_authUserFace.Insert<Model.AuthUserFace>(trainingData);
                    }
                    else
                    {
                        //await apiService_authUserFace.Delete<bool>(1);
                    }
                    //



                    dgvPresence.EndEdit();
                }

                if (e.ColumnIndex == dgvPresence.Columns[14].Index && e.RowIndex != -1)
                {
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
