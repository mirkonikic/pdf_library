using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using pdf.Common;

namespace pdf.Server
{
    public class ClientHandler
    {
        //private readonly Socket socket;
        //private NetworkStream ns;
        //private BinaryFormatter bf;
        private string name = "default";
        private Communication c;
        public bool end = false;

        public ClientHandler(Socket socket) 
        {
            c = new Communication(socket);
        }

        // here implement protocol
        public void HandleRequests() 
        {
            Controller.Instance.PrintOnTerminal("New client connected!");
            // Ovde usluzujemo klijente, primljeni su i pokrenut je thread
            // Za sada samo vraca isti paket
            while (!end) 
            {
                Packet p = c.Recv<Packet>();
                c.Send(p);
            }
            
        }

        public override string ToString()
        {
            return name + c.socket.RemoteEndPoint;
        }
    }
}
