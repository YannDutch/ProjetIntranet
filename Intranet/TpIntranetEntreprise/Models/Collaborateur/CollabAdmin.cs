using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class CollabAdmin :Collaborateur
    {
        

        

        public CollabAdmin() : base()
        {
            
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
    }
}
