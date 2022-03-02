using System;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class DemandeConge
    {
        private bool validN1;
        private bool validN2;
        private DateTime dateConges;
        private DateTime dateDemande;
        private string notifications;
        private string nomDemandeur;
        private bool etat;
        private int matriculeCollab;

        public DemandeConge()
        {

        }

        public DemandeConge(DateTime dateConges, DateTime dateDemande
            , string notifications, bool etat, int matriculeCollab, string nomDemandeur)
        {
            DateConges = dateConges;
            DateDemande = dateDemande;
            Notifications = notifications;
            Etat = etat;
            MatriculeCollab = matriculeCollab;
            NomDemandeur = nomDemandeur;
        }

        public bool ValidN1 { get => validN1; set => validN1 = value; }
        public bool ValidN2 { get => validN2; set => validN2 = value; }
        public DateTime DateConges { get => dateConges; set => dateConges = value; }
        public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
        public string Notifications { get => notifications; set => notifications = value; }
        public bool Etat { get => etat; set => etat = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public string NomDemandeur { get => nomDemandeur; set => nomDemandeur = value; }
    }
}
