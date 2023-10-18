using System.Data.SqlClient;

namespace BackEnd.Services.Db
{
    public interface IDbService
    {
        public string ConnectionString { get => " "; }
        public SqlConnection CreateConnection();

    }
}
