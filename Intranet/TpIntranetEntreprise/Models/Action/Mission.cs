using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.Models.Action
{
    public class Mission
    {
        private int idMission;
        private string nomMission;
        private DateTime dateCreation;
        private string descriptions;
        private DateTime dateDebut;
        private DateTime? dateFin;
        private bool etat;
        private int idService;

        public Mission()
        {
            IdMission++;
        }

        public Mission(string nomMission, DateTime dateCreation, string descriptions,
            DateTime dateDebut, DateTime? dateFin, bool etat, int idService):this()
        {
            NomMission = nomMission;
            DateCreation = dateCreation;
            Descriptions = descriptions;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Etat = etat;
            IdService = idService;
        }
        

        public int IdMission { get => idMission; set => idMission = value; }
        public string NomMission { get => nomMission; set => nomMission = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string Descriptions { get => descriptions; set => descriptions = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime? DateFin { get => dateFin; set => dateFin = value; }
        public bool Etat { get => etat; set => etat = value; }
        public int IdService { get => idService; set => idService = value; }
        public bool Save()
        {
            BaseDAO<Mission> missiondao = new MissionDAO();
            return missiondao.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<Mission> missiondao = new MissionDAO();
            return missiondao.Delete(this);
        }
        public Mission Find(string nom)
        {
            BaseDAO<Mission> missiondao = new MissionDAO();
            return missiondao.Find(nom);
        }
        public List<Mission> Find(Func<Mission, bool> criteria)
        {
            BaseDAO<Mission> missiondao = new MissionDAO();
            return missiondao.Find(criteria);
        }
        public List<Mission> FindAl()
        {
            BaseDAO<Mission> missiondao = new MissionDAO();

            return missiondao.FindAll();
        }
        public bool Update(Mission element)
        {
            BaseDAO<Mission> missiondao = new MissionDAO();
            return missiondao.Update(element);
        }
    }
}