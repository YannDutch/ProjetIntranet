using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.DAO
{
    class MissionDAO : BaseDAO<Mission>
    {
        public override bool Ajouter(Mission element)
        {
            connection = Connection.New;
            request = "INSERT into missions ( nomMission, dateCreation, descriptions, dateDebut,dateFin,etat,idServicePersonne) " +
                "OUTPUT INSERTED.ID values( @nomMission, @dateCreation, @descriptions,@dateDebut,@dateFin,@etat,@idServicePersonne)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@dateCreation", element.DateCreation));
            command.Parameters.Add(new SqlParameter("@descriptions", element.Descriptions));
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@etat", element.Etat));
            command.Parameters.Add(new SqlParameter("@idServicePersonne", element.IdService));
            connection.Open();
            element.IdMission = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.IdMission > 0;
        }

        public override bool Delete(Mission element)
        {
            request = "DELETE FROM missions WHERE idMission=@idMission";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idMission", element.IdMission));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override Mission Find(string nomMission)
        {
            Mission mission = null;
            request = "SELECT nomMission, dateCreation, descriptions,dateDebut, dateFin,etat,idServicePersonne FROM missions WHERE idMission=@idMission";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", nomMission));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                mission = new Mission()
                {
                    NomMission = nomMission,
                    DateCreation = (DateTime)reader.GetSqlDateTime(1),
                    Descriptions = reader.GetString(2),
                    DateDebut = (DateTime)reader.GetSqlDateTime(3),
                    DateFin = (DateTime)reader.GetSqlDateTime(4),
                    Etat= reader.GetBoolean(5),
                    IdService = (int)reader.GetSqlInt64(6),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return mission;
        }

        public override List<Mission> Find(Func<Mission, bool> criteria)
        {
            List<Mission> missions = new List<Mission>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    missions.Add(c);
                }
            });
            return missions;
        }

        public override List<Mission> FindAll()
        {
            List<Mission> missions = new List<Mission>();
            request = "SELECT idMission, nomMission, dateCreation, descriptions,dateDebut, dateFin,etat,idServicePersonne FROM missions";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Mission c = new Mission()
                {
                    IdMission = reader.GetInt32(0),
                    NomMission = reader.GetString(1),
                    DateCreation = (DateTime)reader.GetSqlDateTime(2),
                    Descriptions = reader.GetString(3),
                    DateDebut = (DateTime)reader.GetSqlDateTime(4),
                    DateFin = (DateTime)reader.GetSqlDateTime(5),
                    Etat =reader.GetBoolean(6),
                    IdService = reader.GetInt32(7),
                };
                missions.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return missions;
        }

        public override string ToString(Mission element)
        {
            return $"{{()}}";  
        }

        public override bool Update(Mission element)
        {
            request = "UPDATE missions SET nomMission = @nomMission, dateCreation = @dateCreation, descriptions = @descriptions," +
                " dateDebut = @dateDebut ,dateFin=@dateFin,etat=@Etat , idServicePersonne=@idServicePersonne WHERE idMission = @idMission,";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@dateCreation", element.DateCreation));
            command.Parameters.Add(new SqlParameter("@descriptions", element.Descriptions));
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@etat", element.Etat));
            command.Parameters.Add(new SqlParameter("@idServicePersonne", element.IdService));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}