using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class CollabCompta :Collaborateur
    {
        private string nomTypeCollab;

        public CollabCompta()
        {

        }

        public CollabCompta(string nomTypeCollab):base()
        {
            NomTypeCollab = nomTypeCollab;
        }

        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public new bool Save()
        {
            BaseDAO<CollabCompta> dao = new CollabComptaDAO();
            return dao.Ajouter(this);
        }

    }
}