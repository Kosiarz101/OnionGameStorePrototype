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
    /// Logika interakcji dla klasy SpecialOffers.xaml
    /// </summary>
    public partial class SpecialOffers : UserControl
    {
        public SpecialOffers()
        {
            InitializeComponent();
            ChangeImageSource(PreyImage, "prey.jpg");
            ChangeImageSource(PreyImage2, "prey.jpg");
            ChangeImageSource(ThiefImage, "thief.jpg");
            ChangeImageSource(ThiefImage2, "thief.jpg");
            ChangeImageSource(Civilization6Image, "civilization6.jpg");
            ChangeImageSource(Civilization6Image2, "civilization6.jpg");
            ChangeImageSource(Dirt20Image, "dirtrally20.jpg");
            ChangeImageSource(Dirt20Image2, "dirtrally20.jpg");
        }

        private void PreyButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new GameHomePage("Prey");
        }    

        private void Civilization6Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new GameHomePage("Civilization 6");
        }

        private void ChangeImageSource(Image image, string imagePath)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", imagePath), UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;
        }

        private void ThiefButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new GameHomePage("Thief");
        }
    }
}
