using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class MissionCollab
    {
        private int idMission;
        private string nomMission;
        private DateTime dateDebut;
        private DateTime dateFin;
        private int nbDemiesJournees;
        private int matriculeCollab;
        

        public MissionCollab()
        {

        }

        public MissionCollab(DateTime dateDebut, DateTime dateFin, int nbDemiesJournees, int matriculeCollab, int idMission, string nomMission) : this()
        {
            DateDebut = dateDebut;
            DateFin = dateFin;
            NbDemiesJournees = nbDemiesJournees;
            MatriculeCollab = matriculeCollab;
            IdMission = idMission;
            NomMission = nomMission;
        }

        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime DateFin { get => dateFin; set => dateFin = value; }
        public int NbDemiesJournees { get => nbDemiesJournees; set => nbDemiesJournees = value; }
        public int MatriculeCollab { get => matriculeCollab; set => matriculeCollab = value; }
        public int IdMission { get => idMission; set => idMission = value; }
        public string NomMission { get => nomMission; set => nomMission = value; }
        public bool Save()
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();
            return MCDAO.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();
            return MCDAO.Delete(this);
        }
        public MissionCollab Find(string nom)
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();
            return MCDAO.Find(nom);
        }
        public List<MissionCollab> Find(Func<MissionCollab, bool> criteria)
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();
            return MCDAO.Find(criteria);
        }
        public List<MissionCollab> FindAl()
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();

            return MCDAO.FindAll();
        }
        public bool Update(MissionCollab element)
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();
            return MCDAO.Update(element);
        }
        public string ToString(MissionCollab element)
        {
            BaseDAO<MissionCollab> MCDAO = new MissionCollabDAO();
            return MCDAO.ToString(element);
        }
    }
}
