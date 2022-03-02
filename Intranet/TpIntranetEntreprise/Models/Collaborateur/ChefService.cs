using TpIntranetEntreprise.DAO;

namespace TpIntranetEntreprise.Models.Collaborateur
{
    public class ChefService:Collaborateur
    {
        private string nomTypeCollab;
        private int idService;
        public ChefService()
        {

        }

        public ChefService(string nomTypeCollab, int idService) : base()
        {
            NomTypeCollab = nomTypeCollab;
            IdService = idService;
        }

        public string NomTypeCollab { get => nomTypeCollab; set => nomTypeCollab = value; }
        public int IdService { get => idService; set => idService = value; }

        public new bool Save()
        {
            BaseDAO<ChefService> dao = new ChefServiceDAO();
            return dao.Ajouter(this);
        }
    }
}
