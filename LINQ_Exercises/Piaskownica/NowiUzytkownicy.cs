using System;

namespace LINQ_Exercises
{
    public class NowiUzytkownicy
    {
        public int Wiek { get; set; }
        public string FirstName { get; set; }
        public NowiUzytkownicy(string firstName)
        {
            FirstName = firstName;
            LosujWiek();
        }

        public NowiUzytkownicy()
        {
            LosujWiek();
        }

        private void LosujWiek()
        {
            Wiek = new Random().Next(18, 60);
        }
    }
}
