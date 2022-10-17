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
    public partial class MojTim : System.Web.UI.Page
    {
        private Djelatnik djelatnik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            djelatnik = Session["djelatnik"] as Djelatnik;

            IEnumerable<Djelatnik> clanoviTima = Repozitorij.GetClanoviTima(djelatnik.Tim);

            foreach (Djelatnik clan in clanoviTima)
            {
                DjelatnikUC djelatnikUC = LoadControl("UserControls/DjelatnikUC.ascx") as DjelatnikUC;
                djelatnikUC.ID = $"{clan.IDDjelatnik}";
                djelatnikUC.SetInfo(clan);
                phClanovi.Controls.Add(djelatnikUC);
            }
        }
    }
}