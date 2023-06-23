using pdf.Client.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Client
{
    public class Controller
    {
        public Client client;
        public LoginForm lf;
        public UserForm uf;
        public AdminForm af;

        private static Controller instance;
        public static Controller Instance { 
            get { 
                if (instance == null)
                        instance = new Controller();
                return instance; 
            } 
        }

        private Controller() 
        {
            client = new Client();
        }
    }
}
