using System.Windows;
using TRAVELPAL.Classes;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for TravelDetailWindow.xaml
    /// </summary>
    public partial class TravelDetailWindow : Window {
        private UserManager userManager;
        private TravelManager travelManager;

        public TravelDetailWindow(UserManager userManager, TravelManager travelManager, Travel travel) {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            tbCountry.Text = travel.Country.ToString();
            tbDestination.Text = travel.Destination;
            tbTravelers.Text = travel.Travelers.ToString();
            tbTravelType.Text = travel.GetTravelType();
            tbTravelInfo.Text = travel.GetTravelInfo();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();
        }
    }
}