using System.Collections.Generic;
using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Classes {
    public class User : IUser {
        public List<Travel> userTravels = new();
        public List<Travel> users = new();
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public User(string username, string password, Countries country) {
            Username = username;
            Password = password;
            Location = country;
        }
    }
}