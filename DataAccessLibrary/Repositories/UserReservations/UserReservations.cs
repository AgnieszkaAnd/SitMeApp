using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories.Generic;

namespace DataAccessLibrary.Repositories.UserReservations
{
    public class UserReservations : IUserReservations
    {
        private readonly IRepository<Reservation> _repository;
        private readonly ISqlDataAccess _database;
        private readonly string _tableName;
        private readonly List<string> _properties;

        public UserReservations(ISqlDataAccess database, IRepository<Reservation> repository)
        {
            _tableName = Reservation.TableName;
            _database = database;
            _repository = repository;
        }


        public Task<List<Reservation>> GetUpcomingReservations(Guid UserId)
        {
            var currentTime = DateTime.Now;
            var query = $"Select * From {_tableName} Where [UserId] = @UserId AND [StartDateTime] > currentTime ;";
            return _database.LoadData<Reservation, object>(query, new { UserId = UserId });
        }

        public Task<List<Reservation>> GetReservationsHistory(Guid UserId)
        {
            var currentTime = DateTime.Now;
            var query = $"Select * From {_tableName} Where [UserId] = @UserId AND [StartDateTime] < currentTime ;";
            return _database.LoadData<Reservation, object>(query, new { UserId = UserId });
        }


        
       
        /*
        async Task<List<User>> IRepository<User>.GetAll()
        {
            return await this._repository.GetAll();
        }
        */

        Task<User> IRepository<User>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

