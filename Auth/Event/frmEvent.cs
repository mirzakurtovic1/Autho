using AuthoWeb;
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

namespace Auth.Event
{
    public partial class frmEvent : MetroForm
    {
        private APIService apiService = new APIService("Event");
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        
        private int? userEventId = null;

        public frmEvent(int? id = 2)
        {
            this.userEventId = id;
            InitializeComponent();
        }

        private async void frmEvent_Load(object sender, EventArgs e)
        {
            if (userEventId != null)
            {
                var userEvent = await apiService.GetById<Model.Event>(userEventId);
                writeFields(userEvent);
            }
            loadComboBoxes.loadEventTypes(cbEventType);
            loadComboBoxes.loadEventMasters(cbEventMaster);

        }
        private void writeFields(Model.Event userEvent)
        {
            txtName.Text = userEvent.EventName;
            txtDescription.Text = userEvent.EventDescription;
            dtpDate.Value =(DateTime)userEvent.EventDate;
            dtpStartingTime.Value = (DateTime)userEvent.EventStartingTime;//doradit
            dtpEndingTime.Value = (DateTime)userEvent.EventEndingTime;
            cbEveryoneCanEnter.Checked = (bool)userEvent.AnyoneCanEnter;
            numUserCanEnterBefore.Value =(decimal) userEvent.UserCanEnterBeforeEventMi;
            numUserCanEnterAfter.Value = (decimal)userEvent.UserCanEnterAfterEventSta;
            //cbEventMaster.SelectedValue = userEvent.EventMasterId;
            cbEventType.SelectedValue = userEvent.EventTypeId;
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
            };

            return newEvent;
        }

        private async void btnSumbit_Click(object sender, EventArgs e)
        {
            var newEvent = readFields();
            if (userEventId != null)
            {
                var userEvent = await apiService.Update<Model.Event>(userEventId, newEvent);
            }
            else
            {
                var userEvent = await apiService.Insert<Model.Event>(newEvent);
            }
            //message and erro catch needed...
            this.Close();
        }

        private void cbEventMaster_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStartEvent_Click(object sender, EventArgs e)
        {
            if (userEventId != null)
            {
                var frm = new Authentification.frmAuth(userEventId);
                frm.Show();
            }
        }
    }
}
