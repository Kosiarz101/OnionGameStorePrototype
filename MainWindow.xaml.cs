using KckProject3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KckProject3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MakeAllGames();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

            Publisher publisherEA = new Publisher()
            {
                Name = "Electronics Arts",
                CreationYear = new DateTime(1982, 5, 10)
            };
            Developer developerDice = new Developer()
            {
                Name = "Dice",
                Country = "Sweden",
                Publisher = publisherEA,
                CreationYear = new DateTime(1992, 5, 1)
            };

            //List<Game> ListOfAllGames = new List<Game>();
            //Game battlefield2042 = new Game()
            //{
            //    Name = "Battlefield 2042",
            //    Developer = developerDice,
            //    Publisher = publisherEA,
            //    PublishYear = new DateTime(2021, 11, 19),
            //    Price = 250.0m,
            //    Promotion = 0,
            //    Image = "../Images/battlefield2042.jpg",
            //    Platform = "Windows"
            //};
            //ListOfAllGames.Add(battlefield2042);
            //StoreFrontPage sfp = new StoreFrontPage();
            //sfp.Show();
            //this.Close();
        }

        private void MakeAllGames()
        {
            //Publishers
            Publisher publisherEA = new Publisher()
            {
                Name = "Electronics Arts",
                Country = "United States",
                CreationYear = new DateTime(1982, 5, 10),
                Logo = "eaLogo.png",
                Describtion = "Electronic Arts Inc. (EA) is an American video game company headquartered in Redwood City, California. " +
                "It is the second-largest gaming company in the Americas and Europe by revenue and market capitalization after Activision Blizzard and ahead of Take-Two Interactive, and Ubisoft as of May 2020."
            };
            Publisher squateEnix = new Publisher()
            {
                Name = "Square Enix",
                Country = "Japan",
                CreationYear = new DateTime(1975, 9, 22),
                Logo = "squareEnixLogo.png",
                Describtion = "Square Enix Holdings Co., Ltd.[a] is a Japanese entertainment conglomerate " +
                "and video game company best known for its Final Fantasy, Dragon Quest and Kingdom Hearts " +
                "role-playing video game franchises, among numerous others. Outside of video game publishing and development, it is also in the business of merchandise, " +
                "arcade/amusement facilities and manga publication under its Gangan Comics brand."
            };
            Publisher TwokGames = new Publisher()
            {
                Name = "2k Games",
                Country = "United States",
                CreationYear = new DateTime(2005, 1, 25),
                Logo = "2kGames.png",
                Describtion = "2K is an American video game publisher based in Novato, California. 2K was founded under Take-Two Interactive in January 2005 " +
                "through the 2K Games and 2K Sports labels, following Take-Two Interactive's acquisition of Visual Concepts that same month. Originally based " +
                "in New York City, it moved to Novato in 2007. A third label, 2K Play, was added in September 2007. 2K is governed by David Ismailer as president " +
                "and Phil Dixon as COO. A motion capture studio for 2K is based in Petaluma, California."
            };
            Publisher xboxGamesStudios = new Publisher()
            {
                Name = "Xbox Games Studios",
                Country = "United States",
                CreationYear = new DateTime(2000, 3, 1),
                Logo = "xboxGamesStudiosLogo.png",
                Describtion = "Xbox Game Studios (previously known as Microsoft Studios, Microsoft Game Studios, and Microsoft Games) is an American video game publisher and division of " +
                "Microsoft based in Redmond, Washington. It was established in March 2000, spun out from an internal Games Group, for the development and " +
                "publishing of video games for Microsoft Windows. It has since expanded to include games and other interactive entertainment for the namesake Xbox platforms, " +
                "Windows Mobile and other mobile platforms, and web-based portals."
            };

            //Developers
            Developer developerDice = new Developer()
            {
                Name = "Dice",
                Country = "Sweden",
                Publisher = publisherEA,
                CreationYear = new DateTime(1992, 5, 1), 
                Logo = "dice2.png",
                LogoBackgroundColor = "#4DDABE",
                Describtion = "EA Digital Illusions CE AB (trade name: DICE) is a Swedish video game developer based in Stockholm. The company was founded in 1992 and has been a subsidiary of " +
                "Electronic Arts since 2006. Its releases include the Battlefield, Mirror's Edge and Star Wars Battlefront series. Through their Frostbite Labs division, the company also develops " +
                "the Frostbite game engine."
            };
            Developer playgroundGames = new Developer()
            {
                Name = "Playground Games",
                Country = "England",
                Publisher = xboxGamesStudios,
                CreationYear = new DateTime(2010, 1, 1),
                Logo = "playgroundGames.png",
                LogoBackgroundColor = "#42C548",
                Describtion = "Playground Games Limited is a British video game developer based in Leamington Spa, England. It is known for developing the Forza Horizon series, which is part of the " +
                "larger Forza franchise. In 2018, Playground Games became part of Microsoft Studios (now known as Xbox Game Studios). They are also currently in development of the next game in the Fable series."
            };
            Developer Firaxis = new Developer()
            {
                Name = "Firaxis Games",
                Country = "United States",
                Publisher = TwokGames,
                CreationYear = new DateTime(1996, 5, 1),
                Logo = "firaxisGameLogo.png",
                LogoBackgroundColor = "#AF3131",
                Describtion = "Firaxis Games, Inc. is an American video game developer based in Sparks, Maryland. The company was founded in May 1996 by Sid Meier, Jeff Briggs and " +
                "Brian Reynolds following their departure from MicroProse, Meier's earlier venture. They were acquired by " +
                "Take-Two Interactive in August 2005, and subsequently became part of the publisher's 2K label. Firaxis Games is best known for" +
                " developing the Civilization and XCOM series, as well as many other games bearing Meier's name."
            };
            Developer eidosMontreal = new Developer()
            {
                Name = "Eidos Montreal",
                Country = "Canada",
                Publisher = squateEnix,
                CreationYear = new DateTime(2007, 11, 26),
                Logo = "eidosMontreal.png",
                LogoBackgroundColor = "#31A3AF",
                Describtion = "Eidos-Montréal is a Canadian video game developer based in Montreal. The studio is owned by Square Enix Europe (formerly Eidos Interactive), a subsidiary of Square Enix." +
                "Eidos Interactive announced plans to open a Montreal-based subsidiary studio in February 2007.[1] Eidos-Montréal formally opened with general manager Stéphane D'Astous on 26 November 2007. " +
                "According to D'Astous, unlike other video game development studios, Eidos-Montréal's development cycle as characterized by smaller teams (totalling to 350) working over a longer period."
            };

            //Games
            Game battlefield2042 = new Game()
            {
                Name = "Battlefield 2042",
                Developer = developerDice,
                Publisher = publisherEA,
                PublishYear = new DateTime(2021, 11, 19),
                Price = 250.0m,
                Promotion = 0,
                Image = "battlefield2042.jpg",
                Platform = "Windows",
                Trailer = "../Videos/bfTrailer.mp4",
                Logo = "battlefield2042Logo.png",
                Describtion = "Battlefield ™ 2042 is a first-person shooter that brings back the all-out war that this iconic series of games is famous for. In the future, the world order was shaken. " +
                "Changing battlefields require adaptation and overcoming difficulties with the help of your squad and modern arsenal."
            };
            Game forzaHorizon = new Game()
            {
                Name = "Forza Horizon 5",
                Developer = playgroundGames,
                Publisher = xboxGamesStudios,
                PublishYear = new DateTime(2021, 11, 4),
                Price = 220.0m,
                Promotion = 0,
                Image = "forzahorizon5.jfif",
                Platform = "Windows",
                Trailer = "../Videos/forzaTrailer_01.mp4",
                Logo = "forzaLogo.png",
                Describtion = "Your greatest Horizon adventure awaits. " + 
                       "Travel through Mexico's bustling open world and enjoy the scenery while driving the world's best cars. " +
                       "Get started with Horizon today by adding the game to your wishlist."
            };
            //Game prey = new Game()
            //{
            //    Name = "Prey",
            //    Developer = developerDice,
            //    Publisher = publisherEA,
            //    PublishYear = new DateTime(2021, 11, 4),
            //    Price = 220.0m,
            //    Promotion = 0,
            //    Image = "forzahorizon5.jfif",
            //    Platform = "Windows",
            //    Trailer = "../Videos/forzaTrailer_01.mp4",
            //    Logo = "forzaLogo.png",
            //    Describtion = "Your greatest Horizon adventure awaits. " +
            //           "Travel through Mexico's bustling open world and enjoy the scenery while driving the world's best cars. " +
            //           "Get started with Horizon today by adding the game to your wishlist."
            //};
            Game thief = new Game()
            {
                Name = "Thief",
                Developer = eidosMontreal,
                Publisher = squateEnix,
                PublishYear = new DateTime(2014, 2, 25),
                Price = 79.99m,
                Promotion = 0.4m,
                Image = "thief.jpg",
                Platform = "Windows",
                Trailer = "../Videos/thiefTrailer.mp4",
                Logo = "thiefLogo.png",
                Describtion = "Garrett, the Master Thief, steps out of the shadows into the City. In this treacherous place, where the Baron’s Watch spreads a rising tide of fear and oppression, " +
                "his skills are the only things he can trust. Even the most cautious citizens and their best-guarded possessions are not safe from his reach."
            };
            Game civilization6 = new Game()
            {
                Name = "Civilization 6",
                Developer = Firaxis,
                Publisher = TwokGames,
                PublishYear = new DateTime(2016, 10, 21),
                Price = 160.0m,
                Promotion = 0.5m,
                Image = "civilization6.jpg",
                Platform = "Windows",
                Trailer = "../Videos/civTrailer.mp4",
                Logo = "civ6Logo.png",
                Describtion = "Civilization VI provides brand new opportunities to interact with the world, expand your empire's boundaries, advance your culture, and compete with " +
                "history's greatest leaders in the struggle to create a civilization that will stand the test of time."
            };
            List<Game> games = new List<Game>()
            {
                battlefield2042, forzaHorizon, civilization6, thief
            };
            string gamesSerialized = JsonConvert.SerializeObject(games, Formatting.Indented);
            File.WriteAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database/GameDatabase.json"), gamesSerialized);
        }
    }
}
