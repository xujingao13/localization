using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localization
{
    public partial class formLocAdmin : Form
    {
        public formLocAdmin()
        {
            InitializeComponent();
            // Just for test
            UControl_userCheck user1 = new UControl_userCheck();
            user1.userNameLabel.Text = "测试用户1";
            user1.userNameLabel.Refresh();
            user1.CheckChanged += new System.EventHandler(this.Control_CheckChanged);

            UControl_userCheck user2 = new UControl_userCheck();
            user2.userNameLabel.Text = "测试用户2";
            user2.userNameLabel.Refresh();
            user2.CheckChanged += new System.EventHandler(this.Control_CheckChanged);

            this.flowLayoutPanel1.Controls.Add(user1);
            this.flowLayoutPanel1.Controls.Add(user2);
            
        }

        private Bitmap locMapBitMap;
        private Bitmap originMapBitMap;
        private Point mouseDownPoint = new Point();
        private bool isMove = false;
        private int zoomStep = 20;

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addMapButton_Click(object sender, EventArgs e)
        {
            string mapFileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mapFileName = openFileDialog1.FileName;
                //locViewPictureBox.Load(openFileDialog1.FileName);
            }
            locMapBitMap = new Bitmap(mapFileName);
            originMapBitMap = new Bitmap(mapFileName);
            if(locMapBitMap == null)
            {
                MessageBox.Show("读取失败");
                return;
            }
            locViewPictureBox.Image = locMapBitMap;
            locViewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            locViewPictureBox.Width = locMapBitMap.Width;
            locViewPictureBox.Height = locMapBitMap.Height;
           
        }

        private void locViewPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                locViewPictureBox.Focus();
            }

        }

        private void locViewPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = locViewPictureBox.Width;
            int oh = locViewPictureBox.Height;
            int VX, VY;
            if (e.Delta > 0)
            {
                locViewPictureBox.Width += zoomStep;
                locViewPictureBox.Height += zoomStep;
                PropertyInfo pInfo = locViewPictureBox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                  BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(locViewPictureBox, null);
                locViewPictureBox.Width = rect.Width;
                locViewPictureBox.Height = rect.Height;
            }
            if (e.Delta < 0)
            {
                if (locViewPictureBox.Width < locMapBitMap.Width / 10)
                    return;
                locViewPictureBox.Width -= zoomStep;
                locViewPictureBox.Height -= zoomStep;
                PropertyInfo pInfo = locViewPictureBox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                  BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(locViewPictureBox, null);
                locViewPictureBox.Width = rect.Width;
                locViewPictureBox.Height = rect.Height;
            }
            VX = (int)((double)x * (ow - locViewPictureBox.Width) / ow);
            VY = (int)((double)y * (oh - locViewPictureBox.Height) / oh);
            locViewPictureBox.Location = new Point(locViewPictureBox.Location.X + VX, locViewPictureBox.Location.Y + VY);

        }

        private void locViewPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }

        private void locViewPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            locViewPictureBox.Focus();
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = locViewPictureBox.Location.X + moveX;
                y = locViewPictureBox.Location.Y + moveY;
                locViewPictureBox.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }

        }

        private void addLocButton_Click(object sender, EventArgs e)
        {
            locMapBitMap = new Bitmap(originMapBitMap);
            Graphics g = Graphics.FromImage(locMapBitMap);
            SolidBrush sb = new SolidBrush(Color.FromArgb(255, Color.Red));
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            int x = random.Next(0, locMapBitMap.Width);
            int y = random.Next(0, locMapBitMap.Height);
            g.FillEllipse(sb, x, y, 10, 10);
            locViewPictureBox.Image = locMapBitMap;
        }

        private void Control_CheckChanged(object sender, EventArgs e)
        {
            MessageBox.Show("rrrrr");
        }
    }
}
