using pdf.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client.LoginUserControls
{
    public partial class RegisterUC : UserControl
    {
        public RegisterUC()
        {
            InitializeComponent();
            ip_lbl.Text = Controller.Instance.client.IpAddress;
            port_lbl.Text = Controller.Instance.client.Port;
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            Regex validateEmail = new Regex("^\\w+([\\.-]?\\w+)*@\\w+([\\.-]?\\w+)*(\\.\\w{2,3})+$");
            // validate all fields
            // all must not be null
            // password > 8 slova i svi karakteri
            // email -> regex
            if (username_txt.Text == "" || passwd_txt.Text == "" || firstname_txt.Text == "" || lastname_txt.Text == "" || email_txt.Text == "" || address_txt.Text == "")
            {
                Controller.Instance.PrintLn("All field must be filled!");
                return;
            }
            else if (passwd_txt.Text.Length < 9)
            {
                Controller.Instance.PrintLn("Password must be longer than 8 characters!");
                return;
            }
            else if (!validateEmail.IsMatch(email_txt.Text)) 
            {
                Controller.Instance.PrintLn("Email validation did not pass!");
                return;
            }


            // send register request to server
            // DK1 je onda gotov
            User u = new User 
            {
                UserName = username_txt.Text,
                Password = passwd_txt.Text,
                Name = firstname_txt.Text,
                LastName = lastname_txt.Text,
                Email = email_txt.Text,
                Address = address_txt.Text,
            };

            if (Controller.Instance.speaker.Register(u))
            {
                // if (admin == true)
                // Controller.Instance.InitForm(FormInUse.AdminForm);
                // else
                MessageBox.Show($"Register Succesful!\nHello {Controller.Instance.user.Name} {Controller.Instance.user.LastName}");
            }
            else
            {
                MessageBox.Show("User with that username already exists!");
            }
        }
    }
}
