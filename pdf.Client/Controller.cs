using pdf.Client.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pdf.Domain;
using System.Diagnostics;

namespace pdf.Client
{
    public enum FormInUse { LoginForm, UserForm, AdminForm, NotSet }
    public class Controller
    {
        public Client client;
        public Speaker speaker;
        public User user;
        public LoginForm lf;
        public UserForm uf;
        public AdminForm af;
        public bool DEBUG = true;
        public bool Admin = false;
        FormInUse curr_form = FormInUse.NotSet; // 0->Login; 1->User; 2->Admin

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
            speaker = new Speaker();
        }

        public void PrintLn(string s) 
        {
            switch(curr_form) 
            {
                case FormInUse.LoginForm:
                    // init Login Page
                    lf.PrintLn(s);
                    break;
                case FormInUse.UserForm:
                    // init User Page
                    uf.PrintLn(s);
                    break;
                case FormInUse.AdminForm:
                    // init Admin Page
                    af.PrintLn(s);
                    break;
                default:
                    break;
            }
        }

        public void InitForm(FormInUse type) 
        {
            DisposeCurrentForm();
            switch (type) 
            {
                case FormInUse.LoginForm:
                    // init Login Page
                    lf = new LoginForm();
                    curr_form = FormInUse.LoginForm;
                    lf.ShowDialog();
                    break;
                case FormInUse.UserForm:
                    // init User Page
                    uf = new UserForm();
                    curr_form = FormInUse.UserForm;
                    uf.ShowDialog();
                    break;
                case FormInUse.AdminForm:
                    // init Admin Page
                    af = new AdminForm();
                    curr_form = FormInUse.AdminForm;
                    af.ShowDialog();
                    break;
                default:
                    lf = new LoginForm();
                    curr_form = 0;
                    break;
            }
        }

        private void DisposeCurrentForm() 
        {
            switch (curr_form)
            {
                case FormInUse.LoginForm:
                    // init Login Page
                    lf.Dispose();
                    break;
                case FormInUse.UserForm:
                    // init User Page
                    uf.Dispose();
                    break;
                case FormInUse.AdminForm:
                    // init Admin Page
                    af.Dispose();
                    break;
                default:
                    break;
            }
        }
    }
}
