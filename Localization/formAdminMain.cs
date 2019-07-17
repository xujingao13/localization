using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localization
{
    public partial class formAdminMain : Form
    {
        public formAdminMain()
        {
            InitializeComponent();
        }

        private void deviceManageButton_Click(object sender, EventArgs e)
        {
            formDeviceManagement frm_deviceManagement = new formDeviceManagement();
            this.Hide();
            frm_deviceManagement.ShowDialog();
            this.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userManageButton_Click(object sender, EventArgs e)
        {
            formUserManagement frm_userManagement = new formUserManagement();
            this.Hide();
            frm_userManagement.ShowDialog();
            this.Show();
        }

        private void locAdminViewButton_Click(object sender, EventArgs e)
        {
            formLocAdmin frm_locAdmin = new formLocAdmin();
            this.Hide();
            frm_locAdmin.ShowDialog();
            this.Show();
        }
    }
}
