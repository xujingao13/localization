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
    public partial class UControl_userCheck : UserControl
    {
        public UControl_userCheck()
        {
            InitializeComponent();
            userSelectedBox.CheckedChanged += userSelectedBox_CheckedChanged;
        }

        private event EventHandler checkChanged = null;

        public event EventHandler CheckChanged
        {
            add
            {
                checkChanged += value;
            }
            remove
            {
                checkChanged -= value;
            }
        }

        protected virtual void OnCheckChanged()
        {
            checkChanged?.Invoke(this, EventArgs.Empty);
        }

        private void userSelectedBox_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckChanged();
        }
    }
}
