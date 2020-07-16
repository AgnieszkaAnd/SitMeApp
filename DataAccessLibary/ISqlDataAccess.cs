using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, TP>(string sqlQuery, TP parameters);
        Task SaveData<T>(string sqlQuery, T parameters);
    }
}