using pdf.Client.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Controller.Instance.InitLogin();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm lf = new LoginForm();
            DialogResult dr = lf.ShowDialog();
            lf.Dispose();
            if (dr == DialogResult.OK)
            {
                Application.Run(new UserForm());
            }
            else if (dr == DialogResult.Yes) 
            {
                Application.Run(new AdminForm());
            }
        }
    }
}
