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
        private string nomTypeCollab;
        private string nomServicePersonne;
        public Collaborateur()
        {
            matriculeCollab++;
        }

        public Collaborateur(string nom, string prenom, string dateNaissance, string MDP, string nomTypeCollab, string nomServicePersonne) : this()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            MDP1 = MDP;
            NomTypeCollab = nomTypeCollab;
            NomServicePersonne = nomServicePersonne;
        }

        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string MDP1 { get => MDP; set => MDP = value; }
        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public string NomServicePersonne { get => nomServicePersonne; set => nomServicePersonne = value; }

        public bool Save()
        {
            BaseDAO<Collaborateur> Collaborateurdao = new CollaborateurDAO();
            return Collaborateurdao.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<Collaborateur> Collaborateurdao = new CollaborateurDAO();
            return Collaborateurdao.Delete(this);
        }
        public Collaborateur Find(string nom)
        {
            BaseDAO<Collaborateur> Collaborateurdao = new CollaborateurDAO();
            return Collaborateurdao.Find(nom);
        }
        public List<Collaborateur> Find(Func<Collaborateur, bool> criteria)
        {
            BaseDAO<Collaborateur> Collaborateurdao = new CollaborateurDAO();
            return Collaborateurdao.Find(criteria);
        }
        public List<Collaborateur> FindAl()
        {
            BaseDAO<Collaborateur> Collaborateurdao = new CollaborateurDAO();

            return Collaborateurdao.FindAll();
        }
        public bool Update(Collaborateur element)
        {
            BaseDAO<Collaborateur> Collaborateurdao = new CollaborateurDAO();
            return Collaborateurdao.Update(element);
        }
    }

    
}
