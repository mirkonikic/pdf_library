using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Server
{
    public class ClientHandler
    {
        private readonly Socket socket;
        private NetworkStream ns;
        private BinaryFormatter bf;


        public ClientHandler(Socket socket) 
        {
            this.socket = socket;
            ns = new NetworkStream(socket);
            bf = new BinaryFormatter();
        }

        public void HandleRequest() 
        {
            
        }
    }
}
