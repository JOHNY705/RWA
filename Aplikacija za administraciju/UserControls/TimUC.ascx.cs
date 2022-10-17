using Antlr.Runtime.Tree;
using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju.UserControls
{
    public partial class TimUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetInfo(Tim tim)
        {
            lblTimNaziv.Text = tim.Naziv;
            btnDetalji.Attributes.Add("id", tim.IDTim.ToString());
        }

        protected void btnDetalji_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            Response.Redirect($"DetaljiTima.aspx?id={int.Parse(lb.Attributes["id"])}");
        }
    }
}