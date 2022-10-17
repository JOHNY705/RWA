using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class Login : System.Web.UI.Page
    {
        public string Email { get; set; }
        public string Password { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            Email = tbUsername.Text;
            Password = tbPassword.Text;

            Djelatnik djelatnik = Repozitorij.LoginKorisnika(Email, Password);

            if (djelatnik == null)
            {
                IspisGreske("Krivo korisničko ime ili lozinka");
                return;
            }

            if (djelatnik.Tip == TipDjelatnika.Direktor || djelatnik.Tip == TipDjelatnika.VoditeljTima)
            {
                PrijaviKorisnikaUSustav(djelatnik);
            }
            else
            {
                IspisGreske("Nemate pravo pristupa ovoj aplikaciji");
            }
        }

        private void PrijaviKorisnikaUSustav(Djelatnik djelatnik)
        {
            if (cbRememberMe.Checked)
            {
                KreirajEmailLozinkaKukije();
            }

            Session["djelatnik"] = djelatnik;
            Response.Redirect("Profil.aspx");
        }

        private void KreirajEmailLozinkaKukije()
        {
            HttpCookie emailKuki = new HttpCookie("email", Email);
            HttpCookie lozinkaKuki = new HttpCookie("password", Password);
            emailKuki.Expires = DateTime.Now.AddMinutes(60);
            lozinkaKuki.Expires = DateTime.Now.AddMinutes(60);
            Response.AppendCookie(emailKuki);
            Response.AppendCookie(lozinkaKuki);
        }

        private void IspisGreske(string greska)
        {
            errorMessage.Text = greska;
            errorMessage.Visible = true;
        }
    }
}