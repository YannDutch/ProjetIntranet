using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.DAO;
using TpIntranetEntreprise.Models.Action;

namespace TpIntranetEntreprise.Models.Action
{
    class NotificationDAO : BaseDAO<Notification>
    {
        public override bool Ajouter(Notification element)
        {
            connection = Connection.New;
            request = "INSERT into notifications ( titre, validN1,validN2 ) " +
                "OUTPUT INSERTED.ID values( @titre, @validN1,@validN2)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", element.Titre));
            command.Parameters.Add(new SqlParameter("@validN1", element.ValidN1));
            command.Parameters.Add(new SqlParameter("@validN2", element.ValidN2));
            connection.Open();
            element.IdNotificaitons = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.IdNotificaitons > 0;
        }

        public override bool Delete(Notification element)
        {
            request = "DELETE FROM notifications WHERE idNotificaitons=@idNotificaitons";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idNotificaitons", element.IdNotificaitons));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override Notification Find(string nom)
        {
            Notification notif = null;
            request = "SELECT titre, validN1,validN2 " +
                "FROM notifications WHERE idNotificaitons=@idNotificaitons";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                notif = new Notification()
                {
                    Titre = nom,
                    ValidN1 = reader.GetBoolean(1),
                    ValidN2 = reader.GetBoolean(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return notif;
        }

        public override List<Notification> Find(Func<Notification, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Notification> FindAll()
        {
            List<Notification> notifs = new List<Notification>();
            request = "SELECT idNotificaitons, titre, validN1,validN2" +
                " FROM notificarions";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Notification n = new Notification()
                {
                    IdNotificaitons = reader.GetInt32(0),
                    Titre = reader.GetString(1),
                    ValidN1 = reader.GetBoolean(2),
                    ValidN2 = reader.GetBoolean(3),
                };
                notifs.Add(n);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return notifs;
        }

        public override string ToString(Notification element)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Notification element)
        {
            request = "UPDATE notifications SET titre = @titre, validN1 = @validN1,validN2 = @validN2" +
                " WHERE idnotifications = @idnotifications";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", element.Titre));
            command.Parameters.Add(new SqlParameter("@validN1", element.ValidN1));
            command.Parameters.Add(new SqlParameter("@validN2", element.ValidN2));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
