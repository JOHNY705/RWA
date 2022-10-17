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
    public partial class DetaljiTima : System.Web.UI.Page
    {
        private Tim tim;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null || Session["djelatnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int timID = int.Parse(Request.QueryString["id"]);
                tim = Repozitorij.GetTim(timID);
                if (!IsPostBack)
                {
                    tbNaziv.Text = tim.Naziv;
                    tbVoditelj.Text = tim.Voditelj.ToString();
                }
                IEnumerable<Djelatnik> clanoviTima = Repozitorij.GetClanoviTima(tim);
                foreach (Djelatnik clan in clanoviTima)
                {
                    DjelatnikUC djelatnikUC = LoadControl("UserControls/DjelatnikUC.ascx") as DjelatnikUC;
                    djelatnikUC.ID = $"{clan.IDDjelatnik}";
                    djelatnikUC.SetInfo(clan);
                    phClanovi.Controls.Add(djelatnikUC);
                }
            }
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            tbNaziv.Enabled = true;
        }
        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            tim.Naziv = tbNaziv.Text;
            Repozitorij.UpdateTim(tim);
            tbNaziv.Enabled = false;
        }
        protected void btnTimovi_Click(object sender, EventArgs e)
        {
            Response.Redirect("Timovi.aspx");
        }
    }
}