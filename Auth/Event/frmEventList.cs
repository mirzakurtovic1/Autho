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

            dgvEvents.Columns[4].DefaultCellStyle.Format = "HH:mm";
            dgvEvents.Columns[5].DefaultCellStyle.Format = "HH:mm";

        }

        private void frmEventList_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }
        async void loadDataGridView()
        {
            var events = await apiService_event.Get<List<Model.Event>>(null);
            events = events.OrderBy(d => d.EventDate).ToList();
            dgvEvents.DataSource = events;
        }

        private void dgvEvents_DoubleClick(object sender, EventArgs e)
        {
            var eventId = (int)dgvEvents.SelectedRows[0].Cells[0].Value;
            var frm = new frmEvent(eventId);
            frm.Show();
        }
    }
}
