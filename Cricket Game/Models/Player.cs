using System;
using System.Collections.Generic;
using System.Text;

namespace Cricket_Game.Models
{
    internal class Player
    {
        public string PlayerName { get; set; }
        public string Role { get; set; } // Batsman, Bowler
        public Player(string playerName, string role)
        {
            PlayerName = playerName;
            Role = role;
        }
    }
}
