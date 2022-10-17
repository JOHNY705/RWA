using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class Profil : System.Web.UI.Page
    {
        private Djelatnik djelatnik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                djelatnik = Session["djelatnik"] as Djelatnik;
                if (!IsPostBack)
                {
                    djelatnik.Tim = Repozitorij.GetTimDjelatnika(djelatnik.IDDjelatnik);
                    lblIme.Text = djelatnik.Ime;
                    lblPrezime.Text = djelatnik.Prezime;
                    lblTim.Text = djelatnik.Tim.ToString();
                    tbEmail.Text = djelatnik.Email;
                    lblTipDjelatnika.Text = djelatnik.Tip.ToString();
                    lblDatumZaposlenja.Text = djelatnik.DatumZaposlenja.ToShortDateString();
                }
            }
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            tbEmail.Enabled = true;
        }

        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            djelatnik.Email = tbEmail.Text;
            Repozitorij.UpdateDjelatnik(djelatnik);
            tbEmail.Enabled = false;
        }

        protected void btnPromijeniLozinku_Click(object sender, EventArgs e)
        {
            Response.Redirect("PromijeniLozinku.aspx");
        }
    }
}