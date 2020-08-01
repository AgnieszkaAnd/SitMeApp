using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories.RestaurantRepo {
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAll();
        Task<Restaurant> GetById(Guid id);
        Task Insert(Restaurant entity);
        Task Update(Restaurant entity);
        Task DeleteById(Guid id);
        Task<List<Restaurant>> GetRetaurantsWithTags();
        Task<List<Restaurant>> GetRetaurantsWithTags(string filterBy);
    }
}
