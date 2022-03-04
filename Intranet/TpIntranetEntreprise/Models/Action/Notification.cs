using System;
using System.Collections.Generic;
using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Action
{
    public class Notification
    {
        private string titre;
        private bool validN1;
        private bool validN2;
        private int idNotificaitons;

        public Notification()
        {
            IdNotificaitons++;

        }
        public Notification(string titre, bool validN1, bool validN2):this()
        {
            Titre = titre;
            ValidN1 = validN1;
            ValidN2 = validN2;
        }

        public string Titre { get => titre; set => titre = value; }
        public bool ValidN1 { get => validN1; set => validN1 = value; }
        public bool ValidN2 { get => validN2; set => validN2 = value; }
        public int IdNotificaitons { get => idNotificaitons; set => idNotificaitons = value; }

        public bool Save()
        {
            BaseDAO<Notification> notifDAO = new NotificationDAO();
            return notifDAO.Ajouter(this);
        }
        public bool Delete()
        {
            BaseDAO<Notification> notifDAO = new NotificationDAO();
            return notifDAO.Delete(this);
        }
        public Notification Find(string nom)
        {
            BaseDAO<Notification> notifDAO = new NotificationDAO();
            return notifDAO.Find(nom);
        }
        public List<Notification> Find(Func<Notification, bool> criteria)
        {
            BaseDAO<Notification> notifDAO = new NotificationDAO();
            return notifDAO.Find(criteria);
        }
        public List<Notification> FindAl()
        {
            BaseDAO<Notification> notifDAO = new NotificationDAO();

            return notifDAO.FindAll();
        }
        public bool Update(Notification element)
        {
            BaseDAO<Notification> notifDAO = new NotificationDAO();
            return notifDAO.Update(element);
        }
        public string ToString(Notification element)
        {
            BaseDAO<Notification> notifDAO=new NotificationDAO();
            return notifDAO.ToString(element);
        }
    }
}
