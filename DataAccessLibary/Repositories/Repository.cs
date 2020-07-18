using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibary.Models;

namespace DataAccessLibary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ISqlDataAccess _database;
        private readonly string _tableName;

        public Repository(ISqlDataAccess database)
        {
            _database = database;
            _tableName = (string)typeof(T).GetField("TableName").GetValue(null);
        }

        public  Task<List<T>> GetAll()
        {
            var query = QueryBuilder(SqlResources.GetAll);
            return _database.LoadData<T, object>(query, new {});
        }

        public Task<T> GetById(Guid id)
        {
            var query = QueryBuilder(SqlResources.GetById);
            return _database.LoadData<T, object>(query, new {Id = id })
                .ContinueWith(t => t.Result.FirstOrDefault());
        }

        public Task Insert(T entity)
        {
            var query = QueryBuilder(SqlResources.GetAll);
            return _database.SaveData(query, entity);
        }

        public Task Update(T entity)
        {
            var query = QueryBuilder(SqlResources.GetAll);
            return _database.SaveData(query, entity);
        }
        public Task DeleteById(Guid id)
        {
            var query = QueryBuilder(SqlResources.DeleteById);
            return _database.SaveData(query, new { Id = id });
        }
        private string QueryBuilder(string queryTemplate) => queryTemplate.Replace("@table", _tableName);
    }
}
