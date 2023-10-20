using BackEnd.Services.Configuration;

namespace BackEnd.Services.Db
{
    public class DbService : DbServiceBase
    {
        private new readonly string ConectionString;

        public DbService(IConfigurationService configurationService) : base(configurationService)
        {
            this.ConectionString =  this.ConnectionString;
        }


    }
}
