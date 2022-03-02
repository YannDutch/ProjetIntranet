using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TpIntranetEntreprise.DAO
{
    abstract class BaseDAO<T>
    {
        protected static SqlCommand command;
        protected static SqlConnection connection;
        protected static SqlDataReader reader;
        protected static string request;



        public abstract bool Ajouter(T element);


        public abstract bool Delete(T element);
        
        
        public abstract T Find(string nom);
        
        
        public abstract List<T> Find(Func<T,bool> criteria);
        
        
        public abstract List<T> FindAll();
        
        
        public abstract bool Update(T element);

    }
}
