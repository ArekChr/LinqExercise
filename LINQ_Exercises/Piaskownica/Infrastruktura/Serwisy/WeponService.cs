using LINQ_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Exercises.Piaskownica.Infrastruktura.Serwisy
{
    public class WeponService
    {
        // 1. wygeneruj dla wszystkich uzytkownikow broń {DrawWeapon}

        // WeaponService.GenerateWeaponForPlayers(LIst<Players> players)
        // WeaponService.GenerateWeaponForAllPlayers()

        // albo weapon service dostaje sie do wszystkich playerow poprzez Game.Players, albo wprowazdasz konkretnych playerow w parametr dla ktorych wygenerujesz bronie
        // zrob tak i tak

        public void GenerateWeaponForAllPlayers()
        {
            Game.Players.ForEach(x => x.ActiveGear.DrawWeapon());
        }

        public void GenerateWeaponForPlayers(List<Player> players)
        {
            players.ForEach(x => x.ActiveGear.DrawWeapon());
        }
    }
}
