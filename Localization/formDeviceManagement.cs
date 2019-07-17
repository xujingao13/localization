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
    public partial class formDeviceManagement : Form
    {
        public formDeviceManagement()
        {
            InitializeComponent();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDevice(string deviceID, string deviceMAC)
        {
            UControl_deviceInfo device = new UControl_deviceInfo(deviceID, deviceMAC);
            this.flowLayoutPanel1.Controls.Add(device);
        }

        private void addDeviceButton_Click(object sender, EventArgs e)
        {
            formAddDevice frm_addDevice = new formAddDevice();
            frm_addDevice.deviceRegister += new formAddDevice.deviceInfoDelegate(addDevice);
            frm_addDevice.Show();
        }
    }
}
