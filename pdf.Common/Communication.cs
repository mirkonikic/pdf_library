using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    public class Communication
    {
        public Socket socket;
        NetworkStream ns;
        BinaryFormatter bf;

        public Communication(Socket socket) 
        {
            this.socket = socket;
            ns = new NetworkStream(socket);
            bf = new BinaryFormatter();
        }

        public void Send<T> (T message) where T : class { bf.Serialize(ns, message); }
        public T Recv<T> () where T : class { return (T)bf.Deserialize(ns); }
    }
}
