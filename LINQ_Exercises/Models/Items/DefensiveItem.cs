namespace LINQ_Exercises.Models.Items
{
    public class DefensiveItem : Item
    {
        protected DefensiveItem(string name, bool salable) : base(name, salable)
        {
        }

        public int Defence { get; set; }
    }
}
