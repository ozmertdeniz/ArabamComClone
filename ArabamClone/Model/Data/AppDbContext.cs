using Microsoft.Data.SqlClient;
using System.Data;

namespace ArabamClone.Model.Data
{
    public class AppDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionString =this._configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
