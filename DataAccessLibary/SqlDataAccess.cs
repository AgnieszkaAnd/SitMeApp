using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<T>> LoadData<T, TP>(string sqlQuery, TP parameters)
        {
            var connectionString = _configuration.GetConnectionString(ConnectionStringName);
            using (var connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sqlQuery, parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sqlQuery, T parameters)
        {
            var connectionString = _configuration.GetConnectionString(ConnectionStringName);
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
