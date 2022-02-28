using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class Collaborateur
    {
        private int matricule;
        private string nom;
        private string prenom;
        private string telephone;
        private string email;
        private string IdService;
        public static List<Collaborateur> Liste = new List<Collaborateur> { new Collaborateur() { Nom = "Yannick", Prenom = "Prenom", Telephone = "+33 7 86 05 00 32", Email = "yannick.hourdiau@gmail.com" } };



        public Collaborateur()
        {


        }

        public Collaborateur(int matricule, string nom, string prenom, string telephone, string email)
        {

        }



        public Collaborateur(string nom, string prenom, string telephone, string email)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;

        }

        public int Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string IdService1 { get => IdService; set => IdService = value; }


      



        


 //       public List<Collaborateur> Find(Func<Collaborateur, bool> criteria)
  //      {
  //          BaseDAO<Collaborateur> dao = new List<Collaborateur>
  //          return dao.Find(criteria);
   //     }




        public bool Save()
        {
            BaseDAO<Collaborateur> dao = new CollaborateurDAO();
            return dao.AjouterCollaborateur(this);
        }
    }

    
}
