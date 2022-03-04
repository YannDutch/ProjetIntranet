using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class ChefService : Collaborateur
    {
        private bool validN2;
        public ChefService()
        {

        }

        public ChefService(bool validN2) : base()
        {
            ValidN2 = validN2;
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
    }
}
