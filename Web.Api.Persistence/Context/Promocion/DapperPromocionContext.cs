using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
  
namespace Web.Api.Persistence.Context.Promocion
{
    public class DapperPromocionContext 
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperPromocionContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbPromocionContext");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
   
    }
}
