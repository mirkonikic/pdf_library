using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Server
{
    public class Server
    {
        Socket serverSocket;
        // ideja mozda ovo ubaciti u singleton

        public Server() 
        {
            // nista za sada
        }

        public void Start() 
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);

            // kasnije dodati accept i nov thread za socket
        }

        public void Listen() 
        {
            // Socket cli = serverSocket.Accept();
            // 
            // 
        }

        public void Stop()
        {
            serverSocket.Close();
        }
    }
}
