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
        public int CheckUser(string userName, string passWord)
        {
            ConnectDB db = new ConnectDB();
            int status = 0;
            string real_password;
            string query = $"SELECT * FROM user where UserName=\'{userName}\'";
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
            int status = 0;
            string check_query = $"SELECT * from user where UserName = \'{userName}\'";
            string query = $"INSERT INTO user (UserName,PassWord) VALUES(\'{userName}\',\'{passWord}\')";
            if (db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(check_query, db.connection);
                MySqlDataReader checkReader = cmd.ExecuteReader();
                if (checkReader.HasRows)
                {
                    status = 0;
                }
                else
                {
                    db.connection.Close();
                    db.connection.Open();
                    cmd = new MySqlCommand(query, db.connection);
                    cmd.ExecuteNonQuery();
                    status = (int)cmd.LastInsertedId;
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
    }
}
