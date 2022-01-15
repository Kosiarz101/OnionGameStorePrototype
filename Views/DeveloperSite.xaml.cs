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
    /// Logika interakcji dla klasy DeveloperSite.xaml
    /// </summary>
    public partial class DeveloperSite : UserControl
    {
        public Game Game { get; set; }
        public DeveloperSite()
        {
            InitializeComponent();
        }
        public DeveloperSite(string chosenGame)
        {
            InitializeComponent();
            Game = JsonManager.LoadGame(chosenGame);
            LoadParameters();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlockBf.Visibility = Visibility.Visible;
            ImageBrushBf.Opacity = 0.5;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlockBf.Visibility = Visibility.Hidden;
            ImageBrushBf.Opacity = 1.0;
        }

        private void LoadParameters()
        {
            Developer developer = Game.Developer;
            developerNameTb.Text = developer.Name;
            foundationDateTb.Text = developer.CreationYear.ToString("d");
            countryTb.Text = developer.Country;
            describtionTb.Text = developer.Describtion;

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", developer.Logo), UriKind.Absolute);
            logo.EndInit();
            developerImage.Source = logo;

            var bc = new BrushConverter();
            borderLogo.Background = (Brush)bc.ConvertFrom(developer.LogoBackgroundColor);
            TextBlockBf.Text = Game.Name + "Series";
            logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", Game.Image), UriKind.Absolute);
            logo.EndInit();
            ImageBrushBf.ImageSource = logo;
        }
    }
}
