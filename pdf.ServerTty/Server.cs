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
        private bool running;

        public Server()
        {
            //handleReq.IsBackground = true; 
        }

        public void Start(string ip_addr, int port)
        {
            if (running != true)
            {
                running = true;
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip_addr), port);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(10);
                Controller.Instance.terminal.vPrintLn($"Server started on address: {((IPEndPoint)serverSocket.LocalEndPoint).ToString()}");
            }
            else 
            {
                Controller.Instance.terminal.ePrintLn($"Error: server is already running on port: {((IPEndPoint)serverSocket.LocalEndPoint).Port}");
            }
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
            if (running != false)
            {
                running = false;
                serverSocket.Close();
                serverSocket = null;
                Controller.Instance.terminal.vPrintLn($"Server stopped! {(serverSocket)}");
            }
            else 
            {
                Controller.Instance.terminal.ePrintLn($"Error: server is not running!");
            }
        }

        public Boolean isNull() { return (serverSocket == null); }
        public Boolean isRunning() { return running; }
    }
}
