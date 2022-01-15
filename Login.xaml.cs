using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KckProject3
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public bool isUsernameTextBoxPrepared { get; set; }
        public bool isPasswordTextBoxPrepared { get; set; }
        public Login()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoginButton.IsEnabled = false;
            LoginButton.Opacity = 0.6;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(UsernameTextBox.Text != "" || PasswordTextBox.Password != "")
            {
                ChooseMainOption cmo = new ChooseMainOption();
                cmo.Show();
                this.Close();
            }
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(UsernameTextBox.Text == "")
            {
                LoginButton.IsEnabled = false;
                isUsernameTextBoxPrepared = false;
                LoginButton.Opacity = 0.6;
            }
            else
            {
                isUsernameTextBoxPrepared = true;
            }
            CheckLoginInButton();
        }

        private void PasswordTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password == "")
            {
                LoginButton.IsEnabled = false;
                isPasswordTextBoxPrepared = false;
                LoginButton.Opacity = 0.6;
            }
            else
            {
                isPasswordTextBoxPrepared = true;
            }
            CheckLoginInButton();
        }
        
        private void CheckLoginInButton()
        {
            if (isUsernameTextBoxPrepared && isPasswordTextBoxPrepared)
            {
                LoginButton.IsEnabled = true;
                LoginButton.Opacity = 1.0;
            }
        }
    }
}
