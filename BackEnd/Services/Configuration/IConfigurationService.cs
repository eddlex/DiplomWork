using System.Globalization;

namespace BackEnd.Services.Configuration
{
    public interface IConfigurationService
    {
        string ConnectionString { get; }

        string GeConnectionString();
        JwtConfiguration GetJwt();
    }
}
