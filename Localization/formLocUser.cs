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
    public partial class formLocUser : Form
    {
        public formLocUser()
        {
            InitializeComponent();
            //g = this.locViewPictureBox.CreateGraphics();
            pictureHeight = this.locViewPictureBox.Height;
            pictureWidth = this.locViewPictureBox.Width;
            locViewPictureBox.Image = locMapBitMap;
            locViewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            locViewPictureBox.Width = locMapBitMap.Width;
            locViewPictureBox.Height = locMapBitMap.Height;
            //g = Graphics.FromImage(locMapBitMap);
            pointWidth = pictureWidth / 50;
        }

        private Graphics g;
        private int pictureHeight;
        private int pictureWidth;
        private List<Point> pointList = new List<Point>();
        private int pointWidth;
        private int zoomStep = 40;
        private Point mouseDownPoint = new Point();
        private bool isMove = false;
        private Bitmap locMapBitMap = new Bitmap("C:\\Users\\jingao\\Desktop\\test.png");
        private Bitmap originMapBitMap = new Bitmap("C:\\Users\\jingao\\Desktop\\test.png");

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addLocationResultButton_Click(object sender, EventArgs e)
        {
            //This function is only used for test
            //g.Clear(Color.DarkGray);
            locMapBitMap = new Bitmap(originMapBitMap);
            g = Graphics.FromImage(locMapBitMap);
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            int x = random.Next(pointWidth, locMapBitMap.Width - pointWidth);
            int y = random.Next(pointWidth, locMapBitMap.Height - pointWidth);
            Point p = new Point(x, y);
            pointList.Add(p);

            this.locationXText.Text = x.ToString();
            this.locationYText.Text = y.ToString();
            SolidBrush sb = new SolidBrush(Color.FromArgb(255, Color.Red));
            g.FillEllipse(sb, x - pointWidth, y - pointWidth, pointWidth * 2, pointWidth * 2);
            int count = pointList.Count;
            if (count > 1)
            {
                for (int i = 1; i < 6; i++)
                {
                    if (i > count - 1)
                        break;
                    Point temp_point = pointList[count - 1 - i];
                    Color brush_color = Color.FromArgb(255 - i * 40, Color.Red);
                    Color pen_color = Color.FromArgb(255 - i * 40, Color.Blue);
                    SolidBrush brush = new SolidBrush(brush_color);
                    Pen pen = new Pen(pen_color, pointWidth / 6);
                    g.FillEllipse(brush, temp_point.X - pointWidth / 2, temp_point.Y - pointWidth / 2, pointWidth, pointWidth);
                    g.DrawLine(pen, temp_point, pointList[count - i]);
                }
            }
            locViewPictureBox.Image = locMapBitMap;
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
    }
}
