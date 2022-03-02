using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    class DemandeCongeDAO : BaseDAO<DemandeConge>
    {
        public override bool Ajouter(DemandeConge element)
        {
            connection = Connection.New;
            request = "INSERT into demandeConges( dateConges, dateDemande,nom,etat, notifications) " +
                "OUTPUT INSERTED.ID values( @dateConges, @dateDemande,@nom, @etat,@notifications)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@dateDemande", element.DateDemande));
            command.Parameters.Add(new SqlParameter("@notifications", element.Notifications));
            command.Parameters.Add(new SqlParameter("@nom", element.NomDemandeur));
            command.Parameters.Add(new SqlParameter("@etat", element.Etat));
            command.Parameters.Add(new SqlParameter("@dateConges", element.DateConges));
            connection.Open();
            element.MatriculeCollab = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.MatriculeCollab > 0;
        }

        public override bool Delete(DemandeConge element)
        {
            request = "DELETE FROM demandeConges WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override DemandeConge Find(string nom)
        {
            DemandeConge dc = null;
            request = "SELECT nom,dateConges,dateDemande, notifications,etat " +
                "FROM demandeConges WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                dc = new DemandeConge()
                {
                    NomDemandeur = nom,
                    DateDemande = (DateTime)reader.GetSqlDateTime(2),
                    DateConges = (DateTime)reader.GetSqlDateTime(1),
                    Notifications = reader.GetString(3),
                    Etat = reader.GetBoolean(4),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return dc;
        }

        public override List<DemandeConge> Find(Func<DemandeConge, bool> criteria)
        {
            List<DemandeConge> Dconges = new List<DemandeConge>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    Dconges.Add(c);
                }
            });
            return Dconges;
        }

        public override List<DemandeConge> FindAll()
        {
            List<DemandeConge> Dconges = new List<DemandeConge>();
            request = "SELECT matriculeCollab, nom,notifications,dateConges,dateDemande, etat" +
                " FROM demandeConges";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DemandeConge dc = new DemandeConge()
                {
                    MatriculeCollab = reader.GetInt32(0),
                    NomDemandeur = reader.GetString(1),
                    Notifications = reader.GetString(2),
                    DateConges= (DateTime)reader.GetSqlDateTime(3),
                    DateDemande = (DateTime)reader.GetSqlDateTime(4),
                    Etat = reader.GetBoolean(5),
                };
                Dconges.Add(dc);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return Dconges;
        }

        public override bool Update(DemandeConge element)
        {
            request = "UPDATE demandeConges SET nom = @nom,dateConges=@dateConges, dateDemande = @dateDemande, " +
                            "notifications = @notifications,etat=@etat WHERE matriculeCollab = @matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.NomDemandeur));
            command.Parameters.Add(new SqlParameter("@dateConges", element.DateConges));
            command.Parameters.Add(new SqlParameter("@dateDemande", element.DateDemande));
            command.Parameters.Add(new SqlParameter("@notifications", element.Notifications));
            command.Parameters.Add(new SqlParameter("@etat", element.Etat));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}