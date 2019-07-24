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
    public partial class formAddUserDeivce : Form
    {
        public formAddUserDeivce()
        {
            InitializeComponent();
        }

        public delegate void deviceInfoDelegate(string userName, int deviceID, string deviceMAC);
        public event deviceInfoDelegate deviceAssociate;
        public string userName;
        public Dictionary<int, string> deviceInfo;

        public formAddUserDeivce(string userName, Dictionary<int, string> deviceInfo)
        {
            InitializeComponent();
            this.userNameLabel.Text = userName;
            this.userName = userName;
            this.deviceInfo = new Dictionary<int, string>(deviceInfo);
            foreach (KeyValuePair<int, string> device in deviceInfo)
            {
                this.comboBox1.Items.Add(device.Value);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int deviceID = 0;
            foreach (KeyValuePair<int, string> device in deviceInfo)
            {
                if (device.Value.Equals(comboBox1.Text.ToString()))
                {
                    deviceID = device.Key;
                }
            }
            DAL.User userControl = new DAL.User();
            if (userControl.UpdateUser(userName, deviceID) > 0)
            {
                deviceAssociate?.Invoke(userName, deviceID, this.comboBox1.Text.ToString());
            }
            else
            {
                MessageBox.Show("录入失败");
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
