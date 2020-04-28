using System;

namespace LINQ_Exercises.Models
{
    public class Gear
    {
        public Weapon PrimaryWeapon { get; protected set; }

        public Gear()
        {

        }

        public void DrawWeapon()
        {
            PrimaryWeapon = Weapon.DrawWeapon();
        }
    }
}
