using pdf.Client.AdminUserControls;
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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            ChangePanel(new UserUserControls.AboutUC());
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.Instance.client.Stop();
            Controller.Instance.InitForm(FormInUse.LoginForm);
        }

        private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new AllUsersUC());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new UserUserControls.AboutUC());
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new HelpUC());
        }

        private void allBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new AllBooksUC());
        }

        private void createBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new CreateBookUC());
        }
    }
}
