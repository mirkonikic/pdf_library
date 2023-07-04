using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pdf.Server
{
    public class Server
    {
        private Socket serverSocket;
        private bool running; // cuvaj ovo mozda u databazi
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
        }

        public void HandleClients() 
        {
            while (true)
            {
                try {
                    Socket socket_cli = serverSocket.Accept();
                    ClientHandler cli = new ClientHandler(socket_cli);
                    // lista client_handlera koji se kreira za svaki socket
                    Controller.Instance.clients.Add(cli);
                    Thread handleReq = new Thread(cli.HandleRequests);
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

        public bool isRunning() { return running == true; }
    }
}
