using System.Data.SqlClient;

namespace BackEnd.Services.Db
{
    public class DbService : IDbService
    {
        public string ConnectionString { get; set; }

        public SqlConnection CreateConnection()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                return connection;
            }
        }
    }
}
