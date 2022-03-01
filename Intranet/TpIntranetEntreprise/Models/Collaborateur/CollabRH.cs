using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;


namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class CollabRH : Collaborateur
    {
        private string nomTypeCollab;

        public CollabRH()
        {

        }

        public CollabRH(string nomTypeCollab) : base()
        {
            NomTypeCollab = nomTypeCollab;
        }

        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public new bool Save()
        {
            BaseDAO<CollabRH> dao = new CollabRHDAO();
            return dao.Ajouter(this);
        }

    }
}
