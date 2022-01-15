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
    /// Logika interakcji dla klasy BuyGameSecondScreen.xaml
    /// </summary>
    public partial class BuyGameSecondScreen : UserControl
    {
        private string placeHolder = "XXXX-XXXX-XXXX-XXXX";
        public BuyGameSecondScreen()
        {
            InitializeComponent();
            CardDetails.Text = placeHolder;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new BuyGameFirstScreen();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].DataContext = new BuyGameThirdScreen();
        }

        private void CardDetails_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(CardDetails.Text == placeHolder)
            {
                CardDetails.Text = "";
                CardDetails.Foreground = new SolidColorBrush(Colors.Black);
            }           
        }
    }
}
