using System;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class DemandeAvance 
    {
        private bool validN1;
        private bool validN2;
        private DateTime dateDemande;
        private string notifications;
        private int matriculeCollab;
        private bool etat;
        private string nomMission;
        private string lienNoteFrais;

        public DemandeAvance()
        {

        }

        public DemandeAvance( DateTime dateDemande, string notifications,
            int matriculeCollab, string nomMission, string lienNoteFrais, bool etat)
        {
            DateDemande = dateDemande;
            Notifications = notifications;
            MatriculeCollab = matriculeCollab;
            NomMission = nomMission;
            LienNoteFrais = lienNoteFrais;
            Etat = etat;
        }

        public bool ValidN1 { get => validN1; set => validN1 = value; }
        public bool ValidN2 { get => validN2; set => validN2 = value; }
        public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
        public string Notifications { get => notifications; set => notifications = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string NomMission { get => nomMission; set => nomMission = value; }
        public string LienNoteFrais { get => lienNoteFrais; set => lienNoteFrais = value; }
        public bool Etat { get => etat; set => etat = value; }

        public new bool Save()
        {
            BaseDAO<DemandeAvance> dao = new DemandeAvanceDAO();
            return dao.Ajouter(this);
        }
    }
}
