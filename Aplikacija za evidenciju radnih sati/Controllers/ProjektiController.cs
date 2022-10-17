using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija_za_evidenciju_radnih_sati.Controllers
{
    public class ProjektiController : Controller
    {
        // GET: Projekti
        public ActionResult Index()
        {
            return View();
        }
    }
}