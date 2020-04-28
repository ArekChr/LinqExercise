
using LINQ_Exercises.Models;

namespace LINQ_Exercises.DTOs
{
    public class PlayerStatistic
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public PlayerStatistic(Player player)
        {
            Name = player.Name;
            Points = player.CurrentHealth * player.Statiscits.Agility * player.Statiscits.Strenght * player.Statiscits.Stamina * player.Statiscits.Health * player.Fights;
        }
    }
}
