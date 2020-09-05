using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary.Base;

namespace DataAccessLibrary.Repositories.Generic
{
    public interface IRepository<T>
        where T : DomainBase
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteByIdAsync(Guid id);
    }
}