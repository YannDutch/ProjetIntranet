using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Personne
{
    public class CollabCompta : Collaborateur
    {
        private bool validN1;

        public CollabCompta()
        {
            
        }

        public CollabCompta(int matriculeCollab,string nom, string prenom, DateTime dateNaissance, string MDP, string nomTypeCollab, string nomTypeService) : base()
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
            BaseDAO<CollabCompta> CollabComptadao = new CollabComptaDAO();
            return CollabComptadao.Ajouter(this);
        }
        public new bool Delete()
        {
            BaseDAO<CollabCompta> CollabComptadao = new CollabComptaDAO();
            return CollabComptadao.Delete(this);
        }
        public new CollabCompta Find(string nom)
        {
            BaseDAO<CollabCompta> CollabComptadao = new CollabComptaDAO();
            return CollabComptadao.Find(nom);
        }
        public List<CollabCompta> Find(Func<CollabCompta, bool> criteria)
        {
            BaseDAO<CollabCompta> CollabComptadao = new CollabComptaDAO();
            return CollabComptadao.Find(criteria);
        }
        public new List<CollabCompta> FindAl()
        {
            BaseDAO<CollabCompta> CollabComptadao = new CollabComptaDAO();

            return CollabComptadao.FindAll();
        }
        public bool Update(CollabCompta element)
        {
            BaseDAO<CollabCompta> CollabComptadao = new CollabComptaDAO();
            return CollabComptadao.Update(element);
        }
        public List<MissionCollab> HitoriquesMission(CollabCompta c)
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