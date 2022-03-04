using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class DemandeConge
    {
        private int idDemandeConges;
        private DateTime dateConges;
        private DateTime dateDemande;
        private string nomDemande;
        private bool etat;
        private int matriculeCollab;
        

        public DemandeConge()
        {
            IdDemandeConges++;
        }

        public DemandeConge(DateTime dateConges, DateTime dateDemande
            , bool etat, int matriculeCollab, string nomDemande): this()
        {
            DateConges = dateConges;
            DateDemande = dateDemande;
            Etat = etat;
            MatriculeCollab = matriculeCollab;
            NomDemande = nomDemande;
        }
        public DateTime DateConges { get => dateConges; set => dateConges = value; }
        public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
        public bool Etat { get => etat; set => etat = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string NomDemande { get => nomDemande; set => nomDemande = value; }
        public int IdDemandeConges { get => idDemandeConges; set => idDemandeConges = value; }

        public  bool Save()
        {
            BaseDAO<DemandeConge> dao = new DemandeCongeDAO();
            return dao.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<DemandeConge> dc =new DemandeCongeDAO();
            return dc.Delete(this);
        }
        public DemandeConge Find(string nom)
        {
            BaseDAO<DemandeConge> dc=new DemandeCongeDAO();
            return dc.Find(nom);
        }
        public List<DemandeConge> Find(Func<DemandeConge, bool> criteria)
        {
            BaseDAO<DemandeConge> dc= new DemandeCongeDAO();
            return dc.Find(criteria);
        }
        public List<DemandeConge> FindAl()
        {
            BaseDAO<DemandeConge> dc = new DemandeCongeDAO();

            return dc.FindAll();
        }
        public bool Update(DemandeConge element)
        {
            BaseDAO<DemandeConge> dc = new DemandeCongeDAO();
            return dc.Update(element);
        }

    }
}
