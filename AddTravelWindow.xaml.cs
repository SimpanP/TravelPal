using System;
using System.Collections.Generic;
using System.Windows;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window {
        UserManager userManager;
        private TravelManager travelManager;
        private string selectedTravelType;
        private User user;
        public List<Travel> Travels = new();


        public AddTravelWindow(TravelManager travelManager, UserManager userManager) {
            InitializeComponent();
            this.travelManager = travelManager;
            this.userManager = userManager;

            //populating the country tab with the countries
            string[] countries = Enum.GetNames(typeof(Countries));
            cbCountry.ItemsSource = countries;

            //populating the trip or vacation CB
            string[] travelTypes = Enum.GetNames(typeof(TravelTypes));
            cbTripOrVacation.ItemsSource = travelTypes;

            //Populating the tripType CB for work or leisure
            string[] tripType = Enum.GetNames(typeof(TripTypes));
            cbTriptype.ItemsSource = tripType;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e) {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();
        }


        //cbtriporvacation vänster
        //cbtriptype work eller leisure

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            Console.WriteLine(cbTriptype.SelectedItem);
            Console.WriteLine(cbTripOrVacation.SelectedItem);

            //Checks so everything is filled in (with the if statement)

            if ((cbCountry.SelectedItem != null) && (tbDestination.Text != "") &&
                (tbTravelers.Text != "") && ((cbTriptype.SelectedItem != null) || (cbTripOrVacation.SelectedItem.ToString() == "Vacation"))) {
                string country = cbCountry.SelectedItem as string;
                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                string destination = tbDestination.Text;
                int travelers = Convert.ToInt32(tbTravelers.Text);

                //Creates vacation if all inclusive IS checked
                bool isAllinclsive = false;
                if (cbTriptype.SelectedIndex == -1) {
                    if ((bool)checkBoxAllInclusive.IsChecked) {
                        isAllinclsive = true;
                    }
                    Travel travel = travelManager.CreateVacation(destination, selectedCountry, travelers, isAllinclsive);
                    User user = userManager.signedInUser as User;
                    user.userTravels.Add(travel);
                    userManager.signedInUser = user;
                    //Creates trip based on information user entered and saved in above method
                } else if (cbTriptype.SelectedIndex == 1) {
                    string trip = cbTriptype.SelectedItem as string;
                    TripTypes selectedTrip = (TripTypes)Enum.Parse(typeof(TripTypes), trip);
                    Travel travel = travelManager.CreateTrip(destination, selectedCountry, travelers, selectedTrip);

                    User user = userManager.signedInUser as User;
                    user.userTravels.Add(travel);
                    userManager.signedInUser = user;
                }

                TravelsWindow travelsWindow = new(userManager, travelManager);
                travelsWindow.Show();
                Close();
            } else {
                MessageBox.Show("Fill in all fields idiot!");
            }
        }

        private void cbTripOrVacation_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e) {
            selectedTravelType = cbTripOrVacation.SelectedItem as string;

            //Shows the different options depending on user input (all inclusive or vacation)
            if (selectedTravelType == "Trip") {
                cbTriptype.Visibility = Visibility.Visible;
                checkBoxAllInclusive.Visibility = Visibility.Hidden;
            } else {
                cbTriptype.Visibility = Visibility.Hidden;
                checkBoxAllInclusive.Visibility = Visibility.Visible;
            }
        }
    }
}