using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories.Generic;


namespace DataAccessLibrary.Repositories.RestaurantRepo {
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository {

        private readonly ISqlDataAccess _database;
        private readonly string _tableName;
        private readonly List<string> _properties;

        public RestaurantRepository(ISqlDataAccess database) : base(database)
        {
            _tableName = Restaurant.TableName;
            _database = database;
        }

        //TODO add 2 parameters for pagination
        public async Task<List<Restaurant>> GetRetaurantsWithTags() //int pageNb, int pageSize) { // skip i top
        {
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

            // TODO put grouping in sql query if possible
            var result = restaurants.GroupBy(r => r.Name).Select(g =>
            {
                var groupedRestaurant = g.First();
                // TODO use dictionary local variable: key - tuple (restaurant, tag) - Dapper example
                groupedRestaurant.Tags = g.Select(r => r.Tags.Single()).ToList();
                return groupedRestaurant;
            });

            foreach (var restaurant in result) {
                myResult.Add(restaurant);
            }
            return myResult;
        }

        //TODO change List to IEnumerable
        //TODO mozna wyciągnąć najpierw restauracje a potem dla nich n query po tagi (problem n+1)
        //1 query na początku select * a potem  n queries
        public async Task<List<Restaurant>> GetRetaurantsWithTags(string filters) {
            //List<Restaurant> myResult = new List<Restaurant>();


            var query = new StringBuilder(@"select * from [Manager].[Restaurant] r 
                                            inner join [Manager].[RestaurantTag] rt on rt.RestaurantId = r.Id
                                            inner join [Manager].[Tag] t on t.Id = rt.TagId
                                            where t.Name = ");


            if (!String.IsNullOrEmpty(filters))
            {
                var filtersArr = filters.Split(',');
                foreach (var parameter in filtersArr) { query = query.Append("'" + parameter + "' or t.Name = "); }
                query = query.Append("'");
                query = query.Remove(query.Length - 14, 14);
            }
            else { query = query.Remove(query.Length - 15, 15); }

            //query = query.Append(" group by r.Name");
            var sql = query.ToString();

            Func<Restaurant, Tag, Restaurant> myMappingRestaurantTag = (restaurant, tag) => {
                restaurant.Tags.Add(tag);
                return restaurant;
            };
            var restaurants = await _database.LoadManyToManyData(sql, myMappingRestaurantTag, "Name", new { });

            //var result = restaurants;
            var result = restaurants.GroupBy(r => r.Name).Select(g => {
                var groupedRestaurant = g.First();
                // TODO use dictionary local variable: key - tuple (restaurant, tag) - Dapper example
                groupedRestaurant.Tags = g.Select(r => r.Tags.Single()).ToList();
                return groupedRestaurant;
            });

            //foreach (var restaurant in result) {
            //    myResult.Add(restaurant);
            //}
            return result.ToList();
        }
    }
}
