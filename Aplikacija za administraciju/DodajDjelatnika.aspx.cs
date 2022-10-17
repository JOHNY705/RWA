using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class DodajDjelatnika : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<Tim> timovi = Repozitorij.GetTimovi();
                ddlTimovi.Items.Clear();
                ddlTimovi.Items.Add(new ListItem { Text = "-- odaberi tim --", Selected = true, Value = $"{-1}" });
                ddlTimovi.Items.Add(new ListItem { Text = "-- Nije u timu --", Value = $"{0}" });

                foreach (Tim tim in timovi)
                {
                    ddlTimovi.Items.Add(new ListItem { Text = tim.Naziv, Value = tim.IDTim.ToString() });
                }

                ddlTip.Items.Clear();
                ddlTip.Items.Add(new ListItem { Text = "-- odaberi tip --", Selected = true, Value = $"{-1}" });

                foreach (TipDjelatnika tipDjelatnika in Enum.GetValues(typeof(TipDjelatnika)))
                {
                    ddlTip.Items.Add(new ListItem { Text = tipDjelatnika.ToString(), Value = $"{(int)tipDjelatnika}" });
                }
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Djelatnik djelatnik = new Djelatnik(ime: tbIme.Text, prezime: tbPrezime.Text, tip: int.Parse(ddlTip.SelectedValue),
                email: tbEmail.Text, lozinka: tbLozinka.Text, datumZaposlenja: DateTime.Now,
                tim: int.Parse(ddlTimovi.SelectedValue) == 0 ? null : Repozitorij.GetTim(int.Parse(ddlTimovi.SelectedValue)));
            Repozitorij.DodajNovogDjelatnika(djelatnik);
            Response.Redirect("Djelatnici.aspx");
        }
    }
}