using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client.UserControls
{
    public partial class BannerUC : UserControl
    {
        public BannerUC()
        {
            InitializeComponent();
            setBtns();
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            // Validate IP and Port -> Regex najlakse
            Regex validateIPv4Regex = new Regex("^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            Regex validatePortRegex = new Regex("^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");

            if (ip_txt.Text == "" || port_lbl.Text == "")
            {
                Controller.Instance.PrintLn("Both fields must be filled!");
                return;
            }
            else if (!validateIPv4Regex.IsMatch(ip_txt.Text))
            {
                Controller.Instance.PrintLn("Ip validation did not pass!");
                return;
            }
            else if (!validatePortRegex.IsMatch(port_txt.Text)) 
            {
                Controller.Instance.PrintLn("Port validation did not pass!");
                return;
            }

            Controller.Instance.client.IpAddress = ip_txt.Text;
            Controller.Instance.client.Port = port_txt.Text;
            // Connect with Client
            // Keep connection for later sending of commands
            Controller.Instance.client.Start();
            setBtns();
        }
        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            Controller.Instance.client.Stop();
            setBtns();
        }

        private void setBtns()
        {
            connect_btn.Enabled = !Controller.Instance.client.isConnected;
            disconnect_btn.Enabled = Controller.Instance.client.isConnected;
            
            connect_btn.BackColor = !Controller.Instance.client.isConnected == true ? SystemColors.MenuHighlight : SystemColors.Control;
            connect_btn.ForeColor = !Controller.Instance.client.isConnected == true ? SystemColors.ButtonHighlight : SystemColors.ActiveBorder;
            disconnect_btn.BackColor = SystemColors.Control;
        }
    }
}
