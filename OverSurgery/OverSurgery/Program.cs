using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverSurgery
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

            // Set the connection string.
            DatabaseConnection.ConnectionStr = Properties.Settings.Default.DBConnection;
            // Application.Run(new Form1());
            Application.Run(new ApplicationMenu());
            
        }
    }
}
