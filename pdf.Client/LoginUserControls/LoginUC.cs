using pdf.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client.UserControls
{
    public partial class LoginUC : UserControl
    {
        public LoginUC()
        {
            InitializeComponent();
            ip_lbl.Text = Controller.Instance.client.IpAddress;
            port_lbl.Text = Controller.Instance.client.Port;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            // validacija!
            // ne smeju oba da budu prazna!
            if (username_txt.Text == "" || passwd_txt.Text == "") 
            {
                Controller.Instance.PrintLn("Both field must be filled!");
                return;
            }

            User u = new User();
            u.UserName = username_txt.Text;
            u.Password = passwd_txt.Text;
            if (Controller.Instance.speaker.Login(u))
            {
                // if (admin == true)
                // Controller.Instance.InitForm(FormInUse.AdminForm);
                // else
                MessageBox.Show($"Login Succesful!\nWelcome {Controller.Instance.user.Id} {Controller.Instance.user.Name} {Controller.Instance.user.LastName}");
                
                // check if u is admin
                if(Controller.Instance.user.isAdmin)
                    Controller.Instance.InitForm(FormInUse.AdminForm);
                else
                    Controller.Instance.InitForm(FormInUse.UserForm);
            }
            else 
            {
                MessageBox.Show("Credentials are wrong!");       
            }
        }
    }
}
