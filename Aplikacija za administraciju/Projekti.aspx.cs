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
    public partial class Projekti : System.Web.UI.Page
    {
        private Djelatnik djelatnik;
        protected void Page_Load(object sender, EventArgs e)
        {
            djelatnik = Session["djelatnik"] as Djelatnik;
            if (djelatnik == null)
            {
                Response.Redirect("Login.aspx");
            }

            phProjects.Controls.Clear();

            int korisnikId = djelatnik.IDDjelatnik;

            IEnumerable<Projekt> projekti = Repozitorij.GetProjektiDjelatnika(korisnikId);

            foreach (Projekt p in projekti)
            {
                ProjektUC projektUC = LoadControl("UserControls/ProjektUC.ascx") as ProjektUC;
                projektUC.ID = $"{p.IDProjekt}";
                projektUC.SetInfo(p);
                phProjects.Controls.Add(projektUC);
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Response.Redirect("DodajProjekt.aspx");
        }
    }
}