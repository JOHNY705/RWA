using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class DodajKlijenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Klijent klijent = new Klijent(naziv: tbNaziv.Text, telefon: tbKontakt.Text, email: tbEmail.Text);
            Repozitorij.DodajNovogKlijenta(klijent);
            Response.Redirect("Klijenti.aspx");
        }
    }
}