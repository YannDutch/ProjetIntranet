using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Personne
{
    public class CollabRH : Collaborateur
    {
        private bool validN1;



        public CollabRH()
        {
            
        }

        public CollabRH(int matriculeCollab,string nom, string prenom, DateTime dateNaissance, string MDP, string nomTypeCollab, string nomTypeService) : base()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            MDP1 = MDP;
            NomTypeCollab = nomTypeCollab;
            NomServicePersonne = nomTypeService;
            MatriculeCollab = matriculeCollab;
        }
        public bool ValidN1 { get => validN1; set => validN1 = value; }
        public new bool Save()
        {
            BaseDAO<CollabRH> collabRHdao = new CollabRHDAO();
            return collabRHdao.Ajouter(this);
        }
        public new bool Delete()
        {
            BaseDAO<CollabRH> collabRHdao = new CollabRHDAO();
            return collabRHdao.Delete(this);
        }
        public new CollabRH Find(string nom)
        {
            BaseDAO<CollabRH> collabRHdao = new CollabRHDAO();
            return collabRHdao.Find(nom);
        }
        public List<CollabRH> Find(Func<CollabRH, bool> criteria)
        {
            BaseDAO<CollabRH> collabRHdao = new CollabRHDAO();
            return collabRHdao.Find(criteria);
        }
        public new List<CollabRH> FindAl()
        {
            BaseDAO<CollabRH> collabRHdao = new CollabRHDAO();

            return collabRHdao.FindAll();
        }
        public bool Update(CollabRH element)
        {
            BaseDAO<CollabRH> collabRHdao = new CollabRHDAO();
            return collabRHdao.Update(element);
        }
        public List<MissionCollab> HitoriquesMission(CollabRH c)
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
