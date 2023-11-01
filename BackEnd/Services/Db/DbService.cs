using BackEnd.Services.Configuration;
using System.Data.SqlClient;

namespace BackEnd.Services.Db
{
    public class DbService : DbServiceBase
    {
        public DbService(IConfigurationService configurationService) : base(configurationService)
        {
        }
    }
}
