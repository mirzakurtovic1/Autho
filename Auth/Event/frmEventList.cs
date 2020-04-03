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
    public partial class frmEventList : MetroForm
    {
        APIService apiService_event = new APIService("event");
        LoadComboBoxes loadComboBoxes = new LoadComboBoxes();

        public frmEventList()
        {
            InitializeComponent();
            dgvEvents.EnableHeadersVisualStyles = false;
            dgvEvents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 162, 255);
            dgvEvents.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            //dgvEvents.Columns[4].DefaultCellStyle.Format = "dd.MM.YYYY";
            dgvEvents.Columns[4].DefaultCellStyle.Format = "HH:mm";
            dgvEvents.Columns[5].DefaultCellStyle.Format = "HH:mm";

            dtpDate.Enabled = false;

        }

        private void frmEventList_Load(object sender, EventArgs e)
        {
            loadComboBoxes.loadEventTypes(cbType);
            loadDataGridView();
        }
        async void loadDataGridView()
        {
            var search = new Model.SearchRequest.EventSearchRequest();
            search.EventName = txtName.Text;
            search.showOnlyFutureEvents = cbOnlyFuture.Checked;

            if (cbType.Items.Count > 0)
                search.EventTypeId = (int)cbType.SelectedValue;
            else
                search.EventTypeId = 0;

            if (dtpCheckBox.Checked == true)
                search.EventDate = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, 0, 0, 0, 0);
            

            var events = await apiService_event.Get<List<Model.Event>>(search);
            events = events.OrderBy(d => d.EventDate).ToList();
            dgvEvents.DataSource = events;
        }

        private void dgvEvents_DoubleClick(object sender, EventArgs e)
        {
            var eventId = (int)dgvEvents.SelectedRows[0].Cells[0].Value;
            var frm = new frmEvent(eventId);
            frm.Show();
        }

        private void btnNewEvent_Click(object sender, EventArgs e)
        {
            var frm = new frmEvent();
            frm.Show();
        }

        private void dtpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
                dtpDate.Enabled = dtpCheckBox.Checked;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            loadDataGridView();
        }
    }
}
