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
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }

        public string userName;
        public string passWord;
        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string passWord = passwordTextBox.Text;
            string confirm_password = confirmTextBox.Text;
            if (passWord != confirm_password)
            {
                MessageBox.Show("两次输入密码不一致，请确认");
            }
            else
            {
                DAL.User userControl = new DAL.User();
                userControl.AddUser(userName, passWord);
                this.userName = userName;
                this.passWord = passWord;
            }
            this.Close();
        }
    }
}
