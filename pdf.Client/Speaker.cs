using pdf.Common;
using pdf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Client
{
    public class Speaker
    {
        public Speaker() { }

        // calls Controller.Instance.Client....

        public bool Login(User u) 
        {
            // prosledi objekat user 
            Request request = new Request { Operation = Operation.Login, Argument = u };
            Controller.Instance.client.c.Send(request);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if(response.ResponseCode == ResponseCode.Success) 
                Controller.Instance.user = Communication.parseResponse<User>(response);
            return response.ResponseCode == ResponseCode.Success;
        }
        public bool Register(User u) 
        {
            // prosledi objekat user 
            Request request = new Request { Operation = Operation.Register, Argument = u };
            Controller.Instance.client.c.Send(request);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                Controller.Instance.user = Communication.parseResponse<User>(response);
            return response.ResponseCode == ResponseCode.Success;
        }

        // Edit Delete Create can be made into generics
        // oba ce traziti po id? -> mogu da napravim jos jedan argument npr za criteria

        public bool EditUser(User u)
        {
            Request req = new Request() { Operation = Operation.EditUser, Argument = u };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                Controller.Instance.user = Communication.parseResponse<User>(response);
            return response.ResponseCode == ResponseCode.Success;
        }
        public List<User> AllUsers() 
        {
            List<User> users = null;
            Request req = new Request() { Operation = Operation.AllUsers };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                users = Communication.parseResponse<List<User>>(response);
            return users;
        }
        public bool DeleteUser(User u) 
        {
            Request req = new Request() { Operation = Operation.DeleteUser, Argument = u };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                Controller.Instance.user = Communication.parseResponse<User>(response);
            return response.ResponseCode == ResponseCode.Success;
        }
        public bool CreateBook() { return false; }
        public bool DeleteBook() { return false; }
        public bool EditBook() { return false; }
        public List<BookStatus> SearchBookStatus(User u, Book b) { return new List<BookStatus>(); }
        public List<User> SearchUser(CriteriaArg ca) 
        {
            List<User> users = null;
            Request req = new Request() { Operation = Operation.SearchUser, Argument = ca };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                users = Communication.parseResponse<List<User>>(response);
            return users;
        }

        public bool CreateBookStatus() { return false; }
        public bool EditBookStatus() { return false; }
    }
}
