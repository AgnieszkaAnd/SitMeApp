using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibary.Models;

namespace DataAccessLibary.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Insert(T entity);
        Task Update(T entity);
        Task DeleteById(Guid id);
    }
}