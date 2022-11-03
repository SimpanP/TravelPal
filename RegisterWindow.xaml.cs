using System;
using System.Windows;
using System.Windows.Controls;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;
using TRAVELPAL.Managers;

namespace TRAVELPAL {
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window {
        public Countries countries = new();
        public EuropeanCountries europeanCountries = new();
        private UserManager userManager = new();
        private TravelManager travelManager = new();
        private User users;

        public RegisterWindow(UserManager userManager, TravelManager travelManager) {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            //Populating the combobox with the countries
            string[] countries = Enum.GetNames(typeof(Countries));

            foreach (string Countries in countries) {
                cbCountry.Items.Add(Countries);
            }

            if (!string.IsNullOrEmpty(tbUsernameReg.Text)) {
                MessageBox.Show("The field can not be empty!");
            }
        }


        //Cancel buttons closes the register window and opens the main window once again
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }


        //Register button should save the input data and open mainwindow
        private void BtnRegister_OnClick(object sender, RoutedEventArgs e) {
            string username = tbUsernameReg.Text;
            string password = pbPasswordBox.Password;


            //Check if user already exists / else add the user to the application

            if (userManager.UpdateUsername(users, username) && userManager.IsCheckPassword(password)) {
                string country = cbCountry.Text;
                //Converting country to a string to be able to save it
                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                if (userManager.AddUser(username, password, selectedCountry)) {
                    MainWindow mainWindow = new(userManager, travelManager);
                    mainWindow.Show();
                    Close();
                }
            }
        }

        private void tbConfirmPassword_OnTextChanged(object sender, TextChangedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}