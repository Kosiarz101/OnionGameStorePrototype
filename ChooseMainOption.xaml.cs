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
    /// Logika interakcji dla klasy ChooseMainOption.xaml
    /// </summary>
    public partial class ChooseMainOption : Window
    {
        public ChooseMainOption()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            StoreFrontPage storeFrontPage = new StoreFrontPage();
            storeFrontPage.Show();
            this.Close();
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountHomePage accountHomePage = new AccountHomePage();
            accountHomePage.Show();
            this.Close();
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryWindow libraryWindow = new LibraryWindow();
            libraryWindow.Show();
            this.Close();
        }
    }
}
