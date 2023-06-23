using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using pdf.Common;

namespace pdf.Client
{
    public class Client
    {
        Socket socket;
        public Communication c;
        public string IpAddress = "127.0.0.1";
        public string Port = "9999";

        public Client() 
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start() 
        {
            socket.Connect(IpAddress, Int32.Parse(Port));
        }
        public void Stop() { }
    }
}
