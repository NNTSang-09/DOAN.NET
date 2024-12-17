using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_Ban_Thuoc
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   // đổi tên SQL ở data Source= để sử dụng csdl 
            string connectionString = @"Data Source=.;Initial Catalog=pharmacy;Integrated Security=True;TrustServerCertificate=True;";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin(connectionString));
        }
    }
}
