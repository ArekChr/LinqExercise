using System;
using LINQ_Exercises.Config;

namespace LINQ_Exercises.Models
{
    public class Inventory
    {
        public int NumberOfSlots { get; protected set; }

        public Inventory()
        {
            NumberOfSlots = PlayerConfig.DEFAULT_NUMBER_OF_SLOTS;
        }
    }
}
