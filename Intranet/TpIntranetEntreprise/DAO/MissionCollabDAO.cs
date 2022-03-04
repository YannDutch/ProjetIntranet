using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Action
{
    class MissionCollabDAO : BaseDAO<MissionCollab>
    {
        public override bool Ajouter(MissionCollab element)
        {
            connection = Connection.New;
            request = "INSERT into missionsCollab ( nomMission, dateDebut,dateFin,nbDemiesJournees, matriculeCollab ) " +
                "OUTPUT INSERTED.ID values( @nomMission, @dateDebut,@dateFin,@nbDemiesJournees,@matriculeCollab)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@nbDemiesJournees", element.NbDemiesJournees));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            element.IdMission = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.IdMission > 0;
        }

        public override bool Delete(MissionCollab element)
        {
            request = "DELETE FROM missionsCollab WHERE idMission=@idMission";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idMission", element.IdMission));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override MissionCollab Find(string nom)
        {
            MissionCollab mc = null;
            request = "SELECT  nomMission, dateDebut,dateFin,nbDemiesJournees, matriculeCollab  " +
                "FROM missionsCollab WHERE idMission=@idMission";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                mc = new MissionCollab()
                {
                    NomMission = nom,
                    DateDebut = (DateTime)reader.GetSqlDateTime(1),
                    DateFin = (DateTime)reader.GetSqlDateTime(2),
                    NbDemiesJournees = reader.GetInt32(3),
                    MatriculeCollab = reader.GetInt32(4),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return mc;
        }

        public override List<MissionCollab> Find(Func<MissionCollab, bool> criteria)
        {
            List<MissionCollab> mc = new List<MissionCollab>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    mc.Add(c);
                }
            });
            return mc;
        }

        public override List<MissionCollab> FindAll()
        {
            List<MissionCollab> missioncollabs = new List<MissionCollab>();
            request = "SELECT idMission,nomMission, dateDebut,dateFin,nbDemiesJournees, matriculeCollab FROM missionsCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                MissionCollab mc = new MissionCollab()
                {
                    IdMission = reader.GetInt32(0),
                    NomMission = reader.GetString(1),
                    DateDebut = (DateTime)reader.GetSqlDateTime(2),
                    DateFin = (DateTime)reader.GetSqlDateTime(3),
                    NbDemiesJournees = reader.GetInt32(4),
                    MatriculeCollab = reader.GetInt32(5),
                };
                missioncollabs.Add(mc);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return missioncollabs;
        }

        public override string ToString(MissionCollab element)
        {
            throw new NotImplementedException();
        }

        public override bool Update(MissionCollab element)
        {
            request = "UPDATE missionsCollab SET nomMission = @nomMission,dateDebut = @dateDebut ,dateFin=@dateFin ," +
                " nbDemiesJournees = @nbDemiesJournees, matriucleCollab=@matriucleCollab WHERE idMission = @idMission,";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomMission", element.NomMission));
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@nbDemiesJournees", element.NbDemiesJournees));
            command.Parameters.Add(new SqlParameter("@matriucleCollab", element.MatriculeCollab));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
