using pdf.Common;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pdf.Client.AdminUserControls
{
    public partial class CreateBookUC : UserControl
    {
        List<Autor> authors;
        List<Publisher> publishers;
        public bool isChecked = false;

        public CreateBookUC()
        {
            InitializeComponent();

            // here we load all users from database
            // ucitana je lista autora i izvodjaca
            authors = Controller.Instance.speaker.AllAuthors();
            publishers = Controller.Instance.speaker.AllPublishers();
            if (publishers == null || authors == null)
            {
                MessageBox.Show("Error happened");
            }

            publisher_combo.DataSource = publishers;
            author_combo.DataSource = authors;
            zanr_combo.DataSource = Enum.GetNames(typeof(Zanr));
            format_combo.DataSource = Enum.GetNames(typeof(Format));
            jezik_combo.DataSource = Enum.GetNames(typeof(Jezik));
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            // validacija

            //author_combo
            //format_combo
            //jezik_combo
            //publisher_combo
            //zanr_combo

            //published_date -> not sure what to validate -> maybe over today??

            Regex validateISBN = new Regex("^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$");
            Regex validateIntegers = new Regex("^\\d+$");

            //isbn_txt
            //name_txt
            //opis_txt
            //pagenum_txt
            //verzija_txt
            if (isbn_txt.Text == "" || name_txt.Text == "" || opis_txt.Text == "" || pagenum_txt.Text == "" || verzija_txt.Text == "")
            {
                MessageBox.Show("Fill all fields!");
                return;
            }
            else if (!validateISBN.IsMatch(isbn_txt.Text))
            {
                MessageBox.Show("ISBN validation failed!");
                return;
            }
            else if (!validateIntegers.IsMatch(pagenum_txt.Text)) 
            {
                MessageBox.Show("Page numbers validation failed!");
                return;
            }

            isbn_txt.ReadOnly = true; 
            name_txt.ReadOnly = true;
            opis_txt.ReadOnly = true;
            pagenum_txt.ReadOnly = true;
            verzija_txt.ReadOnly = true;

            author_combo.Enabled = false; 
            zanr_combo.Enabled = false;
            format_combo.Enabled = false;
            jezik_combo.Enabled = false;
            publisher_combo.Enabled = false;

            published_date.Enabled=false;

            isChecked = true;
            setBtns();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            // call serveru da se zapamti
            int outr = 0;
            try
            {
                outr = int.Parse(pagenum_txt.Text);
            }
            catch 
            {
                MessageBox.Show("Probably done a wrong validation with number of pages!");
            }

            Book b = new Book();
            //{ 
            b.KnjigaID = 0;
            b.ImeKnjige = name_txt.Text;//,
            b.Zanr = (Zanr)Enum.Parse(typeof(Zanr), zanr_combo.SelectedValue.ToString());//,
            b.Jezik = (Jezik)Enum.Parse(typeof(Jezik), jezik_combo.SelectedValue.ToString());//,
            b.FormatKnjige = (Format)Enum.Parse(typeof(Format), format_combo.SelectedValue.ToString());//,
            b.DatPublished = published_date.Value.Date;//,
            b.ISBN = isbn_txt.Text;//,
            b.BrStrana = outr;//,
            b.OpisKnjige = opis_txt.Text;//,
            b.VerzijaKnjige = verzija_txt.Text;//,
            b.AutorID = author_combo.SelectedIndex;//,
            b.IzdavacID = publisher_combo.SelectedIndex;
            //};

            // Sending request
            if (Controller.Instance.speaker.CreateBook(b))
            {
                MessageBox.Show("Successfully created book!");
                Controller.Instance.af.ChangePanel(new CreateBookUC());
            }
            else
            {
                MessageBox.Show("Smth went wrong!");
            }
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
    }
}
