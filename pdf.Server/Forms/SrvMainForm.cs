using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Server
{
    public partial class SrvMainForm : Form
    {
        Boolean running = false;
        // prebaci u Controller-a
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
            Controller.Instance.server.Stop();
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            // 1:24:00 -> 11 vezbe mp4
            running = true;
            setButtons();
            Controller.Instance.server.Start();
            Thread nit = new Thread(Controller.Instance.server.HandleClients);
            nit.Start();
            banner();
        }
        private void setButtons()
        {
            start_btn.Enabled = !running;
            stop_btn.Enabled = running;
        }
        private void banner()
        {
            updateTxtBoxLn("Server started!");
        }
        private void enter_btn_Click(object sender, EventArgs e)
        {
            // add on enter
            // execute inputed command
            // CommandParser.Parse();
            Controller.Instance.cmdParse.Parse(cmd_tb.Text);
            cmd_tb.Text = "";
        }
        public void updateTxtBoxLn(string inp) 
        {
            main_rtb.Text = main_rtb.Text + inp + '\n';
            // da postavim caret na kraj i skrolujem na dole
            main_rtb.SelectionStart = main_rtb.Text.Length;
            main_rtb.ScrollToCaret();
        }
        public void updateTxtBox(string inp)
        {
            main_rtb.Text = main_rtb.Text + inp;
            // da postavim caret na kraj i skrolujem na dole
            main_rtb.SelectionStart = main_rtb.Text.Length;
            main_rtb.ScrollToCaret();
        }
        private void cmd_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                // Parse the command inputted
                Controller.Instance.cmdParse.Parse(cmd_tb.Text);
                cmd_tb.Text = "";
            }
        }

        private void SrvMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
