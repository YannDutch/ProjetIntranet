using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Collaborateur;

namespace TpIntranetEntreprise.DAO
{
    class MissionDAO : BaseDAO<Mission>
    {
        public override bool Ajouter(Mission element)
        {
            if (element.IsActive == true)
            {
                connection = Connection.New;
                request = "INSERT into missions (idMission, nomMission, dateCreation, descriptions, dateDebut,dateFin,idService) " +
                    "OUTPUT INSERTED.ID values(@idMission, @nomMission, @dateCreation, @descriptions,@dateDebut,@dateFin,@idService)";
                command = new SqlCommand(request, connection);
                command.Parameters.Add(new SqlParameter("@idMission", element.IdMission));
                command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
                command.Parameters.Add(new SqlParameter("@dateCreation", element.DateCreation));
                command.Parameters.Add(new SqlParameter("@descriptions", element.Descriptions));
                command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
                command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
                command.Parameters.Add(new SqlParameter("@idService", element.IdService));
                connection.Open();
                element.IdMission = (int)command.ExecuteScalar();
                command.Dispose();
                connection.Close();
                return element.IdMission > 0;
            }
            else
                return false;
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
            request = "SELECT nomMission, dateCreation, descriptions,dateDebut, dateFin,idService FROM missions WHERE idMission=@idMission";
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
                    IdService = (int)reader.GetSqlInt64(5),
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
            request = "SELECT idMission, nomMission, dateCreation, descriptions,dateDebut, dateFin,idService FROM missions";
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
                    IdService = reader.GetInt32(6),
                };
                missions.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return missions;
        }

        public override bool Update(Mission element)
        {
            request = "UPDATE missions SET nomMission = @nomMission, dateCreation = @dateCreation, descriptions = @descriptions, dateDebut = @dateDebut ,dateFin=@dateFin , idService=@idService WHERE idMission = @idMission,";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@dateCreation", element.DateCreation));
            command.Parameters.Add(new SqlParameter("@descriptions", element.Descriptions));
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@idService", element.IdService));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}