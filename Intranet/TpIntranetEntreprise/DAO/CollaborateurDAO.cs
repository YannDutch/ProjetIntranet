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
        public override bool Ajouter(Collaborateur element)
        {
            request = "INSERT INTO collaborateurs (nom, prenom, dateNaissance, MDP) " +
                "OUTPUT INSERTED.ID VALUES (@nom, @prenom, @dateNaissance, @MDP)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            connection.Open();
            element.MatriculeCollab = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.MatriculeCollab > 0;
        }

        public override bool Delete(Collaborateur element)
        {
            request = "DELETE FROM collaborateurs WHERE matricule=@matricule";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matricule", element.MatriculeCollab));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override bool Update(Collaborateur element)
        {
            request = "UPDATE collaborateurs SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, MDP = @MDP, WHERE matriculeCollab = @matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override Collaborateur Find(string nom)
        {
            Collaborateur collaborateur = null;
            request = "SELECT matriculeCollab, nom, prenom, dateNaissance, MDP FROM collaborateurs WHERE nom=@nom";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                collaborateur = new Collaborateur
                {
                    MatriculeCollab = reader.GetInt32(0),
                    Nom = nom,
                    Prenom = reader.GetString(2),
                    DateNaissance = reader.GetString(3),
                    MDP1 = reader.GetString(4),
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
            request = "SELECT matriculeCollab, nom, prenom, dateNaissance, MDP FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Collaborateur c = new Collaborateur
                {
                    MatriculeCollab = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    DateNaissance = reader.GetString(3),
                    MDP1 = reader.GetString(4),
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





