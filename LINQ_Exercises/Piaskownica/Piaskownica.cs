using LINQ_Exercises.DTOs;
using LINQ_Exercises.Extensions;
using LINQ_Exercises.Models;
using LINQ_Exercises.Piaskownica.Infrastruktura.Serwisy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Exercises.Piaskownica
{

    public class User
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public User(string userName, string lastName, string password)
        {
            UserName = userName;
            LastName = lastName;
            Password = password;
        }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string LastName { get; set; }

        public UserDto(string userName, string lastName)
        {
            UserName = userName;
            LastName = lastName;
        }

        public UserDto(User user)
        {
            UserName = user.UserName;
            LastName = user.LastName;
        }
    }

    // User user_db.GetUser()
    // UserDto userDto = _mapper<User, UserDto>(user_db);

    public static class Piaskownica
    {
        public static void Test_LINQ()
        {
            /*
             * 
             *  Sum() ForEach() OrderBy() OrderByDescending() Min() Max() Skip() Take() Where()
             * 
             */

            var liczby = new[] { 1, 2, 3, 4, 7, 2, 7, 3, 75, 34, 56, 76 };
            var uzytkownicy = new[] { new { name = "Pati" }, new { name = "Arek" }, new { name = "Kuba" }, new { name = "Ajra" } };
            var jakasTablicaObiektow = new[] { new { value = 1, age = 12 }, new { value = 3, age = 22 }, new { value = 3, age = 18 }, new { value = 2, age = 22 }, new { value = 1, age = 19 }, };

            var posortowaneLiczby = liczby.OrderBy(liczba => liczba).ToArray();

            var posortowaneObiektyPoWartowciValueRosnąco = jakasTablicaObiektow.OrderBy(x => x.value);
            var posortowaneObiektyPoWiekuMalejąco = jakasTablicaObiektow.OrderByDescending(x => x.age);

            var sumaLiczb = liczby.Sum();
            var sumajakasTablicaObiektow = jakasTablicaObiektow.Sum(x => x.age);

            var minimalnaLiczba = liczby.Min();
            var minimalnaWartosciaValue = jakasTablicaObiektow.Min(x => x.value);

            var najwiekszaLiczba = liczby.Max();
            var najwiekszeValueZTablicyObiektow = jakasTablicaObiektow.Max(x => x.value);

            var średniaLiczb = liczby.Average();
            var sredniaWiekowJakichObiektow = jakasTablicaObiektow.Average(x => x.age);


            // { 1, 2, 3, 4, 7, 2, 7, 3, 75, 34, 56, 76 };
            var trzeciaICzwartaLiczba = liczby.Skip(2).Take(2).ToArray(); // 3, 4

            var czyObiektyPosiadaja18latka = jakasTablicaObiektow.Any(x => x.age == 18);
            var czyLiczbyPosiadaja58 = liczby.Any(x => x == 56);


            /*
             *  WHERE
             */

            // Where( "element" => "warunek który zwraca true lub false, jesli zwroci true to element zostaje wrzucony do nowej listy.") 
            // Where zwraca nową liste z elementami które spełniły warunek

            var duzeLiczby = liczby.Where(x => x > 50);
            var osiemnastolatki = jakasTablicaObiektow.Where(x => x.age == 18);
            var dorosliZWartociamiValue40 = jakasTablicaObiektow.Where(x => x.age >= 18 && x.value < 40);
            var listaZArkiem = uzytkownicy.Where(uzytkownik => uzytkownik.name == "Arek").ToList();
            var arek = uzytkownicy.First(uzytkownik => uzytkownik.name == "Arek");

            var liczba52 = liczby.First(x => x == 52);


            int kolejnaLiczba52;

            for (int i = 0; i < liczby.Length; i++)
            {
                if (liczby[i] == 52)
                {
                    kolejnaLiczba52 = liczby[i];
                    break;
                }
            }

            // zrob z tablicy uzytkownicy, nowa tablice ze stringami, 

            var imiona = uzytkownicy.Select(x => x.name).ToArray();

            var nowiAnonimowiUzytkownicy = uzytkownicy.Select(x => new { FirstName = x.name }).ToArray();

            var nowiUzytkownicy = uzytkownicy.Select(x =>
            {
                var nowyuzytkownik = new NowiUzytkownicy();
                nowyuzytkownik.FirstName = x.name;
                return nowyuzytkownik;
            }).ToArray();

            var nowiUzytkownicyZuzyciemKonstruktora = uzytkownicy.Select(x => new NowiUzytkownicy(x.name)).ToArray();


            var user = new User("Pati", "Kubinska", "sekret");

            var userDto = new UserDto(user.UserName, user.LastName);


            var users = new List<User>() { new User("Pati", "Kubinska", "sekret"), new User("Arek", "Chr", "sekret"), new User("Ajra", "Kubinska", "sekret") };

            // List<UserDto> usersDto _mapper<User, UserDto>(users);

            var usersDto = users.Select(x => new UserDto(x.UserName, x.LastName)).ToList();
            var usersDto2 = users.Select(x => new UserDto(x)).ToList();

            var usersDto3 = new List<UserDto>();

            for (int i = 0; i < users.Count; i++)
            {
                var newUserDto = new UserDto(users[i]);
                usersDto3.Add(newUserDto);
            }

            var userId = Guid.NewGuid();
            var _friendService = new FriendsService();

            //

            var friends = _friendService.GetFriends(userId);

            var _weponService = new WeponService();

            _weponService.GenerateWeaponForAllPlayers();
            _weponService.GenerateWeaponForPlayers(friends);

            //

            var _playerService = new PlayerService();
            _playerService.PrepareAttack(30);
            _playerService.LogPlayers(10);
            _playerService.AddRandomFriends(10, Game.You);

            var playerStatistics = _playerService.MapPlayersToPlayerStatistic();
            int index = 1;

            var jacysGracze = new List<Player>() { new Player("Arek"), new Player("Pati") };
            _playerService.PlayersWithTheMostLivesAndFight(jacysGracze);

            _playerService.PlayersWithTheMostLivesAndFight(Game.Players);
        }

      
    }
}
