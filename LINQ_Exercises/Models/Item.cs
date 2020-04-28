using System;

namespace LINQ_Exercises.Models
{
    public class Item
    {
        protected Item(string name, bool salable)
        {
            Name = name;
            Salable = salable;
        }

        public string Name { get; protected set; }
        public bool Salable { get; protected set; }

    }
}
