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
    public partial class DetaljiDjelatnika : System.Web.UI.Page
    {
        private Djelatnik djelatnik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null || Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int idDjelatnik = int.Parse(Request.QueryString["id"]);
                djelatnik = Repozitorij.GetDjelatnik(idDjelatnik);
                if (!IsPostBack)
                {
                    tbIme.Text = djelatnik.Ime;
                    tbPrezime.Text = djelatnik.Prezime;
                    UcitajTipDjelatnika();
                    ddlTip.SelectedValue = djelatnik.Tip.ToString();
                    tbEmail.Text = djelatnik.Email;
                    tbDatumZaposlenja.Text = djelatnik.DatumZaposlenja.ToShortDateString();
                    UcitajTimove();
                    ddlTim.SelectedValue = djelatnik.Tim.IDTim.ToString();
                }
            }
            IEnumerable<Projekt> projektiDjelatnika = Repozitorij.GetProjektiDjelatnika(djelatnik.IDDjelatnik);
            foreach (Projekt projekt in projektiDjelatnika)
            {
                ProjektUC projektUC = LoadControl("UserControls/ProjektUC.ascx") as ProjektUC;
                projektUC.ID = $"{projekt.IDProjekt}";
                projektUC.SetInfo(projekt);
                phProjektiDjelatnika.Controls.Add(projektUC);
            }
        }

        private void UcitajTimove()
        {
            IEnumerable<Tim> timovi = Repozitorij.GetTimovi();
            ddlTim.Items.Clear();
            ddlTim.Items.Add(new ListItem { Text = "Nije u timu", Value = $"{0}" });

            foreach (Tim tim in timovi)
            {
                ddlTim.Items.Add(new ListItem { Text = tim.Naziv, Value = tim.IDTim.ToString() });
            }
        }

        private void UcitajTipDjelatnika()
        {
            ddlTip.Items.Clear();
            foreach (TipDjelatnika tipDjelatnika in Enum.GetValues(typeof(TipDjelatnika)))
            {
                ddlTip.Items.Add(new ListItem { Text = tipDjelatnika.ToString(), Value = $"{(int)tipDjelatnika}" });
            }
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            tbIme.Enabled = true;
            tbPrezime.Enabled = true;
            tbEmail.Enabled = true;
            ddlTip.Enabled = true;
            ddlTim.Enabled = true;
        }
        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            djelatnik.Ime = tbIme.Text;
            djelatnik.Prezime = tbPrezime.Text;
            djelatnik.Tip = (TipDjelatnika)int.Parse(ddlTip.SelectedValue);
            djelatnik.Email = tbEmail.Text;
            djelatnik.Tim = Repozitorij.GetTim(int.Parse(ddlTim.SelectedValue));
            Repozitorij.UpdateDjelatnik(djelatnik);
            tbIme.Enabled = false;
            tbPrezime.Enabled = false;
            tbEmail.Enabled = false;
            ddlTip.Enabled = false;
            ddlTim.Enabled = false;
        }
        protected void btnDjelatnici_Click(object sender, EventArgs e)
        {
            Response.Redirect("Djelatnici.aspx");
        }
    }
}