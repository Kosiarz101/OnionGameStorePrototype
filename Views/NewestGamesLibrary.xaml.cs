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
    /// Logika interakcji dla klasy NewestGamesLibrary.xaml
    /// </summary>
    public partial class NewestGamesLibrary : UserControl
    {
        public List<Game> GameList { get; set; }
        public NewestGamesLibrary()
        {
            InitializeComponent();
            GameList = JsonManager.LoadGames("GameLibrary.json");
            FirstGame.Visibility = Visibility.Hidden;
            SecondGame.Visibility = Visibility.Hidden;
            ThirdGame.Visibility = Visibility.Hidden;
            FourthGame.Visibility = Visibility.Hidden;
            FifthGame.Visibility = Visibility.Hidden;
            SixthGame.Visibility = Visibility.Hidden;
            LoadGames();
        }
        private void LoadGames()
        {
            try
            {
                SetGameImage(FirstGameImage, GameList[0]);
                FirstGame.Visibility = Visibility.Visible;
                SetGameImage(SecondGameImage, GameList[1]);
                SecondGame.Visibility = Visibility.Visible;
                SetGameImage(ThirdGameImage, GameList[2]);
                ThirdGame.Visibility = Visibility.Visible;
                SetGameImage(FourthGameImage, GameList[3]);
                FourthGame.Visibility = Visibility.Visible;
                SetGameImage(FifthGameImage, GameList[4]);
                FifthGame.Visibility = Visibility.Visible;
                SetGameImage(SixthGameImage, GameList[5]);
                SixthGame.Visibility = Visibility.Visible;
            }
            catch(ArgumentOutOfRangeException e)
            {

            }
            
        }
        private void ShowGameDetails(TextBlock title, TextBlock developer, Game game)
        {
            title.Text = game.Name;
            developer.Text = game.Developer.Name;
        }
        private void HideGameDetails(TextBlock title, TextBlock developer)
        {
            title.Text = "";
            developer.Text = "";
        }
        private void SetGameImage(Image image, Game game)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", game.Image), UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;
        }

        private void FirstGame_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowGameDetails(FirstGameTitle, FirstGameDeveloper, GameList[0]);
        }

        private void FirstGame_MouseLeave(object sender, MouseEventArgs e)
        {
            HideGameDetails(FirstGameTitle, FirstGameDeveloper);
        }

        private void SecondGame_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowGameDetails(SecondGameTitle, SecondGameDeveloper, GameList[1]);
        }

        private void SecondGame_MouseLeave(object sender, MouseEventArgs e)
        {
            HideGameDetails(SecondGameTitle, SecondGameDeveloper);
        }

        private void FirstGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SecondGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThirdGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThirdGame_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ThirdGame_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FourthGame_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void FourthGame_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FourthGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FifthGame_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FifthGame_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void FifthGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SixthGame_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void SixthGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SixthGame_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
