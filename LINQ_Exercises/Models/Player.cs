using System.Collections.Generic;
using LINQ_Exercises.Config;
using System;
using LINQ_Exercises.Extensions;

namespace LINQ_Exercises.Models
{
    public class Player
    {
        private int _currentHealth;
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                if(value <= 0 && _currentHealth > 0)
                {
                    ConsoleEx.Log($"Player {Name} dead...", ConsoleColor.DarkRed);
                }
                _currentHealth = value;
            }
        }
        public int MaxHealth { get; protected set; }
        public Inventory Inventory { get; protected set; }
        private Gear _activeGear;
        public Gear ActiveGear
        { 
            get
            {
                return _activeGear;
            }
            protected set
            {
                _activeGear = value;
                if(BaseStatiscits != null && value != null && CurrentStatistics != null)
                {
                    CurrentStatistics.UpdateStatistic(value, BaseStatiscits);
                }
            }
        }
        private BasicStatiscits _baseStatiscits;
        public BasicStatiscits BaseStatiscits
        {
            get 
            {
                return _baseStatiscits;
            }
            protected set
            {
                _baseStatiscits = value;
                if(ActiveGear != null && value != null && CurrentStatistics != null)
                {
                    CurrentStatistics.UpdateStatistic(ActiveGear, value);
                }
            }
        }
        public DynamicStatistic CurrentStatistics { get; protected set; }
        public List<Player> Friends { get; protected set; }
        public int Fights { get; protected set; }

        public Player(string name, BasicStatiscits statistics = null)
        {
            Id = Guid.NewGuid();
            Init(name, statistics);
        }

        public Player(Guid id, string name, BasicStatiscits statistics = null)
        {
            Id = id;
            Init(name, statistics);
           
        }

        protected void Init(string name, BasicStatiscits statistics = null)
        {
            ActiveGear = new Gear();
            Name = name;
            Inventory = new Inventory();
            BaseStatiscits = statistics ?? BasicStatiscits.GenerateRandom();
            MaxHealth = PlayerConfig.DEFAULT_HEALTH + (PlayerConfig.DEFAULT_HEALTH * BaseStatiscits.Health / 100);
            CurrentHealth = PlayerConfig.DEFAULT_HEALTH + (PlayerConfig.DEFAULT_HEALTH * BaseStatiscits.Health / 100);
            Friends = new List<Player>();

            ConsoleEx.Log($"Created new player: {Name}", ConsoleColor.Magenta);
        }

        public void Attack(Player target)
        {
            if(ActiveGear.PrimaryWeapon != null)
            {
                if (target.CurrentHealth > 0)
                {
                    ConsoleEx.Log($"{Name} has attacked {target.Name}", ConsoleColor.Magenta);
                    ConsoleEx.Log($"{target.Name}'s have {target.CurrentHealth} health.", ConsoleColor.Magenta);
                    target.CurrentHealth = target.CurrentHealth - BaseStatiscits.Strenght * BaseStatiscits.Agility;

                    if (target.CurrentHealth <= 0)
                    {
                        ConsoleEx.Log($"{Name} killed {target.Name}", ConsoleColor.Red);
                    }
                    BaseStatiscits.InceraseRandomly();
                    Fights++;
                }
                else
                {
                    ConsoleEx.Log($"{target.Name} is already dead", ConsoleColor.DarkYellow);
                };
            } else
            {
                if(CurrentPlayer.Id == Id)
                {
                    ConsoleEx.Log($"You {Name} don't have weapon to attack.", ConsoleColor.Red);
                } else
                {
                    ConsoleEx.Log($"{Name} has no weapon to attack.", ConsoleColor.Red);
                }
            }
        }

        public void AddFriends(IList<Player> newfriends)
        {
            Friends.AddRange(newfriends);
        }
    }
}
