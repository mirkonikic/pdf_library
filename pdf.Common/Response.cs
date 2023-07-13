using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    [Serializable]
    public class Response
    {
        public ResponseCode ResponseCode { get; set; }
        public object Argument { get; set; }
        public Exception Exception { get; set; }
    }
}
