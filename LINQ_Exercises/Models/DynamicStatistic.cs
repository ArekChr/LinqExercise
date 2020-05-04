using LINQ_Exercises.Models.Items;
using System.Linq;

namespace LINQ_Exercises.Models
{
    public class DynamicStatistic : BasicStatiscits
    {
        public int Damage { get; set; }
        public int Armor { get; set; }

        public void UpdateStatistic(Gear gear, BasicStatiscits BaseStatiscits)
        {
            int currentArmor = 0;
            gear.GetType().GetProperties().ToList().ForEach(prop =>
            {
                if (typeof(DefensiveItem).IsAssignableFrom(prop.PropertyType))
                {
                    var a = (DefensiveItem)prop.GetValue(prop);

                    currentArmor += a.Defence;
                }
            });
            Armor = currentArmor;

            Damage = (int)gear.PrimaryWeapon.Power + BaseStatiscits.Agility * BaseStatiscits.Health;
        }
    }
}
