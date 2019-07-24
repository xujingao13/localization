using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localization
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formLogin frm_login = new formLogin();
            while (frm_login.miClickState == 2)
            {
                frm_login.ShowDialog();
            }
            if (frm_login.miClickState == 1)
            {
                Application.Run(new formLocUser(frm_login.userID, frm_login.userName));
            } else if (frm_login.miClickState == 3)
            {
                Application.Run(new formAdminMain());
            }
        }
    }
}
