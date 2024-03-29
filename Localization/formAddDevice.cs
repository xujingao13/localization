﻿using System;
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
    public partial class formAddDevice : Form
    {
        public formAddDevice()
        {
            InitializeComponent();
        }

        public String deviceID = "";
        public String deviceMAC = "";
        public delegate void deviceInfoDelegate(string deviceID, string deviceMAC);
        public event deviceInfoDelegate deviceRegister;


        private void confirmButton_Click(object sender, EventArgs e)
        {
            deviceMAC = this.macAddressTextBox.Text.ToString();
            DAL.Device deviceControl = new DAL.Device();
            int status = deviceControl.AddDevice(deviceMAC);
            if (status > 0)
            {
                deviceRegister?.Invoke(status.ToString(), deviceMAC);
                this.Close();
            }
            else if (status == 0)
            {
                MessageBox.Show("该设备已存在");
                macAddressTextBox.Text = "";
            }
        }
    }
}
