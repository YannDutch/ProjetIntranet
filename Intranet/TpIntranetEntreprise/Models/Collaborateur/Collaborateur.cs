using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class Collaborateur
    {
        private int matriculeCollab=0;
        private string nom;
        private string prenom;
        private string dateNaissance;
        private string MDP;
        public Collaborateur()
        {
            matriculeCollab++;
        }

        public Collaborateur(string nom, string prenom, string dateNaissance, string MDP):this()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            MDP1 = MDP;
        }

        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string MDP1 { get => MDP; set => MDP = value; }








        //       public List<Collaborateur> Find(Func<Collaborateur, bool> criteria)
        //      {
        //          BaseDAO<Collaborateur> dao = new List<Collaborateur>
        //          return dao.Find(criteria);
        //     }




        public bool Save()
        {
            BaseDAO<Collaborateur> dao = new CollaborateurDAO();
            return dao.Ajouter(this);
        }
    }

    
}
