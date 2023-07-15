using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace ArabamClone.Model.Data
{
    public class AppDbContext
    {
        //private readonly IConfiguration _configuration;
        //private readonly string connectionString;
        //public AppDbContext(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //    this.connectionString =this._configuration.GetConnectionString("connection");
        //}

        //public IDbConnection CreateConnection() => new SqlConnection(connectionString);
        private readonly IConfiguration _configuration;
        private IDbConnection _connection;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            if (_connection == null)
            {
                string connectionString = _configuration.GetConnectionString("connection");
                _connection = new NpgsqlConnection(connectionString);
            }

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            return _connection;
        }
    }
}
