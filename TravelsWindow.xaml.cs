using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TRAVELPAL
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
        }

        private void btnUserDetails(object sender, RoutedEventArgs e)
        {
            //Shall open userDetailsWindow
        }

        private void btnAddTravel(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnTravelDetails(object sender, RoutedEventArgs e)
        {
            //Opens TravelsDetailsWindow which shows the details for a specific trip
        }

        private void btnRemoveTravel(object sender, RoutedEventArgs e)
        {
            //Remove travel from list
        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {
            //Closes current window and opens mainwindow again
        }
    }
}