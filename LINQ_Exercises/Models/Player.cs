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
        public Gear ActiveGear { get; protected set; }
        public Statiscits Statiscits { get; protected set; }
        public IList<Player> Friends { get; protected set; }
        public int Fights { get; protected set; }

        public Player(string name, Statiscits statistics = null)
        {
            Id = Guid.NewGuid();
            Init(name, statistics);
        }

        public Player(Guid id, string name, Statiscits statistics = null)
        {
            Id = id;
            Init(name, statistics);
        }

        protected void Init(string name, Statiscits statistics = null)
        {
            ActiveGear = new Gear();
            MaxHealth = PlayerConfig.DEFAULT_HEALTH;
            Name = name;
            Inventory = new Inventory();
            Statiscits = statistics ?? Statiscits.GenerateRandom();
            CurrentHealth = PlayerConfig.DEFAULT_HEALTH + (PlayerConfig.DEFAULT_HEALTH * Statiscits.Health / 100);
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
                    target.CurrentHealth = target.CurrentHealth - Statiscits.Strenght * Statiscits.Agility;

                    if (target.CurrentHealth <= 0)
                    {
                        ConsoleEx.Log($"{Name} killed {target.Name}", ConsoleColor.Red);
                    }
                    Statiscits.InceraseRandomly();
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
    }
}
