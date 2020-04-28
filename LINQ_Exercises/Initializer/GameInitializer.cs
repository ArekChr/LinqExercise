using System.IO;
using System.Linq;
using System.Net;
using LINQ_Exercises.Models;
using Newtonsoft.Json;
using LINQ_Exercises.Extensions;

namespace LINQ_Exercises.Initializer
{
    public static class GameInitializer
    {
        public static Game Initialize(this Game game)
        {
            ConsoleEx.Log("Initializing new game...", System.ConsoleColor.Green);
            var users = GetUsers(10000).ToList();
            game.Players = users.Select(u => new Player(u)).ToList();
            ConsoleEx.Log($"Created {users.Count()} users.", System.ConsoleColor.Green);
            return game;
        }

        public static string[] GetUsers(int amount)
        {
            string rt;
            var url = string.Format("http://names.drycodes.com/{0}?nameOptions=games", amount);
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            rt = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return JsonConvert.DeserializeObject<string[]>(rt);
        }

        public static Game WithCurrentPlayer(this Game game)
        {
            game.You = new Player(CurrentPlayer.Name, new Statiscits(
                CurrentPlayer.Strenght,
                CurrentPlayer.Stamina,
                CurrentPlayer.Health,
                CurrentPlayer.Agility
            ));
            ConsoleEx.Log($"Current player {game.You.Name} has been created.", System.ConsoleColor.Green);
            return game;
        }
    }
}
