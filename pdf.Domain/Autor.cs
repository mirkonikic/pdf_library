using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Domain
{
    [Serializable]
    public class Autor
    {
        public int AutorID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Autor() { }
        public Autor Self { get { return this; } }
        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
