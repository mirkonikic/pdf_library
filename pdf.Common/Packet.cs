using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    [Serializable]
    public class Packet
    {
        public int Code { get; set; }
        public byte[] Data { get; set; }

        public Packet() { }
    }
}
