using System;
using System.Collections.Generic;
using System.Text;
using Cricket_Game.Models;

namespace Cricket_Game.Models
{

    public class Team
    {
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
        public int Score { get; set; }
        public int BallsPlayed { get; set; }
        public int WicketsLost { get; set; }
        public static void GetTeamInfo(Team team)
        {
            Console.WriteLine("{0,-25} {1,-10} ", "Name", "Role");
            Console.WriteLine("===================================");
            foreach (var player in team.Players)
            {
                //Thread.Sleep(500);
                //Console.WriteLine($"Player Name: {player.PlayerName}, Role: {player.Role}");
                Console.WriteLine("{0,-25} {1,-10} ", player.PlayerName, player.Role);

            }
        }
        public void DisplayChampions()
        {
            Console.WriteLine("Batsman ScoreCard");
            Console.WriteLine("{0,-25} {1,-15} {2,-15}  ", "Name", "Runs", "Balls");
            foreach (var p in Players)
            {
                
                Console.ResetColor();
                Console.WriteLine("{0,-25} {1,-15} {2,-15} ", p.PlayerName, p.PermanantRuns, p.PermanantBallsFaced);
            }

            Console.WriteLine("\nBowlers ScoreCard");
            Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}", "Name", "Overs", "Runs Conceded", "Wickets","Bowler's Extras");
            foreach (var p in Players.Where(p => p.Role == "Bowler"))
            {
                float overs = p.PermanantBowlerBallsBowled / 6;

                Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}{4,-15}", p.PlayerName, overs, p.RunsConceded, p.PermanantWicketsTaken,p.PermanantBowlerExtras);

            }

        }
        public void DisplayBatsmanInfo()
        {
            Console.WriteLine("Batsman ScoreCard");
            Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15} ", "Name", "Runs Scored", "Balls", "Status");
            foreach (var p in Players)
            {
                Console.ForegroundColor = p.isOut ? ConsoleColor.Red : ConsoleColor.White;
                string statusIsOut = p.isOut ? "Out" : "Not Out";
                Console.ResetColor();
                Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}", p.PlayerName, p.Runs, p.BallsFaced, statusIsOut);
            }
        }
        public void DisplayBowlersInfo()
        {
            Console.WriteLine("\nBowlers ScoreCard");
            Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}{4,-15}", "Name", "Overs", "Runs Conceded", "Wickets Taken","Bowler's Extras");
            foreach (var p in Players.Where(p => p.Role == "Bowler"))
            {
                float overs = p.BowlerBallsBowled / 6;
                Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}{4,-15}", p.PlayerName,overs,p.RunsConceded,p.WicketsTaken,p.BowlerExtras);

            }
        }
        public Team(string teamName)
        {
            TeamName = teamName;
            Players = new List<Player>();
            Score = 0;
            WicketsLost = 0;
        }
        public List<Player> GetBowlers()
        {
            return Players.FindAll(p => p.Role == "Bowler");
        }
        public List<Player> GetBatsmen()
        {
            return Players
        .OrderByDescending(p => p.Role == "Batsman")
        .ToList();
        }
        public static Team CreateTeamIndia()
        {
            Team teamIndia = new Team("India");
            teamIndia.Players.Add(new Player("Rohit Sharma", "Batsman"));
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