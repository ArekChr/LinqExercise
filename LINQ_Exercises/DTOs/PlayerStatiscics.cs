
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
            Points = player.CurrentHealth * player.BaseStatiscits.Agility * player.BaseStatiscits.Strenght * player.BaseStatiscits.Stamina * player.BaseStatiscits.Health * player.Fights;
        }
    }
}
