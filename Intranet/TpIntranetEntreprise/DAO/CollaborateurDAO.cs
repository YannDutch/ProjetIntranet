using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Personne;

namespace TpIntranetEntreprise.DAO
{
    class CollaborateurDAO : BaseDAO<Collaborateur>
    {
        public override bool Ajouter(Collaborateur element)
        {
            connection = Connection.New;
            request = "INSERT into collaborateurs ( matriculeCollab,nom, prenom, dateNaissance, MDP,nomServicePersonne, nomTypeCollab) " +
                "OUTPUT INSERTED.ID values( @matriculeCollab,@nom, @prenom, @dateNaissance,@MDP,@nomServicePersonne,@nomTypeCollab)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", element.NomServicePersonne));
            command.Parameters.Add(new SqlParameter("@nomTypeCollab", element.NomTypeCollab));
            connection.Open();
            element.MatriculeCollab = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.MatriculeCollab > 0;
        }

        public override bool Delete(Collaborateur element)
        {
            request = "DELETE FROM collaborateurs WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override bool Update(Collaborateur element)
        {
            request = "UPDATE collaborateurs SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance," +
                " MDP = @MDP,nomServicePersonne=@nomServicePersonne,nomTypeCollab=@nomTypeCollab, WHERE matriculeCollab = @matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@matriculeCollab", element.MatriculeCollab));
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", element.NomServicePersonne));
            command.Parameters.Add(new SqlParameter("@nomTypeCollab", element.NomTypeCollab));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override Collaborateur Find(string nom)
        {
            Collaborateur collaborateur = null;
            request = "SELECT  nom, prenom, dateNaissance, MDP,nomServicePersonne,nomTypeCollab" +
                "FROM collaborateurs WHERE matriucleCollab=@matriucleCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                collaborateur = new Collaborateur
                {
                    Nom = nom,
                    Prenom = reader.GetString(1),
                    DateNaissance= (DateTime)reader.GetSqlDateTime(2),
                    MDP1 = reader.GetString(3),
                    NomServicePersonne = reader.GetString(4),
                    NomTypeCollab = reader.GetString(5),
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
            request = "SELECT matriculeCollab, nom, prenom, dateNaissance, MDP,nomServicePersonne,nomTypeCollab FROM collaborateurs";
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
                    DateNaissance = (DateTime)reader.GetSqlDateTime(3),
                    MDP1 = reader.GetString(4),
                    NomServicePersonne = reader.GetString(5),
                    NomTypeCollab = reader.GetString(6),
                };
                collaborateurs.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return collaborateurs;
        }

        public override string ToString(Collaborateur element)
        {
            return $"{{}}";
        }
    }
}





