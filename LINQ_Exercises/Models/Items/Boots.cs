using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Exercises.Models.Items
{
    public class Boots : DefensiveItem
    {
        protected Boots(string name, bool salable) : base(name, salable)
        {
        }
    }
}
