using pdf.Client.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf.Client
{
    public partial class LoginForm : Form
    {
        /*
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        */

        public LoginForm()
        {
            InitializeComponent();

            // BannerPanel da se odmah pojavi
            BannerUC buc = new BannerUC();
            main_panel.Controls.Add(buc);

            // osmisli kako da kontrolises user kontrole, moja ideja bi bila
            
            // User logs in -> close this form and open main one
            // main forma ima panel u kojem se nalazi gui i menja se na klik
        }

        /*
            1. signal NapraviKorisnika(Korisnik)                        :Register
            2. signal UcitajKorisnike(List<Korisnik>)                   :AllUsers
            3. signal PretraziKorisnike(kriterijum, List<Korisnik>)     :SearchUs
            4. signal UcitajKorisnika(Korisnik)                         :
            5. signal IzmeniKorisnika(Korisnik)
            6. signal ObrisiKorisnika(Korisnik)
            7. signal NapraviKnjigu(Knjiga)
            8. signal UcitajKnjige(List<Knjiga>)
            9. signal PretraziKnjige(kriterijum, List<Knjiga>)
            10. signal UcitajKnjigu(Knjiga)
            11. signal IzmeniKnjigu(Knjiga)
            12. signal ObrisiKnjigu(Knjiga)
            13. signal NapraviStatusKnjige(Status)
            14. signal IzmeniStatusKnjige(StatusKnjige)
            15. signal UcitajAutore(List<Autor>)
            16. signal UcitajIzdavace(List<Izdavac>)
        */
    }
}
