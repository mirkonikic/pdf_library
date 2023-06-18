using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    public class Communication
    {
        private readonly Socket socket;
        NetworkStream ns;
        BinaryFormatter bf;

        public Communication(Socket socket) 
        {
            this.socket = socket;
            ns = new NetworkStream(socket);
            bf = new BinaryFormatter();
        }

        public void Send<T> (T message) where T : class { }
        public void Recv<T> (T message) where T : class { }
    }
}
