using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace pdf.Server
{
    public class Controller
    {
        // stores:
        //      CommandParser
        //      ClientHandler
        //      Sockets
        //      Form Interface
        //      Server socket

        private SrvMainForm form;
        public Server server;
        public CommandParser cmdParse;
        public List<ClientHandler> clients = new List<ClientHandler>();

        private static Controller instance;
        public static Controller Instance {
            get
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        }
        private Controller()
        {
            server = new Server();
            cmdParse = new CommandParser();
        }

        public void PrintOnTerminal(string p) => form.updateTxtBoxLn(p);
        public void SetForm(SrvMainForm f) => this.form = f;
    }
}
