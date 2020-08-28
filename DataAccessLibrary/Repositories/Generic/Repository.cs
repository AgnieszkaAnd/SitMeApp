using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLibrary.Repositories.Generic;
using Microsoft.Extensions.Configuration;
using DataAccessLibrary;


namespace DataAccessLibrary.Repositories.Generic
{
    // TODO change T to eg. IDataTable - with eg. property TableName
    // so we can know more about the class
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ISqlDataAccess _database;
        private readonly string _tableName;
        private readonly List<string> _properties;

        public Repository(ISqlDataAccess database)
        {
            _database = database;
            _tableName = typeof(T).GetField("TableName")?.GetValue(null)?.ToString();
            _properties = typeof(T).GetProperties().Select(p => p.Name).ToList();
        }

        // TODO add error catching (eg. what if type do not have table in repository)
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
