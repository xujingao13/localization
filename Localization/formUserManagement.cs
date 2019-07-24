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
    public partial class formUserManagement : Form
    {
        public formUserManagement()
        {
            InitializeComponent();
        }

        private List<UControl_userInfo> userList = new List<UControl_userInfo>();
        public Dictionary<int, string> deviceInfo = new Dictionary<int, string>();
        public Dictionary<int, string> usefulDeviceInfo;

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formUserManagement_Load(object sender, EventArgs e)
        {
            DAL.User userControl = new DAL.User();
            Dictionary <int, DAL.User.userInfo> userInfo = userControl.getUserInfo();

            DAL.Device deviceControl = new DAL.Device();
            deviceInfo = deviceControl.getDeviceInfo();
            usefulDeviceInfo = new Dictionary<int, string>(deviceInfo);

            foreach (KeyValuePair<int, DAL.User.userInfo> user in userInfo)
            {
                UControl_userInfo newUser;
                if (user.Value.DeviceId == -1)
                {
                    newUser = new UControl_userInfo(user.Key.ToString(), user.Value.userName, "");
                }
                else
                {
                    newUser = new UControl_userInfo(user.Key.ToString(), user.Value.userName, deviceInfo[user.Value.DeviceId]);
                    usefulDeviceInfo.Remove(user.Value.DeviceId);
                }
                userList.Add(newUser);
                this.flowLayoutPanel1.Controls.Add(newUser);
            }
        }

        private void addUserDeviceButton_Click(object sender, EventArgs e)
        {
            bool flag = false;
            UControl_userInfo targetUser = new UControl_userInfo();
            foreach (UControl_userInfo tempUser in userList)
            {
                if (tempUser.checkBox1.Checked)
                {
                    targetUser = tempUser;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                formAddUserDeivce frm_addUserDevice = new formAddUserDeivce(targetUser.userNameLabel.Text, usefulDeviceInfo);
                frm_addUserDevice.deviceAssociate += new formAddUserDeivce.deviceInfoDelegate(addDeviceAssociate);
                frm_addUserDevice.Show();
            }
            else
            {
                MessageBox.Show("请选择一名用户");
            }
        }

        private void addDeviceAssociate(string name, int deviceID, string mac)
        {
            foreach (UControl_userInfo tempUser in userList)
            {
                if (tempUser.userNameLabel.Text == name)
                {
                    tempUser.userDeviceLabel.Text = mac;
                    tempUser.userDeviceLabel.Refresh();
                    usefulDeviceInfo.Remove(deviceID);
                    break;
                }
            }
        }

        private void deleteUserDeviceButton_Click(object sender, EventArgs e)
        {
            bool flag = false;
            UControl_userInfo targetUser = new UControl_userInfo();
            foreach (UControl_userInfo tempUser in userList)
            {
                if (tempUser.checkBox1.Checked)
                {
                    targetUser = tempUser;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                if (targetUser.userDeviceLabel.Text == "")
                {
                    MessageBox.Show("该用户没有关联设备");
                }
                else
                {
                    int deviceId = 0;
                    DAL.User userControl = new DAL.User();
                    foreach (KeyValuePair<int, string> device in deviceInfo)
                    {
                        if (device.Value == targetUser.userDeviceLabel.Text)
                        {
                            deviceId = device.Key;
                        }
                    }
                    if(userControl.UpdateUser(targetUser.userNameLabel.Text, -1) > 0)
                    {
                        usefulDeviceInfo.Add(deviceId, targetUser.userDeviceLabel.Text);
                        targetUser.userDeviceLabel.Text = "";
                        targetUser.userDeviceLabel.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("取消关联失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一名用户");
            }
        }
    }
}
