using KckProject3.ViewModels;
using KckProject3.Views;
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
    /// Logika interakcji dla klasy AccountHomePage.xaml
    /// </summary>
    public partial class AccountHomePage : Window
    {
        Style ButtonStandardStyle;
        Style ButtonCheckedStyle;
        public AccountHomePage()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ButtonStandardStyle = this.FindResource("ButtonStandard") as Style;
            ButtonCheckedStyle = this.FindResource("ButtonChecked") as Style;

            UserDataButton.Style = ButtonCheckedStyle;
            DataContext = new UserDataViewModel();
        }

        private void UserDataButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (UserDataButton.Style == ButtonStandardStyle)
                UserDataButton.Style = ButtonCheckedStyle;

            DataContext = new UserDataViewModel();
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (LanguageButton.Style == ButtonStandardStyle)
                LanguageButton.Style = ButtonCheckedStyle;
            DataContext = new LanguagePreferences();
        }
        private void StorePreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (StorePreferencesButton.Style == ButtonStandardStyle)
                StorePreferencesButton.Style = ButtonCheckedStyle;
            DataContext = new StorePreferences();
        }
        private void ResetAllButtons()
        {
            UserDataButton.Style = ButtonStandardStyle;
            LanguageButton.Style = ButtonStandardStyle;
            StorePreferencesButton.Style = ButtonStandardStyle;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            StoreFrontPage storeFrontPage = new StoreFrontPage();
            storeFrontPage.Show();
            this.Close();
        }
    }
}
