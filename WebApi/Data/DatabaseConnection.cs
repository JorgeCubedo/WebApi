using Microsoft.Data.SqlClient;
using WebApi.Services;

namespace WebApi.Data
{
    public class DatabaseConnection(ConfigService config)
    {
        private readonly ConfigService _config = config;

        public SqlConnection GetConnection()
        {
            string connection = _config.CONNECTION_STRING;

            return new SqlConnection(connection);
        }
    }
}
