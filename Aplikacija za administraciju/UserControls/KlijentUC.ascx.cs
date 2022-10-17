using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju.UserControls
{
    public partial class KlijentUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetInfo(Klijent klijent)
        {
            lblKlijentNaziv.Text = klijent.Naziv;
            btnDetalji.Attributes.Add("id", klijent.IDKlijent.ToString());
        }

        protected void btnDetalji_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            Response.Redirect($"DetaljiKlijenta.aspx?id={int.Parse(lb.Attributes["id"])}");
        }
    }
}