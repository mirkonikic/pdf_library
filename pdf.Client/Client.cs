using System;
using System.Collections.Generic;
using System.IO;
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
        public bool isConnected = false;
        public Communication c;
        public string IpAddress = "127.0.0.1";
        public string Port = "9999";

        public Client() 
        {
        }

        public void Start() 
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(IpAddress, Int32.Parse(Port));
                c = new Communication(socket);
                isConnected = true;
            }
            catch(SocketException e)
            {
                Controller.Instance.PrintLn("Connection refused!");            
            }
        }
        
        public void Stop() 
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            isConnected = false;
            socket = null;
            c = null;
        }
    }
}
