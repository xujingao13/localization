using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class User
    {
        public struct userInfo
        {
            //public int userID;
            public int DeviceId;
            public string userName;
        }
        public int CheckUser(string userName, string passWord)
        {
            ConnectDB db = new ConnectDB();
            int status = 0;
            string real_password;
            string query = $"SELECT * FROM user where UserName='{userName}'";
            if (db.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    real_password = dataReader["PassWord"].ToString();
                    if (real_password == passWord)
                    {
                        status = int.Parse(dataReader["UserID"].ToString());
                    }
                    else
                    {
                        status = 0;
                    }
                }
                db.CloseConnection();
            }
            else
            {
                status = -1;
            }
            return status;
        }
        
        public int AddUser(string userName, string passWord)
        {
            ConnectDB db = new ConnectDB();
            int status = 1;
            string check_query = $"SELECT * from user where UserName = '{userName}'";
            string query = $"INSERT INTO user (UserName,PassWord) VALUES('{userName}','{passWord}')";
            if (db.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(check_query, db.connection))
                {
                    MySqlDataReader checkReader = cmd.ExecuteReader();
                    if (checkReader.HasRows)
                    {
                        status = 0;
                    }
                }
         
                if(status != 0)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                    {
                        cmd.ExecuteNonQuery();
                        status = (int)cmd.LastInsertedId;
                    }
                }
                //close connection
                db.CloseConnection();
            }
            else
            {
                status = -1;
            }
            return status;
        }

        public int UpdateUser(string userName, int deviceID)
        {
            ConnectDB db = new ConnectDB();
            int status = 0;
            string query = "";
            if (deviceID > 0)
            {
                query = $"UPDATE user SET DeviceID = {deviceID} where UserName='{userName}'";
            }
            else
            {
                query = $"UPDATE user SET DeviceID = null where UserName='{userName}'";
            }
            if (db.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                {
                    status = cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
            else
            {
                status = -1;
            }
            return status;
        }

        public Dictionary<int, userInfo> getUserInfo()
        {
            Dictionary<int, userInfo> ds = new Dictionary<int, userInfo>();
            ConnectDB db = new ConnectDB();
            if (db.OpenConnection() == true)
            {
                string query = "SELECT * from user";
                using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        userInfo user_info = new userInfo();
                        if ((dataReader["DeviceID"] == null) || (string.IsNullOrEmpty(dataReader["DeviceID"].ToString())))
                        {
                            user_info.DeviceId = -1;
                        }
                        else
                        {
                            user_info.DeviceId = int.Parse(dataReader[1].ToString());
                        }
                        user_info.userName = dataReader[2].ToString();
                        ds.Add(int.Parse(dataReader[0].ToString()), user_info);
                    }
                }
                db.CloseConnection();
            }
            return ds;
        }
    }
}
