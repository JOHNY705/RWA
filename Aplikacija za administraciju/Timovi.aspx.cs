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
    public partial class Timovi : System.Web.UI.Page
    {
        private Djelatnik djelatnik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["djelatnik"]==null)
            {
                Response.Redirect("Login.aspx");
            }

            djelatnik = Session["djelatnik"] as Djelatnik;

            if (djelatnik.Tip != TipDjelatnika.Direktor)
            {
                Response.Redirect("Login.aspx");
            }

            phTimovi.Controls.Clear();
            IEnumerable<Tim> timovi = Repozitorij.GetTimovi();
            foreach (Tim tim in timovi)
            {
                TimUC timUC = LoadControl("UserControls/TimUC.ascx") as TimUC;
                timUC.ID = $"{tim.IDTim}";
                timUC.SetInfo(tim);
                phTimovi.Controls.Add(timUC);
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Response.Redirect("DodajTim.aspx");
        }
    }
}