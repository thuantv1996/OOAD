using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Features.Login.Main;
namespace ClinicManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(!System.IO.File.Exists("connections.config") || !System.IO.File.Exists("connectionString.txt"))
            {
                Application.Run(new SetupForm());
            }
            else
            {
                Application.Run(new LoginForm());
            } 
        }
    }
}
