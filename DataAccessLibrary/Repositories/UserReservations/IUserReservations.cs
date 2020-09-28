using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary.Repositories.Generic;

namespace DataAccessLibrary.Repositories.UserReservations
{
    public interface IUserReservations : IRepository<User>
    {
        Task<List<Reservation>> GetUpcomingReservations(Guid UserId);
        Task<List<Reservation>> GetReservationsHistory(Guid UserId);
    }
}


  
