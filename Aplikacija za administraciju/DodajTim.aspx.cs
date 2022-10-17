using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class DodajTim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<Djelatnik> djelatnici = Repozitorij.DohvatiDjelatnikeBezTima();
                ddlVoditelj.Items.Clear();
                ddlVoditelj.Items.Add(new ListItem { Text = "-- odaberi voditelja --", Selected = true, Value = $"{-1}" });
                foreach (Djelatnik djelatnik in djelatnici)
                {
                    ddlVoditelj.Items.Add(new ListItem { Text = djelatnik.ToString(), Value = $"{djelatnik.IDDjelatnik}" });
                }
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Djelatnik voditelj = Repozitorij.GetDjelatnik(int.Parse(ddlVoditelj.SelectedValue));
            Tim tim = new Tim(tbNaziv.Text, voditelj);
            Repozitorij.DodajNoviTim(tim);
            Response.Redirect("Timovi.aspx");
        }
    }
}