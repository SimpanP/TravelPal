using System;
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
        public EuropeanCountries europeanCountries = new();
        private UserManager userManager = new();
        private TravelManager travelManager = new();

        public RegisterWindow(TravelManager travelManager, UserManager userManager)
        {
            InitializeComponent();


            //Populating the combobox with the countries
            string[] EuropeanCountries = Enum.GetNames(typeof(EuropeanCountries));

            foreach (string Countries in EuropeanCountries)
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
            string password = pb
            
            //MainWindow mainWindow = new();
            //mainWindow.Show();
            //Close();
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