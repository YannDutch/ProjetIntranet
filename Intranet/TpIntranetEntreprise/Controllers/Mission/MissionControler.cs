using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Models.Personne;
using TpIntranetEntreprise.Tools;
using TpIntranetEntreprise.DAO;
using System.Collections;

namespace TpIntranetEntreprise.Controllers
{
    public class MissionController : Controller
    {

        public IActionResult MissionIndex()
        {
            return View();
        }

        public IActionResult AjouterMission()
        {
            return View();
        }

        public IActionResult SuccesAjout()
        {
            return View();
        }

        public IActionResult ConsulterMission()
        {
            return View();
        }

        public IActionResult SupprimerMission()
        {
            return View();
        }

    }
}