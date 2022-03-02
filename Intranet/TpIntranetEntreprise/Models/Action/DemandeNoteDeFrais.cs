using System;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class DemandeNoteDeFrais
    {
        private int idNoteFrais=-1;
        private string nomNoteFrais;
        private DateTime dateSaisie;
        private DateTime dateEnvoie;
        private bool validN1;
        private bool validN2;
        private decimal sommeTotal;
        private decimal sommeAvance;
        private decimal sommeDue;
        private string notifications;
        private bool saisieTermine;
        private int matriculeCollab;
        private int idMission;


        public DemandeNoteDeFrais()
        {
            IdNoteFrais++;
        }

        public DemandeNoteDeFrais( string nomNoteFrais, DateTime dateSaisie, DateTime dateEnvoie
            , decimal sommeTotal, decimal sommeAvance, decimal sommeDue, string notifications, bool saisieTermine, int matriculeCollab, int idMission) :this()
        {
            NomNoteFrais = nomNoteFrais;
            DateSaisie = dateSaisie;
            DateEnvoie = dateEnvoie;
            SommeTotal = sommeTotal;
            SommeAvance = sommeAvance;
            SommeDue = sommeDue;
            Notifications = notifications;
            SaisieTermine = saisieTermine;
            MatriculeCollab = matriculeCollab;
            IdMission = idMission;
        }

        public int IdNoteFrais { get => idNoteFrais; set => idNoteFrais = value; }
        public string NomNoteFrais { get => nomNoteFrais; set => nomNoteFrais = value; }
        public DateTime DateSaisie { get => dateSaisie; set => dateSaisie = value; }
        public DateTime DateEnvoie { get => dateEnvoie; set => dateEnvoie = value; }
        public bool ValidN1 { get => validN1; set => validN1 = value; }
        public bool ValidN2 { get => validN2; set => validN2 = value; }
        public decimal SommeTotal { get => sommeTotal; set => sommeTotal = value; }
        public decimal SommeAvance { get => sommeAvance; set => sommeAvance = value; }
        public decimal SommeDue { get => sommeDue; set => sommeDue = value; }
        public string Notifications { get => notifications; set => notifications = value; }
        public bool SaisieTermine { get => saisieTermine; set => saisieTermine = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public int IdMission { get => idMission; set => idMission = value; }
    }
}
