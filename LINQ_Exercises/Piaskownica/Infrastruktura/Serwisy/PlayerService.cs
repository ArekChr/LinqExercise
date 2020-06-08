using LINQ_Exercises.DTOs;
using LINQ_Exercises.Extensions;
using LINQ_Exercises.Models;
using LINQ_Exercises.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Exercises.Piaskownica.Infrastruktura.Serwisy
{
    public class PlayerService
    {
        public void PrepareAttack(int userCount)
        {
            int indexOfiar = 0;
            Game.Players.Take(userCount)
                    .ToList()
                    .ForEach(x => x.Attack(Game.Players.Skip(userCount).ToArray()[indexOfiar++]));
        }

        public void Browse(int _count)
        {
            List<Player> trzydziesciGraczy = new List<Player>();
            for (int i = 0; Game.Players.Count < _count; i++)
            {
                trzydziesciGraczy.Add(Game.Players[i]);
            }
        }

        public List<Player> Browse()
        {
            return Game.Players;
        }

        public List<Player> GetPlayersWithLowersHealth(int Count)
        {
            return Game.Players.OrderBy(x => x.CurrentHealth)
                    .Take(Count)
                    .ToList();
        }

        public void GetSortedByHealth()
        {
            Game.Players.OrderByDescending(x => x.CurrentHealth)
                    .ToList()
                    .ForEach(p => ConsoleEx.Log($"Players with name {p.Name} health: {p.CurrentHealth}", ConsoleColor.DarkBlue));
        }

        public void LogPlayers(int Count)
        {
            Game.Players.OrderBy(x => x.CurrentHealth)
                   .Take(Count)
                   .ToList().ForEach(p => ConsoleEx.Log($"Players with name {p.Name} health: {p.CurrentHealth}", ConsoleColor.Cyan));
        }

        public void AddRandomFriends(Player player, int Count)
        {
            player.AddFriends(Game.Players.OrderBy(x => x.CurrentHealth).ToList().Take(Count).ToList());
        }

        public void AddFriendsWithHighestAgility(int count, Player players)
        {
            players.AddFriends(Game.Players.OrderByDescending(x => x.BaseStatiscits.Agility).Take(count).ToList());
        }

        public void AddRandomFriends (int count, Player players)
        {
            players.AddFriends(Game.Players.TakeRandomly(count).ToList());
        }

        public List<IGrouping<Weapon,Player>> GroupByTheSameWeapon()
        {
            return Game.Players.GroupBy(x => x.ActiveGear.PrimaryWeapon).ToList();
        }

        public IEnumerable<PlayerStatistic> MapPlayersToPlayerStatistic()
        {
            return Game.Players.Select(x => new PlayerStatistic(x));
        }

        public int LogTop100Players(IEnumerable<PlayerStatistic> playerStatistics, int index)
        {
            playerStatistics.OrderByDescending(x => x.Points).Take(100).ToList().ForEach(x => ConsoleEx.Log($"{index++}. Name: {x.Name}, Points: {x.Points}", ConsoleColor.Green));
            return index;
        }

        public void ChangeWepons(int count)
        {
            Game.Players.Take(count).ToList().ForEach(x => x.ActiveGear.DrawWeapon());
        }

        public void ChangeWepons(List<Player> players)
        {
            players.ForEach(x => x.ActiveGear.DrawWeapon());
        }

        public void PlayersWithTheMostLivesAndFight(List<Player> players)
        {
            players.OrderByDescending(x => x.CurrentHealth)
                .ThenByDescending(x => x.Fights)
                .Take(10)
                .ToList().ForEach(x => ConsoleEx.Log($"Players with the most lives and fights: {x.Name}", ConsoleColor.Yellow));
        }
    }
}
