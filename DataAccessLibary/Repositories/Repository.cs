using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLibary.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ISqlDataAccess _database;
        private readonly string _tableName;
        private readonly List<string> _properties;


        //TODO: consider refactoring
        private readonly IConfiguration _configuration;
        public string ConnectionStringName { get; set; } = "Default";


        public Repository(ISqlDataAccess database, IConfiguration configuration)
        {
            _database = database;
            _tableName = typeof(T).GetField("TableName")?.GetValue(null)?.ToString();
            _properties = typeof(T).GetProperties().Select(p => p.Name).ToList();

            _configuration = configuration;
        }

        public  Task<List<T>> GetAll()
        {
            var query = $"Select * From {_tableName};";
            return _database.LoadData<T, object>(query, new {});
        }

        public Task<T> GetById(Guid id)
        {
            var query = $"Select * From {_tableName} Where [Id] = @Id;";
            return _database.LoadData<T, object>(query, new {Id = id })
                .ContinueWith(t => t.Result.FirstOrDefault());
        }
        public Task DeleteById(Guid id)
        {
            var query = $"Delete From {_tableName} Where [Id] = @Id;";
            return _database.SaveData(query, new { Id = id });
        }

        public Task Insert(T entity)
        {
            var query = CreateInsertQuery();
            return _database.SaveData(query, entity);
        }

        public Task Update(T entity)
        {
            var query = CreateUpdateQuery();
            return _database.SaveData(query, entity);
        }

        //TODO: consider refactoring
        public async Task<List<Restaurant>> GetAllRestaurantsJoinedTags()
        {
            List<Restaurant> myResult = new List<Restaurant>();

            var connectionString = _configuration.GetConnectionString(ConnectionStringName);
            using (var connection = new SqlConnection(connectionString)) {
                var sql = @"select * from [Manager].[Restaurant] r 
                    inner join [Manager].[RestaurantTag] rt on rt.RestaurantId = r.Id
                    inner join [Manager].[Tag] t on t.Id = rt.TagId";
                var restaurants = await connection.QueryAsync<Restaurant, Tag, Restaurant>(sql, (restaurant, tag) =>
                {
                    restaurant.Tags.Add(tag);
                    return restaurant;
                }, new{}, splitOn: "Name");
                
                var result = restaurants.GroupBy(r => r.Name).Select(g =>
                {
                    var groupedRestaurant = g.First();
                    groupedRestaurant.Tags = g.Select(r => r.Tags.Single()).ToList();
                    return groupedRestaurant;
                });

                foreach (var restaurant in result) {
                    myResult.Add(restaurant);
                }
            }
            return myResult;
        }

        private string CreateInsertQuery()
        {
            var query = new StringBuilder($"Insert Into {_tableName} ");
            query.Append("(");
            _properties.ForEach(name => query.Append($"[{name}], "));
            query.Remove(query.Length - 2, 2);
            query.Append(") Values (");
            _properties.ForEach(name => query.Append($"@{name}, "));
            query.Remove(query.Length - 2, 2);
            query.Append(");");
            return query.ToString();
        }
        private string CreateUpdateQuery()
        {
            var query = new StringBuilder($"Update {_tableName} Set ");
            _properties.ForEach(name =>
            {
                if (name != "Id")
                {
                    query.Append($"[{name}] = @{name}, ");
                }
            });
            query.Remove(query.Length - 2, 2);
            query.Append(" Where [Id] = @Id;");
            return query.ToString();
        }
    }
}
