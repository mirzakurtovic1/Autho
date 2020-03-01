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
    public partial class frmEventList : Form
    {
        public frmEventList()
        {
            InitializeComponent();
        }

        private void frmEventList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'authDataSet.Events1' table. You can move, or remove it, as needed.
            this.events1TableAdapter.Fill(this.authDataSet.Events1);

        }
    }
}
