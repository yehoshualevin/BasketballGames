using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasketballGames.Data;

namespace BasketballGames.Models
{
    public class GamesAndPlayers
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MaxPlayers { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}