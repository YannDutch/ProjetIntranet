using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;


namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class CollabRH : Collaborateur
    {
        private bool validN1;



        public CollabRH()
        {

        }

        public CollabRH(bool validN1) : base()
        {
            ValidN1 = validN1;
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
    }
}
