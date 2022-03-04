using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Collaborateur;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.DAO
{
    class CollabAdminDAO : BaseDAO<CollabAdmin>
    {
        public override bool Ajouter(CollabAdmin element)
        {
            connection = Connection.New;
            request = "INSERT into collaborateurs ( nom, prenom, dateNaissance, MDP,nomServicePersonne, nomTypeCollab) " +
                "OUTPUT INSERTED.ID values( @nom, @prenom, @dateNaissance,@MDP,@nomServicePersonne,@nomTypeCollab)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@nomTypeCollab", element.NomTypeCollab));
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", element.NomServicePersonne));
            connection.Open();
            element.MatriculeCollab = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.MatriculeCollab > 0;
        }

        public override bool Delete(CollabAdmin element)
        {
            request = "DELETE FROM collaborateurs WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@matricule", element.MatriculeCollab));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }

        public override CollabAdmin Find(string nom)
        {
            CollabAdmin admin = null;
            request = "SELECT nom, prenom,dateNaissance, MDP,nomServicePersonne," +
                "nomTypeCollab FROM collaborateurs WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                admin = new CollabAdmin()
                {
                    Nom = nom,
                    Prenom = reader.GetString(1),
                    DateNaissance = reader.GetString(2),
                    MDP1 = reader.GetString(3),
                    NomServicePersonne = reader.GetString(4),
                    NomTypeCollab = reader.GetString(5),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return admin;
        }

        public override List<CollabAdmin> Find(Func<CollabAdmin, bool> criteria)
        {
            List<CollabAdmin> admins = new List<CollabAdmin>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    admins.Add(c);
                }
            });
            return admins;
        }

        public override List<CollabAdmin> FindAll()
        {
            List<CollabAdmin> admins = new List<CollabAdmin>();
            request = "SELECT matriculeCollab, nom,prenom, dateNaissance, MDP" +
                ",nomServicePersonne,nomTypeColabb FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CollabAdmin a = new CollabAdmin()
                {
                    MatriculeCollab = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    DateNaissance = reader.GetString(3),
                    MDP1 = reader.GetString(4),
                    NomServicePersonne = reader.GetString(5),
                    NomTypeCollab = reader.GetString(5),
                };
                admins.Add(a);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return admins;
        }

        public override bool Update(CollabAdmin element)
        {
            request = "UPDATE collaborateurs SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, MDP = @MDP" +
                "nomServicePersonne=@nomServicePersonne,nomTypeCollab=@nomTypeCollab WHERE matriculeCollab = @matriculeCollab";
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

        public override string ToString(CollabAdmin element)
        {
            return $"{{}}";
        }
    }
}
