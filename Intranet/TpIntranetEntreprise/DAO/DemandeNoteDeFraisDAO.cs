using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    class DemandeNoteDeFraisDAO : BaseDAO<DemandeNoteDeFrais>
    {
        public override bool Ajouter(DemandeNoteDeFrais element)
        {
            connection = Connection.New;
            request = "INSERT into notesFrais( nomNoteFrais, dateSaisie,dateEnvoie,sommmeTotal,sommeAvance,sommeDue,notifications,saisieTermine,matriculeCollab,idMission) " +
                "OUTPUT INSERTED.ID values( @nomNoteFrais, @dateSaisie,@dateEnvoie, @sommmeTotal,@sommeAvance,@sommeDue,@notifications,@saisieTermine,@matriculeCollab,@idMission)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomNoteFrais", element.NomNoteFrais));
            command.Parameters.Add(new SqlParameter("@dateSaisie", element.DateSaisie));
            command.Parameters.Add(new SqlParameter("@dateEnvoie", element.DateEnvoie));
            command.Parameters.Add(new SqlParameter("@sommmeTotal", element.SommeTotal));
            command.Parameters.Add(new SqlParameter("@sommeAvance", element.SommeAvance));
            command.Parameters.Add(new SqlParameter("@sommeDue", element.SommeDue));
            command.Parameters.Add(new SqlParameter("@notifications", element.Notifications));
            command.Parameters.Add(new SqlParameter("@saisieTermine", element.SaisieTermine));
            command.Parameters.Add(new SqlParameter("@idMission", element.IdMission));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            element.IdNoteFrais = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.IdNoteFrais > 0;
        }

        public override bool Delete(DemandeNoteDeFrais element)
        {
            request = "DELETE FROM notesFrais WHERE idNoteFrais=@idNoteFrais";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idNoteFrais", element.IdNoteFrais));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override DemandeNoteDeFrais Find(string nom)
        {
            DemandeNoteDeFrais dnf = null;
            request = "SELECT nomNoteFrais, dateSaisie,dateEnvoie,sommmeTotal,sommeAvance,sommeDue,notifications,saisieTermine,matriculeCollab,idMission " +
                "FROM notesFrais WHERE idNoteFrais=@idNoteFrais";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomNoteFrais", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                dnf = new DemandeNoteDeFrais()
                {
                    NomNoteFrais = nom,
                    DateSaisie = (DateTime)reader.GetSqlDateTime(1),
                    DateEnvoie = (DateTime)reader.GetSqlDateTime(2),
                    SommeTotal = reader.GetDecimal(3),
                    SommeAvance = reader.GetDecimal(4),
                    SommeDue = reader.GetDecimal(5),
                    Notifications = reader.GetString(6),
                    SaisieTermine = reader.GetBoolean(7),
                    MatriculeCollab = reader.GetInt32(8),
                    IdMission = reader.GetInt32(9),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return dnf;
        }

        public override List<DemandeNoteDeFrais> Find(Func<DemandeNoteDeFrais, bool> criteria)
        {
            List<DemandeNoteDeFrais> DnotesFrais = new List<DemandeNoteDeFrais>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    DnotesFrais.Add(c);
                }
            });
            return DnotesFrais;
        }

        public override List<DemandeNoteDeFrais> FindAll()
        {
            List<DemandeNoteDeFrais> DnotesFrais = new List<DemandeNoteDeFrais>();
            request = "SELECT nomNoteFrais, dateSaisie,dateEnvoie,sommmeTotal,sommeAvance,sommeDue,notifications,saisieTermine,matriculeCollab,idMission" +
                " FROM notesFrais";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DemandeNoteDeFrais dnf = new DemandeNoteDeFrais()
                {
                    NomNoteFrais = reader.GetString(0),
                    DateSaisie = (DateTime)reader.GetSqlDateTime(1),
                    DateEnvoie = (DateTime)reader.GetSqlDateTime(2),
                    SommeTotal = reader.GetDecimal(3),
                    SommeAvance = reader.GetDecimal(4),
                    SommeDue = reader.GetDecimal(5),
                    Notifications = reader.GetString(6),
                    SaisieTermine = reader.GetBoolean(7),
                    MatriculeCollab = reader.GetInt32(8),
                    IdMission = reader.GetInt32(9)
                };
                DnotesFrais.Add(dnf);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return DnotesFrais;
        }

        public override bool Update(DemandeNoteDeFrais element)
        {
            request = "UPDATE noteFrais SET nomNoteFrais = @nomNoteFrais,dateSaisie=@dateSaisie, dateEnvoie = @dateEnvoie,sommmeTotal = @notifications," +
                "sommeAvance=@etat,sommeDue=@sommeDue,notifications=@notifications,saisieTermine=@saisieTermine,matriculeCollab=@matriculeCollab,idMission=@idMission WHERE idNoteFrais = @idNoteFrais";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomNoteFrais", element.NomNoteFrais));
            command.Parameters.Add(new SqlParameter("@dateSaisie", element.DateSaisie));
            command.Parameters.Add(new SqlParameter("@dateEnvoie", element.DateEnvoie));
            command.Parameters.Add(new SqlParameter("@sommmeTotal", element.SommeTotal));
            command.Parameters.Add(new SqlParameter("@sommeAvance", element.SommeAvance));
            command.Parameters.Add(new SqlParameter("@sommeDue", element.SommeDue));
            command.Parameters.Add(new SqlParameter("@notifications", element.Notifications));
            command.Parameters.Add(new SqlParameter("@saisieTermine", element.SaisieTermine));
            command.Parameters.Add(new SqlParameter("@idMission", element.IdMission));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
