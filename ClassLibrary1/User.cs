using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class User {
        public string Nick {
            get => default;
            set {
            }
        }

        public string FirstName {
            get => default;
            set {
            }
        }

        public string LastName {
            get => default;
            set {
            }
        }

        public string Password {
            get => default;
            set {
            }
        }

        public string Email {
            get => default;
            set {
            }
        }

        public string Telephone {
            get => default;
            set {
            }
        }

        public UserRole UserRole {
            get => default;
            set {
            }
        }

        public int ID {
            get => default;
            set {
            }
        }

        public List<Reservtion> ReservationHistory {
            get => default;
            set {
            }
        }

        public List<Restaurant> FavouriteRestaurants {
            get => default;
            set {
            }
        }

        public List<Restaurant> CurrentReservations {
            get => default;
            set {
            }
        }

        public int CalendarHandler {
            get => default;
            set {
            }
        }

        public int SMSHandler {
            get => default;
            set {
            }
        }

        public int PayPalHandler {
            get => default;
            set {
            }
        }

        public bool Register() {
            throw new System.NotImplementedException();
        }

        public bool Login() {
            throw new System.NotImplementedException();
        }

        public void GetAllReservations() {
            throw new System.NotImplementedException();
        }
    }
}