using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class ChefService : Collaborateur
    {
        private string nomTypeCollab;

        public ChefService()
        {

        }

        public ChefService(string nomTypeCollab) : base()
        {
            NomTypeCollab = nomTypeCollab;
        }

        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public new bool Save()
        {
            BaseDAO<ChefService> dao = new ChefServiceDAO();
            return dao.Ajouter(this);
        }
    }
}
