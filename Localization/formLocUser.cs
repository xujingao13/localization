using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localization
{
    public partial class formLocUser : Form
    {
        public formLocUser()
        {
            InitializeComponent();
        }

        public formLocUser(int userID, string userName)
        {
            InitializeComponent();
            this.userID = userID;
            this.userName = userName;
            pictureHeight = this.locViewPictureBox.Height;
            pictureWidth = this.locViewPictureBox.Width;
            locViewPictureBox.Image = locMapBitMap;
            locViewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            locViewPictureBox.Width = locMapBitMap.Width;
            locViewPictureBox.Height = locMapBitMap.Height;
            //g = Graphics.FromImage(locMapBitMap);
            pointWidth = pictureWidth / 50;
        }

        SerialPort _serialPort;
        private int userID;
        private string userName;
        private string deviceMAC;
        private Graphics g;
        private int pictureHeight;
        private int pictureWidth;
        private int time = 0;
        private List<Point> pointList = new List<Point>();
        private int pointWidth;
        private int zoomStep = 40;
        private Point mouseDownPoint = new Point();
        private bool isMove = false;
        private Bitmap locMapBitMap = new Bitmap("C:\\Users\\jingao\\Desktop\\map.png");
        private Bitmap originMapBitMap = new Bitmap("C:\\Users\\jingao\\Desktop\\map.png");
        private int[,] beacon;
        private int beacon_num;
        private delegate void getPortData(string data);
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addLocationResultButton_Click(object sender, EventArgs e)
        {
            DAL.User userControl = new DAL.User();
            this.deviceMAC = userControl.getUserDeviceMAC(this.userName);
            if (deviceMAC == "")
            {
                MessageBox.Show("你还没有被分配定位标签");
            }
            else
            {
                try
                {
                    if (!_serialPort.IsOpen)
                        _serialPort.Open();

                    _serialPort.Write("SI\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
                }
            }
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

        private void formLocUser_Load(object sender, EventArgs e)
        {
            _serialPort = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            int[,] map_beacon = { { 0, 0, 1650},
                                  { 7500, 0, 1650},
                                  { 7500, 7400, 1650}, 
                                  { 0, 7400, 950} };
            beacon = map_beacon;
            beacon_num = 4;

        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            indata = indata.Substring(0, 63);
            this.BeginInvoke(new getPortData(si_DataReceived), new object[] { indata });
        }

        private void si_DataReceived(string data)
        {
            Algorithm.Locate locate = new Algorithm.Locate();
            int [] location = locate.getLocation(data, beacon, beacon_num);
            //Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            int x = 780 - location[0] / 10;
            int y = 850 - location[1] / 10;
            //int x = random.Next(pointWidth, locMapBitMap.Width - pointWidth);
            //int y = random.Next(pointWidth, locMapBitMap.Height - pointWidth);
            drawUserLocation(x, y, location[2]);
        }

        private void drawUserLocation(int x, int y, int z)
        {
            locMapBitMap = new Bitmap(originMapBitMap);
            g = Graphics.FromImage(locMapBitMap);
            Point p = new Point(x, y);
            pointList.Add(p);

            this.locationXText.Text = x.ToString();
            this.locationYText.Text = y.ToString();
            this.locationZText.Text = z.ToString();
            //this.locationYText.Text = pointList.Count.ToString();
            time += 1;
            SolidBrush sb = new SolidBrush(Color.FromArgb(255, Color.Red));
            g.FillEllipse(sb, x - pointWidth, y - pointWidth, pointWidth * 2, pointWidth * 2);
            if(pointList.Count > 20)
            {
                pointList.RemoveRange(0, 15);
            }
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
    }
}
