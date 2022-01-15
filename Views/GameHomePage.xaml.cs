using KckProject3.Models;
using KckProject3.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Logika interakcji dla klasy GameHomePage.xaml
    /// </summary>
    public partial class GameHomePage : UserControl
    {
        public bool IsPlaying { get; set; } = true;
        public List<Game> ShopCartGames { get; set; }
        public Game Game { get; set; }
        public GameHomePage()
        {
            InitializeComponent();
            //string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Videos\\forzaTrailer_01.mp4");
            //BitmapImage logo = new BitmapImage();
            //logo.BeginInit();
            //logo.UriSource = new Uri(path, UriKind.Relative);
            //logo.EndInit();
            //trailerME.Source = new Uri(path, UriKind.Relative);
            //trailerME.Play();

            LoadGameData("Battlefield 2042");
        }
        public GameHomePage(string chosenGame)
        {
            InitializeComponent();
            //string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Videos\\forzaTrailer_01.mp4");
            //BitmapImage logo = new BitmapImage();
            //logo.BeginInit();
            //logo.UriSource = new Uri(path, UriKind.Relative);
            //logo.EndInit();
            //trailerME.Source = new Uri(path, UriKind.Relative);
            //trailerME.Play();

            LoadGameData(chosenGame);
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(IsPlaying)
            {
                trailerME.Pause();
                IsPlaying = false;
            }
            else
            {
                trailerME.Play();
                IsPlaying = true;
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if(!ShopCartGames.Any(x => x.Name == Game.Name))
                ShopCartGames.Add(Game);
            if (ShopCartGames.Count > 4)
                ShopCartGames.RemoveAt(0);
            string shopCartGamesSerialized = JsonConvert.SerializeObject(ShopCartGames, Formatting.Indented);
            File.WriteAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", "ShopCart.json"), shopCartGamesSerialized);
        }

        public void LoadGameData(string chosenGame)
        {
            List<Game> games = JsonManager.LoadGames();
            Game = games.Where(x => x.Name == chosenGame).FirstOrDefault();

            nametb.Text = Game.Name;
            releasedatetb.Text = Game.PublishYear.ToString("d");
            publishertb.Text = Game.Publisher.Name;
            developertb.Text = Game.Developer.Name;
            describtionTb.Text = Game.Describtion;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", Game.Logo), UriKind.Absolute);
            logo.EndInit();
            gameLogo.Source = logo;

            if(Game.Promotion == 0)
            {
                FirstGamePromotion.Visibility = Visibility.Hidden;
                FirstGameLastPrice.TextDecorations = null;                
                FirstGameLastPrice.Style = this.FindResource("MainTextBlock") as Style;
                FirstGameNewPrice.Visibility = Visibility.Hidden;
            }
            else
            {
                FirstGamePromotion.Text = "-" + (Game.Promotion * 100).ToString() +"%";
                FirstGameNewPrice.Text = (Game.Price - (Game.Price * Game.Promotion)).ToString("F2") + " zł";
            }
            FirstGameLastPrice.Text = Game.Price.ToString() + " zł";
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Videos", Game.Trailer);          
            trailerME.Source = new Uri(path, UriKind.Relative);
            trailerME.Play();

            string shopCartGamesSerialized = File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", "ShopCart.json"));
            ShopCartGames = JsonConvert.DeserializeObject<List<Game>>(shopCartGamesSerialized);
        }

        private void DeveloperButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new DeveloperSite(Game.Name);
        }

        private void PublisherButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new PublisherSite(Game.Name);
        }
    }
}
