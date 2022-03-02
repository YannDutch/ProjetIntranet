using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class Mission
    {
        private int idMission;
        private string nomMission;
        private DateTime dateCreation;
        private string descriptions;
        private DateTime dateDebut;
        private DateTime? dateFin;
        private bool isActive;
        private int idService;

        public Mission()
        {
            IdMission++;
        }

        public Mission(string nomMission, DateTime dateCreation, string descriptions, DateTime dateDebut, DateTime? dateFin, bool isActive, int idService):this()
        {
            NomMission = nomMission;
            DateCreation = dateCreation;
            Descriptions = descriptions;
            DateDebut = dateDebut;
            DateFin = dateFin;
            IsActive = isActive;
            IdService = idService;
        }
        public bool Save()
        {
            BaseDAO<Mission> dao = new MissionDAO();
            return dao.Ajouter(this);
        }

        public int IdMission { get => idMission; set => idMission = value; }
        public string NomMission { get => nomMission; set => nomMission = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string Descriptions { get => descriptions; set => descriptions = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime? DateFin { get => dateFin; set => dateFin = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int IdService { get => idService; set => idService = value; }
    }
}