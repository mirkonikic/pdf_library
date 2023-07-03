using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace pdf.ServerTty
{
    public class Server
    {
        private Socket serverSocket;
        private Thread handleReq;

        public Server()
        {
            //handleReq.IsBackground = true; 
        }

        public void Start(string ip_addr, int port)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip_addr), port);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);
        }

        public void HandleClients()
        {
            while (true)
            {
                try
                {
                    Socket socket_cli = serverSocket.Accept();
                    Handler cli = new Handler(socket_cli);
                    // lista client_handlera koji se kreira za svaki socket
                    Controller.Instance.clients.Add(cli);
                    handleReq = new Thread(cli.HandleRequests);
                    handleReq.Start();

                }
                catch (SocketException ex)
                {
                    Debug.WriteLine(ex.ToString());
                    break;
                }
            }
        }

        public void Stop()
        {
            serverSocket.Close();
            serverSocket = null;
        }

        public Boolean isNull() { return (serverSocket == null); }
    }
}
