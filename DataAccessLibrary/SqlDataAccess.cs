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

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        public string ConnectionStringName { get; } = "SitMeDatabase";
        public string ConnectionString { get; }
        public bool ConnectionAvailable { get; }
        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString(ConnectionStringName);
            try
            {
                var connection = new SqlConnection(ConnectionString);
                ConnectionAvailable = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                ConnectionAvailable = false;
                throw;
            }
        }

        public async Task<List<T>> LoadData<T, TP>(string sqlQuery, TP parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            var data = await connection.QueryAsync<T>(sqlQuery, parameters);
            return data.ToList();
    }

        public async Task SaveData<T>(string sqlQuery, T parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync(sqlQuery, parameters);
        }

        // -------------------- Many To Many -------------------------
        public async Task<IEnumerable<T1>> LoadManyToManyData<T1, T2, TP>(string sqlQuery, Func<T1, T2, T1> function, string splitOn, TP parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            var data = await connection.QueryAsync<T1, T2, T1>(sqlQuery, function, new{ Offset = 0, Limit = 9 }, splitOn: splitOn);
            return data.ToList();
        }

    }
}
