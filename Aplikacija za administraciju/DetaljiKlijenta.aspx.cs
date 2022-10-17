using Aplikacija_za_administraciju.Models;
using Aplikacija_za_administraciju.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class DetaljiKlijenta : System.Web.UI.Page
    {
        private Klijent klijent;
        IEnumerable<Projekt> projektiKlijenta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null || Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int idKlijent = int.Parse(Request.QueryString["id"]);
                klijent = Repozitorij.GetKlijent(idKlijent);
                if (!IsPostBack)
                {
                    tbNaziv.Text = klijent.Naziv;
                    tbKontakt.Text = klijent.Telefon;
                    tbEmail.Text = klijent.Email;
                }
            }

            projektiKlijenta = Repozitorij.DohvatiProjekteKlijenta(klijent);
            foreach (Projekt projekt in projektiKlijenta)
            {
                ProjektUC projektUC = LoadControl("UserControls/ProjektUC.ascx") as ProjektUC;
                projektUC.ID = $"{projekt.IDProjekt}";
                projektUC.SetInfo(projekt);
                phProjekti.Controls.Add(projektUC);
            }
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            tbNaziv.Enabled = true;
            tbKontakt.Enabled = true;
            tbEmail.Enabled = true;
        }

        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            klijent.Naziv = tbNaziv.Text;
            klijent.Telefon = tbKontakt.Text;
            klijent.Email = tbEmail.Text;
            Repozitorij.UpdateKlijent(klijent);
            tbNaziv.Enabled = false;
            tbKontakt.Enabled = false;
            tbEmail.Enabled = false;
        }

        protected void btnKlijenti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Klijenti.aspx");
        }
    }
}