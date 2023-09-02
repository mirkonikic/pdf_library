using pdf.Common;
using pdf.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*
1. Combobox za autorID i publisherID
*/

namespace pdf.Client.AdminUserControls
{
    public partial class AllBooksUC : UserControl
    {
        List<Book> books = new List<Book>();
        List<Autor> authors;
        List<pdf.Domain.Publisher> publishers;
        public AllBooksUC()
        {
            InitializeComponent();
            book_crit_combo.DataSource = Enum.GetValues(typeof(Criteria.BookCriteria));

            // create columns wiht combobox etc...

            // idea is to select the row and click edit -> than opens a new form where you edit data ->
                // send it to db and reload this UC 

            // here we load all users from database
            books = Controller.Instance.speaker.AllBooks();
            authors = Controller.Instance.speaker.AllAuthors();
            publishers = Controller.Instance.speaker.AllPublishers();
            if (books != null)
            {
                books_dgv.DataSource = books;
                createCellsCombo();
            }
            else
                MessageBox.Show("Error happened");
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            // Send selected User object as a parameter to Delete User action

            // prvi delete samo setuje isDeleted to true, drugi ga brise iz baze
            try
            {
                Book b = (Book)books_dgv.SelectedRows[0].DataBoundItem;
                MessageBox.Show($"{b.ImeKnjige} selected");

                if (Controller.Instance.speaker.DeleteBook(b))
                {
                    MessageBox.Show("Book succesfully deleted!");
                    // easiest way to reload
                    Controller.Instance.af.ChangePanel(new AllBooksUC());
                }
                else
                    MessageBox.Show("Some mistake happened");
            }
            catch
            {
                MessageBox.Show("Please select whole row!");
            }
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
                    updateCellsCombo();
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
                    updateCellsCombo();
                }
                else
                    MessageBox.Show("Error happened");
            }
        }

        private void books_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "FormatColumn")
                {
                    //set FormatKnjige.Value =...
                    Debug.WriteLine("FORMAT");
                    Book b = new Book
                    {
                        KnjigaID = Int32.Parse(books_dgv.Rows[e.RowIndex].Cells["KnjigaId"].Value.ToString()),
                        FormatKnjige = (Format)Enum.Parse(typeof(Format), books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                    };

                    if (Controller.Instance.speaker.EditBook(b))
                    {
                        MessageBox.Show("Successfully edited book!");
                        Controller.Instance.af.ChangePanel(new AllBooksUC());
                    }
                    else
                    {
                        MessageBox.Show("Smth went wrong!");
                    }
                }
                else if (books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "JezikColumn")
                {
                    //set Jezik.Value =...
                    Debug.WriteLine("JEZIK");
                    Book b = new Book
                    {
                        KnjigaID = Int32.Parse(books_dgv.Rows[e.RowIndex].Cells["KnjigaId"].Value.ToString()),
                        Jezik = (Jezik)Enum.Parse(typeof(Jezik), books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                    };

                    if (Controller.Instance.speaker.EditBook(b))
                    {
                        MessageBox.Show("Successfully edited book!");
                        Controller.Instance.af.ChangePanel(new AllBooksUC());
                    }
                    else
                    {
                        MessageBox.Show("Smth went wrong!");
                    }
                }
                else if (books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ZanrColumn")
                {
                    //set Zanr.Value =...
                    Debug.WriteLine("ZANR");
                    Book b = new Book
                    {
                        KnjigaID = Int32.Parse(books_dgv.Rows[e.RowIndex].Cells["KnjigaId"].Value.ToString()),
                        Zanr = (Zanr)Enum.Parse(typeof(Zanr), books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                    };

                    if (Controller.Instance.speaker.EditBook(b))
                    {
                        MessageBox.Show("Successfully edited book!");
                        Controller.Instance.af.ChangePanel(new AllBooksUC());
                    }
                    else
                    {
                        MessageBox.Show("Smth went wrong!");
                    }
                }
                else
                {
                    Debug.WriteLine("TEXTBOX");
                    Debug.WriteLine(e.RowIndex);
                    Debug.WriteLine(e.ColumnIndex);
                    Debug.WriteLine(books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name);

                    //call EditDatabase()
                    Book b = new Book { KnjigaID = Int32.Parse(books_dgv.Rows[e.RowIndex].Cells["KnjigaId"].Value.ToString()) };
                    switch (books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name)
                    {
                        case "ImeKnjige":
                            b.ImeKnjige = books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            break;
                        case "BrStrana":
                            Regex validateIntegers = new Regex("^\\d+$");
                            if (validateIntegers.IsMatch(books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                                b.BrStrana = Int32.Parse(books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                            break;
                        case "OpisKnjige":
                            b.OpisKnjige = books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            break;
                        case "VerzijaKnjige":
                            b.VerzijaKnjige = books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            break;
                        case "DatPublished":
                            Regex validateDate = new Regex("\\d{1,2}\\/\\d{1,2}\\/\\d{2,4}");
                            if (validateDate.IsMatch(books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                                b.DatPublished = DateTime.Parse(books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                            break;
                        case "ISBN":
                            Regex validateISBN = new Regex("^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$");
                            if (validateISBN.IsMatch(books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                                b.ISBN = books_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            break;
                        default:
                            break;
                    }

                    if (Controller.Instance.speaker.EditBook(b))
                    {
                        MessageBox.Show("Successfully edited book!");
                        Controller.Instance.af.ChangePanel(new AllBooksUC());
                    }
                    else
                    {
                        MessageBox.Show("Smth went wrong!");
                    }

                    // send edit request
                    // odlucio sam da saljem edit req za svaki promenjen cell
                    //  nije toliko cesto da se menja podatak o knjizi
                }

                // send request to db to change book content
                // couple of rules:
                //      cant change ID
                //      put comboboxes instead of enums
                //      put datpicker instead of date published
            }
            catch (Exception) 
            {
                MessageBox.Show("Error");
            }
        }

        private void createCellsCombo() 
        {
            // create additional columns -> combobox columns.
            DataGridViewComboBoxColumn FormatCol = new DataGridViewComboBoxColumn();
            FormatCol.Name = "FormatColumn";
            FormatCol.DataSource = Enum.GetValues(typeof(Format));
            FormatCol.ValueType = typeof(Format);
            books_dgv.Columns.Add(FormatCol);

            DataGridViewComboBoxColumn JezikCol = new DataGridViewComboBoxColumn();
            JezikCol.Name = "JezikColumn";
            JezikCol.DataSource = Enum.GetValues(typeof(Jezik));
            JezikCol.ValueType = typeof(Jezik);
            books_dgv.Columns.Add(JezikCol);

            DataGridViewComboBoxColumn ZanrCol = new DataGridViewComboBoxColumn();
            ZanrCol.Name = "ZanrColumn";
            ZanrCol.DataSource = Enum.GetValues(typeof(Zanr));
            ZanrCol.ValueType = typeof(Zanr);
            books_dgv.Columns.Add(ZanrCol);

            // autor combobox
            // publisher combobox

            // hide old columns
            books_dgv.Columns["FormatKnjige"].Visible = false;
            books_dgv.Columns["Zanr"].Visible = false;
            books_dgv.Columns["Jezik"].Visible = false;
            
            books_dgv.Columns["AutorID"].Visible = false;
            books_dgv.Columns["IzdavacID"].Visible = false;

            books_dgv.Columns["KnjigaId"].Visible = false;

            // add new columns
            //books_dgv.Columns.Add(FormatColumn);
            //books_dgv.Columns.Add(ZanrColumn);
            //books_dgv.Columns.Add(JezikColumn);
        }

        private void updateCellsCombo()
        {
        
            // for i in rows, update each combobox cell with value from hidden textbox        
            for (int i = 0; i < books_dgv.Rows.Count; i++) 
            {
                // set Columns[i] combo box = Columns[i] text
                books_dgv.Rows[i].Cells["FormatColumn"].Value = (Format)Enum.Parse(typeof(Format), books_dgv.Rows[i].Cells["FormatKnjige"].Value.ToString());
                books_dgv.Rows[i].Cells["JezikColumn"].Value = (Jezik)Enum.Parse(typeof(Jezik), books_dgv.Rows[i].Cells["Jezik"].Value.ToString());
                books_dgv.Rows[i].Cells["ZanrColumn"].Value = (Zanr)Enum.Parse(typeof(Zanr), books_dgv.Rows[i].Cells["Zanr"].Value.ToString());
            }

            // this happens on edit and on show
        }

        private void AllBooksUC_Load(object sender, EventArgs e)
        {
            updateCellsCombo();
        }
    }
}
