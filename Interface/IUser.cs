using TRAVELPAL.Enums;

namespace TRAVELPAL.Interface {
    public interface IUser {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
    }
}