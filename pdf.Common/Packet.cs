using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    public enum Operation 
    {
        Request,
        Response
    }

    [Serializable]
    public class Packet
    {
        public Operation op;
        public int Code { get; set; }
        public byte[] Data { get; set; }

        public Packet() { }
    }
}
