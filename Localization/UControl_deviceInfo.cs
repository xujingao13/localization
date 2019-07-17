﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localization
{
    public partial class UControl_deviceInfo : UserControl
    {
        public UControl_deviceInfo()
        {
            InitializeComponent();
        }

        public UControl_deviceInfo(string id, string mac)
        {
            InitializeComponent();
            this.deviceIDLabel.Text = id;
            this.MACaddressLabel.Text = mac;
        }
    }
}
