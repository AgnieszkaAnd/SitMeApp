using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories.RestaurantRepo
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRstaurantsWithTags();
    }
}
