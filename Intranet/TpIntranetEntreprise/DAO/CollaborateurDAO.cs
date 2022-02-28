using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Collaborateur;

namespace TpIntranetEntreprise.DAO
{
    class CollaborateurDAO : BaseDAO<Collaborateur>
    {
        public override bool AjouterCollaborateur(Collaborateur element)
        {
            request = "INSERT INTO collaborateurs (nom, prenom, telephone, Email) " +
                "OUTPUT INSERTED.ID VALUES (@nom, @prenom, @telephone, @Email)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", element.Telephone));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            connection.Open();
            element.Matricule = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Matricule > 0;
        }

        public override bool Delete(Collaborateur element)
        {
            request = "DELETE FROM collaborateurs WHERE matricule=@matricule";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matricule", element.Matricule));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override bool Update(Collaborateur element)
        {
            request = "UPDATE collaborateur SET nom = @nom, prenom = @prenom, telephone = telephone, email = @email, WHERE matricule = @matricule";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", element.Telephone));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            command.Parameters.Add(new SqlParameter("@matricule", element.Matricule));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override Collaborateur Find(string nom)
        {
            Collaborateur collaborateur = null;
            request = "SELECT matricule, nom, prenom, telephone, email FROM collaborateurs WHERE nom=@nom";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                collaborateur = new Collaborateur
                {
                    Matricule = reader.GetInt32(0),
                    Nom = nom,
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                    Email = reader.GetString(4),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return collaborateur;
        }

        public override List<Collaborateur> Find(Func<Collaborateur, bool> criteria)
        {
            List<Collaborateur> collaborateurs = new List<Collaborateur>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    collaborateurs.Add(c);
                }
            });
            return collaborateurs;
        }


        public override List<Collaborateur> FindAll()
        {
            List<Collaborateur> collaborateurs = new List<Collaborateur>();
            request = "SELECT matricule, nom, prenom, telephone, email FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Collaborateur c = new Collaborateur
                {
                    Matricule = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                    Email = reader.GetString(4),                   
                };
                collaborateurs.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return collaborateurs;
        }

    }
}





