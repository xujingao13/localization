using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Device
    {
        public int AddDevice(string macAddress)
        {
            ConnectDB db = new ConnectDB();
            int status = -1;
            string check_query = $"SELECT * from device where MacAddress = '{macAddress}'";
            string query = $"INSERT INTO device (MacAddress) VALUES('{macAddress}')";
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

                if (status != 0)
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

        public Dictionary<int, string> getDeviceInfo()
        {
            Dictionary<int, string> ds = new Dictionary<int, string>();
            ConnectDB db = new ConnectDB();
            if (db.OpenConnection() == true)
            {
                string query = "SELECT * from device";
                using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ds.Add(int.Parse(dataReader[0].ToString()), dataReader[1].ToString());
                    }
                }
                db.CloseConnection();
            }
            return ds;
        }

        public int deleteDevice(List<int> deleteList)
        {
            int row = 0;
            ConnectDB db = new ConnectDB();
            if (db.OpenConnection() == true)
            {
                string tumple = "(";
                tumple += deleteList[0].ToString();
                for (int i = 1; i < deleteList.Count; i++)
                {
                    tumple += ",";
                    tumple += deleteList[i].ToString();
                }
                tumple += ")";
                string query = $"DELETE from device where DeviceID in {tumple}";

                using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                {
                    row = cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
            else
            {
                row = -1;
            }
            return row;
        }
    }
}
