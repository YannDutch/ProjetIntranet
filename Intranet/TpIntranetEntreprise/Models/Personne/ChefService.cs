using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Personne
{
    public class ChefService : Collaborateur
    {
        private bool validN2;
        public ChefService()
        {

        }

        public ChefService(int matriculeCollab,string nom, string prenom, DateTime dateNaissance, string MDP, string nomTypeCollab, string nomTypeService) : base()
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            MDP1 = MDP;
            NomTypeCollab = nomTypeCollab;
            NomServicePersonne = nomTypeService;
            MatriculeCollab= matriculeCollab;
        }

        public bool ValidN2 { get => validN2; set => validN2 = value; }

        public new bool Save()
        {
            BaseDAO<ChefService> ChefServicedao = new ChefServiceDAO();
            return ChefServicedao.Ajouter(this);
        }
        public new bool Delete()
        {
            BaseDAO<ChefService> ChefServicedao = new ChefServiceDAO();
            return ChefServicedao.Delete(this);
        }
        public new ChefService Find(string nom)
        {
            BaseDAO<ChefService> ChefServicedao = new ChefServiceDAO();
            return ChefServicedao.Find(nom);
        }
        public List<ChefService> Find(Func<ChefService, bool> criteria)
        {
            BaseDAO<ChefService> ChefServicedao = new ChefServiceDAO();
            return ChefServicedao.Find(criteria);
        }
        public new List<ChefService> FindAl()
        {
            BaseDAO<ChefService> ChefServicedao = new ChefServiceDAO();

            return ChefServicedao.FindAll();
        }
        public bool Update(ChefService element)
        {
            BaseDAO<ChefService> ChefServicedao = new ChefServiceDAO();
            return ChefServicedao.Update(element);
        }
        public List<MissionCollab> HitoriquesMission(ChefService c)
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
