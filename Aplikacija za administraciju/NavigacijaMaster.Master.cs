using Aplikacija_za_administraciju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija_za_administraciju
{
    public partial class NavigacijaMaster : System.Web.UI.MasterPage
    {
        public HyperLink NavItemProjekti { get; set; }
        public HyperLink NavItemMojTim { get; set; }
        public HyperLink NavItemIzvjestaji { get; set; }
        public HyperLink NavItemTimovi { get; set; }
        public HyperLink NavItemDjelatnici { get; set; }
        public HyperLink NavItemKlijenti { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Djelatnik djelatnik = Session["djelatnik"] as Djelatnik;
            if (djelatnik == null)
            {
                Response.Redirect("Login.aspx");
            }

            NagivacijskaTraka(djelatnik.Tip);

            lbImePrezime.Text = djelatnik.ToString();

            NavItemProjekti = navitemProjekti;
            NavItemMojTim = navitemMojTim;
            NavItemIzvjestaji = navitemIzvjestaji;
            NavItemTimovi = navitemTimovi;
            NavItemDjelatnici = navitemDjelatnici;
            NavItemKlijenti = navitemKlijenti;
        }

        private void NagivacijskaTraka(TipDjelatnika tip)
        {
            if (tip == TipDjelatnika.Direktor)
            {
                navitemMojTim.Visible = false;
            }
            if (tip == TipDjelatnika.VoditeljTima)
            {
                navitemTimovi.Visible = false;
                navitemKlijenti.Visible = false;
                navitemDjelatnici.Visible = false;
            }
        }

        protected void btnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

        protected void btnOdjava_Click(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Session.Clear();
            ViewState.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}