using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TRAVELPAL.Enums;
using TRAVELPAL.Managers;

namespace TRAVELPAL
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public Countries countries = new();
        public EuropeanCountries europeanCountries = new();
        private UserManager userManager = new();
        private TravelManager travelManager = new();

        public RegisterWindow(TravelManager travelManager, UserManager userManager)
        {
            InitializeComponent();


            //Populating the combobox with the countries
            string[] countries = Enum.GetNames(typeof(Countries));

            foreach (string Countries in countries)
            {
                cbCountry.Items.Add(Countries);
            }

            if (!string.IsNullOrEmpty(tbUsernameReg.Text))
            {
                MessageBox.Show("The field can not be empty!");
            }

            this.travelManager = travelManager;
            this.userManager = userManager;
        }


        //Cancel buttons closes the register window and opens the main window once again
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }


        //Register button should save the input data and open mainwindow
        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            string userName = tbUsernameReg.Text;
            string password = pbPasswordBox.Password;
            string country = cbCountry.Text;
            //Converting country to a string to be able to save it
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);


            //MainWindow mainWindow = new();
            //mainWindow.Show();
            //Close();

            //Check if user already exists / else add the user to the application

            if (userName.Length == 0 || password.Length == 0 || country.Length == 0)
            {
                MessageBox.Show("User already exists or you've not filled in all fields");
            }
        }


        private void TbUsernameReg_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void tbConfirmPassword_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}