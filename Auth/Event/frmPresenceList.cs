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
        APIService apiService_event = new APIService("Event");
        LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        Model.Event userEvent = null;
        List<Model.DateBasic> dates = new List<Model.DateBasic>();
        int eventId;

        public frmPresenceList(int eventId = 2)
        {
            InitializeComponent();
            this.eventId = eventId;
        }

        private void frmPresenceList_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            //filling comboboxes with data
            loadComboBoxes.loadGroups(cbGroup);
            loadComboBoxes.loadRoles(cbRole);
            //filling data grid view with data based on filter data
            loadData();
            this.Enabled = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            loadData();
        }

        #region load_data
        async void loadData()
        {
            userEvent = await apiService_event.GetById<Model.Event>(eventId);
            lblEventGroupId.Text = userEvent.EventGroupId;

            #region load_dates
            var eventSearch = new EventSearchRequest() { EventGroupId = userEvent.EventGroupId };
            var eventSearchResult =  await apiService_event.Get<List<Model.Event>>(eventSearch);
            //taking only events that did not happen 
            eventSearchResult = eventSearchResult.Where(e => e.EventDate >= DateTime.Now).OrderBy(e=>e.EventDate).ToList();
            if (eventSearchResult.Count <= 1)
            {
                cbMultiple.Checked = false;
                cbMultiple.Visible = false;
                panelMultipleDates.Visible = false;
            }
            else
            {
                foreach (var x in eventSearchResult)
                {
                    var d = new Model.DateBasic() { Date = x.EventDate, eventId = x.Id};
                    dates.Add(d);
                }


                for (int i = 0; i < dates.Count; i++)
                {
                    cblDates.Items.Add(dates[i]);
                    cblDates.SetItemChecked(i, true);
                }
                cblDates.DisplayMember = "Display";

            }
            #endregion load_dates

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
        #endregion load_data

        private async void dgvPresence_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPresence.Columns[4].Index && e.RowIndex != -1)
            {
                var row = dgvPresence.Rows[e.RowIndex];
                var userId = Convert.ToInt32(row.Cells[0].Value);
                var invited = Convert.ToBoolean(row.Cells[4].Value);
                //var selectedDates = dates.checkedItems;
                if (invited == true)
                {
                    //remove invitation for one or move events
                    if (cbMultiple.Checked == true)
                        foreach (Model.DateBasic x in cblDates.CheckedItems)
                            await addPresenceAsync(userId, (int)x.eventId);
                    else
                        await addPresenceAsync(userId, eventId);

                }
                else
                {
                    //remove invitation for one or move events
                    if (cbMultiple.Checked == true)
                        foreach (Model.DateBasic x in cblDates.CheckedItems)
                            await removePresenceAsync(userId,(int)x.eventId);
                    else
                        await removePresenceAsync(userId, eventId);
                }

                dgvPresence.EndEdit();
            }
        }
        #region add_remove_presence



        async Task addPresenceAsync(int userId, int eventId)
        {
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

            await apiService_presence.Insert<Model.Presence>(presenceInsertRequest);
        }

        async Task removePresenceAsync(int userId, int eventId)
        {
            var presenceSearchRequest = new PresenceSearchRequest()
            {
                EventId = eventId,
                UserId = userId,
            };
            var presenceList = await apiService_presence.Get<List<Model.Presence>>(presenceSearchRequest);
            if (presenceList.Count <= 0) return;
            var presenceId = presenceList[0].Id;
            await apiService_presence.Delete<Model.Presence>(presenceId);
        }
        #endregion add_remove_presence

        private void cbMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMultiple.Checked == true)
                panelMultipleDates.Visible = true;
            else
                panelMultipleDates.Visible = false;
        }



        #region delete
        private void dgvPresence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }
        #endregion delete
    }
}
