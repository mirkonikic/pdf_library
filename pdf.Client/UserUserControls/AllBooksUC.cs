using pdf.Common;
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

namespace pdf.Client.UserUserControls
{
    public partial class AllBooksUC : UserControl
    {
        List<Book> books = new List<Book>();
        public AllBooksUC()
        {
            InitializeComponent();
            book_crit_combo.DataSource = Enum.GetValues(typeof(Criteria.BookCriteria));

            // create columns wiht combobox etc...

            // here we load all users from database
            books = Controller.Instance.speaker.AllBooks();
            if (books != null)
            {
                books_dgv.DataSource = books;
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

                CriteriaArg ca = new CriteriaArg { bc = (Criteria.BookCriteria)book_crit_combo.SelectedItem, val = filter_value_txt.Text };

                MessageBox.Show($"{book_crit_combo.Text}");

                if (book_crit_combo.Text == "format")
                {
                    MessageBox.Show($"FORMAT {((int)((Format)Enum.Parse(typeof(Format), filter_value_txt.Text))).ToString()}");
                    ca.val = ((int)((Format)Enum.Parse(typeof(Format), filter_value_txt.Text))).ToString();
                }
                else if (book_crit_combo.Text == "genre")
                {
                    MessageBox.Show($"GENRE {((int)((Zanr)Enum.Parse(typeof(Zanr), filter_value_txt.Text))).ToString()}");
                    ca.val = ((int)((Zanr)Enum.Parse(typeof(Zanr), filter_value_txt.Text))).ToString();
                }
                else if (book_crit_combo.Text == "language")
                {
                    MessageBox.Show($"JEZIK {((int)((Jezik)Enum.Parse(typeof(Jezik), filter_value_txt.Text))).ToString()}");
                    ca.val = ((int)((Jezik)Enum.Parse(typeof(Jezik), filter_value_txt.Text))).ToString();
                }

                books = Controller.Instance.speaker.SearchBook(ca);
                if (books != null)
                {
                    books_dgv.DataSource = books;
                }
                else
                    MessageBox.Show("Error happened");
            }
            else
            {
                // here we load all users from database
                books = Controller.Instance.speaker.AllBooks();
                if (books != null)
                {
                    books_dgv.DataSource = books;
                }
                else
                    MessageBox.Show("Error happened");
            }
        }

        private void books_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // send request to db to change book content
            // couple of rules:
            //      cant change ID
            //      put comboboxes instead of enums
            //      put datpicker instead of date published



            MessageBox.Show("cell changed");

            // send edit request
        }
    }
}
