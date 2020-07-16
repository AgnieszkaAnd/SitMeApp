using System;
using System.Collections.Generic;

namespace DataAccessLibary.Models
{
    public class User
    {
        public string Nick { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public UserRole UserRole { get; set; }

        public int ID { get; set; }

        public List<Reservtion> ReservationHistory { get; set; }

        public List<Restaurant> FavouriteRestaurants { get; set; }

        public List<Restaurant> CurrentReservations { get; set; }

        public int CalendarHandler { get; set; }

        public int SMSHandler { get; set; }

        public int PayPalHandler { get; set; }
    }
}