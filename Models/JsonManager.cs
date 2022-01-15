using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KckProject3.Models
{
    public static class JsonManager
    {
        public static List<Game> LoadGames(string database = "GameDatabase.json")
        {
            string shopCartGamesSerialized = File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", database));
            return JsonConvert.DeserializeObject<List<Game>>(shopCartGamesSerialized);
        }
        public static Game LoadGame(string chosenGame)
        {
            List<Game> games = LoadGames();
            return games.Where(x => x.Name == chosenGame).FirstOrDefault();            
        }
        public static void SaveGames(List<Game> gamesList, string database = "GameDatabase.json")
        {
            string gamesSerialized = JsonConvert.SerializeObject(gamesList, Formatting.Indented);
            File.WriteAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", database), gamesSerialized);
        }
        public static void AddGamesToLibrary(List<Game> gamesList)
        {
            List<Game> gamesLibrary = LoadGames("GameLibrary.json");
            foreach(Game game in gamesList)
            {
                gamesLibrary.Add(game);
            }
            string gamesSerialized = JsonConvert.SerializeObject(gamesLibrary, Formatting.Indented);
            File.WriteAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Database", "GameLibrary.json"), gamesSerialized);
        }
    }
}
