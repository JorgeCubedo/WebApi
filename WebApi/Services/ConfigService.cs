namespace WebApi.Services
{
    public class ConfigService
    {
        private readonly IConfiguration _configuration;

        public ConfigService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            CONNECTION_STRING = _configuration.GetConnectionString("SQLConnection") ?? string.Empty;

        }

        public string CONNECTION_STRING;
    }

    
}
