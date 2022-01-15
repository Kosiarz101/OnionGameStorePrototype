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
    /// Logika interakcji dla klasy PublisherSite.xaml
    /// </summary>
    public partial class PublisherSite : UserControl
    {
        public Game Game { get; set; }
        public PublisherSite()
        {
            InitializeComponent();
        }
        public PublisherSite(string chosenGame)
        {
            InitializeComponent();
            Game = JsonManager.LoadGame(chosenGame);
            LoadParameters();
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlockDeveloper.Visibility = Visibility.Visible;
            ImageBrushBf2.Opacity = 0.5;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlockDeveloper.Visibility = Visibility.Hidden;
            ImageBrushBf2.Opacity = 1.0;
        }

        private void LoadParameters()
        {
            Publisher publisher = Game.Publisher;
            nametb.Text = publisher.Name;
            datetb.Text = publisher.CreationYear.ToString("d");
            countrytb.Text = publisher.Country;
            describtiontb.Text = publisher.Describtion;

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", publisher.Logo), UriKind.Absolute);
            logo.EndInit();
            logoPublisher.Source = logo;

            var bc = new BrushConverter();
            //BorderDeveloper.Background = (Brush)bc.ConvertFrom(Game.Developer.LogoBackgroundColor);
            BorderPublisher.Background = (Brush)bc.ConvertFrom(Game.Publisher.LogoBackgroundColor);
            TextBlockDeveloper.Text = Game.Developer.Name;
            BitmapImage logo2 = new BitmapImage();
            logo2.BeginInit();
            logo2.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", Game.Developer.Logo), UriKind.Absolute);
            logo2.EndInit();
            ImageBrushBf2.ImageSource = logo2;
        }

        private void BorderDeveloper_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new DeveloperSite(Game.Name);
        }
    }
}
