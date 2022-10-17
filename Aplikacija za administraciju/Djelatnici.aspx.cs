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
    public partial class Djelatnici : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            IEnumerable<Djelatnik> djelatnici = Repozitorij.DohvatiDjelatnikeBezDirektora();
            foreach (Djelatnik djelatnik in djelatnici)
            {
                DjelatnikUC duc = LoadControl("UserControls/DjelatnikUC.ascx") as DjelatnikUC;
                duc.ID = $"{djelatnik.IDDjelatnik}";
                duc.SetInfo(djelatnik);
                phDjelatnici.Controls.Add(duc);
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Response.Redirect("DodajDjelatnika.aspx");
        }
    }
}