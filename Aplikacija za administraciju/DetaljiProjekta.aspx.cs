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
    public partial class DetaljiProjekta : System.Web.UI.Page
    {
        private Projekt projekt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null || Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int idProjekt = int.Parse(Request.QueryString["id"].ToString());
                projekt = Repozitorij.GetProjekt(idProjekt);
                if (!IsPostBack)
                {
                    tbNaziv.Text = projekt.Naziv;
                    tbDatum.Text = projekt.DatumOtvaranja.ToShortDateString();
                    tbVoditelj.Text = projekt.Voditelj.ToString();
                    tbKlijent.Text = projekt.Klijent.ToString();
                    tbOpis.Text = projekt.OpisProjekta;
                }
                IEnumerable<Djelatnik> djelatniciProjekta = Repozitorij.DohvatiDjelatnikeKojiRadeNaProjektu(projekt);
                foreach (Djelatnik djelatnik in djelatniciProjekta)
                {
                    DjelatnikUC duc = LoadControl("UserControls/DjelatnikUC.ascx") as DjelatnikUC;
                    duc.ID = $"{djelatnik.IDDjelatnik}";
                    duc.SetInfo(djelatnik);
                    phDjelatniciNaProjektu.Controls.Add(duc);
                }
            }
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            tbNaziv.Enabled = true;
            tbDatum.Enabled = true;
            tbOpis.Enabled = true;
        }

        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            projekt.Naziv = tbNaziv.Text;
            projekt.DatumOtvaranja = DateTime.Parse(tbDatum.Text);
            projekt.OpisProjekta = tbOpis.Text;
            Repozitorij.UpdateProjekt(projekt);
            tbNaziv.Enabled = false;
            tbDatum.Enabled = false;
            tbOpis.Enabled = false;
        }

        protected void btnProjekti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Projekti.aspx");
        }
    }
}