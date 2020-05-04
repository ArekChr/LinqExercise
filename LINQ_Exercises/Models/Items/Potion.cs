using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Exercises.Models.Items
{
    public class Potion : Item
    {
        protected Potion(string name, bool salable) : base(name, salable)
        {
        }
    }
}
