using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Domain
{
    public class BookStatus
    {
        // vezba 7 -> GUI sa binding listama

        public int KorisnikID { get; set; }
        public int KnjigaID { get; set; }
        public int BrProcitanihStrana { get; set; }
        public Status StatusKnjige{ get; set; }
        public DateTime DatAdded { get; set; }
        public DateTime DatLastModified{ get; set; }
        public Rating Rating{ get; set; }
        public String Feedback{ get; set; }
    }
}
