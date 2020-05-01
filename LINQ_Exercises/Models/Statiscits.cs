using System;
using LINQ_Exercises.Config;
using LINQ_Exercises.Extensions;

namespace LINQ_Exercises.Models
{
    public class Statiscits
    {
        public int Strenght { get; protected set; }
        public int Stamina { get; protected set; }
        public int Health { get; protected set; }
        public int Agility { get; protected set; }

        public int FreePoints { get; protected set; }

        public Statiscits()
        {

        }

        public static Statiscits GenerateRandom()
        {
            var rnd = new Random();
            int a = rnd.Next(0, 30);
            int b = rnd.Next(0, 30);
            int c = rnd.Next(0, 30);
            int d = rnd.Next(0, 30);
            return new Statiscits(a, b, c, d);
        }

        public Statiscits(int strenght, int stamina, int health, int agility)
        {
            FreePoints = PlayerConfig.DEFAULT_FREE_POINTS;
            if (strenght < FreePoints) {
                Strenght = strenght;
                FreePoints -= strenght;
            }
            else {
                Strenght = FreePoints;
                FreePoints = 0;
            }

            if (stamina < FreePoints)
            {
                Stamina = stamina;
                FreePoints -= stamina;
            }
            else
            {
                Stamina = FreePoints;
                FreePoints = 0;
            }

            if (health < FreePoints)
            {
                Health = health;
                FreePoints -= health;
            }
            else
            {
                Health = FreePoints;
                FreePoints = 0;
            }

            if (agility < FreePoints)
            {
                Agility = agility;
                FreePoints -= agility;
            }
            else
            {
                Agility = FreePoints;
                FreePoints = 0;
            }
        }


        public void InceraseRandomly()
        {
            var rnd = new Random().Next(0, 3);
            switch (rnd)
            {
                case 0: Strenght++; break;
                case 1: Stamina++; break;
                case 2: Health++; break;
                case 3: Agility++; break;
            }
        }

        public void InceraseStrenght()
        {
            if (FreePoints > 0)
            {
                Strenght++;
                FreePoints--;
            }
            else
            {
                StatsError();
            }
        }

        public void InceraseStamina()
        {
            if (FreePoints > 0)
            {
                Stamina++;
                FreePoints--;
            }
            else
            {
                StatsError();
            }
        }

        public void InceraseHealth()
        {
            if (FreePoints > 0)
            {
                Health++;
                FreePoints--;
            }
            else
            {
                StatsError();
            }
        }

        public void InceraseAgility()
        {
            if (FreePoints > 0)
            {
                Agility++;
                FreePoints--;
            }
            else
            {
                StatsError();
            }
        }

        private void StatsError () => ConsoleEx.Error("You don't have free points to increment stats.");
    }
}
