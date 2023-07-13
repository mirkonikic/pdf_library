using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pdf.Common;
using pdf.Domain;

namespace pdf.Client.AdminUserControls
{
    public partial class AllUsersUC : UserControl
    {
        List<User> users = new List<User>();
        public AllUsersUC()
        {
            InitializeComponent();
            user_crit_combo.DataSource = Enum.GetValues(typeof(Criteria.UserCriteria));

            // here we load all users from database
            users = Controller.Instance.speaker.AllUsers();
            if (users != null)
            {
                users_dgv.DataSource = users;
            }
            else
                MessageBox.Show("Error happened");
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            if (filter_chk.Checked)
            {
                // check enum list what is being filtered 
                // check textbox and send it as Pretrazi Korisnike
                if (filter_value_txt.Text == "")
                    return;

                CriteriaArg ca = new CriteriaArg { uc = (Criteria.UserCriteria)user_crit_combo.SelectedItem, val = filter_value_txt.Text };
                users = Controller.Instance.speaker.SearchUser(ca);
                if (users != null)
                {
                    users_dgv.DataSource = users;
                }
                else
                    MessageBox.Show("Error happened");
            }
            else 
            {
                // here we load all users from database
                users = Controller.Instance.speaker.AllUsers();
                if (users != null)
                {
                    users_dgv.DataSource = users;
                }
                else
                    MessageBox.Show("Error happened");
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            // Send selected User object as a parameter to Delete User action

            // prvi delete samo setuje isDeleted to true, drugi ga brise iz baze
            try
            {
                User u = (User)users_dgv.SelectedRows[0].DataBoundItem;
                MessageBox.Show($"{u.UserName} selected");

                if (Controller.Instance.speaker.DeleteUser(u))
                {
                    MessageBox.Show("User succesfully deleted!");
                    // easiest way to reload
                    Controller.Instance.af.ChangePanel(new AllUsersUC());
                }
                else
                    MessageBox.Show("Some mistake happened");
            }
            catch 
            {
                MessageBox.Show("Please select whole row!");
            }
        }
    }
}
