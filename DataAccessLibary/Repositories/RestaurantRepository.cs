using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLibary.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibary.Repositories {
    public class RestaurantRepository : Repository<Restaurant> {

        private readonly ISqlDataAccess _database;
        private readonly string _tableName;
        private readonly List<string> _properties;

        public RestaurantRepository(ISqlDataAccess database) : base(database)
        {
            _tableName = Restaurant.TableName;
            _database = database;
        }

        public async Task<List<Restaurant>> GetAllRestaurantsJoinedTags() {
            List<Restaurant> myResult = new List<Restaurant>();

            var sql = @"select * from [Manager].[Restaurant] r 
                inner join [Manager].[RestaurantTag] rt on rt.RestaurantId = r.Id
                inner join [Manager].[Tag] t on t.Id = rt.TagId";
            Func<Restaurant, Tag, Restaurant> myMappingRestaurantTag = (restaurant, tag) =>
            {
                restaurant.Tags.Add(tag);
                return restaurant;
            };
            var restaurants = await _database.LoadManyToManyData(sql, myMappingRestaurantTag, "Name", new { });

            var result = restaurants.GroupBy(r => r.Name).Select(g =>
            {
                var groupedRestaurant = g.First();
                groupedRestaurant.Tags = g.Select(r => r.Tags.Single()).ToList();
                return groupedRestaurant;
            });

            foreach (var restaurant in result) {
                myResult.Add(restaurant);
            }
            return myResult;
        }
    }
}
