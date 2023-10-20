using System.Data.SqlClient;

namespace BackEnd.Services.Db
{
    public interface IDbService
    {
        string ConnectionString { get; set; }
        //void CreateConnection();
        public SqlCommand CreateCommand();

    }
}
