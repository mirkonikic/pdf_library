using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Domain
{
    [Serializable]
    public class Publisher
    {
        public int IzdavacID { get; set; }
        public string ImeIzdavaca { get; set; }
        public Publisher() { }
        public Publisher Self { get { return this; } }
        public override string ToString()
        {
            return ImeIzdavaca;
        }
    }
}
