using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.ServerTty
{

    public class Controller
    {
        // stores:
        //      CommandParser
        //      ClientHandler
        //      Sockets
        //      Form Interface
        //      Server socket

        public Terminal terminal;
        public Server server;
        public Parser parser;
        public List<Handler> clients = new List<Handler>();

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        }
        private Controller()
        {
            terminal = new Terminal();
            server = new Server();
            parser = new Parser();
        }
    }
}
