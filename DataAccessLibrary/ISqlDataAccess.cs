using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionString { get; }
        bool ConnectionAvailable { get; }
        Task<List<T>> LoadData<T, TP>(string sqlQuery, TP parameters);
        Task SaveData<T>(string sqlQuery, T parameters);

        Task<IEnumerable<T1>> LoadManyToManyData<T1, T2, TP>(string sqlQuery, Func<T1, T2, T1> function, string splitOn,
            TP parameters);
    }
}