using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logika interakcji dla klasy LanguagePreferences.xaml
    /// </summary>
    public partial class LanguagePreferences : UserControl
    {
        public LanguagePreferences()
        {
            InitializeComponent();
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string[] languageListPreModified = File.ReadAllLines(System.IO.Path.Combine(basePath, "Database/LanguageList.txt"));
            string[] languageList = new string[languageListPreModified.Length * 2];
            for (int i = 0; i < languageListPreModified.Length; i++)
            {
                string[] current = languageListPreModified[i].Split("\t");
                languageList[i] = current[1];
                ComboBox.Items.Add(languageList[i]);
            }
            ComboBox.SelectedItem = "Polish";
            List<string> currencyList = new List<string>()
            {
                "PLN",  "USD", "EUR", "RUB", "GBP", "JPY", "CHF", "MXN", "INR"
            };
            foreach(string currency in currencyList)
            {
                ComboBox2.Items.Add(currency);
            }
            ComboBox2.SelectedItem = "PLN";
        }
    }
}
