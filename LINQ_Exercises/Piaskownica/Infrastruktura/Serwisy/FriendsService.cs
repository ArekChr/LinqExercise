using LINQ_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Exercises.Piaskownica.Infrastruktura.Serwisy
{
    public class FriendsService
    {
        // pobierz znajomych po uzytkowniku (jednym jakims konkretnym ktory wprowadzimy z parametru)
        // tej metdy co tu napiszesz

        public List<Player> GetFriends(Guid userId)
        {
            var player = Game.Players.Single(x => x.Id == userId);

            if(player == null)
            {
                throw new Exception("Player does not exists.");
            }

            return player.Friends;
        }

        
    }
}
