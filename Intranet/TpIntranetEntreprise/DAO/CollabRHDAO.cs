using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Collaborateur;

namespace TpIntranetEntreprise.DAO
{
    class CollabRHDAO : BaseDAO<CollabRH>
    {
        public override bool Ajouter(CollabRH element)
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

        public override bool Delete(CollabRH element)
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

        public override CollabRH Find(string nom)
        {
            CollabRH rH = null;
            request = "SELECT nom, prenom,dateNaissance, MDP,nomServicePersonne,nomTypeCollab" +
                " FROM collaborateurs WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                rH = new CollabRH()
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
            return rH;
        }

        public override List<CollabRH> Find(Func<CollabRH, bool> criteria)
        {
            List<CollabRH> rhs = new List<CollabRH>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    rhs.Add(c);
                }
            });
            return rhs;
        }

        public override List<CollabRH> FindAll()
        {
            List<CollabRH> rhs = new List<CollabRH>();
            request = "SELECT matriculeCollab, nom,prenom, dateNaissance, MDP,nomServicePersonne,nomTypeColabb FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CollabRH r = new CollabRH()
                {
                    MatriculeCollab = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    DateNaissance = reader.GetString(3),
                    MDP1 = reader.GetString(4),
                    NomServicePersonne = reader.GetString(5),
                    NomTypeCollab = reader.GetString(6),
                };
                rhs.Add(r);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return rhs;
        }

        public override bool Update(CollabRH element)
        {
            request = "UPDATE collaborateurs SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance," +
                " MDP = @MDP,nomServicePersonne=@nomServicePersonne,nomTypeCollab=@nomTypeCollab WHERE matricule = @matricule";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@matricule", element.MatriculeCollab));
            command.Parameters.Add(new SqlParameter("@nomTypeCollab", element.NomTypeCollab));
            command.Parameters.Add(new SqlParameter("@nomServicePersonne", element.NomServicePersonne));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public override string ToString(CollabRH element)
        {
            return $"{{}}";
        }
    }
}
