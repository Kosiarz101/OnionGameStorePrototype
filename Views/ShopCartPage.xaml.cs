using KckProject3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KckProject3.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ShopCartPage.xaml
    /// </summary>
    public partial class ShopCartPage : UserControl
    {
        List<Game> shopCartGames;
        public ShopCartPage()
        {
            InitializeComponent();
            HideAllGames();
            LoadShopCartGames();
            ChangeSummary();
        }

        private void Game1Delete_Click(object sender, RoutedEventArgs e)
        {
            Game1.Visibility = Visibility.Hidden;
            shopCartGames.RemoveAt(0);
            SaveChangesJson();
            HideAllGames();
            LoadShopCartGames();
            ChangeSummary();
        }

        private void Game2Delete_Click(object sender, RoutedEventArgs e)
        {
            Game2.Visibility = Visibility.Hidden;
            shopCartGames.RemoveAt(1);
            SaveChangesJson();
            HideAllGames();
            LoadShopCartGames();
            ChangeSummary();
        }

        private void Game3Delete_Click(object sender, RoutedEventArgs e)
        {
            Game3.Visibility = Visibility.Hidden;
            shopCartGames.RemoveAt(2);
            SaveChangesJson();
            HideAllGames();
            LoadShopCartGames();
            ChangeSummary();
        }

        private void Game4Delete_Click(object sender, RoutedEventArgs e)
        {
            Game4.Visibility = Visibility.Hidden;
            shopCartGames.RemoveAt(3);
            SaveChangesJson();
            HideAllGames();
            LoadShopCartGames();
            ChangeSummary();
        }

        private void LoadShopCartGames()
        {
            string shopCartGamesSerialized = File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", "ShopCart.json"));
            shopCartGames = JsonConvert.DeserializeObject<List<Game>>(shopCartGamesSerialized);

            try
            {
                ChangeGameValues(Game1, Game1Title, Game1OriginalPrice, Game1CurrentPrice, Game1Promotion, Game1Image, shopCartGames[0]);
                ChangeGameValues(Game2, Game2Title, Game2OriginalPrice, Game2CurrentPrice, Game2Promotion, Game2Image, shopCartGames[1]);
                ChangeGameValues(Game3, Game3Title, Game3OriginalPrice, Game3CurrentPrice, Game3Promotion, Game3Image, shopCartGames[2]);
                ChangeGameValues(Game4, Game4Title, Game4OriginalPrice, Game4CurrentPrice, Game4Promotion, Game4Image, shopCartGames[3]);
            }
            catch(ArgumentOutOfRangeException e)
            {

            }

        }

        private void ChangeGameValues(Border gameBorder, TextBlock gameName, TextBlock oldPrice, TextBlock newPrice, TextBlock promotion, Image image, Game game)
        {
            gameName.Text = game.Name;
            if(game.Promotion != 0)
            {
                oldPrice.Text = game.Price.ToString() + " zł";
                newPrice.Text = (game.Price - (game.Price * game.Promotion)).ToString() + " zł";
                promotion.Text = "-" + (game.Promotion * 100).ToString() + "%";
            }
            else
            {
                oldPrice.Text = "";
                newPrice.Text = game.Price.ToString() + " zł";
                promotion.Text = "";
            }
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", game.Image), UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;

            gameBorder.Visibility = Visibility.Visible;
        }
        private void SaveChangesJson()
        {
            string shopCartGamesSerialized = JsonConvert.SerializeObject(shopCartGames, Formatting.Indented);
            File.WriteAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", "ShopCart.json"), shopCartGamesSerialized);
        }
        private void ChangeSummary()
        {
            decimal wholePrice = 0;
            decimal youSave = 0;
            foreach(Game game in shopCartGames)
            {
                if(game.Promotion == 0)
                    wholePrice += game.Price;
                else
                    wholePrice += (game.Price - (game.Price * game.Promotion));
                youSave += (game.Price * game.Promotion);
            }
            GamesWholePrice.Text = "Whole Price: " + wholePrice.ToString() + " zł";
            GamesSaveMoney.Text = "You Save: " + youSave.ToString() + " zł";
        }
        private void HideAllGames()
        {
            Game1.Visibility = Visibility.Hidden;
            Game2.Visibility = Visibility.Hidden;
            Game3.Visibility = Visibility.Hidden;
            Game4.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new BuyGameFirstScreen();
        }
    }
}
