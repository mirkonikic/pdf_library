using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client.UserControls
{
    public partial class LoginUC : UserControl
    {
        public LoginUC()
        {
            InitializeComponent();
            ip_lbl.Text = Controller.Instance.client.IpAddress;
            port_lbl.Text = Controller.Instance.client.Port;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            // Send login information on already established connection
            // If there is no such account, i get an option to register


        }
    }
}
