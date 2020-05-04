using System;
using LINQ_Exercises.Mock;
using LINQ_Exercises.Extensions;

namespace LINQ_Exercises.Models.Items
{
    public class Weapon : Item
    {
        protected Weapon(float power, string name, bool selable) : base(name, selable)
        {
            Power = power;
        }

        public float Power { get; protected set; }

        public static Weapon DrawWeapon()
        {
            var rnd = new Random();
            var randomWeaponName = MockWeapons.Data[rnd.Next(0, MockWeapons.Data.Length)];
            ConsoleEx.Log($"Generated new weapon: {randomWeaponName}", ConsoleColor.Yellow);
            return new Weapon(rnd.Next(30, 100),randomWeaponName , false);
        }
    }
}
