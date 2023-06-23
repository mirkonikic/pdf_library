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
    public partial class BannerUC : UserControl
    {
        public BannerUC()
        {
            InitializeComponent();
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            // Validate IP and Port
            Controller.Instance.client.IpAddress = ip_txt.Text;
            Controller.Instance.client.Port = port_lbl.Text;
            
            // Connect with Client
            // Keep connection for later sending of commands
        }
    }
}
