using System;
using System.Collections.Generic;

namespace DataAccessLibary.Models
{
    public class Table
    {
        public int NbOfSeats { get; set; }

        public string Picture { get; set; }

        public HashSet Tags { get; set; }

        public List<Reservation> Reservations { get; set; }

        public int ID { get; set; }

        public Tuple LocationInRestaurant { get; set; }

        public Enum Type { get; set; }

        public bool isVisibleForUsers { get; set; }

        public int MaxNbOfSeats { get; set; }
    }
}