using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    public static class Criteria
    {
        public enum UserCriteria { id, username, name, lastname, email, address }
        public enum BookCriteria { id, name, page_num, format, date_pub, isbn, genre, language, author, publisher }
        public enum BookStatusCriteria { KorisnikID, KnjigaID, BrProcitanihStrana, StatusKnjige, DatAdded, DatLastModified, Rating, Feedback }
    }
}
