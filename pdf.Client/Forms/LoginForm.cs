using pdf.Client.LoginUserControls;
using pdf.Client.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();

            // BannerPanel da se odmah pojavi
            ChangePanel(new BannerUC());

            // Na BannerUC, postaviti IP adresu i Port i ostala podesavanja
            // -> povezati se i onda otici na login dugme?

            // osmisli kako da kontrolises user kontrole, moja ideja bi bila
            
            // User logs in -> close this form and open main one
            // main forma ima panel u kojem se nalazi gui i menja se na klik
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new BannerUC());
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Controller.Instance.client.isConnected)
                ChangePanel(new LoginUC());
            else
                Controller.Instance.PrintLn("You have to connect first!");
        }
        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Controller.Instance.client.isConnected)
                ChangePanel(new RegisterUC());
            else
                Controller.Instance.PrintLn("You have to connect first!");
        }

        public void PrintLn(string s) 
        {
            MessageBox.Show(s);
        }

        public void ChangePanel(Control control)
        {
            main_panel.Controls.Clear();
            main_panel.Controls.Add(control);
            //control.Dock = DockStyle.Fill;
            //control.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            //main_panel.AutoSize = true;
            //main_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
