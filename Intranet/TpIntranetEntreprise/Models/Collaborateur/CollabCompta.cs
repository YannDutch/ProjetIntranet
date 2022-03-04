using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class CollabCompta :Collaborateur
    {
        private bool validN1;

        public CollabCompta():base()
        {

        }

        public CollabCompta(bool validN1):base()
        {
            ValidN1 = validN1;
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

    }
}