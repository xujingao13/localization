using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
        }

        public SerialPort _serialPort;
        private int[,] beacon;
        private int beacon_num;
        private Bitmap originMapBitMap = new Bitmap("C:\\Users\\jingao\\Desktop\\map.png");
        private Point mouseDownPoint = new Point();
        private bool isMove = false;
        private int zoomStep = 20;
        private List<string> drawMacList = new List<string>();
        private List<UserControl> userList = new List<UserControl>();
        Dictionary<string, string> userDeviceAssociate = new Dictionary<string, string>();
        private delegate void getPortData(string data);
        private Dictionary<string, Color> colorDic = new Dictionary<string, Color>();

        private Dictionary<string, List<Point>> allUserLocations = new Dictionary<string, List<Point>>();

        private void exitButton_Click(object sender, EventArgs e)
        {
            _serialPort.Close();
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
            originMapBitMap = new Bitmap(mapFileName);
            if(originMapBitMap == null)
            {
                MessageBox.Show("读取失败");
                return;
            }
            locViewPictureBox.Image = originMapBitMap;
            locViewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            locViewPictureBox.Width = originMapBitMap.Width;
            locViewPictureBox.Height = originMapBitMap.Height;
           
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
                if (locViewPictureBox.Width < originMapBitMap.Width / 10)
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

        private void Control_CheckChanged(object sender, EventArgs e)
        {
            drawMacList.Clear();
            //MessageBox.Show("rrrrr");
            foreach (UControl_userCheck temp_user in userList)
            {
                if (temp_user.userSelectedBox.CheckState == CheckState.Checked)
                {
                    drawMacList.Add(userDeviceAssociate[temp_user.userNameLabel.Text]);
                }
            }
        }

        private void formLocAdmin_Load(object sender, EventArgs e)
        {
            DAL.User userControl = new DAL.User();
            userDeviceAssociate = userControl.getUserDevice();
            foreach (KeyValuePair<string, string> userDevice in userDeviceAssociate)
            {
                UControl_userCheck temp_user = new UControl_userCheck(userDevice.Key, userDevice.Value);
                temp_user.CheckChanged += new System.EventHandler(this.Control_CheckChanged);
                userList.Add(temp_user);
                this.flowLayoutPanel1.Controls.Add(temp_user);

                allUserLocations.Add(userDevice.Value, new List<Point>());
            }

            _serialPort = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            int[,] map_beacon = { { 0, 0, 1650},
                                  { 7500, 0, 1650},
                                  { 7500, 7400, 1650},
                                  { 0, 7400, 950} };
            beacon = map_beacon;
            beacon_num = 4;

            locViewPictureBox.Image = originMapBitMap;
            locViewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            locViewPictureBox.Width = panel1.Width;
            

            colorDic.Add("a0", Color.Red);
            colorDic.Add("a1", Color.Green);
            colorDic.Add("a2", Color.Yellow);
        }

        public void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            indata = indata.Substring(0, 63);
            string temp_mac = indata.Substring(59, 2);
            if (drawMacList.Count == 0)
            {
                locViewPictureBox.Image = originMapBitMap;
            }
            if (drawMacList.Contains(temp_mac))
            {
                this.BeginInvoke(new getPortData(si_DataReceived), new object[] { indata });
            }
        }

        private void si_DataReceived(string data)
        {
            Algorithm.Locate locate = new Algorithm.Locate();
            int[] location = locate.getLocation(data, beacon, beacon_num);
            int x = 780 - location[0] / 10;
            int y = 850 - location[1] / 10;
            string temp_mac = data.Substring(59, 2);
            allUserLocations[temp_mac].Add(new Point(x, y));
            if (allUserLocations[temp_mac].Count > 20)
            {
                allUserLocations[temp_mac].RemoveRange(0, 15);
            }
            mapRefresh();
        }

        private void mapRefresh()
        {
            Bitmap locMapBitMap = new Bitmap(originMapBitMap);
            foreach (KeyValuePair<string, List<Point>> userLocations in allUserLocations)
            {
                if (drawMacList.Contains(userLocations.Key))
                {
                    drawUserLocation(userLocations.Key, userLocations.Value, locMapBitMap);
                }
            }
        }
        private void drawUserLocation(string mac, List<Point> pointList, Bitmap locMapBitMap)
        {
            int len = pointList.Count;
            if(len == 0)
            {
                return;
            }
            int pointWidth = locMapBitMap.Width / 40;
            Graphics g = Graphics.FromImage(locMapBitMap);
            int x = pointList[pointList.Count - 1].X;
            int y = pointList[pointList.Count - 1].Y;
            

            //this.locationYText.Text = pointList.Count.ToString();
            SolidBrush sb = new SolidBrush(Color.FromArgb(255, colorDic[mac]));
            g.FillEllipse(sb, x - pointWidth, y - pointWidth, pointWidth * 2, pointWidth * 2);
            if (pointList.Count > 20)
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
                    Color brush_color = Color.FromArgb(255 - i * 40, colorDic[mac]);
                    Color pen_color = Color.FromArgb(255 - i * 40, Color.Gray);
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
