using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Service;

namespace TpIntranetEntreprise.DAO
{
    class ServiceDAO : BaseDAO<Service>
    {
        public override bool Ajouter(Service element)
        {
            connection = Connection.New;
            request = "INSERT into servicesPersonnes ( dateDebut, dateFin,matriculeCollab,nomServicePersonne ) " +
                "OUTPUT INSERTED.ID values( @dateDebut, @dateFin,@matriculeCollab,@nomServicePersonne)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", element.NomService));
            connection.Open();
            element.IdService = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.IdService > 0;
        }

        public override bool Delete(Service element)
        {
            request = "DELETE FROM servicesPersonnes WHERE idServicePersonne=@idServicePersonne";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idServicePersonne", element.IdService));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override Service Find(string nom)
        {
            Service service = null;
            request = "SELECT  dateDebut, dateFin,matriculeCollab,nomServicePersonne  " +
                "FROM servicesPersonnes WHERE idServicePersonne=@idServicePersonne";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                service = new Service()
                {
                    NomService = nom,
                    DateDebut = (DateTime)reader.GetSqlDateTime(0),
                    DateFin = (DateTime)reader.GetSqlDateTime(1),
                    MatriculeCollab = reader.GetInt32(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return service;
        }

        public override List<Service> Find(Func<Service, bool> criteria)
        {
            List<Service> services = new List<Service>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    services.Add(c);
                }
            });
            return services;
        }

        public override List<Service> FindAll()
        {
            List<Service> services = new List<Service>();
            request = "SELECT idServicePersonne,dateDebut, dateFin,matriculeCollab" +
                ",nomServicePersonne FROM servicesPersonnes";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Service s = new Service()
                {
                    IdService = reader.GetInt32(0),
                    DateDebut = (DateTime)reader.GetSqlDateTime(1),
                    DateFin = (DateTime)reader.GetSqlDateTime(2),
                    MatriculeCollab = reader.GetInt32(3),
                    NomService = reader.GetString(4),
                };
                services.Add(s);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return services;
        }

        public override string ToString(Service element)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Service element)
        {
            request = "UPDATE servicesPersonnes SET dateDebut = @dateDebut, dateFin = @dateFin,matriculeCollab = @matriculeCollab" +
                ",nomServicePersonne=@nomServicePersonne WHERE idServicePersonne = @idServicePersonne";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@dateDebut", element.DateDebut));
            command.Parameters.Add(new SqlParameter("@dateFin", element.DateFin));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", element.NomService));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
