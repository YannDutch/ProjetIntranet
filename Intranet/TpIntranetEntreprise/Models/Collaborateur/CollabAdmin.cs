using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class CollabAdmin : Collaborateur
    {
        private string nomTypeCollab;

        public CollabAdmin()
        {

        }

        public CollabAdmin(string nomTypeCollab) : base()
        {
            NomTypeCollab = nomTypeCollab;
        }

        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public new bool Save()
        {
            BaseDAO<CollabAdmin> dao = new CollabAdminDAO();
            return dao.Ajouter(this);
        }
    }
}
