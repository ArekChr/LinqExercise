using System.Collections.Generic;
using LINQ_Exercises.Models;
using LINQ_Exercises.Core;
using System.Linq;
using System;
using LINQ_Exercises.Extensions;
using LINQ_Exercises.DTOs;
using LINQ_Exercises.Config;

namespace LINQ_Exercises
{

    public class Game : GameCore
    {
        public static List<Player> Players { get; set; }
        public static Player You;

        public override void Start()
        {
            base.Start();
            // 1. wygeneruj dla wszystkich uzytkownikow broń {DrawWeapon}

            // WeaponService.GenerateWeaponForPlayers(LIst<Players> players)
            // WeaponService.GenerateWeaponForAllPlayers()

            // albo weapon service dostaje sie do wszystkich playerow poprzez Game.Players, albo wprowazdasz konkretnych playerow w parametr dla ktorych wygenerujesz bronie
            // zrob tak i tak

            Players.ForEach(x => x.ActiveGear.DrawWeapon());

            // 2. zaatakuj 30 uzytkownikami 30 innych uzytkownikow.

            // PlayerService 
            // parametrem ma byc ilosc uzytkownikow nic wiecej.
            // _playerService.PrepareAttack(int userCount); <- 30

            // rozwiazanie pierwsze w jednej lini LINQ
            int indexOfiar = 0;
            Players.Take(30)
                    .ToList()
                    .ForEach(x => x.Attack(Players.Skip(30).ToArray()[indexOfiar++]));


            var psiontgraczy = from p in Players where p.CurrentHealth > 10000 select p;
            var psiontgracz2 = Players.Where(p => p.CurrentHealth > 10000);

            // 2.1 pobierz 30 graczy bez LINQ

            // PlayerService Browse()
            // niech browse dziala tak ze mozna pobrac wszystkich jesli nie podamy zadnego argumentu (parametru) 
            // jesli podamy to ma byc ilosc ludzi do pobrania np 30
            // Browse() Browse(30)

            // Player[] trzydziesciGraczy = new Player[30];
            List<Player> trzydziesciGraczy = new List<Player>();
            for (int i = 0; Players.Count < 30; i++)
            {
                trzydziesciGraczy.Add(Players[i]);
            }

            // Inne rozwiazania:

            // przygotowanie listy graczy
            var trzydziesciGraczyGotowychDoAtaku = Players.Take(30).ToList();
            var trzydziesciOfiar = Players.Skip(30).ToArray();

            // rozwiązanie drugie
            indexOfiar = 0;
            trzydziesciGraczyGotowychDoAtaku.ForEach(gracz => gracz.Attack(trzydziesciOfiar[indexOfiar++]));

            // rozwiązanie trzecie
            indexOfiar = 0;
            foreach (var gotowyGraczDoAtaku in trzydziesciGraczyGotowychDoAtaku)
            {
                var ofiara = trzydziesciOfiar[indexOfiar];
                gotowyGraczDoAtaku.Attack(ofiara);
                indexOfiar++;
            }

            // rozwiazanie czwarte
            indexOfiar = 0;
            for (int indexGotowychGraczy = 0; indexGotowychGraczy < trzydziesciGraczyGotowychDoAtaku.Count; indexGotowychGraczy++)
            {
                var ofiara = trzydziesciOfiar[indexOfiar];
                trzydziesciGraczyGotowychDoAtaku[indexGotowychGraczy].Attack(ofiara);
                indexOfiar++;
            }


            // 3. pobrac 10 uzytkownikow ktorzy maja najmniej {CurrentHealth}.

            // PlayerService GetPlayersWithLowerstHealth(int count)

            var tenPlayersWithLowestHealth = Players.OrderBy(x => x.CurrentHealth)
                    .Take(10)
                    .ToList();


            // PlayerService GetSortedByHealth

            // 4. posortowac wszystkich uzytkowników po poziomie {CurrentHealth} malejąco.

            Players.OrderByDescending(x => x.CurrentHealth)
                    .ToList()
                    .ForEach(p => ConsoleEx.Log($"Players with name {p.Name} health: {p.CurrentHealth}", ConsoleColor.DarkBlue));

            Players.OrderBy(x => x.Friends);


            // 5. SERVICe -> wyświetlic 10 uzytkownikow poprzez serwis
            // PlayerService.LogPlayers(int count);

            // 5. wyświetlic ostatnio posortowanych 10 uzytkownikow uzywajac petli z LINQ.

            tenPlayersWithLowestHealth.ForEach(p => ConsoleEx.Log($"Players with name {p.Name} health: {p.CurrentHealth}", ConsoleColor.Cyan));

            foreach (var p in tenPlayersWithLowestHealth)
            {
                ConsoleEx.Log($"Players with name {p.Name} health: {p.CurrentHealth}", ConsoleColor.Cyan);
            }

            // FriendsService.AddRandomFriends(Player player, int count)

            // 6. dodaj do znajomych 15 uzytkownikow z najwieksza iloscia {CurrentHealth}

            You.AddFriends(Players.OrderBy(x => x.CurrentHealth).ToList().Take(15).ToList());

            You.AddFriends(Players.OrderByDescending(x => x.CurrentHealth).Take(15).ToList());

            // 7. dodaj do znajomych 10 uzytkownikow z najwiekszą ilościa statystyki {Agility}.
            // FriendsService.AddFriendsWithHighestAgility(Player player, int count)

            You.AddFriends(Players.OrderByDescending(x => x.BaseStatiscits.Agility).Take(10).ToList());

            // 8. dodaj do znajomych 5 randomowych uzytkownikow
            //Friends.Service.AddFriendsRandom(Player player, int count)

            You.AddFriends(Players.TakeRandomly(5).ToList());

            You.AddFriends(Players.Skip(154).Take(5).ToList());

            Enumerable.Range(0, 5).ToList().ForEach(x => You.AddFriends(new List<Player>() { Players[new Random().Next(1, PlayerConfig.FAKE_PLAYERS)] }));

            for (int i = 0; i > 5; i++)
            {
                You.AddFriends(new List<Player>() { Players[new Random().Next(1, PlayerConfig.FAKE_PLAYERS)] });
            }

            Players.Take(5);


            Players.TakeRandomly(5);

            // 9. usuń ze swoich znajomych uzytkownika z najgorszą ilością {CurrentHealth} (agregate, remove)
            //Frends.Service.RemoveYourFriendWithTheLowestCurrentHealth()

            You.Friends.Remove(You.Friends.OrderBy(x => x.CurrentHealth).First());

            var a = You.Friends.Aggregate((prev, next) => prev.CurrentHealth < next.CurrentHealth ? prev : next);

            You.Friends.Remove(a);

            // 10. pogrupuj uzytkownikow po takich samych broniach {PrimaryWeapon}
            //Weponservice.GroupByTheSameWeapon()

            var grouppedWeapons = Players.GroupBy(x => x.ActiveGear.PrimaryWeapon);

            // 11. wyswietl sume powtarzalnych broni z pogrupowanej powyzej listy {PrimaryWeapon}

            // 12. wyswietl top 100 graczy uzywajac modelu PlayerStatiscic w folderze DTOs, lista musi byc posortowana po punktach malejąco {Points} (select)
            //Players.LogTop100Players()


            int index = 1;
            Players.Select(x => new PlayerStatistic(x)).OrderByDescending(x => x.Points).Take(100).ToList().ForEach(x => ConsoleEx.Log($"{index++}. Name: {x.Name}, Points: {x.Points}", ConsoleColor.Green));

            // 13. zamien 50 randomowym uzytkownikom broń na inna randomową broń

            Players.Take(50).ToList().ForEach(x => x.ActiveGear.DrawWeapon());

            // 14. znajdz 10 uzytkownikow z najwieksza iloscia zycia, oraz z najwieksza iloscia stoczonych walk {Fights}

            var players_with_the_most_lives_and_fights = Players.OrderByDescending(x => x.CurrentHealth)
                    .ThenByDescending(x => x.Fights)
                    .Take(10)
                    .ToList();

            players_with_the_most_lives_and_fights.ForEach(x => ConsoleEx.Log($"Players with the most lives and fights: {x.Name}", ConsoleColor.Yellow));

            // 15. zaatakuj 10-cioma uzytkownikami 10 innych uzytkownikow 10 razy (foreach), (foreach, enumerable.range) lub (select).

            // 1
            //for(int i = 0; i < 10; i++)
            //{
            //      ...
            //}

            // 2
            //new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList().ForEach(i => )

            // 3
            //Enumerable.Range(0, 10).ToList().ForEach(i => ....)

            // 1. rozwiazanie gdzie atakujacy atakuje kazdego jeden raz

            
            Players.Take(10).ToList().ForEach(atakujący1 => {

                for (int ofiaraIndex = 10; ofiaraIndex < 20; ofiaraIndex++)
                {
                    atakujący1.Attack(Players[ofiaraIndex]);
                }

            });

            // 1. rozwiazanie gdzie atakujacy atakuje 10 razy ta sama ofiare

            
            int indexOfiary2 = 0;
            Players.Take(10).ToList().ForEach(atakujący1 => {

                for (int i = 10; i < 20; i++)
                {
                    var ofiara = Players[indexOfiary2];
                    atakujący1.Attack(ofiara);
                }
                indexOfiary2++;

            });

            // 2 rozwiazanie gdzie atakujacy atakuje kazdego jeden raz

            Players.Take(10).ToList().ForEach(atakujący1 => new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList().ForEach(ofiaraIndex => atakujący1.Attack(Players.Skip(10).Take(10).ToArray()[ofiaraIndex])));


            // 3 rozwiazanie gdzie atakujacy atakuje kazdego jeden raz

            Players.Take(10).ToList().ForEach(atakujący1 => Enumerable.Range(0, 10).ToList().ForEach(ofiaraIndex => atakujący1.Attack(Players.Skip(10).Take(10).ToArray()[ofiaraIndex])));


            ConsoleEx.Log("#######################", ConsoleColor.Red);

            Players.Take(10).ToList().ForEach(_atakujacy =>  Players.Skip(10).Take(10).ToList().ForEach(ofiara => _atakujacy.Attack(ofiara)));

            ConsoleEx.Log("#######################", ConsoleColor.Red);


            Players.Take(10).Select((x, i) => new { player = x, index = i }).ToList().ForEach(x => x.player.Attack(Players.Skip(10).ToList()[x.index]));

            // 16. wyświetl przegranych uzytkownikow jesli tacy są CurrentHealth < 0

            Players.Where(x => x.CurrentHealth <= 0)
                    .ToList()
                    .ForEach(x => ConsoleEx.Log($"Players killed: {x.Name}.", ConsoleColor.Black));


            // 17. Przepisz konstruktor na get i set w statystykach.

            // 18. Sprawdź czy {You} wystepuje w liscie {Players}. (Contains)

            ConsoleEx.Log(Players.Contains(You) ? $"Current player exists in Player list." : $"Current player does not exists in Player list.");

            // 19. Wyświetl średnią ilość żyć wszystkich graczy 

            string averageHealth = Players.Average(x => x.CurrentHealth).ToString();

            ConsoleEx.Log($"Average life expectancy of all players: {averageHealth}");

            // 20. Wyświetl średnią ilość agility wszystkich graczy

            string averageAgility = Players.Average(x => x.BaseStatiscits.Agility).ToString();

            ConsoleEx.Log($"Average agility of all players: {averageAgility}");

            // 21. Wyświetl gracza który posiada najwiekszą ilosc jednej z statystyk

            // 1. znajdź wartość maksymalną dla agility, health, stamina, strenght (linq, max) i i utwórz nową zmienną
            // 2. używając if, else if, if sprawdź, która wartość z tych 4 jest największa

            // Rozwiązanie pierwsze

            double agility = Players.Max(x => x.BaseStatiscits.Agility);
            double health = Players.Max(x => x.BaseStatiscits.Health); 
            double stamina = Players.Max(x => x.BaseStatiscits.Stamina); 
            double strenght = Players.Max(x => x.BaseStatiscits.Strenght);

            if (agility>health && agility>stamina && agility>strenght)
            {
                ConsoleEx.Log($"The highest value of agility:{agility}");
            }
            else if (health > agility && health > stamina && health > strenght)
            {
                ConsoleEx.Log($"The highest value of health:{health}");
            }
            else if (stamina > health && stamina > agility && stamina > strenght)
            {
                ConsoleEx.Log($"The highest value of stamina:{stamina}");
            }
            else
            {
                ConsoleEx.Log($"The highest value of strenght:{strenght}");
            }

            // Rozwiązanie drugie

            // 1. Utwórz tablicę z parametrami nazwa i wartość (wykorzystując linq max)
            // 2. Użyj agreggate, aby znaleźć najwyższą wartość.
            // 3. Wyświetl wartość na konsoli na podstawie danych z punktu pierwszego.

            var highestStat = new[]
            {
                new { name = "Agility", value = Players.Max(x => x.BaseStatiscits.Agility) },
                new { name = "Health", value = Players.Max(x => x.BaseStatiscits.Health) },
                new { name = "Stamina", value = Players.Max(x => x.BaseStatiscits.Stamina) },
                new { name = "Strenght", value = Players.Max(x => x.BaseStatiscits.Strenght) }
            }.Aggregate((prev, next) => prev.value > next.value ? prev : next);

            ConsoleEx.Log($"The highest Statistics is {highestStat.name} with value: {highestStat.value}");

            // Rozwiązanie trzecie (almost pro)

            Func<Player, int> agilitySelector = selector => selector.BaseStatiscits.Agility;
            Func<Player, int> healthSelector = selector => selector.BaseStatiscits.Health;
            Func<Player, int> staminaSelector = selector => selector.BaseStatiscits.Stamina;
            Func<Player, int> strenghtSelector = selector => selector.BaseStatiscits.Strenght;

            // delegate int selector(Func<Player, int> selector);

            var playerWithBestStats = new[]
            {
                new { selector = agilitySelector, player = Players.Aggregate((prev, next) => prev.BaseStatiscits.Agility > next.BaseStatiscits.Agility ? prev : next) },
                new { selector = healthSelector, player = Players.Aggregate((prev, next) => prev.BaseStatiscits.Health > next.BaseStatiscits.Health ? prev : next) },
                new { selector = staminaSelector, player = Players.Aggregate((prev, next) => prev.BaseStatiscits.Stamina > next.BaseStatiscits.Stamina ? prev : next) },
                new { selector = strenghtSelector, player = Players.Aggregate((prev, next) => prev.BaseStatiscits.Strenght > next.BaseStatiscits.Strenght ? prev : next) }
            }.Aggregate((prev, next) => prev.selector(prev.player) > next.selector(next.player) ? prev : next);

            ConsoleEx.Log($"The highest Statistics is {playerWithBestStats.selector(playerWithBestStats.player)}");

            // 22. Utwórz i dodaj nowego gracza na początku sekwencji/listy graczy

            var newplayer = new Player("Guzik");
            Players.Insert(0, newplayer);

            // 23. Usuń wszystkich graczy którzy posiadają broń "Amnesia" oraz wyświetl liczbe usuniętych graczy


            var listaużytkownikówdousunięcia = Players.Where(x => x.ActiveGear?.PrimaryWeapon?.Name == "Amnesia").ToList();
            foreach (var użytkownikdousunięcia in listaużytkownikówdousunięcia)
            {
                Players.Remove(użytkownikdousunięcia);
            }

            Players.Where(x => x.ActiveGear?.PrimaryWeapon?.Name == "Amnesia").ToList().ForEach(x => ConsoleEx.Log(x.Name));
            Players.RemoveAll(x => x.ActiveGear?.PrimaryWeapon?.Name == "Amnesia");

            // 24. Wyświetl całkowitą liczbe stoczonych walk wszystkich graczy (pojedyncza liczba) 
            // - 

            int stoczonewalki = Players.Sum(x => x.Fights);
            ConsoleEx.Log($"{stoczonewalki}");

            var liczba = 0;
            foreach (var gracz in Players)
            {
                liczba = liczba + gracz.Fights;
            }

            Console.WriteLine("Liczba stoczonych walk to " + liczba);

            liczba = 0;
            for(int i = 0; i < Players.Count; i++)
            {
                liczba = liczba + Players[i].Fights;
            }

            Console.WriteLine("Liczba stoczonych walk to " + liczba);

            Console.WriteLine("Liczba stoczonych walk to " + Players.Sum(x => x.Fights));

            // 25. Spróbuj zabić jednego uzytkownika (while, bez linQ)

            // rozwiązanie 1

            var ofiara2 = Players[101];
            var atakujący = Players[102];


            while (ofiara2.CurrentHealth>0)
            {
                atakujący.Attack(ofiara2);
            }

            // rozwiązanie 2

            Players[32].Friends.Add(atakujący);

            while (ofiara2.CurrentHealth > 0)
            {
                Players[32].Attack(ofiara2);
            }

            Console.WriteLine(ofiara2.DeathDate.ToString());


            // 26. Zmodyfikuj model playera o date zgonu

            // done

            // 27. Wyświetl wszystkie informacje powyższego uzytkownika, uwzgledniając date zgonu.

         Console.WriteLine($"Informacje o użytkowniku Imię: {ofiara2.Name}, " +
                $"Agility: {ofiara2.BaseStatiscits.Agility}, " +
                $"Stamina: {ofiara2.BaseStatiscits.Stamina}, " +
                $"Strengh: {ofiara2.BaseStatiscits.Strenght}, " +
                $"Health: {ofiara2.BaseStatiscits.Health}," +
                $"Ponits: {new PlayerStatistic(ofiara2).Points}," +
                $"Data zgonu: {ofiara2.DeathDate}"
            );


            // 28. Usuń połowe graczy z najsłabszym hp {CurrentHealth}
            
            Players.OrderByDescending(x => x.CurrentHealth).Take(Players.Count / 2).ToList().ForEach(x => Players.Remove(x));

            // 29. Sprawdź czy jakiś uzytkonik ma w znajomych zgona. (where, any)

            var usersWithDeathPlayers = Players.Where(x => x.Friends.Any(y => y.CurrentHealth <= 0));

            // 30. Znajdz uzytkownika z najdłuższym imieniem.


            var nnnn = Players.OrderByDescending(x => x.Name.Length).First();

            Players.Aggregate((prev, next) => 
            {
                if (prev.Name.Length>next.Name.Length)
                {
                    return prev;
                }
                return next;
            });

            // true ? true : false

            var użytkownikznajdłuższymimieniem1 = Players.Aggregate((prev, next) => prev.Name.Length > next.Name.Length ? prev : next);



            // 31. Znajdz uzytkownika z najwiekszą ilością życia.


            Players.Aggregate((prev, next) =>
            {
                if (prev.CurrentHealth > next.CurrentHealth)
                {
                    return prev;
                }
                return next;
            });

            Players.Aggregate((prev, next) => prev.CurrentHealth > next.CurrentHealth ? prev : next);

            // 32. Utworz metode ktora przyjmuje dwóch playerów i zwraca tego ktory ma wieksze {MaxHealth}


            Player GetPlayerWithHigherMaxHealth(Player first, Player next)
            {
                if (first.MaxHealth > next.MaxHealth)
                {
                    return first;
                }

                return next;
            }

            Player GetPlayerWithHigherMaxHealth2(Player first, Player next) => first.MaxHealth > next.MaxHealth ? first : next;

            var abcdef1 = GetPlayerWithHigherMaxHealth(new Player("asdasd"), new Player("Asdasd"));

            // 33. Uzyj jeden z utworzonej powyzej metody jako parametr metody Aggregate

            Func<Player, Player, Player> GetPlayerWithHigherMaxHealthFunc = (first, next) => first.MaxHealth > next.MaxHealth ? first : next;


            Players.Aggregate(GetPlayerWithHigherMaxHealth);

            Players.Aggregate(GetPlayerWithHigherMaxHealthFunc);

            // 34. Dodaj do każdego uzytkownika kilku randomowych znajomych.

            Players.ForEach(x => x.AddFriends(Players.ToList().TakeRandomly(5).ToList()));

            // 35. Znajdź uzytkownika z najwiekszą ilościa znajomych.


            Players.Aggregate((prev, next) => prev.Friends.Count > next.Friends.Count ? prev : next);

           
        }
    }
}
