using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    [Serializable]
    public class CriteriaArg
    {
        public Criteria.UserCriteria uc { get; set; }
        public Criteria.BookCriteria bc { get; set; }
        public Criteria.BookStatusCriteria bsc { get; set; }

        public string val;


        public CriteriaArg() { }
    }   
}
