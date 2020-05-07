using System;
using System.Collections.Generic;
using LINQ_Exercises.Config;
using LINQ_Exercises.Models.Items;

namespace LINQ_Exercises.Models
{
    public class Inventory
    {
        public int NumberOfSlots { get; protected set; }

        public IList<Item> Items { get; protected set; }

        public Inventory()
        {
            NumberOfSlots = PlayerConfig.DEFAULT_NUMBER_OF_SLOTS;
        }
    }
}
