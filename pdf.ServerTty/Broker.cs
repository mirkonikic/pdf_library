using pdf.Common;
using pdf.Domain;
using pdf.DbBroker;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.ServerTty
{
    public class Broker
    {
        private DbBroker.Broker broker;

        // implementirati sve funkcije koje treba da se izvrse
        /*
                +. signal NapraviKorisnika(Korisnik)
                +. signal UcitajKorisnike(List<Korisnik>)
                +. signal PretraziKorisnike(kriterijum, List<Korisnik>)
                +. signal UcitajKorisnika(Korisnik)
                +. signal IzmeniKorisnika(Korisnik)
                +. signal ObrisiKorisnika(Korisnik)
                +. signal NapraviKnjigu(Knjiga)
                +. signal UcitajKnjige(List<Knjiga>)
                +. signal PretraziKnjige(kriterijum, List<Knjiga>)
                +. signal UcitajKnjigu(Knjiga)
                +. signal IzmeniKnjigu(Knjiga)
                +. signal ObrisiKnjigu(Knjiga)
                +. signal NapraviStatusKnjige(Status)
                +. signal IzmeniStatusKnjige(StatusKnjige)
                +. signal UcitajAutore(List<Autor>)
                +. signal UcitajIzdavace(List<Izdavac>)
        */

        public Broker() { broker = new DbBroker.Broker(); }

        public bool NapraviKorisnika(User u)
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"Insert into Korisnik(username, password, Ime, Prezime, Email, Adresa) values('{u.UserName}', '{u.Password}', '{u.Name}', '{u.LastName}', '{u.Email}', '{u.Address}')";
            //cmd.Parameters.AddWithValue("@username", u.UserName);
            //cmd.Parameters.AddWithValue("@ime", u.Name);
            //cmd.Parameters.AddWithValue("@prezime", u.LastName);
            //cmd.Parameters.AddWithValue("@email", u.Email);
            //cmd.Parameters.AddWithValue("@adresa", u.Address);
            cmd.Connection = broker.returnConnection();

            Controller.Instance.terminal.vPrintLn($"User -> {u.UserName} {u.Name}");
            Controller.Instance.terminal.vPrintLn($"cmd -> {cmd.CommandText}");

            int n = cmd.ExecuteNonQuery();

            Controller.Instance.terminal.vPrintLn($"n -> {n}");

            broker.Close();
            
            Controller.Instance.terminal.vPrintLn("Closed connection!");

            if (n > 0)
                return true;
            return false;

        }
        public List<User> UcitajKorisnike()
        {
            List<User> list = new List<User>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Korisnik";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            { 
                while (reader.Read())
                {
                    User u = new User();
                    {
                        u.Id = (int)reader["KorisnikID"];
                        u.UserName = (string)reader["username"];
                        u.Password = (string)reader["password"];
                        u.Name = (string)reader["Ime"];
                        u.LastName = (string)reader["Prezime"];
                        u.Email = (string)reader["Email"];
                        u.Address = (string)reader["Adresa"];
                        u.isDeleted = (bool)reader["isDeleted"];
                        u.isAdmin = (bool)reader["isAdmin"];
                    };

                    list.Add(u);
                }
            }

            broker.Close();
            return list; 
        }
        public List<User> PretraziKorisnike(CriteriaArg ca) 
        {
            // string columnName = uc.ToString();
            // string query = $"SELECT * FROM Korisnik WHERE {columnName} LIKE @value";

            List<User> list = new List<User>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = broker.returnConnection();

            string columnName = "";
            switch (ca.uc)
            {
                case Criteria.UserCriteria.id:
                    columnName = "KorisnikID";
                    break;
                case Criteria.UserCriteria.username:
                    columnName = "username";
                    break;
                case Criteria.UserCriteria.name:
                    columnName = "Ime";
                    break;
                case Criteria.UserCriteria.lastname:
                    columnName = "Prezime";
                    break;
                case Criteria.UserCriteria.email:
                    columnName = "Email";
                    break;
                case Criteria.UserCriteria.address:
                    columnName = "Adresa";
                    break;
                case Criteria.UserCriteria.isDeleted:
                    columnName = "isDeleted";
                    break;
                case Criteria.UserCriteria.isAdmin:
                    columnName = "isAdmin";
                    break;
            }

            cmd.CommandText = $"SELECT * FROM Korisnik WHERE {columnName} = @value";
            cmd.Parameters.AddWithValue("@value", ca.val);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    User u = new User()
                    {
                        Id = (int)reader["KorisnikID"],
                        UserName = (string)reader["username"],
                        Password = (string)reader["password"],
                        Name = (string)reader["Ime"],
                        LastName = (string)reader["Prezime"],
                        Email = (string)reader["Email"],
                        Address = (string)reader["Adresa"],
                        isDeleted = (bool)reader["isDeleted"],
                        isAdmin = (bool)reader["isAdmin"]
                    };

                    list.Add(u);
                }
            }

            broker.Close();
            return list;
        }
        public User UcitajKorisnika(User u) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM Korisnik WHERE KorisnikID = {u.Id}";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    u.UserName = (string)reader["username"];
                    u.Password = (string)reader["password"];
                    u.Name = (string)reader["Ime"];
                    u.LastName = (string)reader["Prezime"];
                    u.Email = (string)reader["Email"];
                    u.Address = (string)reader["Adresa"];
                    u.isDeleted = (bool)reader["isDeleted"];
                    u.isAdmin = (bool)reader["isAdmin"];

                    return u;
                }
            }

            broker.Close();
            return null;
        }
        public bool IzmeniKorisnika(User u) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"UPDATE Korisnik SET username = @username, Ime = @ime, Prezime = @prezime, Email = @email, Adresa = @adresa, Password = @password WHERE KorisnikID = @id";
            cmd.Connection = broker.returnConnection();

            cmd.Parameters.AddWithValue("@username", u.UserName);
            cmd.Parameters.AddWithValue("@ime", u.Name);
            cmd.Parameters.AddWithValue("@prezime", u.LastName);
            cmd.Parameters.AddWithValue("@email", u.Email);
            cmd.Parameters.AddWithValue("@adresa", u.Address);
            cmd.Parameters.AddWithValue("@id", u.Id);
            cmd.Parameters.AddWithValue("@password", u.Password);
            
            Controller.Instance.terminal.vPrintLn(cmd.CommandText);

            int n = cmd.ExecuteNonQuery();

            Controller.Instance.terminal.vPrintLn($"{n} rows affected for {u.Id}");


            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public bool SakrijKorisnika(User u) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"UPDATE Korisnik SET isDeleted = 1 WHERE KorisnikID = @id";
            cmd.Connection = broker.returnConnection();

            cmd.Parameters.AddWithValue("@id", u.Id);

            int n = cmd.ExecuteNonQuery();

            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public bool ObrisiKorisnika(User u) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"DELETE FROM Korisnik WHERE KorisnikID = @id";
            cmd.Connection = broker.returnConnection();

            cmd.Parameters.AddWithValue("@id", u.Id);

            int n = cmd.ExecuteNonQuery();

            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public bool NapraviKnjigu(Book b) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Knjiga (ImeKnjige, BrStrana, FormatKnjigeID, DatPublished, ISBN, ZanrID, JezikID, OpisKnjige, VerzijeKnjige, AutorID, IzdavacID)
                        VALUES (@imeKnjige, @brStrana, @formatKnjigeID, @datPublished, @isbn, @zanrID, @jezikID, @opisKnjige, @verzijaKnjige, @autorID, @izdavacID)";
            cmd.Connection = broker.returnConnection();

            cmd.Parameters.AddWithValue("@imeKnjige", b.ImeKnjige);
            cmd.Parameters.AddWithValue("@brStrana", b.BrStrana);
            cmd.Parameters.AddWithValue("@formatKnjigeID", (int)b.FormatKnjige);
            cmd.Parameters.AddWithValue("@datPublished", b.DatPublished);
            cmd.Parameters.AddWithValue("@isbn", b.ISBN);
            cmd.Parameters.AddWithValue("@zanrID", (int)b.Zanr);
            cmd.Parameters.AddWithValue("@jezikID", (int)b.Jezik);
            cmd.Parameters.AddWithValue("@opisKnjige", b.OpisKnjige);
            cmd.Parameters.AddWithValue("@verzijaKnjige", b.VerzijaKnjige);
            cmd.Parameters.AddWithValue("@autorID", b.AutorID);
            cmd.Parameters.AddWithValue("@izdavacID", b.IzdavacID);

            Controller.Instance.terminal.vPrintLn($"{b.ImeKnjige} {b.BrStrana} {(int)b.FormatKnjige} {b.DatPublished} {b.ISBN} {(int)b.Zanr} {(int)b.Jezik} {b.OpisKnjige} {b.VerzijaKnjige} {b.AutorID}");
            Controller.Instance.terminal.sPrintLn(cmd.CommandText);

            int n = cmd.ExecuteNonQuery();

            Controller.Instance.terminal.sPrintLn($"rows affected: {n}");

            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public List<Book> UcitajKnjige()
        {
            List<Book> list = new List<Book>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Knjiga k JOIN Format f ON k.FormatKnjigeID = f.FormatID JOIN Genre g ON k.ZanrID = g.GenreID JOIN Jezik j ON k.JezikID = j.JezikID";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Book b = new Book();

                    b.KnjigaID = (int)reader["KnjigaID"];
                    b.ImeKnjige = (string)reader["ImeKnjige"];
                    b.BrStrana = (int)reader["BrStrana"];
                    b.FormatKnjige = (Format)reader["FormatID"];
                    b.DatPublished = (DateTime)reader["DatPublished"];
                    b.ISBN = (string)reader["ISBN"];
                    b.Zanr = (Zanr)reader["GenreID"];
                    b.Jezik = (Jezik)reader["JezikID"];
                    b.OpisKnjige = (string)reader["OpisKnjige"];
                    b.VerzijaKnjige = (string)reader["VerzijeKnjige"];
                    b.AutorID = (int)reader["AutorID"];
                    b.IzdavacID = (int)reader["IzdavacID"];
                    

                    list.Add(b);
                }
            }

            broker.Close();
            return list;
        }
        public List<Book> PretraziKnjige(CriteriaArg ca) 
        {
            List<Book> list = new List<Book>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = broker.returnConnection();

            string columnName = "";
            switch (ca.bc)
            {
                case Criteria.BookCriteria.id:
                    columnName = "KnjigaID";
                    break;
                case Criteria.BookCriteria.name:
                    columnName = "ImeKnjige";
                    break;
                case Criteria.BookCriteria.page_num:
                    columnName = "BrStrana";
                    break;
                case Criteria.BookCriteria.format:
                    columnName = "FormatKnjigeID";
                    break;
                case Criteria.BookCriteria.date_pub:
                    columnName = "DatPublished";
                    break;
                case Criteria.BookCriteria.isbn:
                    columnName = "ISBN";
                    break;
                case Criteria.BookCriteria.genre:
                    columnName = "ZanrID";
                    break;
                case Criteria.BookCriteria.language:
                    columnName = "JezikID";
                    break;
                case Criteria.BookCriteria.author:
                    columnName = "AutorID";
                    break;
                case Criteria.BookCriteria.publisher:
                    columnName = "IzdavacID";
                    break;
            }

            cmd.CommandText = $"SELECT * FROM Knjiga WHERE {columnName} = @value";
            cmd.Parameters.AddWithValue("@value", ca.val);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Book b = new Book()
                    {
                        KnjigaID = (int)reader["KnjigaID"],
                        ImeKnjige = (string)reader["ImeKnjige"],
                        BrStrana = (int)reader["BrStrana"],
                        FormatKnjige = (Format)reader["FormatKnjigeID"],
                        DatPublished = (DateTime)reader["DatPublished"],
                        ISBN = (string)reader["ISBN"],
                        Zanr = (Zanr)reader["ZanrID"],
                        Jezik = (Jezik)reader["JezikID"],
                        OpisKnjige = (string)reader["OpisKnjige"],
                        VerzijaKnjige = (string)reader["VerzijeKnjige"],
                        AutorID = (int)reader["AutorID"],
                        IzdavacID = (int)reader["IzdavacID"]
                    };

                    list.Add(b);
                }
            }

            broker.Close();
            return list;
        }
        public Book UcitajKnjigu(Book b) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT Knjiga.*, Jezik.Jezik AS JezikName, Zanr.Genre AS ZanrName, Format.Format AS FormatName
                        FROM Knjiga
                        LEFT JOIN Jezik ON Knjiga.JezikID = Jezik.JezikID
                        LEFT JOIN Zanr ON Knjiga.ZanrID = Zanr.GenreID
                        LEFT JOIN Format ON Knjiga.FormatKnjigeID = Format.FormatID
                        WHERE Knjiga.KnjigaID = @id";
            cmd.Parameters.AddWithValue("@id", b.KnjigaID);
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    b.ImeKnjige = (string)reader["ImeKnjige"];
                    b.BrStrana = (int)reader["BrStrana"];
                    b.FormatKnjige = (Format)reader["FormatKnjigeID"];
                    b.DatPublished = (DateTime)reader["DatPublished"];
                    b.ISBN = (string)reader["ISBN"];
                    b.Zanr = (Zanr)reader["ZanrID"];
                    b.Jezik = (Jezik)reader["JezikID"];
                    b.OpisKnjige = (string)reader["OpisKnjige"];
                    b.VerzijaKnjige = (string)reader["VerzijeKnjige"];
                    b.AutorID = (int)reader["AutorID"];
                    b.IzdavacID = (int)reader["IzdavacID"];
                }
            }

            broker.Close();
            return b;
        }
        public bool IzmeniKnjigu(Book b) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();

            // --------------------------------- \\

            if (b.ImeKnjige != null) { cmd.Parameters.AddWithValue("@imeKnjige", b.ImeKnjige); cmd.CommandText = @"UPDATE Knjiga SET ImeKnjige = @imeKnjige WHERE KnjigaID = @knjigaID"; }
            else if (b.BrStrana != -1) { cmd.Parameters.AddWithValue("@brStrana", b.BrStrana); cmd.CommandText = @"UPDATE Knjiga SET BrStrana = @brStrana WHERE KnjigaID = @knjigaID"; }
            else if (b.OpisKnjige != null) { cmd.Parameters.AddWithValue("@opisKnjige", b.OpisKnjige); cmd.CommandText = @"UPDATE Knjiga SET OpisKnjige = @opisKnjige WHERE KnjigaID = @knjigaID"; }
            else if (b.VerzijaKnjige != null) { cmd.Parameters.AddWithValue("@verzijaKnjige", b.VerzijaKnjige); cmd.CommandText = @"UPDATE Knjiga SET VerzijeKnjige = @verzijaKnjige WHERE KnjigaID = @knjigaID"; }
            else if (b.DatPublished != null) { cmd.Parameters.AddWithValue("@datPublished", b.DatPublished); cmd.CommandText = @"UPDATE Knjiga SET DatPublished = @datPublished WHERE KnjigaID = @knjigaID"; }
            else if (b.ISBN!= null) { cmd.Parameters.AddWithValue("@isbn", b.ISBN); cmd.CommandText = @"UPDATE Knjiga SET ISBN = @isbn WHERE KnjigaID = @knjigaID"; }
            else if (b.FormatKnjige != Format.NotSet) { cmd.Parameters.AddWithValue("@formatKnjigeID", (int)b.FormatKnjige); cmd.CommandText = @"UPDATE Knjiga SET FormatKnjigeID = @formatKnjigeID WHERE KnjigaID = @knjigaID"; }
            else if (b.Jezik != Jezik.NotSet) { cmd.Parameters.AddWithValue("@jezikID", (int)b.Jezik); cmd.CommandText = @"UPDATE Knjiga SET JezikID = @jezikID WHERE KnjigaID = @knjigaID"; }
            else if (b.Zanr != Zanr.NotSet) { cmd.Parameters.AddWithValue("@zanrID", (int)b.Zanr); cmd.CommandText = @"UPDATE Knjiga SET ZanrID = @zanrID WHERE KnjigaID = @knjigaID"; }
            else if (b.AutorID != -1) { cmd.Parameters.AddWithValue("@autorID", b.AutorID); cmd.CommandText = @"UPDATE Knjiga SET AutorID = @autorID WHERE KnjigaID = @knjigaID"; }
            else if (b.IzdavacID != -1) { cmd.Parameters.AddWithValue("@izdavacID", b.IzdavacID); cmd.CommandText = @"UPDATE Knjiga SET IzdavacID = @izdavacID WHERE KnjigaID = @knjigaID"; }
            else { }
            
            cmd.Parameters.AddWithValue("@knjigaID", b.KnjigaID);
            cmd.Connection = broker.returnConnection();
            Controller.Instance.terminal.sPrintLn(cmd.CommandText);

            // --------------------------------- \\

            int n = cmd.ExecuteNonQuery();

            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public bool ObrisiKnjigu(Book b) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Knjiga WHERE KnjigaID = @knjigaID";
            cmd.Parameters.AddWithValue("@knjigaID", b.KnjigaID);
            cmd.Connection = broker.returnConnection();
            Controller.Instance.terminal.sPrintLn($"{cmd.CommandText}");

            int n = cmd.ExecuteNonQuery();

            Controller.Instance.terminal.vPrintLn($"n: {n}");

            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public void NapraviJedanStatus(BookStatus bs) 
        {
            
        }
        public bool NapraviStatusKnjige(List<BookStatus> lbs) 
        {
            try
            {
                broker.Open();
                broker.BeginTransaction();
                SqlTransaction sqlt = broker.returnTransaction();

                foreach (BookStatus bs in lbs) 
                {
                    //NapraviJedanStatus(bs);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Transaction = sqlt;
                    cmd.CommandText = @"INSERT INTO StatusKnjige (KnjigaID, KorisnikID, BrProcitanihStrana, StatusKnjigeID, DatAdded, DatLastModified, RatingID, Feedback)
                        VALUES (@knjigaID, @korisnikID, @brProcitanihStrana, @statusKnjigeID, @datAdded, @datLastModified, @ratingID, @feedback)";
                    cmd.Parameters.AddWithValue("@knjigaID", bs.Knjiga.KnjigaID);
                    cmd.Parameters.AddWithValue("@korisnikID", bs.KorisnikID);
                    cmd.Parameters.AddWithValue("@brProcitanihStrana", bs.BrProcitanihStrana);
                    cmd.Parameters.AddWithValue("@statusKnjigeID", (int)bs.StatusKnjige);
                    cmd.Parameters.AddWithValue("@datAdded", bs.DatAdded);
                    cmd.Parameters.AddWithValue("@datLastModified", bs.DatLastModified);
                    cmd.Parameters.AddWithValue("@ratingID", (int)bs.Rating);
                    cmd.Parameters.AddWithValue("@feedback", bs.Feedback);
                    cmd.Connection = broker.returnConnection();

                    int n = cmd.ExecuteNonQuery();

                    Controller.Instance.terminal.sPrintLn($"AddStatus uspeo? {n}");
                }

                broker.Commit();
                Controller.Instance.terminal.sPrintLn("commited");
                broker.Close();
                return true;
            }
            catch (Exception ex) 
            {
                broker.Rollback();
                Controller.Instance.terminal.sPrintLn($"rollbacked, {ex.Message}");
                broker.Close();
                return false;
            }
        }
        public List<BookStatus> PretraziStatuseKnjiga(Criteria.BookStatusCriteria criteria, string value)
        {
            List<BookStatus> listaStatusa = new List<BookStatus>();

            broker.Open();

            string columnName = string.Empty;
            switch (criteria)
            {
                case Criteria.BookStatusCriteria.KorisnikID:
                    columnName = "KorisnikID";
                    break;
                case Criteria.BookStatusCriteria.KnjigaID:
                    columnName = "KnjigaID";
                    break;
                case Criteria.BookStatusCriteria.BrProcitanihStrana:
                    columnName = "BrProcitanihStrana";
                    break;
                case Criteria.BookStatusCriteria.StatusKnjige:
                    columnName = "StatusKnjige";
                    break;
                case Criteria.BookStatusCriteria.DatAdded:
                    columnName = "DatAdded";
                    break;
                case Criteria.BookStatusCriteria.DatLastModified:
                    columnName = "DatLastModified";
                    break;
                case Criteria.BookStatusCriteria.Rating:
                    columnName = "Rating";
                    break;
                case Criteria.BookStatusCriteria.Feedback:
                    columnName = "Feedback";
                    break;
            }

            SqlCommand cmd = new SqlCommand();
            // JOIN ISKORISTI OVDE
            cmd.CommandText = $"SELECT * FROM BookStatus bs JOIN Knjiga kk ON (bs.KnjigaID = kk.KnjigaID) WHERE {columnName} = @value";
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BookStatus status = new BookStatus()
                    {
                        KorisnikID = (int)reader["KorisnikID"],
                        Knjiga = new Book { KnjigaID = (int)reader["KnjigaID"], ImeKnjige = (string)reader["ImeKnjige"], BrStrana = (int)reader["BrStrana"], AutorID = (int)reader["AutorID"], DatPublished = (DateTime)reader["DatPublished"], FormatKnjige = (Format)reader["FormatKnjigeID"], ISBN = (string)reader["ISBN"], IzdavacID = (int)reader["IzdavacID"], Jezik = (Jezik)reader["Jezik"], OpisKnjige = (string)reader["OpisKnjige"], VerzijaKnjige = (string)reader["VerzijaKnjige"], Zanr = (Zanr)reader["Zanr"] },
                        BrProcitanihStrana = (int)reader["BrProcitanihStrana"],
                        StatusKnjige = (Status)reader["StatusKnjige"],
                        DatAdded = (DateTime)reader["DatAdded"],
                        DatLastModified = (DateTime)reader["DatLastModified"],
                        Rating = (Rating)reader["Rating"],
                        Feedback = (string)reader["Feedback"]
                    };

                    listaStatusa.Add(status);
                }
            }

            broker.Close();

            return listaStatusa;
        }
        public List<BookStatus> UcitajStatuseKnjige(User u)
        {
            List<BookStatus> listaStatusa = new List<BookStatus>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM StatusKnjige sk JOIN Knjiga kk ON (sk.KnjigaID = kk.KnjigaID) WHERE KorisnikID = {u.Id}";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BookStatus status = new BookStatus()
                    {
                        KorisnikID = (int)reader["KorisnikID"],
                        Knjiga = new Book { KnjigaID = (int)reader["KnjigaID"], ImeKnjige = (string)reader["ImeKnjige"], BrStrana = (int)reader["BrStrana"], AutorID = (int)reader["AutorID"], DatPublished = (DateTime)reader["DatPublished"], FormatKnjige = (Format)reader["FormatKnjigeID"], ISBN = (string)reader["ISBN"], IzdavacID = (int)reader["IzdavacID"], Jezik = (Jezik)reader["JezikID"], OpisKnjige = (string)reader["OpisKnjige"], VerzijaKnjige = (string)reader["VerzijeKnjige"], Zanr = (Zanr)reader["ZanrID"] },
                        BrProcitanihStrana = (int)reader["BrProcitanihStrana"],
                        StatusKnjige = (Status)reader["StatusKnjigeID"],
                        DatAdded = (DateTime)reader["DatAdded"],
                        DatLastModified = (DateTime)reader["DatLastModified"],
                        Rating = (Rating)reader["RatingID"],
                        Feedback = (string)reader["Feedback"]
                    };

                    listaStatusa.Add(status);
                }
            }

            broker.Close();

            return listaStatusa;
        }
        public void IzmeniJedanStatus(BookStatus bs) 
        {
            
        }
        public bool IzmeniStatusKnjige(List<BookStatus> lbs) 
        {
            try
            {
                broker.Open();
                broker.BeginTransaction();
                SqlTransaction sqlt = broker.returnTransaction();

                foreach (BookStatus bs in lbs)
                {
                    //NapraviJedanStatus(bs);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Transaction = sqlt;
                    cmd.CommandText = @"UPDATE StatusKnjige
                        SET BrProcitanihStrana = @brProcitanihStrana,
                            StatusKnjigeID = @statusKnjigeID,
                            DatAdded = @datAdded,
                            DatLastModified = @datLastModified,
                            RatingID = @ratingID,
                            Feedback = @feedback
                        WHERE KnjigaID = @knjigaID AND KorisnikID = @korisnikID";
                    cmd.Parameters.AddWithValue("@brProcitanihStrana", bs.BrProcitanihStrana);
                    cmd.Parameters.AddWithValue("@statusKnjigeID", (int)bs.StatusKnjige);
                    cmd.Parameters.AddWithValue("@datAdded", bs.DatAdded);
                    cmd.Parameters.AddWithValue("@datLastModified", bs.DatLastModified);
                    cmd.Parameters.AddWithValue("@ratingID", (int)bs.Rating);
                    cmd.Parameters.AddWithValue("@feedback", bs.Feedback);
                    cmd.Parameters.AddWithValue("@knjigaID", bs.Knjiga.KnjigaID);
                    cmd.Parameters.AddWithValue("@korisnikID", bs.KorisnikID);
                    cmd.Connection = broker.returnConnection();

                    int n = cmd.ExecuteNonQuery();
                    Controller.Instance.terminal.sPrintLn($"Edited jedan! {n}");
                }

                broker.Commit();
                Controller.Instance.terminal.sPrintLn("commited");
                broker.Close();
                return true;
            }
            catch (Exception ex)
            {
                broker.Rollback();
                Controller.Instance.terminal.sPrintLn("rollbacked");
                broker.Close();
                return false;
            }
        }
        public List<Autor> UcitajAutore() 
        {
            List<Autor> listaAutora = new List<Autor>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Autor";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Autor autor = new Autor()
                    {
                        AutorID = (int)reader["AutorID"],
                        Ime = (string)reader["Ime"],
                        Prezime = (string)reader["Prezime"]
                    };

                    listaAutora.Add(autor);
                }
            }

            broker.Close();

            return listaAutora;
        }
        public List<Publisher> UcitajIzdavace() 
        {
            List<Publisher> listaIzdavaca = new List<Publisher>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Izdavac";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Publisher izdavac = new Publisher()
                    {
                        IzdavacID = (int)reader["IzdavacID"],
                        ImeIzdavaca = (string)reader["ImeIzdavaca"]
                    };

                    listaIzdavaca.Add(izdavac);
                }
            }

            broker.Close();

            return listaIzdavaca;
        }
    
        // mozda Ucitaj sve zivo za laksi rad sa klasama!
    
    }

}
