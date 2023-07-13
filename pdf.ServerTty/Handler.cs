using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using pdf.Common;
using pdf.Domain;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace pdf.ServerTty
{
    public class Handler
    {
        public User user;
        private Communication c;
        public bool end = false;

        public Handler(Socket socket)
        {
            c = new Communication(socket);
            user = new User();
        }

        // here implement protocol
        public void HandleRequests()
        {
            Controller.Instance.terminal.sPrintLn($"New Client connected {user.Name} {c.socket.RemoteEndPoint}!");
            try
            {
                while (true)
                {
                    Request r = c.Recv<Request>();
                    Response response = parseRequests(r);
                    c.Send(response);
                }
            }
            catch (SocketException ex)
            {
                Controller.Instance.terminal.sPrintLn($"Client disconnected: {user.Name} {c.socket.RemoteEndPoint}!");
                Controller.Instance.terminal.ePrintLn($"Exception caught: {ex.Message}");
                for (int i = 0; i < Controller.Instance.clients.Count; i++)
                {
                    if (c.socket.RemoteEndPoint == Controller.Instance.clients[i].c.socket.RemoteEndPoint)
                    {
                        Controller.Instance.clients.RemoveAt(i);
                    }
                }
                Debug.WriteLine(">>>" + ex.Message);
            }
            catch (IOException ex)
            {
                Controller.Instance.terminal.sPrintLn($"Client disconnected: {user.Name} {c.socket.RemoteEndPoint}!");
                Controller.Instance.terminal.ePrintLn($"Exception caught: {ex.Message}");
                for (int i = 0; i < Controller.Instance.clients.Count; i++)
                {
                    if (c.socket.RemoteEndPoint == Controller.Instance.clients[i].c.socket.RemoteEndPoint)
                    {
                        Controller.Instance.clients.RemoveAt(i);
                    }
                }
                Debug.WriteLine(">>>" + ex.Message);
            }
            catch (SerializationException ex)
            {
                Controller.Instance.terminal.sPrintLn($"Client disconnected: {user.Name} {c.socket.RemoteEndPoint}!");
                Controller.Instance.terminal.ePrintLn($"Exception caught: {ex.Message}");
                for (int i = 0; i < Controller.Instance.clients.Count; i++)
                {
                    if (c.socket.RemoteEndPoint == Controller.Instance.clients[i].c.socket.RemoteEndPoint)
                    {
                        Controller.Instance.clients.RemoveAt(i);
                    }
                }
                Debug.WriteLine(">>>" + ex.Message);
            }
        }

        public Response parseRequests(Request r) 
        {
            // Ovde usluzujemo klijente, primljeni su i pokrenut je thread
            // Za sada samo vraca isti paket
            Response resp = new Response { ResponseCode = ResponseCode.Failed, Argument = null };
            Book result_b;
            User result_u;
            Controller.Instance.terminal.vPrintLn($"Client sent a packet! {r.Operation.ToString()}");

            try
            {
                switch (r.Operation)
                {
                    case Operation.Register:
                        Controller.Instance.terminal.vPrintLn($"Register Attempt: {user.Name} {c.socket.RemoteEndPoint} claims he is {Communication.parseRequest<User>(r).UserName}!");
                        // Logic for Register operation
                        // Check for collision! -> usernames are unique!
                        List<User> u_reg = Controller.Instance.broker.PretraziKorisnike(new CriteriaArg { uc = Criteria.UserCriteria.username, val = Communication.parseRequest<User>(r).UserName});
                        if (u_reg.Count == 0)
                        {
                            Controller.Instance.terminal.vPrintLn($" validation passed! no username: {Communication.parseRequest<User>(r).UserName}");
                            if (Controller.Instance.broker.NapraviKorisnika(Communication.parseRequest<User>(r)))
                            {
                                // Success
                                result_u = Communication.parseRequest<User>(r);
                                resp = new Response { ResponseCode = ResponseCode.Success, Argument = result_u };
                            }
                            else
                            {
                                // Fail
                                Controller.Instance.terminal.ePrintLn($" couldnt register! {Communication.parseRequest<User>(r).UserName}");
                            }
                        }
                        else 
                        {
                            Controller.Instance.terminal.ePrintLn($" validation not passed! db returned {u_reg.Count} users with usrnm: {Communication.parseRequest<User>(r).UserName}");
                        }
                        break;
                    case Operation.Login:
                        Controller.Instance.terminal.vPrintLn($"Login Attempt: {user.Name} {c.socket.RemoteEndPoint} claims he is {Communication.parseRequest<User>(r).UserName}!");
                        // Success ili Failed
                        // pozovi nad bazom -> uporedi dal Password and Username matches
                        List<User> u_log = Controller.Instance.broker.PretraziKorisnike(new CriteriaArg { uc = Criteria.UserCriteria.username, val = Communication.parseRequest<User>(r).UserName });
                        // loop trough the list and check for password + username match
                        foreach (var u in u_log) 
                        {
                            Controller.Instance.terminal.vPrintLn($"   testing: {u.UserName} == {Communication.parseRequest<User>(r).UserName} AND {u.Password} == {Communication.parseRequest<User>(r).Password}");
                            if (u.UserName == Communication.parseRequest<User>(r).UserName && u.Password == Communication.parseRequest<User>(r).Password)
                            {
                                Controller.Instance.terminal.vPrintLn($"Found him: {u.Id} {u.UserName} {u.Password}");
                                result_u = new User { Id = u.Id, UserName = u.UserName, Name = u.Name, LastName = u.LastName, Email = u.Email, Address = u.Address, isAdmin = u.isAdmin, Password = u.Password };
                                resp = new Response { ResponseCode = ResponseCode.Success, Argument = result_u };
                                user = result_u;
                                break;
                            }
                        }
                        break;
                    case Operation.EditUser:
                        User resp_u = Communication.parseRequest<User>(r);
                        Controller.Instance.terminal.vPrintLn($"Edit Attempt: {user.Name} {c.socket.RemoteEndPoint}");
                        Controller.Instance.terminal.vPrintLn($"        old: {user.Id} {user.UserName} {user.Name} {user.LastName} {user.Address} {user.Email} {user.Password}");
                        Controller.Instance.terminal.vPrintLn($"        new: {resp_u.Id} {resp_u.UserName} {resp_u.Name} {resp_u.LastName} {resp_u.Address} {resp_u.Email} {resp_u.Password}");
                        // Success ili Failed
                        // pozovi nad bazom -> uporedi dal Password and Username matches

                        if (Controller.Instance.broker.IzmeniKorisnika(resp_u)) 
                        {
                            resp = new Response { Argument = resp_u, ResponseCode = ResponseCode.Success };
                        }
                        break;
                    case Operation.DeleteUser:
                        User del_u = Communication.parseRequest<User>(r);
                        Controller.Instance.terminal.vPrintLn($"Delete Attempt: {user.Name} {c.socket.RemoteEndPoint}");
                        Controller.Instance.terminal.vPrintLn($"        del: {del_u.Id} {del_u.UserName} {del_u.Name} {del_u.LastName} {del_u.Address} {del_u.Email} {del_u.Password}");
                        // Success ili Failed
                        // pozovi nad bazom -> uporedi dal Password and Username matches

                        List<User> u_del = Controller.Instance.broker.PretraziKorisnike(new CriteriaArg { uc = Criteria.UserCriteria.id, val = Communication.parseRequest<User>(r).Id.ToString() });
                        if(u_del.Count > 1) { Controller.Instance.terminal.ePrintLn("Something went wrong!"); }

                        if (u_del[0].isDeleted == false) 
                        {
                            if (Controller.Instance.broker.SakrijKorisnika(del_u))
                            {
                                resp = new Response { ResponseCode = ResponseCode.Success };
                            }
                        }
                        else 
                        {
                            if (Controller.Instance.broker.ObrisiKorisnika(del_u))
                            {
                                resp = new Response { ResponseCode = ResponseCode.Success };
                            }
                        }
                        break;
                    case Operation.AllUsers:
                        Controller.Instance.terminal.vPrintLn($"All Users Attempt: {user.Name} {c.socket.RemoteEndPoint}");
                        List<User> all_u = null;
                        all_u = Controller.Instance.broker.UcitajKorisnike();
                        Controller.Instance.terminal.vPrintLn($"Number of users retrieved: {all_u.Count}");
                        if (all_u != null)
                            resp = new Response { ResponseCode = ResponseCode.Success, Argument = all_u };
                        break;
                    case Operation.SearchUser:
                        Controller.Instance.terminal.vPrintLn($"Search User Attempt: {user.Name} {c.socket.RemoteEndPoint}");
                        List<User> search_u = null;
                        search_u = Controller.Instance.broker.PretraziKorisnike(Communication.parseRequest<CriteriaArg>(r));
                        Controller.Instance.terminal.vPrintLn($"Number of users retrieved: {search_u.Count}");
                        if (search_u != null)
                            resp = new Response { ResponseCode = ResponseCode.Success, Argument = search_u };
                        break;
                    default:
                        resp = new Response();
                        // Default case when the selected operation is not handled
                        break;
                }
            }
            catch (Exception ex) 
            {
                resp = new Response { Exception = new Exception(ex.Message), ResponseCode = ResponseCode.Error };
            }

            return resp;
        }

        public void Kick() { }
        public void Message() {  }
    }
}
