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

        private List<UControl_deviceInfo> deviceList = new List<UControl_deviceInfo>();

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDevice(string deviceID, string deviceMAC)
        {
            UControl_deviceInfo device = new UControl_deviceInfo(deviceID, deviceMAC);
            this.flowLayoutPanel1.Controls.Add(device);
            deviceList.Add(device);
        }

        private void addDeviceButton_Click(object sender, EventArgs e)
        {
            formAddDevice frm_addDevice = new formAddDevice();
            frm_addDevice.deviceRegister += new formAddDevice.deviceInfoDelegate(addDevice);
            frm_addDevice.Show();
        }

        private void formDeviceManagement_Load(object sender, EventArgs e)
        {
            DAL.Device deviceControl = new DAL.Device();
            Dictionary<int, string> deviceInfo = deviceControl.getDeviceInfo();
            foreach (KeyValuePair<int, string> device in deviceInfo)
            {
                UControl_deviceInfo newDevice = new UControl_deviceInfo(device.Key.ToString(), device.Value);
                deviceList.Add(newDevice);
                this.flowLayoutPanel1.Controls.Add(newDevice);
            }
        }

        private void deleteDeviceButton_Click(object sender, EventArgs e)
        {
            List<int> deleteDeviceList = new List<int>();
            List<UControl_deviceInfo> deleteDeviceControl = new List<UControl_deviceInfo>();
            DAL.Device deviceControl = new DAL.Device();
            foreach (UControl_deviceInfo tempDevice in deviceList)
            {
                if (tempDevice.checkBox1.Checked)
                {
                    deleteDeviceList.Add(int.Parse(tempDevice.deviceIDLabel.Text));
                    deleteDeviceControl.Add(tempDevice);
                }
            }
            if(deleteDeviceList.Count > 0)
            {
                if(deviceControl.deleteDevice(deleteDeviceList) > 0)
                {
                    foreach(UControl_deviceInfo tempDevice in deleteDeviceControl)
                    {
                        this.flowLayoutPanel1.Controls.Remove(tempDevice);
                    }
                }
            }
        }
    }
}
