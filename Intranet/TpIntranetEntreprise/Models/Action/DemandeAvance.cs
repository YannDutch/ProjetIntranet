using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class DemandeAvance 
    {
        private int idDemandeAvance;
        private DateTime dateDemande;
        private int matriculeCollab;
        private bool etat;
        private string nomDemande;
        private string lienNoteFrais;

        public DemandeAvance()
        {
            IdDemandeAvance++;
        }

        public DemandeAvance( DateTime dateDemande, string titreNotifications,
            int matriculeCollab, string nomDemande, string lienNoteFrais, bool etat) : this()
        {
            DateDemande = dateDemande;
            MatriculeCollab = matriculeCollab;
            NomDemande = nomDemande;
            LienNoteFrais = lienNoteFrais;
            Etat = etat;
        }

        public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string NomDemande { get => nomDemande; set => nomDemande = value; }
        public string LienNoteFrais { get => lienNoteFrais; set => lienNoteFrais = value; }
        public bool Etat { get => etat; set => etat = value; }
        public int IdDemandeAvance { get => idDemandeAvance; set => idDemandeAvance = value; }

        public bool Save()
        {
            BaseDAO<DemandeAvance> DemandeAvancedao = new DemandeAvanceDAO();
            return DemandeAvancedao.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<DemandeAvance> DemandeAvancedao = new DemandeAvanceDAO();
            return DemandeAvancedao.Delete(this);
        }
        public DemandeAvance Find(string nom)
        {
            BaseDAO<DemandeAvance> DemandeAvancedao = new DemandeAvanceDAO();
            return DemandeAvancedao.Find(nom);
        }
        public List<DemandeAvance> Find(Func<DemandeAvance, bool> criteria)
        {
            BaseDAO<DemandeAvance> DemandeAvancedao = new DemandeAvanceDAO();
            return DemandeAvancedao.Find(criteria);
        }
        public List<DemandeAvance> FindAl()
        {
            BaseDAO<DemandeAvance> DemandeAvancedao = new DemandeAvanceDAO();

            return DemandeAvancedao.FindAll();
        }
        public bool Update(DemandeAvance element)
        {
            BaseDAO<DemandeAvance> DemandeAvancedao = new DemandeAvanceDAO();
            return DemandeAvancedao.Update(element);
        }
    }
}
