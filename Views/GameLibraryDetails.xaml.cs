using KckProject3.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KckProject3.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameLibraryDetails.xaml
    /// </summary>
    public partial class GameLibraryDetails : UserControl
    {
        public Game Game { get; set; }
        public GameLibraryDetails()
        {
            InitializeComponent();
        }
        public GameLibraryDetails(Game game)
        {
            InitializeComponent();
            Game = game;
            SetGameDetails();
        }
        private void SetGameDetails()
        {
            GameTitle.Text = Game.Name;
            GameDeveloper.Text = Game.Developer.Name;
            GamePublisher.Text = Game.Publisher.Name;
            GameYear.Text = Game.PublishYear.ToString("d");
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", Game.Image), UriKind.Absolute);
            image.EndInit();
            GameCover.Source = image;

            Random random = new Random();
            int achievements = random.Next(14, 60);
            TimePlayedTB.Text = "0.00 h";
            TimePlayedTB.FontWeight = FontWeights.Bold;
            AchievementsTB.Text = "0/" + achievements.ToString();
            AchievementsTB.FontWeight = FontWeights.Bold;
        }
    }
}
