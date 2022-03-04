using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class DemandeNoteDeFrais
    {
        private int idNoteFrais=-1;
        private string nomNoteFrais;
        private DateTime dateSaisie;
        private DateTime dateEnvoie;
        private decimal sommeTotal;
        private decimal sommeAvance;
        private decimal sommeDue;
        private bool saisieTermine;
        private int matriculeCollab;
        private int idMission;


        public DemandeNoteDeFrais()
        {
            IdNoteFrais++;
        }

        public DemandeNoteDeFrais( string nomNoteFrais, DateTime dateSaisie, DateTime dateEnvoie
            , decimal sommeTotal, decimal sommeAvance, decimal sommeDue, bool saisieTermine, int matriculeCollab, int idMission) :this()
        {
            NomNoteFrais = nomNoteFrais;
            DateSaisie = dateSaisie;
            DateEnvoie = dateEnvoie;
            SommeTotal = sommeTotal;
            SommeAvance = sommeAvance;
            SommeDue = sommeDue;
            SaisieTermine = saisieTermine;
            MatriculeCollab = matriculeCollab;
            IdMission = idMission;
        }

        public int IdNoteFrais { get => idNoteFrais; set => idNoteFrais = value; }
        public string NomNoteFrais { get => nomNoteFrais; set => nomNoteFrais = value; }
        public DateTime DateSaisie { get => dateSaisie; set => dateSaisie = value; }
        public DateTime DateEnvoie { get => dateEnvoie; set => dateEnvoie = value; }
        public decimal SommeTotal { get => sommeTotal; set => sommeTotal = value; }
        public decimal SommeAvance { get => sommeAvance; set => sommeAvance = value; }
        public decimal SommeDue { get => sommeDue; set => sommeDue = value; }
        public bool SaisieTermine { get => saisieTermine; set => saisieTermine = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public int IdMission { get => idMission; set => idMission = value; }
        public bool Save()
        {
            BaseDAO<DemandeNoteDeFrais> DemandeNoteDeFraisdao = new DemandeNoteDeFraisDAO();
            return DemandeNoteDeFraisdao.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<DemandeNoteDeFrais> DemandeNoteDeFraisdao = new DemandeNoteDeFraisDAO();
            return DemandeNoteDeFraisdao.Delete(this);
        }
        public DemandeNoteDeFrais Find(string nom)
        {
            BaseDAO<DemandeNoteDeFrais> DemandeNoteDeFraisdao = new DemandeNoteDeFraisDAO();
            return DemandeNoteDeFraisdao.Find(nom);
        }
        public List<DemandeNoteDeFrais> Find(Func<DemandeNoteDeFrais, bool> criteria)
        {
            BaseDAO<DemandeNoteDeFrais> DemandeNoteDeFraisdao = new DemandeNoteDeFraisDAO();
            return DemandeNoteDeFraisdao.Find(criteria);
        }
        public List<DemandeNoteDeFrais> FindAl()
        {
            BaseDAO<DemandeNoteDeFrais> DemandeNoteDeFraisdao = new DemandeNoteDeFraisDAO();

            return DemandeNoteDeFraisdao.FindAll();
        }
        public bool Update(DemandeNoteDeFrais element)
        {
            BaseDAO<DemandeNoteDeFrais> DemandeNoteDeFraisdao = new DemandeNoteDeFraisDAO();
            return DemandeNoteDeFraisdao.Update(element);
        }
    }
}
