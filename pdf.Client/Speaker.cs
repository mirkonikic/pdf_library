using pdf.Common;
using pdf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public List<Autor> AllAuthors() 
        {
            List<Autor> authors = null;
            Request req = new Request() { Operation = Operation.AllAuthors };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                authors = Communication.parseResponse<List<Autor>>(response);
            return authors;
        }
        public List<Publisher> AllPublishers() 
        {
            List<Publisher> publishers = null;
            Request req = new Request() { Operation = Operation.AllPublishers };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                publishers = Communication.parseResponse<List<Publisher>>(response);
            return publishers;
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
        public bool CreateBook(Book b) 
        {
            Request req = new Request() { Operation = Operation.CreateBook, Argument = b };
            Controller.Instance.client.c.Send(req);
            Response response;
            try
            {
                response = Controller.Instance.client.c.Recv<Response>();
            }
            catch(Exception e) 
            {
                serverDied();
                return false;
            }

            return response.ResponseCode == ResponseCode.Success;
        }
        public List<Book> AllBooks()
        {
            List<Book> books = null;
            Request req = new Request() { Operation = Operation.AllBooks };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                books = Communication.parseResponse<List<Book>>(response);
            return books;
        }
        public bool DeleteBook(Book b) 
        {
            Request req = new Request() { Operation = Operation.DeleteBook, Argument = b };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            return response.ResponseCode == ResponseCode.Success;
        }
        public bool EditBook(Book b) 
        {
            Request req = new Request() { Operation = Operation.EditBook, Argument = b };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            return response.ResponseCode == ResponseCode.Success;
        }
        public List<BookStatus> SearchBookStatus(User u, Book b) 
        { 
            return new List<BookStatus>(); 
        }
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
        public List<Book> SearchBook(CriteriaArg ca)
        {
            List<Book> books = null;
            Request req = new Request() { Operation = Operation.SearchBook, Argument = ca };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                books = Communication.parseResponse<List<Book>>(response);
            return books;
        }

        public bool CreateBookStatus(List<BookStatus> lbs) 
        {
            Request req = new Request() { Operation = Operation.CreateBookStatus, Argument = lbs };
            Controller.Instance.client.c.Send(req);
            Response response;
            try
            {
                response = Controller.Instance.client.c.Recv<Response>();
            }
            catch (Exception e)
            {
                serverDied();
                return false;
            }

            return response.ResponseCode == ResponseCode.Success;
        }
        public bool EditBookStatus(List<BookStatus> lbs) 
        {
            Request req = new Request() { Operation = Operation.EditBookStatus, Argument = lbs };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            return response.ResponseCode == ResponseCode.Success;
        }
        public List<BookStatus> AllStatus()
        {
            List<BookStatus> status = null;
            Request req = new Request() { Operation = Operation.AllBookStatuses };
            Controller.Instance.client.c.Send(req);
            Response response = Controller.Instance.client.c.Recv<Response>();
            if (response.ResponseCode == ResponseCode.Success)
                status = Communication.parseResponse<List<BookStatus>>(response);
            return status;
        }

        public void serverDied() 
        {
            MessageBox.Show("This server died!");
            Controller.Instance.InitForm(FormInUse.LoginForm);
            Controller.Instance.client.Stop();
        }
    }
}
