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
    public partial class Klijenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            IEnumerable<Klijent> klijenti = Repozitorij.GetKlijenti();
            foreach (Klijent klijent in klijenti)
            {
                KlijentUC klijentUC = LoadControl("UserControls/KlijentUC.ascx") as KlijentUC;
                klijentUC.ID = $"{klijent.IDKlijent}";
                klijentUC.SetInfo(klijent);
                phKlijenti.Controls.Add(klijentUC);
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Response.Redirect("DodajKlijenta.aspx");
        }
    }
}