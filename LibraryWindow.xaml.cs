using KckProject3.Models;
using KckProject3.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logika interakcji dla klasy LibraryWindow.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        public List<Game> gamesList { get; set; }
        public LibraryWindow()
        {
            InitializeComponent();
            gamesList = new List<Game>();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadGameList();
            DataContext = new NewestGamesLibrary();
        }
        private void LoadGameList()
        {
            gamesList = JsonManager.LoadGames("GameLibrary.json");
            TextBlock textBlock;
            foreach (Game game in gamesList)
            {
                textBlock = new TextBlock();
                textBlock.Text = game.Name;
                textBlock.FontSize = 12;
                textBlock.Style = this.FindResource("MainTextBlock") as Style;
                Button button = new Button();
                button.MinHeight = 30;
                button.Content = textBlock;
                button.Click += btnGameDetails_Click;
                button.Style = this.FindResource("ButtonStandard") as Style;
                gamesListSP.Children.Add(button);
            }
        }
        private void btnGameDetails_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Content;
            Game game = gamesList.Where(x => x.Name == textBlock.Text).FirstOrDefault();
            DataContext = new GameLibraryDetails(game);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            StoreFrontPage storeFrontPage = new StoreFrontPage();
            storeFrontPage.Show();
            this.Close();
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewestGamesLibrary();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            AccountHomePage accountHomePage = new AccountHomePage();
            accountHomePage.Show();
            this.Close();
        }
    }
    
}
