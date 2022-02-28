using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Models.Collaborateur;
using TpIntranetEntreprise.Tools;
using TpIntranetEntreprise.DAO;
using System.Collections;

namespace TpIntranetEntreprise.Controllers
{
    public class ServiceController : Controller
    {

        public IActionResult ServiceIndex()
        {
            return View();
        }

        public IActionResult AjouterService()
        {
            return View();
        }

        public IActionResult SuccesAjout()
        {
            return View();
        }
    }
}