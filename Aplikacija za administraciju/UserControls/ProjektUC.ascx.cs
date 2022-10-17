using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju.UserControls
{
    public partial class ProjektUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetInfo(Projekt p)
        {
            lblProjektNaslov.Text = p.Naziv;
            lblProjektOpis.Text = p.OpisProjekta;
            btnDetalji.Attributes.Add("id", p.IDProjekt.ToString());
        }

        protected void btnDetalji_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            Response.Redirect($"DetaljiProjekta.aspx?id={int.Parse(btn.Attributes["id"])}");
        }
    }
}