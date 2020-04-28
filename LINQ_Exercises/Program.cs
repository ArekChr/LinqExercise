using System;
using LINQ_Exercises.Initializer;

namespace LINQ_Exercises
{
    public static class CurrentPlayer
    {
        public static Guid Id = Guid.Empty;
        public static string Name = "Aras";
        public static int Strenght = 40;
        public static int Stamina = 0;
        public static int Health = 45;
        public static int Agility = 15;
    }

    class Program
    {
        static void Main(string[] args)
            => new Game().Initialize().WithCurrentPlayer().Start();
    }
}
