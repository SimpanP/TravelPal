using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TRAVELPAL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }



}
