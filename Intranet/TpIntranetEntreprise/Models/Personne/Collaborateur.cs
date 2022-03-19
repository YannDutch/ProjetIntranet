using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;
using TpIntranetEntreprise.Models.Action;


namespace TpIntranetEntreprise.Models.Personne
{
    public class Collaborateur
    {
        private int matriculeCollab = 0;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private string MDP;
        private string nomServicePersonne;
        private string nomTypeCollab;
        private List<MissionCollab> missionCollabs = new List<MissionCollab>();
        private List<DemandeConge> demandeConges = new List<DemandeConge>();
        public Collaborateur()
        {
            MatriculeCollab++;
        }

        public Collaborateur(int matriculeCollab, string nom, string prenom, DateTime dateNaissance, string MDP, string nomServicePersonne, string nomTypeCollab) : this()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            MDP1 = MDP;
            NomServicePersonne = nomServicePersonne;
            NomTypeCollab = nomTypeCollab;
            MatriculeCollab = matriculeCollab;
        }

        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string MDP1 { get => MDP; set => MDP = value; }
        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public string NomServicePersonne { get => nomServicePersonne; set => nomServicePersonne = value; }
        public List<MissionCollab> MissionCollabs { get => missionCollabs; set => missionCollabs = value; }
        public List<DemandeConge> DemandeConges { get => demandeConges; set => demandeConges = value; }

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
        public List<MissionCollab> HitoriquesMission(Collaborateur c)
        {
            MissionCollab mc = new MissionCollab();
            if (mc.Save() == true)
            {
                if (mc.MatriculeCollab == c.MatriculeCollab)
                {
                    MissionCollabs.Add(mc);
                }
            }
            return MissionCollabs;
        }
    }


}
