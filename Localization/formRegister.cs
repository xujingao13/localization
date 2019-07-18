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
                int status = userControl.AddUser(userName, passWord);
                if (status > 0)
                {
                    this.userName = userName;
                    this.passWord = passWord;
                    MessageBox.Show("注册成功");
                    this.Close();
                }
                else if (status == 0)
                {
                    MessageBox.Show("该用户已存在");
                    userNameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    confirmTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("连接数据库失败");
                }
            }
            
        }
    }
}
