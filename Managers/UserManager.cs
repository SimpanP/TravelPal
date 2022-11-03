using System.Collections.Generic;
using System.Windows;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Managers {
    public class UserManager {
        //TODO : Remove user
        //TODO : Update username after input from user
        //TODO : Sign in the user to the application
        //TODO : Add admin to the application upon startup. // done


        public List<IUser> users = new();
        public IUser signedInUser { get; set; }

        public UserManager() {
            AddAdminUser();
            AddGandalf();
        }


        //hard coding in the admin user as per described in the instructions so generic login can be used
        public void AddAdminUser() {
            Admin admin = new("Admin", "password");
            users.Add(admin);
        }

        //Adding Gandalf with the hard coded trip in the application
        public void AddGandalf() {
            //TODO add Gandalf to the list and dedicate two trips for hím in the manager
            User gandalf = new("Gandalf", "password", Countries.Swaziland);
            Vacation gandalfVacation = new Vacation(true, "Spain", Countries.Barbados, 6);
            Trip gandalfTrip = new(3, "Poland", Countries.Argentina, TripTypes.Work);
            users.Add(gandalf);
            //TODO add vacation and trip
            gandalf.userTravels.Add(gandalfVacation);
            gandalf.userTravels.Add(gandalfTrip);

        }

        public bool IsCheckPassword(string password) {
            if (password.Length < 5) {
                MessageBox.Show("Minimum requirement 5 characters");
                return false;
            }

            return true;
        }

        public bool AddUser(string username, string password, Countries country) {
            if (ValidateUsername(username)) {
                User user = new(username, password, country);
                users.Add(user);
                return true;
            }

            return false;
        }

        //Updates the username and checks all criterias
        public bool UpdateUsername(IUser user, string username) {
            if (username.Length < 3) {
                MessageBox.Show("Minimum length is 3 characters");
                return false;
            }

            if (username == null) {
                MessageBox.Show("Username can not be empty");
                return false;
            }

            if (ValidateUsername(username) == false) {
                return false;
            }

            return true;
        }

        //Updates the password and checks all criterias
        public bool UpdatePassword(string confirmPassword, string password) {
            if (password.Length < 5) {
                MessageBox.Show("Minimum password length is 5");
                return false;
            } else if (string.IsNullOrEmpty(password)) {
                MessageBox.Show("You need to enter as password");
                return false;
            } else if (password != confirmPassword) {
                MessageBox.Show("Passwords does not match");
            }
            return true;
        }


        private bool ValidateUsername(string username) {
            foreach (var user in users) {
                if (user.Username == username) {
                    return false;
                }
            }

            return true;
        }

        public List<IUser> GetAllUsers() {
            return users;
        }
    }
}