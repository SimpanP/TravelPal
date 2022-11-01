using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Classes {
    public class Admin : IUser {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; } //TODO, cant delete this one as it's heriting from IUSER blueprint, wont be using it in the constructor below

        public Admin(string username, string password) {
            Username = username;
            Password = password;
        }
    }
}