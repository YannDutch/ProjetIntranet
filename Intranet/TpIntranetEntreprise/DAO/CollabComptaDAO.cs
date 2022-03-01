using TpIntranetEntreprise.Models;
using TpIntranetEntreprise.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TpIntranetEntreprise.Models.Collaborateur;

namespace TpIntranetEntreprise.DAO
{
    class CollabComptaDAO : BaseDAO<CollabCompta>
    {
        public override bool Ajouter(CollabCompta element)
        {
            connection = Connection.New;
            request = "INSERT into collaborateurs ( nom, prenom, dateNaissance, MDP, nomTypeCollab) " +
                "OUTPUT INSERTED.ID values( @nom, @prenom, @dateNaissance,@MDP,@nomTypeCollab)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@nomTypeCollab", element.NomTypeCollab)); ;
            connection.Open();
            element.MatriculeCollab = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.MatriculeCollab > 0;
        }

        public override bool Delete(CollabCompta element)
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

        public override CollabCompta Find(string nom)
        {
            CollabCompta compta = null;
            request = "SELECT nom, prenom,dateNaissance, MDP,nomTypeCollab FROM collaborateurs WHERE matriculeCollab=@matriculeCollab";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                compta = new CollabCompta()
                {
                    Nom = nom,
                    Prenom = reader.GetString(1),
                    DateNaissance = reader.GetString(2),
                    MDP1 = reader.GetString(3),
                    NomTypeCollab = reader.GetString(4),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return compta;
        }

        public override List<CollabCompta> Find(Func<CollabCompta, bool> criteria)
        {
            List<CollabCompta> comptas = new List<CollabCompta>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    comptas.Add(c);
                }
            });
            return comptas;
        }

        public override List<CollabCompta> FindAll()
        {
            List<CollabCompta> comptas = new List<CollabCompta>();
            request = "SELECT matriculeCollab, nom,prenom, dateNaissance, MDP,nomTypeColabb FROM collaborateurs";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CollabCompta c = new CollabCompta()
                {
                    MatriculeCollab = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    DateNaissance = reader.GetString(3),
                    MDP1 = reader.GetString(4),
                    NomTypeCollab = reader.GetString(5),
                };
                comptas.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return comptas;
        }

        public override bool Update(CollabCompta element)
        {
            request = "UPDATE collaborateurs SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, MDP = @MDP,nomTypeCollab=@nomTypeCollab WHERE matricule = @matricule";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", element.DateNaissance));
            command.Parameters.Add(new SqlParameter("@MDP", element.MDP1));
            command.Parameters.Add(new SqlParameter("@matricule", element.MatriculeCollab));
            command.Parameters.Add(new SqlParameter("@nomTypeCollab", element.NomTypeCollab));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
