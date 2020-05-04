using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Exercises.Models.Items
{
    public class Necklace : Item
    {
        protected Necklace(string name, bool salable) : base(name, salable)
        {
        }
    }
}
