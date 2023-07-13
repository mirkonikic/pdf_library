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
            cmd.Parameters.AddWithValue("@formatKnjigeID", b.FormatKnjige.FormatID);
            cmd.Parameters.AddWithValue("@datPublished", b.DatPublished);
            cmd.Parameters.AddWithValue("@isbn", b.ISBN);
            cmd.Parameters.AddWithValue("@zanrID", b.Zanr.ZanrID);
            cmd.Parameters.AddWithValue("@jezikID", b.Jezik.JezikID);
            cmd.Parameters.AddWithValue("@opisKnjige", b.OpisKnjige);
            cmd.Parameters.AddWithValue("@verzijaKnjige", b.VerzijaKnjige);
            cmd.Parameters.AddWithValue("@autorID", b.AutorID);
            cmd.Parameters.AddWithValue("@izdavacID", b.IzdavacID);

            int n = cmd.ExecuteNonQuery();

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
                    Book b = new Book()
                    {
                        KnjigaID = (int)reader["KnjigaID"],
                        ImeKnjige = (string)reader["ImeKnjige"],
                        BrStrana = (int)reader["BrStrana"],
                        FormatKnjige = new Format()
                        {
                            FormatID = (int)reader["FormatID"],
                            Name = (string)reader["Format"]
                        },
                        DatPublished = (DateTime)reader["DatPublished"],
                        ISBN = (int)reader["ISBN"],
                        Zanr = new Zanr()
                        {
                            ZanrID = (int)reader["GenreID"],
                            Ime = (string)reader["Genre"]
                        },
                        Jezik = new Jezik()
                        {
                            JezikID = (int)reader["JezikID"],
                            Name = (string)reader["JezikName"]
                        },
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
        public List<Book> PretraziKnjige(Criteria.BookCriteria bc, string value) 
        {
            List<Book> list = new List<Book>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = broker.returnConnection();

            string columnName = "";
            switch (bc)
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
            cmd.Parameters.AddWithValue("@value", value);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Book b = new Book()
                    {
                        KnjigaID = (int)reader["KnjigaID"],
                        ImeKnjige = (string)reader["ImeKnjige"],
                        BrStrana = (int)reader["BrStrana"],
                        FormatKnjige = new Format { FormatID = (int)reader["FormatKnjigeID"], Name = (string)reader["FormatName"] },
                        DatPublished = (DateTime)reader["DatPublished"],
                        ISBN = (int)reader["ISBN"],
                        Zanr = new Zanr { ZanrID = (int)reader["ZanrID"], Ime = (string)reader["ZanrName"] },
                        Jezik = new Jezik { JezikID = (int)reader["JezikID"], Name = (string)reader["JezikName"] },
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
                    b.FormatKnjige = new Format { FormatID = (int)reader["FormatKnjigeID"], Name = (string)reader["FormatName"] };
                    b.DatPublished = (DateTime)reader["DatPublished"];
                    b.ISBN = (int)reader["ISBN"];
                    b.Zanr = new Zanr { ZanrID = (int)reader["ZanrID"], Ime = (string)reader["ZanrName"] };
                    b.Jezik = new Jezik { JezikID = (int)reader["JezikID"], Name = (string)reader["JezikName"] };
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
            cmd.CommandText = @"UPDATE Knjiga
                        SET ImeKnjige = @imeKnjige,
                            BrStrana = @brStrana,
                            FormatKnjigeID = @formatKnjigeID,
                            DatPublished = @datPublished,
                            ISBN = @isbn,
                            ZanrID = @zanrID,
                            JezikID = @jezikID,
                            OpisKnjige = @opisKnjige,
                            VerzijeKnjige = @verzijaKnjige,
                            AutorID = @autorID,
                            IzdavacID = @izdavacID
                        WHERE KnjigaID = @knjigaID";
            cmd.Parameters.AddWithValue("@imeKnjige", b.ImeKnjige);
            cmd.Parameters.AddWithValue("@brStrana", b.BrStrana);
            cmd.Parameters.AddWithValue("@formatKnjigeID", b.FormatKnjige.FormatID);
            cmd.Parameters.AddWithValue("@datPublished", b.DatPublished);
            cmd.Parameters.AddWithValue("@isbn", b.ISBN);
            cmd.Parameters.AddWithValue("@zanrID", b.Zanr.ZanrID);
            cmd.Parameters.AddWithValue("@jezikID", b.Jezik.JezikID);
            cmd.Parameters.AddWithValue("@opisKnjige", b.OpisKnjige);
            cmd.Parameters.AddWithValue("@verzijaKnjige", b.VerzijaKnjige);
            cmd.Parameters.AddWithValue("@autorID", b.AutorID);
            cmd.Parameters.AddWithValue("@izdavacID", b.IzdavacID);
            cmd.Parameters.AddWithValue("@knjigaID", b.KnjigaID);
            cmd.Connection = broker.returnConnection();

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

            int n = cmd.ExecuteNonQuery();

            broker.Close();

            if (n > 0)
                return true;
            return false;
        }
        public bool NapraviStatusKnjige(BookStatus bs) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO BookStatus (KnjigaID, KorisnikID, BrProcitanihStrana, StatusKnjigeID, DatAdded, DatLastModified, RatingID, Feedback)
                        VALUES (@knjigaID, @korisnikID, @brProcitanihStrana, @statusKnjigeID, @datAdded, @datLastModified, @ratingID, @feedback)";
            cmd.Parameters.AddWithValue("@knjigaID", bs.KnjigaID);
            cmd.Parameters.AddWithValue("@korisnikID", bs.KorisnikID);
            cmd.Parameters.AddWithValue("@brProcitanihStrana", bs.BrProcitanihStrana);
            cmd.Parameters.AddWithValue("@statusKnjigeID", bs.StatusKnjige.StatusID);
            cmd.Parameters.AddWithValue("@datAdded", bs.DatAdded);
            cmd.Parameters.AddWithValue("@datLastModified", bs.DatLastModified);
            cmd.Parameters.AddWithValue("@ratingID", bs.Rating.RatingID);
            cmd.Parameters.AddWithValue("@feedback", bs.Feedback);
            cmd.Connection = broker.returnConnection();

            int n = cmd.ExecuteNonQuery();

            broker.Close();

            if (n > 0)
                return true;
            return false;
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
            cmd.CommandText = $"SELECT * FROM BookStatus WHERE {columnName} = @value";
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BookStatus status = new BookStatus()
                    {
                        KorisnikID = (int)reader["KorisnikID"],
                        KnjigaID = (int)reader["KnjigaID"],
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
        public List<BookStatus> UcitajStatusKnjige(BookStatus bs)
        {
            List<BookStatus> listaStatusa = new List<BookStatus>();

            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM StatusKnjige sk JOIN Status s ON (sk.StatusKnjigeID = s.StatusID) JOIN Rating r ON (r.RatingID = sk.RatingID) WHERE KorisnikID = {bs.KorisnikID} AND KnjigaID = {bs.KnjigaID}";
            cmd.Connection = broker.returnConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BookStatus status = new BookStatus()
                    {
                        KorisnikID = (int)reader["KorisnikID"],
                        KnjigaID = (int)reader["KnjigaID"],
                        BrProcitanihStrana = (int)reader["BrProcitanihStrana"],
                        StatusKnjige = new Status { StatusID = (int)reader["StatusID"], Name = (string)reader["Status"] },
                        DatAdded = (DateTime)reader["DatAdded"],
                        DatLastModified = (DateTime)reader["DatLastModified"],
                        Rating = new Rating { RatingID = (int)reader["RatingID"], Name = (string)reader["Name"] },
                        Feedback = (string)reader["Feedback"]
                    };

                    listaStatusa.Add(status);
                }
            }

            broker.Close();

            return listaStatusa;
        }
        public bool IzmeniStatusKnjige(BookStatus bs) 
        {
            broker.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE StatusKnjige
                        SET BrProcitanihStrana = @brProcitanihStrana,
                            StatusKnjigeID = @statusKnjigeID,
                            DatAdded = @datAdded,
                            DatLastModified = @datLastModified,
                            RatingID = @ratingID,
                            Feedback = @feedback
                        WHERE KnjigaID = @knjigaID AND KorisnikID = @korisnikID";
            cmd.Parameters.AddWithValue("@brProcitanihStrana", bs.BrProcitanihStrana);
            cmd.Parameters.AddWithValue("@statusKnjigeID", bs.StatusKnjige.StatusID);
            cmd.Parameters.AddWithValue("@datAdded", bs.DatAdded);
            cmd.Parameters.AddWithValue("@datLastModified", bs.DatLastModified);
            cmd.Parameters.AddWithValue("@ratingID", bs.Rating.RatingID);
            cmd.Parameters.AddWithValue("@feedback", bs.Feedback);
            cmd.Parameters.AddWithValue("@knjigaID", bs.KnjigaID);
            cmd.Parameters.AddWithValue("@korisnikID", bs.KorisnikID);
            cmd.Connection = broker.returnConnection();

            int n = cmd.ExecuteNonQuery();

            broker.Close();

            if (n > 0)
                return true;
            return false;
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
