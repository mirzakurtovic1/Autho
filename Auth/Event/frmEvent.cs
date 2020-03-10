using AuthoWeb;
using MetroFramework.Forms;
using Model;
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
    public partial class frmEvent : MetroForm
    {
        #region variables
        private APIService apiService = new APIService("Event");
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        QRCodeHelper QRCodeHelper = new QRCodeHelper();
        List<DateBasic> dates = new List<DateBasic>();
        private int? userEventId = null;
        #endregion variables

        public frmEvent(int? id = 2)
        {
            this.userEventId = id;
            InitializeComponent();
            if (userEventId == null)
            {
                if (cbCreateMultipleEvents.Checked == true)
                    panelMultipleDates.Visible = true;
            }
            else
            {
                panelMultipleDates.Visible = false;
                cbCreateMultipleEvents.Visible = false;
            }
            loadComboBoxes.loadEventTypes(cbEventType);
            loadComboBoxes.loadEventMasters(cbEventMaster);
        }
        private async void frmEvent_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (userEventId != null)
            {
                var userEvent = await apiService.GetById<Model.Event>(userEventId);
                writeFields(userEvent);
            }
            this.Enabled = true;
        }
        private async void btnSumbit_Click(object sender, EventArgs e)
        {
            //Reading fields from form
            var newEvent = readFields();
            //If event exists we update it
            if (userEventId != null)
            {
                //We update every event which has same group
                var search = new EventSearchRequest() {EventGroupId = newEvent.EventGroupId};
                var events = await apiService.Get<List<Model.Event>>(search);
                if (events.Count > 0)
                {
                    foreach (var x in events)
                    {
                        newEvent.EventDate = x.EventDate;
                        await apiService.Update<Model.Event>(x.Id, newEvent);
                    }
                }
                else
                {
                    //If there is only one event.
                    await apiService.Update<Model.Event>(userEventId, newEvent);
                }


            }
            else
            {
                var unique = false;
                var eventGroupCode = "";
                while (unique != true)
                {
                    eventGroupCode = QRCodeHelper.GenerateRandomString(32);
                    var search = new EventSearchRequest() { EventGroupId = eventGroupCode };
                    var events = await apiService.Get<List<Model.Event>>(search);
                    if (events.Count == 0) unique = true;
                }
                //if there are multiple events.
                if (dates.Count > 0)
                {
                    foreach (var date in dates)
                    {
                        newEvent.EventDate = date.Date;
                        newEvent.EventGroupId = eventGroupCode;
                         await apiService.Insert<Model.Event>(newEvent);
                    }
                }
                else
                {
                    //If there is only one event.
                    newEvent.EventGroupId = eventGroupCode;
                    await apiService.Insert<Model.Event>(newEvent);
                }


            }
            //message and erro catch needed...
            this.Close();
        }
        private void btnStartEvent_Click(object sender, EventArgs e)
        {
            if (userEventId != null)
            {
                var frm = new Authentification.frmAuth(userEventId);
                frm.Show();
            }
        }
        private void cbCreateMultipleEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreateMultipleEvents.Checked == true)
                panelMultipleDates.Visible = true;
            else
                panelMultipleDates.Visible = false;
            
        }

        #region read_write
        private void writeFields(Model.Event userEvent)
        {
            txtName.Text = userEvent.EventName;
            txtDescription.Text = userEvent.EventDescription;
            dtpDate.Value = (DateTime)userEvent.EventDate;
            dtpStartingTime.Value = (DateTime)userEvent.EventStartingTime;//doradit
            dtpEndingTime.Value = (DateTime)userEvent.EventEndingTime;
            cbEveryoneCanEnter.Checked = (bool)userEvent.AnyoneCanEnter;
            numUserCanEnterBefore.Value = (decimal)userEvent.UserCanEnterBeforeEventMi;
            numUserCanEnterAfter.Value = (decimal)userEvent.UserCanEnterAfterEventSta;
            //cbEventMaster.SelectedValue = userEvent.EventMasterId;
            cbEventType.SelectedValue = userEvent.EventTypeId;
            lblEventGroupId.Text = userEvent.EventGroupId;
        }
        private Model.Event readFields()
        {
            Model.Event newEvent = new Model.Event()
            {
                EventName = txtName.Text,
                EventDescription = txtDescription.Text,
                EventDate = dtpDate.Value,
                EventStartingTime = dtpStartingTime.Value,
                EventEndingTime = dtpEndingTime.Value,
                AnyoneCanEnter = cbEveryoneCanEnter.Checked,
                UserCanEnterBeforeEventMi = (int)numUserCanEnterBefore.Value,
                UserCanEnterAfterEventSta = (int)numUserCanEnterAfter.Value,
                //EventMasterId=cbEventMaster.SelectedValue,
                EventTypeId = (int)cbEventType.SelectedValue,
                EventGroupId = lblEventGroupId.Text.ToString()
            };

            return newEvent;
        }
        #endregion read_write

        #region dates
        //Daily
        //Every working day
        //Weekly
        //Every other week
        //Monthly 
        private void cbRepeatType_SelectedValueChanged(object sender, EventArgs e)
        {
            string value =(string)cbRepeatType.SelectedItem;
            cblDates.Items.Clear();
            dates.Clear();
            dates.Add(new DateBasic() { Date = dtpDate.Value });            
            DateTime latestDate = dtpDate.Value;
            if (value == "Daily")
            {
                for (var i = 0; i < nudEvents.Value-1; i++)
                {
                    latestDate = latestDate.AddDays(1);
                    dates.Add(new DateBasic() { Date = latestDate });
                }
            }
            if (value == "Every working day")
            {
                for (var i = 0; i < nudEvents.Value-1; i++)
                {
                    var dayOfTheWeekIndex = 0;

                    do
                    {
                        latestDate = latestDate.AddDays(1);
                        dayOfTheWeekIndex = (int)latestDate.DayOfWeek;

                    } while (dayOfTheWeekIndex <= 0 || dayOfTheWeekIndex >= 6);
                    dates.Add(new DateBasic() { Date = latestDate });
                }
            }
            if (value == "Weekly")
            {
                for (var i = 0; i < nudEvents.Value - 1; i++)
                {
                    latestDate = latestDate.AddDays(7);
                    dates.Add(new DateBasic() { Date = latestDate });
                }
            }
            if (value == "Every other week")
            {
                for (var i = 0; i < nudEvents.Value - 1; i++)
                {
                    latestDate = latestDate.AddDays(14);
                    dates.Add(new DateBasic() { Date = latestDate });
                }
            }
            if (value == "Monthly")
            {
                for (var i = 0; i < nudEvents.Value - 1; i++)
                {
                    latestDate = latestDate.AddMonths(1);
                    dates.Add(new DateBasic() { Date = latestDate });
                }
            }


            for (int i=0;i<dates.Count;i++)
            {
                cblDates.Items.Add(dates[i]);
                cblDates.SetItemChecked(i, true);
            }
            cblDates.DisplayMember = "Display";
        }
        #endregion dates

        #region delete
        private void txtDescription_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {

        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroLabel12_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {

        }
        private void cbEventMaster_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
            #endregion delete
    }
}
