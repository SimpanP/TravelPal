using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TRAVELPAL.Classes;
using TRAVELPAL.Interface;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window {
        private UserManager userManager;
        private TravelManager travelManager;
        private User user;
        private Travel travel;
        public List<Travel> travels = new();

        public TravelsWindow(UserManager userManager, TravelManager travelManager) {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            if (this.userManager.signedInUser is User) {
                user = (User)this.userManager.signedInUser;
                lblUser.Content = $"Welcome {user.Username}";
                User signedInUser = userManager.signedInUser as User;

                foreach (var travel in signedInUser.userTravels) {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;
                    lvTravelInfo.Items.Add(item);
                }
            }

            if (userManager.signedInUser is Admin) {
                lblUser.Content = "Welcome Senpai";
                btnAddTravels.Visibility = Visibility.Hidden;

                foreach (var travel in travelManager.travels) {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;

                    lvTravelInfo.Items.Add(item);
                }
            }

        }

        private void btnUserDetails(object sender, RoutedEventArgs e) {
            //TODO Shall open userDetailsWindow and show details about the user
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);

            userDetailsWindow.Show();
            Close();
        }

        private void btnAddTravel(object sender, RoutedEventArgs e) {
            //TODO Add travel and show the add travel window
            AddTravelWindow addTravelWindow = new(travelManager, userManager);
            addTravelWindow.Show();
            Close();
        }

        private void btnTravelDetails(object sender, RoutedEventArgs e) {
            //TODO open a small window which shows details about the selected trip given from the travelswindow
            ListViewItem selectedItem = lvTravelInfo.SelectedItem as ListViewItem;
            if (selectedItem != null) {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetailWindow travelDetailWindow = new(userManager, travelManager, selectedTravel);
                travelDetailWindow.Show();
                Hide();
            } else {
                MessageBox.Show("Select a travel please!");
            }

        }

        private void btnRemoveTravel(object sender, RoutedEventArgs e) {
            //TODO Remove travel from list
            ListViewItem itemToRemove = lvTravelInfo.SelectedItem as ListViewItem;
            lvTravelInfo.Items.Remove(itemToRemove);
            Travel selectedTravel = itemToRemove.Tag as Travel;
            travelManager.travels.Remove(selectedTravel);

            foreach (IUser user in userManager.users) {
                if (user is User) {
                    User userUser = user as User;
                    if (userUser.userTravels.Contains(selectedTravel)) {
                        userUser.userTravels.Remove(selectedTravel);
                    }

                }
            }
        }


        //Closes current window and opens mainwindow again
        private void btnSignOut(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new(userManager, travelManager);
            mainWindow.Show();
            Close();
        }

        private void btnInfo(object sender, RoutedEventArgs e) {
            //TODO Opens a messagebox which shows the details for a specific trip
            MessageBox.Show("Welcome to the TravelPal application lorem ipsum lorem ipsum...");
        }
    }
}