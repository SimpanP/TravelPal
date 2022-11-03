using System;
using System.Windows;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>

    public partial class UserDetailsWindow : Window {
        private UserManager userManager;
        private TravelManager travelManager;
        private User user;
        public UserDetailsWindow(UserManager userManager, TravelManager travelManager) {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            //Populating the comboBox in the window
            cbChooseCountry.ItemsSource = Enum.GetNames(typeof(Countries));
            //Save user inputs
            //tbNewUsername.Text = userManager.signedInUser.Username;
            //tbNewPassword.Text = userManager.signedInUser.Password;
            //cbChooseCountry.SelectedItem = userManager.signedInUser.Location;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            string newUsername = tbNewUsername.Text;
            string newPassword = tbNewPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            if (userManager.UpdateUsername(user, newUsername) && userManager.UpdatePassword(newPassword, confirmPassword)) {
                string newCountry = cbChooseCountry.Text;
                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), newCountry);
                userManager.signedInUser.Username = newUsername;
                userManager.signedInUser.Password = newPassword;
                userManager.signedInUser.Location = selectedCountry;
            }
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();

        }
    }
}
