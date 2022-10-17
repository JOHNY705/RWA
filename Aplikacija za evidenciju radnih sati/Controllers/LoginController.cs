using Aplikacija_za_administraciju.Models;
using Aplikacija_za_evidenciju_radnih_sati.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija_za_evidenciju_radnih_sati.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                Djelatnik djelatnik = Repozitorij.LoginUser(user.Email, user.Password);
                if (djelatnik != null && djelatnik.Tip != TipDjelatnika.Neaktivan)
                {
                    Session["djelatnik"] = djelatnik;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Message"] = "Neispravno korisničko ime ili lozinka.";
                }
            }

            return View(user);
        }
    }
}