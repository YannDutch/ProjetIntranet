using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Service
{
    public class Service
    {
        private int matriculeCollab;
        private DateTime dateDebut;
        private DateTime dateFin;
        private string nomService;
        private int idService;


        public Service()
        {
            idService++;
        }

        public Service(int matriculeCollab, DateTime dateDebut, DateTime dateFin
            , string nomService) : this()
        {
            MatriculeCollab = matriculeCollab;
            DateDebut = dateDebut;
            DateFin = dateFin;
            NomService = nomService;
        }

        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime DateFin { get => dateFin; set => dateFin = value; }
        public string NomService { get => nomService; set => nomService = value; }
        public int IdService { get => idService; set => idService = value; }
        public bool Save()
        {
            BaseDAO<Service> Servicedao = new ServiceDAO();
            return Servicedao.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<Service> Servicedao = new ServiceDAO();
            return Servicedao.Delete(this);
        }
        public Service Find(string nom)
        {
            BaseDAO<Service> Servicedao = new ServiceDAO();
            return Servicedao.Find(nom);
        }
        public List<Service> Find(Func<Service, bool> criteria)
        {
            BaseDAO<Service> Servicedao = new ServiceDAO();
            return Servicedao.Find(criteria);
        }
        public List<Service> FindAl()
        {
            BaseDAO<Service> Servicedao = new ServiceDAO();

            return Servicedao.FindAll();
        }
        public bool Update(Service element)
        {
            BaseDAO<Service> Servicedao = new ServiceDAO();
            return Servicedao.Update(element);
        }
    }
}
