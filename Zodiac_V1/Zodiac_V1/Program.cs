using System;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace MASSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] p;
            p = Process.GetProcessesByName(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            if (p.Length > 1)
            {
                MessageBox.Show("Already Tool is Running", "Zodiac_V1.0", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                Application.Exit();
            }
            else

            {
                Start();
            }
        }
        private static void Start()
        {
            if (MainModule.gsFTP == string.Empty)
            {
                Application.Run(new frmSettings());
                Application.Exit();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSync());
              
        }
    }
}
