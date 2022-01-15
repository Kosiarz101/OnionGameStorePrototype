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
    /// Logika interakcji dla klasy Newest.xaml
    /// </summary>
    public partial class Newest : UserControl
    {
        public Newest()
        {
            InitializeComponent();
            ChangeImageSource(Battlefield2042Image, "battlefield2042.jpg");
            ChangeImageSource(Battlefield2042Image2, "battlefield2042.jpg");
            ChangeImageSource(Battlefield2042Image3, "battlefield2042.jpg");
            ChangeImageSource(Battlefield2042Image4, "battlefield2042.jpg");
            ChangeImageSource(Battlefield2042Image5, "battlefield2042.jpg");
            ChangeImageSource(Battlefield2042Image6, "battlefield2042.jpg");
            ChangeImageSource(ForzaHorizon5Image, "forzahorizon5.jfif");
            ChangeImageSource(HaloInfiniteImage, "haloinfinite.jpg");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Battlefield2042_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new GameHomePage("Battlefield 2042");
        }

        private void ForzaHorizon5_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new GameHomePage("Forza Horizon 5");
        }
        private void ChangeImageSource(Image image, string imagePath)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", imagePath), UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;
        }
    }
}
