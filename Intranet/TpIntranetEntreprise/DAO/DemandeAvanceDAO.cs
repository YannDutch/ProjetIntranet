using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Action
{
    class DemandeAvanceDAO : BaseDAO<DemandeAvance>
    {
        public override bool Ajouter(DemandeAvance element)
        {
            connection = Connection.New;
            request = "INSERT into demandeAvance ( dateDemande, notifications,nomMission,etat, lienNoteFrais) " +
                "OUTPUT INSERTED.ID values( @dateDemande, @notifications,@nomMission, @etat,@lienNoteFrais)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@dateDemande", element.DateDemande));
            command.Parameters.Add(new SqlParameter("@notifications", element.Notifications));
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@etat", element.Etat));
            command.Parameters.Add(new SqlParameter("@lienNoteFrais", element.LienNoteFrais));
            connection.Open();
            element.MatriculeCollab = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.MatriculeCollab > 0;
        }

        public override bool Delete(DemandeAvance element)
        {
            request = "DELETE FROM demandeAvance WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override DemandeAvance Find(string nom)
        {
            DemandeAvance da  = null;
            request = "SELECT nomMission,dateDemande, notifications,lienNoteFrais,etat " +
                "FROM demandeAvance WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                da = new DemandeAvance()
                {
                    NomMission = nom,
                    DateDemande = (DateTime)reader.GetSqlDateTime(1),
                    Notifications = reader.GetString(2),
                    LienNoteFrais = reader.GetString(3),
                    Etat = reader.GetBoolean(4),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return da;
        }

        public override List<DemandeAvance> Find(Func<DemandeAvance, bool> criteria)
        {
            List<DemandeAvance> Davances = new List<DemandeAvance>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    Davances.Add(c);
                }
            });
            return Davances;
        }        

        public override List<DemandeAvance> FindAll()
        {
            List<DemandeAvance> Davances = new List<DemandeAvance>();
            request = "SELECT matriculeCollab, nomMission,notifications,dateDemande, etat, lienNoteFrais" +
                " FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DemandeAvance da = new DemandeAvance()
                {
                    MatriculeCollab = reader.GetInt32(0),
                    NomMission = reader.GetString(1),
                    Notifications = reader.GetString(2),
                    DateDemande = (DateTime)reader.GetSqlDateTime(3),
                    Etat = reader.GetBoolean(4),
                    LienNoteFrais = reader.GetString(5),
                };
                Davances.Add(da);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return Davances;
        }

        public override bool Update(DemandeAvance element)
        {
            request = "UPDATE demandeAvance SET nomMission = @nomMission, dateDemande = @dateDemande, " +
                "notifications = @notifications,etat=@etat,lienNoteFrais=@lienNoteFrais WHERE matriculeCollab = @matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@dateDemande", element.DateDemande));
            command.Parameters.Add(new SqlParameter("@notifications", element.Notifications));
            command.Parameters.Add(new SqlParameter("@etat", element.Etat));
            command.Parameters.Add(new SqlParameter("@lienNoteFrais", element.LienNoteFrais));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}

