using System;
using System.Collections.Generic;
using System.Text;
using Cricket_Game.Models;
using Cricket_Game.Logic;
using Cricket_Game.Utilities;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome Developers to This Amazing game of cricket:");
        Console.WriteLine("Starting Game ...");
        Console.WriteLine("Press Enter to continue:");
        Console.ReadLine();
        Thread.Sleep(2000);
        Team team1 = Team.CreateTeamIndia();
        Team team2 = Team.CreateTeamAustralia();
        Team team3 = Team.CreateTeamEngland();
        Console.WriteLine(" FIRST MATCH");
        Console.ReadLine();
        Console.WriteLine($"Match between {team1.TeamName} vs {team2.TeamName}");
        Console.WriteLine($"Team : {team1.TeamName}:");
        Team.GetTeamInfo(team1);
        Console.ReadLine();
        Console.WriteLine($"Team : {team2.TeamName}");
        Team.GetTeamInfo(team2);
        Console.ReadLine();
        Console.Clear();
        Team winner1 = Match.PlayMatch(team1, team2);

        Team finalist = (winner1 == team1) ? team3 : team2;
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("\n FINAL MATCH");
        Console.ReadLine();
        Console.WriteLine($"Match between {winner1.TeamName} vs {finalist.TeamName}");
        Console.WriteLine($"Team : {winner1.TeamName}:");
        Team.GetTeamInfo(winner1);
        Console.ReadLine();
        Console.WriteLine($"Team : {finalist.TeamName}");
        Team.GetTeamInfo(finalist);
        Console.ReadLine();
        Console.Clear();
        Team champion = Match.PlayMatch(winner1, finalist);

        Console.WriteLine($"\n TOURNAMENT WINNER: {champion.TeamName}");
        Console.ReadLine();
    }
}
