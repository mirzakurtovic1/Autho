using AuthoWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth
{
    class LoadComboBoxes
    {
        private APIService apiservice_eventType = new APIService("EventType");
        private APIService apiservice_authUser = new APIService("AuthUser");
        private APIService apiservice_role = new APIService("Role");
        private APIService apiservice_group = new APIService("UserGroup");
        public async void loadEventTypes(object sender)
        {
            var combo = (ComboBox)sender;
            var data =await apiservice_eventType.Get<List<Model.EventType>>(null);
            combo.DataSource = data;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public async void loadEventMasters(object sender)
        {
            var combo = (ComboBox)sender;
            var data = await apiservice_authUser.Get<List<Model.AuthUser>>(null);//search request fali, trebaju nam samo oni koji imaju mogucnost kreiranja eventova...
            combo.DataSource = data;
            combo.DisplayMember = "Display";
            combo.ValueMember = "Id";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public async void loadAuthUsers(object sender)
        {
            var combo = (ComboBox)sender;
            var data = await apiservice_authUser.Get<List<Model.AuthUser>>(null);
            combo.DataSource = data;
            combo.DisplayMember = "Display";
            combo.ValueMember = "Id";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public async void loadRoles(object sender)
        {
            var combo = (ComboBox)sender;
            var data = await apiservice_role.Get<List<Model.Role>>(null);
            Model.Role role = new Model.Role() { Id = 0, Name = "All roles" };
            data.Insert(0, role);
            combo.DataSource = data;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public async void loadGroups(object sender)
        {
            var combo = (ComboBox)sender;
            var data = await apiservice_group.Get<List<Model.UserGroup>>(null);
            Model.UserGroup group = new Model.UserGroup() { Id = 0, Name = "All groups" };
            data.Insert(0, group);
            combo.DataSource = data;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        

    }
}
