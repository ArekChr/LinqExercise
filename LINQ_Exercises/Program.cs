using System;
using LINQ_Exercises.Initializer;

namespace LINQ_Exercises
{
    public static class CurrentPlayer
    {
        public static Guid Id = Guid.Empty;
        public static string Name = "Patrycja";
        public static int Strenght = 40;
        public static int Stamina = 20;
        public static int Health = 20;
        public static int Agility = 20;
    }

    class Program
    {
        static void Main(string[] args)
            => new Game().Initialize().WithCurrentPlayer().Start();
    }
}
