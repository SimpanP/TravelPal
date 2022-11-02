using System.Collections.Generic;
using System.Windows;
using TRAVELPAL.Classes;
using TRAVELPAL.Interface;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window {
        public List<IUser> Users;
        private UserManager userManager;
        private TravelManager travelManager;
        private User user;
        private Travel travel;

        public TravelsWindow(UserManager userManager, TravelManager travelManager) {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            //lblUsername.Content = User.Username;
        }

        private void btnUserDetails(object sender, RoutedEventArgs e) {
            //TODO Shall open userDetailsWindow and show details about the user
        }

        private void btnAddTravel(object sender, RoutedEventArgs e) {
            //TODO Add travel and show the add travel window
            AddTravelWindow addTravelWindow = new(travelManager, userManager);
            addTravelWindow.Show();
            Close();
        }

        private void btnTravelDetails(object sender, RoutedEventArgs e) {
        }

        private void btnRemoveTravel(object sender, RoutedEventArgs e) {
            //TODO Remove travel from list
        }


        //Closes current window and opens mainwindow again
        private void btnSignOut(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new(userManager, travelManager);
            mainWindow.Show();
            Close();
        }

        private void btnInfo(object sender, RoutedEventArgs e) {
            //TODO Opens a messagebox which shows the details for a specific trip
            MessageBox.Show("Welcome to the TravelPal application \\n");
        }
    }
}