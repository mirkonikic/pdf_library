using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Domain
{
    public enum Status
    {
        NotSet = 0,
        to_read = 1,
        reading = 2,
        read = 3
    }
}
