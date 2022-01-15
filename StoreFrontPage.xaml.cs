using KckProject3.Models;
using KckProject3.ViewModels;
using KckProject3.Views;
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
    /// Logika interakcji dla klasy StoreFrontPage.xaml
    /// </summary>
    public partial class StoreFrontPage : Window
    {
        public int NewestGameCounter { get; set; } = 0;
        public int SpecialOfferGameCounter { get; set; } = 0;
        public List<GameStoreFrontPageModel> NewestGames { get; set; }
        public List<GameStoreFrontPageModel> SpecialOfferGames { get; set; }
        public StoreFrontPage()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            string basePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images");
            NewestGames = new List<GameStoreFrontPageModel>();
            NewestGames.Add(new GameStoreFrontPageModel("Battlefield 2042", 250.00m, basePath + "\\battlefield2042.jpg", 0));
            NewestGames.Add(new GameStoreFrontPageModel("Forza Horizon 5", 220.00m, basePath + "\\forzahorizon5.jfif", 0));
            NewestGames.Add(new GameStoreFrontPageModel("Halo Infinite", 255.00m, basePath + "\\haloinfinite.jpg", 0));
            NewestGames.Add(new GameStoreFrontPageModel("Forza Horizon 5", 220.00m, basePath + "\\forzahorizon5.jfif", 0));
            NewestGames.Add(new GameStoreFrontPageModel("Battlefield 2042", 250.00m, basePath + "\\battlefield2042.jpg", 0));

            SpecialOfferGames = new List<GameStoreFrontPageModel>();
            SpecialOfferGames.Add(new GameStoreFrontPageModel("Prey", 140.99m, basePath + "\\prey.jpg", 60));
            SpecialOfferGames.Add(new GameStoreFrontPageModel("Thief", 79.99m, basePath + "\\thief.jpg", 40));
            SpecialOfferGames.Add(new GameStoreFrontPageModel("Civilization 6", 160.00m, basePath + "\\civilization6.jpg", 50));
            SpecialOfferGames.Add(new GameStoreFrontPageModel("Dirt Rally 2.0", 180.00m, basePath + "\\dirtrally20.jpg", 20));

            Update(FirstGameNewestImage, NewestGameCounter, NewestGames);
            Update(SecondGameNewestImage, (NewestGameCounter + 1) % NewestGames.Count, NewestGames);
            Update(ThirdGameNewestImage, (NewestGameCounter + 2) % NewestGames.Count, NewestGames);

            Update(FirstGameSpecialImage, SpecialOfferGameCounter, SpecialOfferGames);
            Update(SecondGameSpecialImage, (SpecialOfferGameCounter + 1) % SpecialOfferGames.Count, SpecialOfferGames);
            Update(ThirdGameSpecialImage, (SpecialOfferGameCounter + 2) % SpecialOfferGames.Count, SpecialOfferGames);
        }

        private void NewestLeft_Click(object sender, RoutedEventArgs e)
        {
            NewestGameCounter--;
            if(NewestGameCounter < 0)
            {
                NewestGameCounter = NewestGames.Count - 1;
            }
            Update(FirstGameNewestImage, NewestGameCounter, NewestGames);
            Update(SecondGameNewestImage, (NewestGameCounter + 1) % NewestGames.Count, NewestGames);
            Update(ThirdGameNewestImage, (NewestGameCounter + 2) % NewestGames.Count, NewestGames);
        }
        private void ShowDetailsNewest(TextBlock textBlockPrice, TextBlock textBlockTitle, Image image, int index)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(NewestGames[index].Image, UriKind.Absolute);
            logo.EndInit();
            image.Source =  logo;
            textBlockPrice.Text = NewestGames[index].Price.ToString();
            textBlockTitle.Text = NewestGames[index].Name;
        }
        private void Update(Image image, int index, List<GameStoreFrontPageModel> gamesList)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(gamesList[index].Image, UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;
        }

        private void NewestRight_Click(object sender, RoutedEventArgs e)
        {
            NewestGameCounter = (NewestGameCounter + 1) % NewestGames.Count;
            Update(FirstGameNewestImage, NewestGameCounter, NewestGames);
            Update(SecondGameNewestImage, (NewestGameCounter + 1) % NewestGames.Count, NewestGames);
            Update(ThirdGameNewestImage, (NewestGameCounter + 2) % NewestGames.Count, NewestGames);
        }

        private void FirstGameNewest_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowDetailsNewest(FirstGameNewestPrice, FirstGameNewestTitle, FirstGameNewestImage, NewestGameCounter);
        }

        private void FirstGameNewest_MouseLeave(object sender, MouseEventArgs e)
        {
            HideDetails(FirstGameNewestPrice);
            HideDetails(FirstGameNewestTitle);
        }
        private void HideDetails(TextBlock textBlock)
        {
            textBlock.Text = "";
        }

        private void SecondGameNewest_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowDetailsNewest(SecondGameNewestPrice, SecondGameNewestTitle, SecondGameNewestImage, (NewestGameCounter + 1) % NewestGames.Count);
        }

        private void SecondGameNewest_MouseLeave(object sender, MouseEventArgs e)
        {
            HideDetails(SecondGameNewestPrice);
            HideDetails(SecondGameNewestTitle);
        }

        private void ThirdGameNewest_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowDetailsNewest(ThirdGameNewestPrice, ThirdGameNewestTitle, ThirdGameNewestImage, (NewestGameCounter + 2) % NewestGames.Count);
        }

        private void ThirdGameNewest_MouseLeave(object sender, MouseEventArgs e)
        {
            HideDetails(ThirdGameNewestPrice);
            HideDetails(ThirdGameNewestTitle);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewestViewModel();
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryWindow libraryWindow = new LibraryWindow();
            libraryWindow.Show();
            this.Close();
        }
        private void ShowDetailsSpecialOffers(TextBlock textBlockOriginalPrice, TextBlock textBlockPercentage, TextBlock textBlockNewPrice, TextBlock textBlockTitle, Image image, int index)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(SpecialOfferGames[index].Image, UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;
            textBlockOriginalPrice.Text = SpecialOfferGames[index].Price.ToString();
            textBlockTitle.Text = SpecialOfferGames[index].Name;
            textBlockPercentage.Text = "-" + SpecialOfferGames[index].Promotion.ToString() + "%";
            textBlockNewPrice.Text = (SpecialOfferGames[index].Price - SpecialOfferGames[index].Price * (SpecialOfferGames[index].Promotion * 0.01m)).ToString("f2");
        }
        private void SpecialLeft_Click(object sender, RoutedEventArgs e)
        {
            SpecialOfferGameCounter--;
            if (SpecialOfferGameCounter < 0)
            {
                SpecialOfferGameCounter = SpecialOfferGames.Count - 1;
            }
            Update(FirstGameSpecialImage, SpecialOfferGameCounter, SpecialOfferGames);
            Update(SecondGameSpecialImage, (SpecialOfferGameCounter + 1) % SpecialOfferGames.Count, SpecialOfferGames);
            Update(ThirdGameSpecialImage, (SpecialOfferGameCounter + 2) % SpecialOfferGames.Count, SpecialOfferGames);
        }

        private void SpecialRight_Click(object sender, RoutedEventArgs e)
        {
            SpecialOfferGameCounter = (SpecialOfferGameCounter + 1) % SpecialOfferGames.Count;
            Update(FirstGameSpecialImage, SpecialOfferGameCounter, SpecialOfferGames);
            Update(SecondGameSpecialImage, (SpecialOfferGameCounter + 1) % SpecialOfferGames.Count, SpecialOfferGames);
            Update(ThirdGameSpecialImage, (SpecialOfferGameCounter + 2) % SpecialOfferGames.Count, SpecialOfferGames);
        }

        private void FirstGameSpecial_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowDetailsSpecialOffers(FirstGameSpecialOriginalPrice, FirstGameSpecialPercentage, FirstGameSpecialNewPrice, FirstGameSpecialTitle, FirstGameSpecialImage, SpecialOfferGameCounter);
        }

        private void FirstGameSpecial_MouseLeave(object sender, MouseEventArgs e)
        {
            HideDetails(FirstGameSpecialTitle);
            HideDetails(FirstGameSpecialOriginalPrice);
            HideDetails(FirstGameSpecialPercentage);
            HideDetails(FirstGameSpecialNewPrice);
        }

        private void SecondGameSpecial_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowDetailsSpecialOffers(SecondGameSpecialOriginalPrice, SecondGameSpecialPercentage, SecondGameSpecialNewPrice, SecondGameSpecialTitle, 
                SecondGameSpecialImage, (SpecialOfferGameCounter + 1) % SpecialOfferGames.Count);
        }

        private void SecondGameSpecial_MouseLeave(object sender, MouseEventArgs e)
        {
            HideDetails(SecondGameSpecialTitle);
            HideDetails(SecondGameSpecialOriginalPrice);
            HideDetails(SecondGameSpecialPercentage);
            HideDetails(SecondGameSpecialNewPrice);
        }

        private void ThirdGameSpecial_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowDetailsSpecialOffers(ThirdGameSpecialOriginalPrice, ThirdGameSpecialPercentage, ThirdGameSpecialNewPrice, ThirdGameSpecialTitle,
                ThirdGameSpecialImage, (SpecialOfferGameCounter + 2) % SpecialOfferGames.Count);
        }

        private void ThirdGameSpecial_MouseLeave(object sender, MouseEventArgs e)
        {
            HideDetails(ThirdGameSpecialTitle);
            HideDetails(ThirdGameSpecialOriginalPrice);
            HideDetails(ThirdGameSpecialPercentage);
            HideDetails(ThirdGameSpecialNewPrice);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new SpecialOffersViewModel();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            AccountHomePage ahp = new AccountHomePage();
            ahp.Show();
            this.Close();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ShopCartPageViewModel();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            StoreFrontPage storeFrontPage = new StoreFrontPage();
            storeFrontPage.Show();
            this.Close();
        }

        private void FirstGameNewest_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GameHomePage(NewestGames[NewestGameCounter].Name);
        }

        private void SecondGameNewest_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GameHomePage(NewestGames[(NewestGameCounter + 1) % NewestGames.Count].Name);
        }

        private void ThirdGameNewest_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GameHomePage(NewestGames[(NewestGameCounter + 2) % NewestGames.Count].Name);
        }

        private void FirstGameSpecial_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GameHomePage(SpecialOfferGames[(SpecialOfferGameCounter) % SpecialOfferGames.Count].Name);
        }

        private void SecondGameSpecial_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GameHomePage(SpecialOfferGames[(SpecialOfferGameCounter + 1) % SpecialOfferGames.Count].Name);
        }

        private void ThirdGameSpecial_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GameHomePage(SpecialOfferGames[(SpecialOfferGameCounter + 2) % SpecialOfferGames.Count].Name);
        }
    }
}
