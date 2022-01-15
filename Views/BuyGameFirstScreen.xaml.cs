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
    /// Logika interakcji dla klasy BuyGameFirstScreen.xaml
    /// </summary>
    public partial class BuyGameFirstScreen : UserControl
    {
        private Style ButtonStandardStyle;
        private Style ButtonCheckedStyle;

        public BuyGameFirstScreen()
        {
            InitializeComponent();
            ButtonStandardStyle = this.FindResource("ButtonStandard") as Style;
            ButtonCheckedStyle = this.FindResource("ButtonChecked") as Style;
            LoadParameters();
        }

        private void PayPalButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (PayPalButton.Style == ButtonStandardStyle)
                PayPalButton.Style = ButtonCheckedStyle;
            ChosenPaymentMethodTb.Text = "PayPal";
        }

        private void VisaButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (VisaButton.Style == ButtonStandardStyle)
                VisaButton.Style = ButtonCheckedStyle;
            ChosenPaymentMethodTb.Text = "Visa";
        }

        private void MasterCardButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (MasterCardButton.Style == ButtonStandardStyle)
                MasterCardButton.Style = ButtonCheckedStyle;
            ChosenPaymentMethodTb.Text = "Master Card";
        }

        private void PaySafeCardButton_Click(object sender, RoutedEventArgs e)
        {
            ResetAllButtons();
            if (PaySafeCardButton.Style == ButtonStandardStyle)
                PaySafeCardButton.Style = ButtonCheckedStyle;
            ChosenPaymentMethodTb.Text = "PaySafeCard";
        }

        private void LoadParameters()
        {
            ChangeImageSource(PayPalImage, "paypalLogo.png");
            ChangeImageSource(VisaImage, "visaLogo.png");
            ChangeImageSource(MasterCardImage, "mastercardLogo.png");
            ChangeImageSource(PaySafeCardImage, "paysafecardLogo.png");
        }

        private void ChangeImageSource(Image image, string imagePath)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", imagePath), UriKind.Absolute);
            logo.EndInit();
            image.Source = logo;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new BuyGameSecondScreen();
        }
        private void ResetAllButtons()
        {
            PayPalButton.Style = ButtonStandardStyle;
            VisaButton.Style = ButtonStandardStyle;
            MasterCardButton.Style = ButtonStandardStyle;
            PaySafeCardButton.Style = ButtonStandardStyle;
        }
    }
}
