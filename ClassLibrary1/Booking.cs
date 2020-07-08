using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public abstract class Booking : IBooking {
        public User User {
            get => default;
            set {
            }
        }

        public DateTime DateCreated {
            get => default;
            set {
            }
        }

        public User User1 {
            get => default;
            set {
            }
        }

        public int ID {
            get => default;
            set {
            }
        }

        public bool CustomerArrived {
            get => default;
            set {
            }
        }

        public string CustomerSpecialRequest {
            get => default;
            set {
            }
        }

        public TimeSpan TimeSlot {
            get => default;
            set {
            }
        }
    }
}