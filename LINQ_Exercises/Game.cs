using System.Collections.Generic;
using LINQ_Exercises.Models;
using LINQ_Exercises.Core;
using System.Linq;

namespace LINQ_Exercises
{
    public class Game : GameCore
    {
        public List<Player> Players;
        public Player You;

        public override void Start()
        {
            base.Start();

            // uzywaj tylko LINQ, nie uzywaj for, foreach, while itd.
            // zadania rozwiązuj pod komentarzami.

            // 1. wygeneruj dla wszystkich uzytkownikow broń {PrimaryWeapon}

            // 2. zaatakuj 300 uzytkownikami 300 innych uzytkownikow.

            // 3. pobrac 100 uzytkownikow ktorzy maja najmniej {CurrentHealth}.

            // 4. posortowac wszystkich uzytkowników po poziomie {CurrentHealth} malejąco.

            // 5. wyświetlic ostatnio posortowanych 100 uzytkownikow uzywajac petli z LINQ.

            // 6. dodaj do znajomych 15 uzytkownikow z najwieksza iloscia {CurrentHealth}

            // 7. dodaj do znajomych 10 uzytkownikow z najwiekszą ilościa statystyki {Agility}.

            // 8. dodaj do znajomych 5 randomowych uzytkownikow

            // 9. usuń ze znajomych uzytkownika z najgorszą ilością {CurrentHealth}

            // 10. pogrupuj uzytkownikow po takich samych broniach {PrimaryWeapon}

            // 11. wyswietl sume powtarzalnych broni z pogrupowanej powyzej listy {PrimaryWeapon}

            // 12. wyswietl top 100 graczy uzywajac modelu PlayerStatiscic w folderze DTOs, lista musi byc posortowana po punktach malejąco {Points}

            // 13. zamien 500 randomowym uzytkownikom broń na inna randomową broń

            // 14. znajdz 10 uzytkownikow z najwieksza iloscia zycia, oraz z najwieksza iloscia stoczonych walk {Fights}

            // 15. zaatakuj 10-cioma uzytkownikami 10 innych uzytkownikow 10 razy

            // 16. wyświetl przegranych uzytkownikow jesli tacy są CurrentHealth < 0

            // 17. Przepisz konstruktor na get i set w statystykach.

            // 18. Sprawdź czy {You} wystepuje w liscie {Players}. (Contains)

            // 19. Wyświetl średnią ilość żyć wszystkich graczy

            // 20. Wyświetl średnią ilość agility wszystkich graczy

            // 21. Wyświetl gracza który posiada najwiekszą ilosc jednej z statystyk

            // 22. Utwórz i dodaj nowego gracza na początku sekwencji/listy

            // 23. Usuń wszystkich graczy którzy posiadają broń "Amnesia" oraz wyświetl liczbe usuniętych graczy

            // 24. Wyświetl całkowitą liczbe stoczonych walk wszystkich graczy (pojedyncza liczba)

            // 26. Zmodyfikuj model playera o date zgonu

            // 25. Spróbuj zabić jednego uzytkownika

            // 27. Wyświetl wszystkie informacje powyższego uzytkownika, uwzgledniając date zgonu.

            // 28. Usuń połowe graczy z najsłabszym hp {CurrentHealth}

            // 29. Sprawdź czy jakiś uzytkonik ma w znajomych zgona.
        }
    }
}
