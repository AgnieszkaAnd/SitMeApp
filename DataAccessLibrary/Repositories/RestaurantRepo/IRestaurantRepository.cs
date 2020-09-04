using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary.Repositories.Generic;

namespace DataAccessLibrary.Repositories.RestaurantRepo {
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<List<Restaurant>> GetRetaurantsWithTagsAsync(int pageNb, int pageSize);

        Task<List<Restaurant>> GetRetaurantsWithTagsAsync(string filters);
    }
}
