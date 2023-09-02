using pdf.Common;
using pdf.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
preostalo:
1. add dugme -> prebacuje iz books liste u status grid i dodaje u addedRows
2. remove -> prebacuje iz status grida nazad u books listu i brise iz addedRows
3. on load -> prvo se popuni status -> onda books popuni samo sa onima koje nemaju u status
4. on edit -> ako vec nema, cuva se taj red u editedRows
5. save dugme -> salje added listu prvo onda i edited listu pod dva razlicita poziva -> transakcije
6. kreiraj operaciju EditBookStatuses
+. kreiraj operaciju AllBookStatuses
9. kreiraj operaciju CreateBookStatuses
*/

/*
int KorisnikID { get; set; }
int KnjigaID { get; set; }
int BrProcitanihStrana { get; set; }
Status StatusKnjige
DateTime DatAdded
DateTime DatLastModified
Rating Rating
String Feedback
*/


namespace pdf.Client.UserUserControls
{
    public partial class MyBooksUC : UserControl
    {
        BindingList<BookStatus> status;
        BindingList<Book> books;
        BindingList<Book> shown_books;
        List<int> addedRows = new List<int>();
        List<int> editedRows = new List<int>();
        public MyBooksUC()
        {
            InitializeComponent();

            // read in books
            books = new BindingList<Book>(Controller.Instance.speaker.AllBooks());
            status = new BindingList<BookStatus>(Controller.Instance.speaker.AllStatus());
            shown_books = new BindingList<Book>();
            if (books != null)
            {
                status_dgv.DataSource = status;
                updateBookList();
                book_list.DataSource = shown_books;
                createCellsCombo();
            }
            else
                MessageBox.Show("Error happened");
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            // validate and send statuses as a List
            // serverside than updates/inserts new rows

            Debug.WriteLine($"edited num: {editedRows.Count}");

            // delete all addedRows indices from editedRows
            for (int i = 0; i < addedRows.Count; i++) 
            {
                editedRows.RemoveAll(item => item == addedRows[i]);
            }

            Debug.WriteLine($"added num: {addedRows.Count}");
            Debug.WriteLine($"edited after num: {editedRows.Count}");

            // pozovi createStatus kao transakciju
            // pozovi editStatus kao transakciju

            if (addedRows.Count != 0) 
            {
                List<BookStatus> addedRowsList = new List<BookStatus>();
                for (int i = 0; i < addedRows.Count; i++) 
                {
                    addedRowsList.Add(status[addedRows[i]]);
                }
                if (Controller.Instance.speaker.CreateBookStatus(addedRowsList))
                {
                    Debug.WriteLine("uspeh1");
                }
                else
                {
                    MessageBox.Show("Couldnt send added rows!");
                    return;
                }
            }

            if (editedRows.Count != 0)
            {
                List<BookStatus> editedRowsList = new List<BookStatus>();
                for (int j = 0; j < editedRows.Count; j++)
                {
                    editedRowsList.Add(status[editedRows[j]]);
                }
                if (Controller.Instance.speaker.EditBookStatus(editedRowsList))
                {
                    Debug.WriteLine("uspeh1");
                }
                else
                {
                    MessageBox.Show("Couldnt send edited rows!");
                    return;
                }
            }

            MessageBox.Show("Succesfully updated the database!");
            Controller.Instance.uf.ChangePanel(new MyBooksUC());
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            // creates new row in dgv and deletes book from list
            // add bookStatus to addedRows
            BookStatus bs = new BookStatus { KorisnikID = Controller.Instance.user.Id, Knjiga = book_list.SelectedItem as Book, BrProcitanihStrana = 0, DatAdded = DateTime.Today, DatLastModified = DateTime.Today, Rating = Rating.NotSet, StatusKnjige = Status.to_read };
            shown_books.RemoveAt(book_list.SelectedIndex);
            status.Add(bs);
            // add to created
            addedRows.Add(status_dgv.RowCount-1);
            //addedRows.Add(((status_dgv.Rows[status_dgv.RowCount-1].DataBoundItem) as BookStatus).Knjiga.KnjigaID);
            updateCellsCombo();
        }

        private void createCellsCombo()
        {
            // create additional columns -> combobox columns.
            DataGridViewComboBoxColumn StatBookCol = new DataGridViewComboBoxColumn();
            StatBookCol.Name = "Status";
            StatBookCol.DataSource = Enum.GetValues(typeof(Status));
            StatBookCol.ValueType = typeof(Status);
            status_dgv.Columns.Add(StatBookCol);

            DataGridViewComboBoxColumn RatingCol = new DataGridViewComboBoxColumn();
            RatingCol.Name = "Ratings";
            RatingCol.DataSource = Enum.GetValues(typeof(Rating));
            RatingCol.ValueType = typeof(Rating);
            status_dgv.Columns.Add(RatingCol);

            status_dgv.Columns["Knjiga"].ReadOnly = true;
            status_dgv.Columns["DatAdded"].ReadOnly = true;
            status_dgv.Columns["DatLastModified"].ReadOnly = true;

            // hide old columns
            status_dgv.Columns["StatusKnjige"].Visible = false;
            status_dgv.Columns["Rating"].Visible = false;

            status_dgv.Columns["KorisnikID"].Visible = false;
        }

        private void updateCellsCombo()
        {

            // for i in rows, update each combobox cell with value from hidden textbox        
            for (int i = 0; i < status_dgv.Rows.Count; i++)
            {
                // set Columns[i] combo box = Columns[i] text
                status_dgv.Rows[i].Cells["Status"].Value = (Status)Enum.Parse(typeof(Status), status_dgv.Rows[i].Cells["StatusKnjige"].Value.ToString());
                status_dgv.Rows[i].Cells["Ratings"].Value = (Rating)Enum.Parse(typeof(Rating), status_dgv.Rows[i].Cells["Rating"].Value.ToString());
            }

            // this happens on edit and on show
        }

        private void MyBooksUC_Load(object sender, EventArgs e)
        {
            updateCellsCombo();
        }

        private void updateBookList() 
        {
            // go trough rows in status dgv and delete ones that are displayed in the dgv
            // use shown_books to display and books to list all

            for (int i = 0; i < books.Count; i++) 
            {
                Debug.WriteLine($"testing book: {books[i].ImeKnjige}");
                for (int j = 0; j < status_dgv.RowCount; j++)
                {
                    // if same id is found in dgv, skip // continue
                    if (books[i].KnjigaID == (status_dgv.Rows[j].DataBoundItem as BookStatus).Knjiga.KnjigaID) 
                    {
                        Debug.WriteLine($"Nasao sam knjigu: {(status_dgv.Rows[j].DataBoundItem as BookStatus).Knjiga.ImeKnjige}");
                        break;
                    }
                    if (j == status_dgv.RowCount-1) 
                    {
                        shown_books.Add(books[i]);
                    }
                }
                // add to books_shown
            }
        }

        private void status_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // add row to editedRows
            // check what has been changed, if combobox, set textbox enum values

            // add rowIndex u editedRows
            // validate edit value
            editedRows.Add(((status_dgv.Rows[e.RowIndex].DataBoundItem) as BookStatus).Knjiga.KnjigaID);
            Debug.WriteLine(((status_dgv.Rows[e.RowIndex].DataBoundItem) as BookStatus).Knjiga.KnjigaID);

            // check enum list what is being filtered 
            // check textbox and send it as Pretrazi Korisnike

            // BrProcitanihStrana, Feedback, Status, Ratings

            try
            {
                if (status_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "Ratings")
                {
                    //set FormatKnjige.Value =...
                    Debug.WriteLine("Rating");
                    status_dgv.Rows[e.RowIndex].Cells["Rating"].Value = (Rating)Enum.Parse(typeof(Rating), status_dgv.Rows[e.RowIndex].Cells["Ratings"].Value.ToString());
                }
                else if (status_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "Status")
                {
                    //set Jezik.Value =...
                    Debug.WriteLine("Status");
                    status_dgv.Rows[e.RowIndex].Cells["StatusKnjige"].Value = (Status)Enum.Parse(typeof(Status), status_dgv.Rows[e.RowIndex].Cells["Status"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }

        }

        private void status_dgv_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("cant save that format!");
            }
        }
    }
}
