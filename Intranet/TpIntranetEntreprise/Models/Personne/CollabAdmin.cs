using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Personne
{
    public class CollabAdmin :Collaborateur
    {
        
        public CollabAdmin()
        {

        }
        

        public CollabAdmin(int matriculeCollab,string nom, string prenom, DateTime dateNaissance, string MDP, string nomTypeCollab, string nomTypeService) : base()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            MDP1 = MDP;
            NomTypeCollab = nomTypeCollab;
            NomServicePersonne = nomTypeService;
            MatriculeCollab = matriculeCollab;
        }


        public new bool Save()
        {
            BaseDAO<CollabAdmin> CollabAdmindao = new CollabAdminDAO();
            return CollabAdmindao.Ajouter(this);
        }
        public new bool Delete()
        {
            BaseDAO<CollabAdmin> CollabAdmindao = new CollabAdminDAO();
            return CollabAdmindao.Delete(this);
        }
        public new CollabAdmin Find(string nom)
        {
            BaseDAO<CollabAdmin> CollabAdmindao = new CollabAdminDAO();
            return CollabAdmindao.Find(nom);
        }
        public List<CollabAdmin> Find(Func<CollabAdmin, bool> criteria)
        {
            BaseDAO<CollabAdmin> CollabAdmindao = new CollabAdminDAO();
            return CollabAdmindao.Find(criteria);
        }
        public new List<CollabAdmin> FindAl()
        {
            BaseDAO<CollabAdmin> CollabAdmindao = new CollabAdminDAO();

            return CollabAdmindao.FindAll();
        }
        public bool Update(CollabAdmin element)
        {
            BaseDAO<CollabAdmin> CollabAdmindao = new CollabAdminDAO();
            return CollabAdmindao.Update(element);
        }
        public List<MissionCollab> HitoriquesMission(CollabAdmin c)
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
