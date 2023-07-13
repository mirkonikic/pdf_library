using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    public enum Operation
    {
        Register,
        Login,
        SearchBookStatus,
        SearchUser,
        EditUser,
        AllUsers,
        DeleteUser,
        CreateBook,
        DeleteBook,
        EditBook,
        CreateBookStatus,
        EditBookStatus
    }

    public enum ResponseCode 
    {
        Success, Failed, Error
    }
}
