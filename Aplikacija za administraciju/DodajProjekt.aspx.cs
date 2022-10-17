using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class DodajProjekt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<Klijent> klijenti = Repozitorij.GetKlijenti();
                ddlKlijenti.Items.Clear();
                ddlKlijenti.Items.Add(new ListItem { Text = "-- odaberi klijenta --", Selected = true, Value = $"{-1}" });
                foreach (Klijent klijent in klijenti)
                {
                    ddlKlijenti.Items.Add(new ListItem { Text = klijent.Naziv, Value = klijent.IDKlijent.ToString() });
                }
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Projekt projekt = new Projekt(naziv: tbNaziv.Text, datumOtvaranja: DateTime.Today, voditelj: Session["djelatnik"] as Djelatnik,
                klijent: Repozitorij.GetKlijent(int.Parse(ddlKlijenti.SelectedValue)), opisProjekta: tbOpis.Text);
            Repozitorij.DodajNoviProjekt(projekt);
            Response.Redirect("Projekti.aspx");
        }
    }
}