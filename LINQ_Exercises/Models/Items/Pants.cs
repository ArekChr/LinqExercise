using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Exercises.Models.Items
{
    public class Pants : DefensiveItem
    {
        protected Pants(string name, bool salable) : base(name, salable)
        {
        }
    }
}
