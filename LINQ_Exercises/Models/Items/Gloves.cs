using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Exercises.Models.Items
{
    public class Gloves : DefensiveItem
    {
        protected Gloves(string name, bool salable) : base(name, salable)
        {
        }
    }
}
