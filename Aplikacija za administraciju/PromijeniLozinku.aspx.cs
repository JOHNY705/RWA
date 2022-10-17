using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class PromijeniLozinku : System.Web.UI.Page
    {
        private Djelatnik djelatnik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            djelatnik = Session["djelatnik"] as Djelatnik;
        }

        protected void btnPromijeniLozinku_Click(object sender, EventArgs e)
        {
            djelatnik.Lozinka = tbNovaLozinka.Text;
            Repozitorij.PromijeniDjelatnikuLozinku(djelatnik);
            Response.Redirect("Profil.aspx");
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

        protected void CvTrenutnaLozinka_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (djelatnik.Lozinka != tbTrenutnaLozinka.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}