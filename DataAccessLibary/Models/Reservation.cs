using System;

namespace DataAccessLibary.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public bool CustomerArrived { get; set; }

        public string CustomerSpecialRequest { get; set; }

        public TimeSpan TimeSpan { get; set; }

        public DateTime Date { get; set; }

        public Restaurant Restaurant { get; set; }

        public Table Table { get; set; }

        public bool isConfirmed { get; set; }

        public User User { get; set; }
    }
}