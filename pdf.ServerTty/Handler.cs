using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using pdf.Common;
using pdf.Domain;

namespace pdf.ServerTty
{
    public class Handler
    {
        //private readonly Socket socket;
        //private NetworkStream ns;
        //private BinaryFormatter bf;
        private User user;
        private Communication c;
        public bool end = false;

        public Handler(Socket socket)
        {
            c = new Communication(socket);
        }

        // here implement protocol
        public void HandleRequests()
        {
            Controller.Instance.terminal.PrintLn($"New Client connected {user.Name} {c.socket.RemoteEndPoint}!");
            // Ovde usluzujemo klijente, primljeni su i pokrenut je thread
            // Za sada samo vraca isti paket
            while (!end)
            {
                Packet p = c.Recv<Packet>();
                c.Send(p);
            }

        }

        public void Kick() { }
        public void Message() { }
    }
}
