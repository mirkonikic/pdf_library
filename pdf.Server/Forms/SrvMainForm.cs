using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Server
{
    public partial class SrvMainForm : Form
    {
        Boolean running = false;
        Server server;
        CommandParser cmd;

        public SrvMainForm()
        {
            InitializeComponent();
            setButtons();
            server = new Server();
            cmd = new CommandParser();
            // napravi thread koji uhvati klijenta
            // napravi singleton koji cuva najbitnije
            // napravi nacin da komand parser prati sve sto se desava, najverovatnije preko singltona
            // 22 minut 10. vezbe

            // podici bazu podataka za server
            // ispisati komandu za svaki moguci zahtev klijenta
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            running = false;
            setButtons();
            server.Stop();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            running = true;
            setButtons();
            server.Start();
            banner();
        }

        private void setButtons() 
        {
            start_btn.Enabled = !running;
            stop_btn.Enabled = running;
        }

        private void banner() 
        {
            main_rtb.Text += "Server started!\n";
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            // execute inputed command
            
        }
    }
}
