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

namespace Auth.User
{
    public partial class frmUserList : MetroForm
    {
        APIService apiService_user = new APIService("AuthUser");

        public frmUserList()
        {
            InitializeComponent();
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 162, 255);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }
        async void loadDataGridView()
        {
            var users = await apiService_user.Get<List<Model.AuthUser>>(null);
            
            dgvUsers.DataSource = users;
        }

        private void dgvEvents_DoubleClick(object sender, EventArgs e)
        {
            var userId = (int)dgvUsers.SelectedRows[0].Cells[0].Value;
            var frm = new frmUsers(userId);
            frm.Show();
        }
    }
}
