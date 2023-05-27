using HappyParking.Infraestructure.Interface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace HappyParking.Infraestructure.Data
{
    public class ConnectionBD: IConnectionBD
    {
        private readonly IConfiguration _configuration;

        public ConnectionBD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnectionMySql
        {
            get
            {
                var npgsqlConnection = new MySqlConnection(_configuration.GetConnectionString("ConexionMySql"));
                npgsqlConnection.Open();
                return npgsqlConnection;
            }
        }
    }
}
