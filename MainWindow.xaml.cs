using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TRAVELPAL.Interface;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private UserManager userManager = new();
        private TravelManager travelManager = new();

        public MainWindow() {
            InitializeComponent();
            userManager = new();
        }


        //Trial and error
        public MainWindow(UserManager userManager, TravelManager travelManager) {
            InitializeComponent();
        }

        private void TextUserName_OnMouseDown(object sender, MouseButtonEventArgs e) {
            tbUsername.Focus();
        }

        private void TbUsername_OnTextChanged(object sender, TextChangedEventArgs e) {
            if (!string.IsNullOrEmpty(tbUsername.Text) && tbUsername.Text.Length > 0) {
                textUserName.Visibility = Visibility.Collapsed;
            } else {
                textUserName.Visibility = Visibility.Visible;
            }
        }


        private void TextPassword_OnMouseDown(object sender, MouseButtonEventArgs e) {
            pbMainWindow.Focus();
        }


        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(pbMainWindow.Password) && pbMainWindow.Password.Length > 0) {
                textPassword.Visibility = Visibility.Collapsed;
            } else {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e) {
            //TODO, create a new window and open this, send information with the user
            string username = tbUsername.Text;
            string password = pbMainWindow.Password;

            List<IUser> users = userManager.GetAllUsers();

            bool userFound = false;

            foreach (IUser user in users) {

                if (user.Username == username && user.Password == password) {
                    userFound = true;
                    userManager.signedInUser = user;
                    TravelsWindow travelsWindow = new TravelsWindow(userManager, travelManager);
                    travelsWindow.Show();
                    Close();
                }
            }

            if (!userFound) {
                MessageBox.Show("You have entered the wrong information");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        //open new register window and closes current window
        private void SignUpButton_Click(object sender, RoutedEventArgs e) {
            RegisterWindow registerWindow = new(travelManager, userManager); //TODO
            Hide();
            registerWindow.Show();
        }
    }
}