using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Common
{
    public enum Operation
    {
        Login,
        SearchUser,
        SearchBook,
        SearchBookStatus,
        AllUsers,
        AllBooks,
        AllAuthors,
        AllPublishers,
        AllBookStatuses,
        DeleteUser,
        DeleteBook,
        EditUser,
        EditBook,
        EditBookStatus,
        Register,
        CreateBook,
        CreateBookStatus,
    }

    public enum ResponseCode 
    {
        Success, Failed, Error
    }
}
