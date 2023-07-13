using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
        public static T parseResponse<T>(Response response) where T : class
        {
            if (response.Exception == null)
            {
                return (T)response.Argument;
            }
            else
            {
                throw response.Exception;
            }
        }
        public static T parseRequest<T>(Request request) where T : class
        {
            if (request.Argument != null)
            {
                return (T)request.Argument;
            }
            else
            {
                return null;
            }
        }
    }
}
