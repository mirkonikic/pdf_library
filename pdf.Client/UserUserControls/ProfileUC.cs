using pdf.Common;
using pdf.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// ideja: kliknuti na checkbox sta zelimo da editujemo
// kliknuti na check da bi dopustio slanje objekta i vratio readonly
// sacuvati sve u Tag property pa uporediti samo one koji su uncheckovani
// kad svu validaciju prodje tad se kreira User object i salje serveru
// u User object ubacuje samo Text pod _txt gde je checkbox checkiran, ostale samo prekopira

namespace pdf.Client.UserUserControls
{
    public partial class ProfileUC : UserControl
    {
        public bool isChecked = false;

        public ProfileUC()
        {
            InitializeComponent();

            // postavljam sve na read only
            uname_txt.ReadOnly = true;
            lname_txt.ReadOnly = true;
            fname_txt.ReadOnly = true;
            email_txt.ReadOnly = true;
            addr_txt.ReadOnly = true;
            passwd_txt.ReadOnly = true;

            // sakrivam password textbox
            npasswd_txt.Visible = false;
            npasswd_lbl.Visible = false;
            rpasswd_txt.Visible = false;
            rpasswd_lbl.Visible = false;

            setBtns();
            fillInFields();
        }

        private void save_button_Click(object sender, EventArgs e)
        {

            // send user here

            // email validation
            // password fields checked
            // Create user and send request for change
            User u = Controller.Instance.user;

            if (uname_chk.Checked)
                u.UserName = uname_txt.Text;
            else
                u.UserName = Controller.Instance.user.UserName;

            if (fname_chk.Checked)
                u.Name = fname_txt.Text;
            else
                u.Name = Controller.Instance.user.Name;

            if (lname_chk.Checked)
                u.LastName = lname_txt.Text;
            else
                u.LastName = Controller.Instance.user.LastName;

            if (address_chk.Checked)
                u.Address = addr_txt.Text;
            else
                u.Address = Controller.Instance.user.Address;

            if (email_chk.Checked)
                u.Email = email_txt.Text;
            else
                u.Email = Controller.Instance.user.Email;

            if (passwd_chk.Checked)
                u.Password = npasswd_txt.Text;
            else
                u.Password = Controller.Instance.user.Password;

            // Sending request
            if (Controller.Instance.speaker.EditUser(u))
            {
                MessageBox.Show("Successfully edited user!");
            }
            else 
            {
                MessageBox.Show("Either username exists or smth went wrong!");
            }

            // if success or not, we print out err message and continue
            uname_txt.ReadOnly = true;
            lname_txt.ReadOnly = true;
            fname_txt.ReadOnly = true;
            email_txt.ReadOnly = true;
            addr_txt.ReadOnly = true;
            passwd_txt.ReadOnly = true;

            uname_chk.Checked = false;
            fname_chk.Checked = false;
            lname_chk.Checked = false;
            address_chk.Checked = false;
            email_chk.Checked = false;
            passwd_chk.Checked = false;

            // sakrivam password textbox
            npasswd_txt.Visible = passwd_chk.Checked;
            npasswd_lbl.Visible = passwd_chk.Checked;
            rpasswd_txt.Visible = passwd_chk.Checked;
            rpasswd_lbl.Visible = passwd_chk.Checked;

            uname_chk.AutoCheck = true;
            fname_chk.AutoCheck = true;
            lname_chk.AutoCheck = true;
            address_chk.AutoCheck = true;
            email_chk.AutoCheck = true;
            passwd_chk.AutoCheck = true;

            isChecked = false;
            setBtns();

        }

        private void check_button_Click(object sender, EventArgs e)
        {
            // open up for editing
            // update .tag field with current values
            fillInTags();

            // Check fields here!
            // za svaki checked proverim i gledam da li je isti texbox osim ako je passwd
            // za email validiram input
            // za password validiram input > 8 characters
            // popunim User() sa checkiranim textboxovima
            // readonlyujem sve i posaljem kad klikne send

            // na bazi ce morati da proveri za ponavljanja
            // razmisljam da predjem da je username primary key
            // id mi u teoriji ne treba, a username da se ponavlja je nepozeljno
            Regex validateEmail = new Regex("^\\w+([\\.-]?\\w+)*@\\w+([\\.-]?\\w+)*(\\.\\w{2,3})+$");
            if (uname_chk.Checked && uname_txt.Text == "")
            {
                MessageBox.Show("Username field empty!");
                return;
            }
            else if (fname_chk.Checked && fname_txt.Text == "")
            {
                MessageBox.Show("First name field empty!");
                return;
            }
            else if (lname_chk.Checked && lname_txt.Text == "")
            {
                MessageBox.Show("Last Name field empty!");
                return;
            }
            else if (address_chk.Checked && addr_txt.Text == "")
            {
                MessageBox.Show("Address field empty!");
                return;
            }
            else if (email_chk.Checked && !validateEmail.IsMatch(email_txt.Text))
            {
                MessageBox.Show("Email validation failed!");
                return;
            }
            else if (passwd_chk.Checked && (passwd_txt.Text == "" || npasswd_txt.Text == "" || rpasswd_txt.Text == "" || npasswd_txt.Text != rpasswd_txt.Text || npasswd_txt.Text.Length < 9))
            {
                MessageBox.Show("Password validation failed!");
                return;
            }

            // add validation if nothing changed!

            // set everything to readonly -> next step is to call send/save
            // set checkboxes to readonly
            // postavljam sve na read only
            uname_txt.ReadOnly = true;
            lname_txt.ReadOnly = true;
            fname_txt.ReadOnly = true;
            email_txt.ReadOnly = true;
            addr_txt.ReadOnly = true;
            passwd_txt.ReadOnly = true;

            // sakrivam password textbox
            if (passwd_chk.Checked)
            {
                npasswd_txt.ReadOnly = true;
                rpasswd_txt.ReadOnly = true;
            }

            uname_chk.AutoCheck = false;
            fname_chk.AutoCheck = false;
            lname_chk.AutoCheck = false;
            address_chk.AutoCheck = false;
            email_chk.AutoCheck = false;
            passwd_chk.AutoCheck = false;

            isChecked = true;
            setBtns();
        }

        private void setBtns()
        {
            // enable/disable buttons
            check_button.Enabled = !isChecked;
            save_button.Enabled = isChecked;

            check_button.BackColor = !isChecked == true ? SystemColors.MenuHighlight : SystemColors.Control;
            check_button.ForeColor = !isChecked == true ? SystemColors.ButtonHighlight : SystemColors.ActiveBorder;
            save_button.BackColor = SystemColors.Control;
        }

        private void fillInFields() 
        {
            uname_txt.Text = Controller.Instance.user.UserName;
            lname_txt.Text = Controller.Instance.user.Name;
            fname_txt.Text = Controller.Instance.user.LastName;
            addr_txt.Text = Controller.Instance.user.Address;
            email_txt.Text = Controller.Instance.user.Email;
        }

        private void fillInTags() 
        {
            uname_txt.Tag = uname_txt.Text;
            lname_txt.Tag = lname_txt.Text;
            fname_txt.Tag = fname_txt.Text;
            addr_txt.Tag = addr_txt.Text;
            email_txt.Tag = email_txt.Text;
            passwd_txt.Tag = passwd_txt.Text;
            npasswd_txt.Tag = npasswd_txt.Text;
            rpasswd_txt.Tag = rpasswd_txt.Text;
        }

        private void uname_chk_CheckedChanged(object sender, EventArgs e)
        {
            uname_txt.ReadOnly = !uname_chk.Checked;
        }

        private void fname_chk_CheckedChanged(object sender, EventArgs e)
        {
            fname_txt.ReadOnly = !fname_chk.Checked;
        }

        private void lname_chk_CheckedChanged(object sender, EventArgs e)
        {
            lname_txt.ReadOnly = !lname_chk.Checked;
        }

        private void email_chk_CheckedChanged(object sender, EventArgs e)
        {
            email_txt.ReadOnly = !email_chk.Checked;
        }

        private void address_chk_CheckedChanged(object sender, EventArgs e)
        {
            addr_txt.ReadOnly = !address_chk.Checked;
        }

        private void passwd_chk_CheckedChanged(object sender, EventArgs e)
        {
            passwd_txt.ReadOnly = !passwd_chk.Checked;

            npasswd_txt.Visible = passwd_chk.Checked;
            npasswd_lbl.Visible = passwd_chk.Checked;
            rpasswd_txt.Visible = passwd_chk.Checked;
            rpasswd_lbl.Visible = passwd_chk.Checked;
        }
    }
}
