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

namespace Auth
{
    public partial class frmUsers : MetroForm
    {
        private APIService apiService = new APIService("AuthUser");
        private LoadComboBoxes loadComboBoxes = new LoadComboBoxes();
        private int? userId = null;

        public frmUsers(int? userId = null)
        {
            this.userId = userId;


            InitializeComponent();
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            loadComboBoxes.loadRoles(cbRole);

            if (userId != null)
            {
                var user =await apiService.GetById<Model.AuthUser>(userId);
                writeFields(user);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var user = readFields();

            if (userId != null)
                await apiService.Update<Model.AuthUser>(userId,user);
            else
                await apiService.Insert<Model.AuthUser>(user);

            this.Close();
        
        }

        private void writeFields(Model.AuthUser authUser)
        {
            txtFirstName.Text = authUser.FirstName;
            txtLastName.Text = authUser.LastName;
            txtUserName.Text = authUser.UserName;
            dtpAccountCreationDate.Value =(DateTime)authUser.AccountCreatingDate;
            dtpBirthDate.Value = (DateTime)authUser.BirthDate;
            cbRole.SelectedValue = authUser.RoleId;

            //image stuff...
        }
        private Model.InsertRequests.AuthUserInsertRequest readFields()
        {
            Model.InsertRequests.AuthUserInsertRequest newUser = new Model.InsertRequests.AuthUserInsertRequest()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                UserName = txtUserName.Text,
                AccountCreatingDate = dtpAccountCreationDate.Value,
                BirthDate = dtpBirthDate.Value,
                RoleId = (int)cbRole.SelectedValue
            };

            return newUser;
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {

        }
    }
}
