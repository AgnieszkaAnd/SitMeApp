using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibary.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}