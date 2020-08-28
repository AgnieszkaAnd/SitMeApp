using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary.Repositories.Generic;

namespace DataAccessLibrary.Repositories.RestaurantRepo {
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<List<Restaurant>> GetRetaurantsWithTags(int pageNb, int pageSize);
        Task<List<Restaurant>> GetRetaurantsWithTags(string filters);
    }
}
