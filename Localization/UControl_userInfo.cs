using System;
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
    public partial class UControl_userInfo : UserControl
    {
        public UControl_userInfo()
        {
            InitializeComponent();
        }

        public UControl_userInfo(string id, string name, string deviceName)
        {
            InitializeComponent();
            this.userIDLabel.Text = id;
            this.userNameLabel.Text = name;
            this.userDeviceLabel.Text = deviceName;
        }
    }
}
