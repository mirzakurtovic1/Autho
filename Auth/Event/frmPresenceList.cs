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
    public partial class frmPresenceList : MetroForm
    {
        APIService apiService_presence = new APIService("Presence");
        APIService apiService_authUser = new APIService("AuthUser");
        LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        int eventId;

        public frmPresenceList(int eventId = 2)
        {
            InitializeComponent();
            this.eventId = eventId;
        }

        private void frmPresenceList_Load(object sender, EventArgs e)
        {

            //filling comboboxes with data
            loadComboBoxes.loadGroups(cbGroup);
            loadComboBoxes.loadRoles(cbRole);
            //filling data grid view with data based on filter data
            loadData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            loadData();
        }

        #region load data from api into data grid view
        async void loadData()
        {
            var presenceSearch = new Model.SearchRequest.PresenceSearchRequest(){ EventId = eventId };
            #region search parametres

                


            #endregion search parametres
            var presence = await apiService_presence.Get<List<Model.Presence>>(presenceSearch);

            var authUserSearch = new Model.SearchRequest.AuthUserSearchRequest();
            #region search parametres
                authUserSearch.FirstName = txtFirstName.Text;
                authUserSearch.LastName = txtLastName.Text;
                authUserSearch.UserName = txtUserName.Text;
                authUserSearch.RoleId = (int)cbRole.SelectedValue;
                authUserSearch.UserGroupId = (int)cbGroup.SelectedValue;
            #endregion search parametres
            var users = await apiService_authUser.Get<List<Model.AuthUser>>(authUserSearch);

            List<Model.presenceBasic> data = new List<Model.presenceBasic>();
            foreach (Model.AuthUser user in users)
            {
                var temp = new Model.presenceBasic()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                };
                temp.AttendingEvent = presence.Any(p => p.UserId == user.Id);
                data.Add(temp);
            }
            dgvPresence.DataSource = data;
        }
        #endregion load data from api into data grid view

        private async void dgvPresence_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPresence.Columns[4].Index && e.RowIndex != -1)
            {
                var row = dgvPresence.Rows[e.RowIndex];
                var userId = Convert.ToInt32(row.Cells[0].Value);
                var invited = Convert.ToBoolean(row.Cells[4].Value);

                if (invited == true)
                {
                    //add invitation
                    var presenceInsertRequest = new PresenceInsertRequest()
                    {
                        PresenceCreatingDateTime = DateTime.Now,
                        PresenceAttendingDateTime = null,
                        PresenceLeavingDateTime = null,
                        Notes = null,
                        AttendedWholeEvent = null,
                        UserId = userId,
                        EventId = eventId,
                    };

                   var result = await apiService_presence.Insert<Model.Presence>(presenceInsertRequest);
                 
                }
                else
                {
                    //remove invitation
                    var presenceSearchRequest = new PresenceSearchRequest()
                    {
                        EventId = eventId,
                        UserId = userId,
                    };
                    var presenceList = await apiService_presence.Get<List<Model.Presence>>(presenceSearchRequest);
                    var presenceId = presenceList[0].Id;
                    var result = await apiService_presence.Delete<Model.Presence>(presenceId);
                }

                dgvPresence.EndEdit();
            }
        }

        private void dgvPresence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
