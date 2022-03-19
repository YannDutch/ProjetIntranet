using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TpIntranetEntreprise.Models.Personne;

namespace TpIntranetEntreprise.Controllers.Interface
{
    public class InterfaceController : Controller
    {
        
        // GET: InterfaceCollabController
        public ActionResult Index()
        {
            return View();
        }
        
       
        // GET: InterfaceCollabController/Details/5
        public IActionResult InterfaceCollab()
        {
            return View();
        }
        public IActionResult InterfaceAdmin()
        {
            return View();
        }
        public IActionResult SubmitCollab(string nom, string prenom, DateTime dateNaissance, string MDP, string nomServicePersonne, string nomTypeCollab)
        {
            Personne personne = new();
            personne.Collab = new Collaborateur();
            personne.Compta = new CollabCompta();
            personne.Rh = new CollabRH();
            personne.Admin = new CollabAdmin();
            personne.Chef = new ChefService();

            switch (nomServicePersonne)
            {
                case "Collaborateur":
                    personne.Collab.Nom = nom;
                    personne.Collab.Prenom = prenom;
                    personne.Collab.DateNaissance = dateNaissance;
                    personne.Collab.MDP1 = MDP;
                    personne.Collab.NomServicePersonne = nomServicePersonne;
                    break;
                case "Compta":
                    personne.Compta.Nom = nom;
                    personne.Compta.Prenom = prenom;
                    personne.Compta.DateNaissance = dateNaissance;
                    personne.Compta.MDP1 = MDP;
                    personne.Compta.NomServicePersonne = nomServicePersonne;
                    break;
                case "RH":
                    personne.Rh.Nom = nom;
                    personne.Rh.Prenom = prenom;
                    personne.Rh.DateNaissance = dateNaissance;
                    personne.Rh.MDP1 = MDP;
                    personne.Rh.NomServicePersonne = nomServicePersonne;
                    break;
                case "ChefService":
                    personne.Chef.Nom = nom;
                    personne.Chef.Prenom = prenom;
                    personne.Chef.DateNaissance = dateNaissance;
                    personne.Chef.MDP1 = MDP;
                    personne.Chef.NomServicePersonne = nomServicePersonne;
                    break;
                case "Admin":
                    personne.Admin.Nom = nom;
                    personne.Admin.Prenom = prenom;
                    personne.Admin.DateNaissance = dateNaissance;
                    personne.Admin.MDP1 = MDP;
                    personne.Admin.NomServicePersonne = nomServicePersonne;
                    break;
            }
            if (nomServicePersonne == "Collaborateur")
            {
                switch (nomTypeCollab)
                {
                    case "Collaborateur":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "Comptabilité":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "RH":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "Admin":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "ChefService":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;

                }
                return View("InterfaceCollab", personne.Collab);
            }
            else if (nomServicePersonne == "Compta")
            {
                switch (nomTypeCollab)
                {
                    case "Collaborateur":
                        personne.Compta.NomTypeCollab = nomTypeCollab;
                        personne.Compta.Save();
                        break;
                    case "Comptabilité":
                        personne.Compta.NomTypeCollab = nomTypeCollab;
                        personne.Compta.Save();
                        break;
                    case "RH":
                        personne.Compta.NomTypeCollab = nomTypeCollab;
                        personne.Compta.Save();
                        break;
                    case "Admin":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "ChefService":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;

                }
                return View("InterfaceCompta", personne.Compta);
            }
            else if (nomServicePersonne == "RH")
            {
                switch (nomTypeCollab)
                {
                    case "Collaborateur":
                        personne.Rh.NomTypeCollab = nomTypeCollab;
                        personne.Rh.Save();
                        break;
                    case "Comptabilité":
                        personne.Rh.NomTypeCollab = nomTypeCollab;
                        personne.Rh.Save();
                        break;
                    case "RH":
                        personne.Rh.NomTypeCollab = nomTypeCollab;
                        personne.Rh.Save();
                        break;
                    case "Admin":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "ChefService":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                }
                return View("InterfaceRH", personne.Rh);
            }
            else if (nomServicePersonne == "ChefService")
            {
                switch (nomTypeCollab)
                {
                    case "Collaborateur":
                        personne.Chef.NomTypeCollab = nomTypeCollab;
                        personne.Chef.Save();
                        break;
                    case "Comptabilité":
                        personne.Chef.NomTypeCollab = nomTypeCollab;
                        personne.Chef.Save();
                        break;
                    case "RH":
                        personne.Chef.NomTypeCollab = nomTypeCollab;
                        personne.Chef.Save();
                        break;
                    case "Admin":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "ChefService":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                }
                return View("InterfaceChefService", personne.Chef);
            }
            else if (nomServicePersonne == "Admin")
            {
                switch (nomTypeCollab)
                {
                    case "Collaborateur":
                        personne.Admin.NomTypeCollab = nomTypeCollab;
                        personne.Admin.Save();
                        break;
                    case "Comptabilité":
                        personne.Admin.NomTypeCollab = nomTypeCollab;
                        personne.Admin.Save();
                        break;
                    case "RH":
                        personne.Admin.NomTypeCollab = nomTypeCollab;
                        personne.Admin.Save();
                        break;
                    case "Admin":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                    case "ChefService":
                        personne.Collab.NomTypeCollab = nomTypeCollab;
                        personne.Collab.Save();
                        break;
                }
                return View("InterfaceAdmin", personne.Admin);
            }
            else
                return View("Error");
        }

        // GET: InterfaceCollabController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterfaceCollabController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InterfaceCollabController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InterfaceCollabController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InterfaceCollabController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InterfaceCollabController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
