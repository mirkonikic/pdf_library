using pdf.Client.UserUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client.Forms
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            // client logs in to the server with login form
            // main form opens up main screen and gives options to user what can be clicked
            // klikom na nesto, salje se zahtev serveru u obliku broja?

            // takodje postoje opcije za detailed info o pdf fajlovima -> advanced
            ChangePanel(new AboutUC());
        }

        public void PrintLn(string s)
        {
            MessageBox.Show(s);
        }

        public void ChangePanel(Control control)
        {
            main_panel.Controls.Clear();
            main_panel.Controls.Add(control);
            //control.Dock = DockStyle.Fill;
            //control.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            //pnlMain.AutoSize = true;
            //pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Profile with an edit button
            ChangePanel(new ProfileUC());
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // implement Logout
            Controller.Instance.client.Stop();
            Controller.Instance.InitForm(FormInUse.LoginForm);
        }

        private void allBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DataGridView lists all books with a button to create BookStatus
            ChangePanel(new AllBooksUC());
        }

        private void myBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Same as goodreads My Books -> read, to_read, reading
            // lists all bookstatuses that way
            ChangePanel(new MyBooksUC());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // just an About page
            ChangePanel(new AboutUC());
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // just a Help page
            ChangePanel(new HelpUC());
        }
    }
}
