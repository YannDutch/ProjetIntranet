using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Models.Personne;

namespace TpIntranetEntreprise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeamCrisis()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Personne personne = new();
            personne.Collab = new Collaborateur();
            personne.Compta = new CollabCompta();
            personne.Rh = new CollabRH();
            personne.Admin = new CollabAdmin();
            personne.Chef = new ChefService();
            if (username == personne.Collab.Nom && password == personne.Collab.MDP1)
            {
                HttpContext.Session.SetString("username", username);
                return View("InterfaceCollab", personne.Collab);
            }
            else if (username == personne.Compta.Nom && password == personne.Compta.MDP1)
            {
                HttpContext.Session.SetString("username", username);
                return View("InterfaceCompta", personne.Compta);
            }
            else if (username == personne.Rh.Nom && password == personne.Rh.MDP1)
            {
                HttpContext.Session.SetString("username", username);
                return View("InterfaceRH", personne.Rh);
            }
            else if (username == personne.Chef.Nom && password == personne.Chef.MDP1)
            {
                HttpContext.Session.SetString("username", username);
                return View("InterfaceChefService", personne.Chef);
            }
            else if (username == personne.Admin.Nom && password == personne.Admin.MDP1)
            {
                HttpContext.Session.SetString("username", username);
                return View("InterfaceAdmin", personne.Admin);
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
        public IActionResult Details()
        {
            CollabRH c = new();
            return View(c);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
