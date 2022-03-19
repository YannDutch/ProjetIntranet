using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TpIntranetEntreprise.Models.Personne;
using TpIntranetEntreprise.Tools;

namespace TpIntranetEntreprise.DAO
{
    class ChefServiceDAO : BaseDAO<ChefService>
    {
        public override bool Ajouter(ChefService element)
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

        public override bool Delete(ChefService element)
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

        public override ChefService Find(string nom)
        {
            ChefService chefservice = null;
            request = "SELECT nom, prenom,dateNaissance, MDP,nomTypeCollab,nomServicePersonne FROM collaborateurs WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                chefservice = new ChefService()
                {
                    Nom = nom,
                    Prenom = reader.GetString(1),
                    DateNaissance = (DateTime)reader.GetSqlDateTime(2),
                    MDP1 = reader.GetString(3),
                    NomTypeCollab = reader.GetString(4),
                    NomServicePersonne = reader.GetString(5),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return chefservice;
        }

        public override List<ChefService> Find(Func<ChefService, bool> criteria)
        {
            List<ChefService> chefservices = new List<ChefService>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    chefservices.Add(c);
                }
            });
            return chefservices;
        }

        public override List<ChefService> FindAll()
        {
            List<ChefService> chefservices = new List<ChefService>();
            request = "SELECT matriculeCollab, nom,prenom, dateNaissance, MDP,nomServicePersonne,nomTypeCollab FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ChefService cs = new ChefService()
                {
                    MatriculeCollab = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    DateNaissance = (DateTime)reader.GetSqlDateTime(3),
                    MDP1 = reader.GetString(4),
                    NomServicePersonne = reader.GetString(5),
                    NomTypeCollab = reader.GetString(6),
                };
                chefservices.Add(cs);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return chefservices;
        }

        public override bool Update(ChefService element)
        {
            request = "UPDATE collaborateurs SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, MDP = @MDP" +
                ",nomServicePersonne=@nomServicePersonne,nomTypeCollab=@nomTypeCollab WHERE matriculeCollab = @matriculeCollab";
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

        public override string ToString(ChefService element)
        {
            return $"{{}}";
        }
    }
}
