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
        LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        public frmUserList()
        {
            InitializeComponent();
            //making form blue
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 162, 255);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }
        private void frmUserList_Load(object sender, EventArgs e)
        {
            //loading combobox 
            loadComboBoxes.loadRoles(cbType);
            //loading dgv
            loadDataGridView();
        }
        async void loadDataGridView()
        {
            var search = new Model.SearchRequest.AuthUserSearchRequest()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                UserName = txtUserName.Text,
            };

            //if combobox did not load making sure its result is 0
            if (cbType.Items.Count > 0)
                search.RoleId = (int)cbType.SelectedValue;
            else
                search.RoleId = 0;

            var users = await apiService_user.Get<List<Model.AuthUser>>(search);
            dgvUsers.DataSource = users;
        }
        //getting user detailes
        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            var userId = (int)dgvUsers.SelectedRows[0].Cells[0].Value;
            var frm = new frmUsers(userId);
            frm.Show();
        }
        //opening new form for user detailes
        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroButton1.Enabled = false;
            var frm = new frmUsers();
            frm.Show();
            metroButton1.Enabled = true;
        }
        //filtering dgv
        private void btnFilter_Click(object sender, EventArgs e)
        {
            btnFilter.Enabled = false;
            loadDataGridView();
            btnFilter.Enabled = true;
        }
    }
}
