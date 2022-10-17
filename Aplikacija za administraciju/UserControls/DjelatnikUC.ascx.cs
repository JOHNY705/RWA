using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju.UserControls
{
    public partial class DjelatnikUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetInfo(Djelatnik djelatnik)
        {
            lblDjelatnikNaziv.Text = djelatnik.ToString();
            lblDjelatnikProjekti.Text = PostaviNazivProjekta(djelatnik.IDDjelatnik);
            btnDetalji.Attributes.Add("id", djelatnik.IDDjelatnik.ToString());
        }

        private string PostaviNazivProjekta(int iDDjelatnik)
        {
            IEnumerable<Projekt> projektiDjelatnika = Repozitorij.GetProjektiDjelatnika(iDDjelatnik);
            StringBuilder sb = new StringBuilder();
            sb.Append("Projekti: ");
            foreach (Projekt projekt in projektiDjelatnika)
            {
                sb.Append(projekt.ToString() + " |" + Environment.NewLine);
            }

            return sb.ToString();
        }

        protected void btnDetalji_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            Response.Redirect($"DetaljiDjelatnika.aspx?id={int.Parse(lb.Attributes["id"])}");
        }
    }
}