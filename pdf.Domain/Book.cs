using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Domain
{
    public class Book
    {
        public int KnjigaID { get; set; }
        public String ImeKnjige { get; set; }
        public int BrStrana { get; set; }
        public Format FormatKnjige { get; set; }
        public DateTime DatPublished { get; set; }
        public int ISBN { get; set; }
        public Zanr Zanr { get; set; }
        public Jezik Jezik { get; set; }
        public string OpisKnjige { get; set; }
        public string VerzijaKnjige { get; set; }
        public int AutorID { get; set; }
        public int IzdavacID { get; set; }

        public Book() { }
    }
}
