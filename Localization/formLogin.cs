using DAL;
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
    public partial class formLogin : Form
    {

        public formLogin()
        {
            InitializeComponent();
        }
        public string msUserName = "jingao";
        public string msPassWord = "123456";
        public string msAdminName = "admin";
        public string msAdminPassWord = "admin";
        public int miClickState = 2;
        public ConnectDB test = new ConnectDB();

        private void connectButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            //MessageBox.Show(userName + password, "系统提示");
            //TODO Check username & password
            if(userName == msAdminName && password == msAdminPassWord)
            {
                //Is admin
                miClickState = 3;
            }
            else if (userName == "" || password == "")
            {
                MessageBox.Show("请输入用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                miClickState = 1;
            }
            this.Hide();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Yes;
            miClickState = 2;
            this.Hide();
            formRegister frm_register = new formRegister();
            frm_register.ShowDialog();
            this.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            miClickState = 4;
            this.Close();
        }
    }
}
