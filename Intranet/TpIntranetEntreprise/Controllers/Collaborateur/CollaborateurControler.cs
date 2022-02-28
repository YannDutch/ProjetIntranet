using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using TpIntranetEntreprise.Models;


namespace TpIntranetEntreprise.Controllers
{













    public class CollaborateurController : Controller
    {

        // GET : Collaborateur/Index
        public IActionResult CollaborateurIndex(string recherche)
        { 
            return View();
        }


        // GET: Collaborateur/AjouterCollaborateur
        public IActionResult AjouterCollaborateur()
        {
            return View();
        }

        // GET : ContactController/SuccesAjout
        public ActionResult SuccesAjout()
        {
            return View();
        }

        // GET : ContactController/SuccesAjout
        public ActionResult Collaborateur()
        {
            return View();
        }

        // GET : ContactController/SuccesAjout
        public ActionResult Admin()
        {
            return View();
        }


    }
}
