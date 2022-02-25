using System.Data.SqlClient;

namespace TpIntranetEntreprise.Tools
{
    public class Connection
    {
        static string connectionString = @"Data Source=(LocalDB)\Intranet;Integrated Security=True";
        public static SqlConnection New { get => new SqlConnection(connectionString); }
    }
}
