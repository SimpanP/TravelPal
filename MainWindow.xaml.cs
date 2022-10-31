﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TRAVELPAL.Managers;

namespace TRAVELPAL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager travelManager = new();
        private TravelManager userManager = new();

        public MainWindow()
        {
            InitializeComponent();
        }


        //Trial and error
        public MainWindow(UserManager travelManager, TravelManager userManager, TextBlock textUserName,
            TextBox tbUsername, TextBlock textPassword, PasswordBox tbPassword, bool contentLoaded)
        {
            this.travelManager = travelManager;
            this.userManager = userManager;
            this.textUserName = textUserName;
            this.tbUsername = tbUsername;
            this.textPassword = textPassword;
            this.tbPassword = tbPassword;
            _contentLoaded = contentLoaded;
        }

        private void TextUserName_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbUsername.Focus();
        }

        private void TbUsername_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUsername.Text) && tbUsername.Text.Length > 0)
            {
                textUserName.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUserName.Visibility = Visibility.Visible;
            }
        }


        private void TextPassword_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPassword.Focus();
        }


        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassword.Password) && tbPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO, create a new window and open this, send information with the user
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //open new register window and closes current window
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager, travelManager);
            Hide();
            registerWindow.Show();
        }
    }
}