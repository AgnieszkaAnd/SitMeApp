using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibary.Repositories
{
    public class Repository<T> : IRepository<T> where T: class, new()
    {
        private readonly ISqlDataAccess _database;

        public Repository(ISqlDataAccess database)
        {
            _database = database;
        }

        public  Task<List<T>> GetAll()
        {
            return _database.LoadData<T, object>(SqlResources.SelectAll, new { });
        }

        public Task<T> GetById(int Id)
        {
            return _database.LoadData<T, object>("select", new { })
                .ContinueWith(t => t.Result.FirstOrDefault());
        }

        public Task Insert(T entity)
        {
            return _database.SaveData("insert", entity);
        }

        public Task Update(T entity)
        {
            return _database.SaveData("update", entity);
        }
        public Task Delete(T entity)
        {
            return _database.SaveData("delete", entity);
        }

    }
}
