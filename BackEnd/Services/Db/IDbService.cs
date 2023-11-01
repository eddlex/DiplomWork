using System.Data.SqlClient;

namespace BackEnd.Services.Db
{
    public interface IDbService
    {
        string ConnectionString { get; set; }
        public SqlCommand CreateCommand();
        SqlConnection CreateConnection();

    }
}
