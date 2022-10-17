using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija_za_evidenciju_radnih_sati.Controllers
{
    public class PregledRadaController : Controller
    {
        // GET: PregledRada
        public ActionResult Index()
        {
            return View();
        }
    }
}