using LINQ_Exercises.Models.Items;

namespace LINQ_Exercises.Models
{
    public class Gear
    {
        public Weapon PrimaryWeapon { get; protected set; }
        public Armor Armor { get; set; }
        public Boots Boots { get; set; }
        public Gloves Gloves { get; set; }
        public Helmet Helmet { get; set; }
        public Pants Pants { get; set; }
        public Necklace Necklace { get; set; }
        public Ring RingOne { get; set; }
        public Ring RingTwo { get; set; }

        public Gear()
        {

        }

        public void DrawWeapon()
        {
            PrimaryWeapon = Weapon.DrawWeapon();
        }
    }
}
