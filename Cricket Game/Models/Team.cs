using System;
using System.Collections.Generic;
using System.Text;
using Cricket_Game.Models;

namespace Cricket_Game.Models
{
    internal class Team
    {
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
        public int Score { get; set; }
        public int BallsPlayed { get; set; }
        public int WicketsLost { get; set; }
        public static void GetTeamInfo(Team team)
        {
            foreach (var player in team.Players)
            {
                Console.WriteLine($"Player Name: {player.PlayerName}, Role: {player.Role}");
            }
        }

        public Team(string teamName)
        {
            TeamName = teamName;
            Players=new List<Player>();
            Score = 0;
            WicketsLost = 0;
        }
        public List<Player> GetBowlers()
        {
            return Players.FindAll(p => p.Role == "Bowler");
        }
        public List<Player> GetBatsmen()
        {
            return Players.FindAll(p => p.Role == "Batsman");
        }
        public static Team CreateTeamIndia()
        {
            Team teamIndia = new Team("India");
            teamIndia.Players.Add(new Player("Rohit Sharma","Batsman"));
            teamIndia.Players.Add(new Player("Virat Kohli", "Batsman"));
            teamIndia.Players.Add(new Player("Shubman Gill", "Batsman"));
            teamIndia.Players.Add(new Player("KL Rahul", "Batsman"));

            teamIndia.Players.Add(new Player("Jasprit Bumrah", "Bowler"));
            teamIndia.Players.Add(new Player("Mohammed Shami", "Bowler"));
            teamIndia.Players.Add(new Player("Ravindra Jadeja", "Bowler"));

            return teamIndia;
        }

        public static Team CreateTeamAustralia()
        {
            Team teamAustralia = new Team("Australia");
            teamAustralia.Players.Add(new Player("David Warner", "Batsman"));
            teamAustralia.Players.Add(new Player("Steve Smith", "Batsman"));
            teamAustralia.Players.Add(new Player("Marnus Labuschagne", "Batsman"));
            teamAustralia.Players.Add(new Player("Glenn Maxwell", "Batsman"));

            teamAustralia.Players.Add(new Player("Pat Cummins", "Bowler"));
            teamAustralia.Players.Add(new Player("Mitchell Starc", "Bowler"));
            teamAustralia.Players.Add(new Player("Adam Zampa", "Bowler"));
            return teamAustralia;
        }
        public static Team CreateTeamEngland()
        {
            Team teamEngland = new Team("England");
            teamEngland.Players.Add(new Player("Joe Root", "Batsman"));
            teamEngland.Players.Add(new Player("Ben Stokes", "Batsman"));
            teamEngland.Players.Add(new Player("Jonny Bairstow", "Batsman"));
            teamEngland.Players.Add(new Player("Jos Buttler", "Batsman"));

            teamEngland.Players.Add(new Player("James Anderson", "Bowler"));
            teamEngland.Players.Add(new Player("Jofra Archer", "Bowler"));
            teamEngland.Players.Add(new Player("Mark Wood", "Bowler"));

            return teamEngland;
        }
    }
}
