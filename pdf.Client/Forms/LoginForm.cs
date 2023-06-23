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
            main_panel.Controls.Clear();
            BannerUC buc = new BannerUC();
            main_panel.Controls.Add(buc);

            // Na BannerUC, postaviti IP adresu i Port i ostala podesavanja
            // -> povezati se i onda otici na login dugme?

            // osmisli kako da kontrolises user kontrole, moja ideja bi bila
            
            // User logs in -> close this form and open main one
            // main forma ima panel u kojem se nalazi gui i menja se na klik
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();
            BannerUC buc = new BannerUC();
            main_panel.Controls.Add(buc);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();
            LoginUC luc = new LoginUC();
            main_panel.Controls.Add(luc);
        }
    }
}
