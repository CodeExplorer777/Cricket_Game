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
        void Load()
        {
        for (int i = 3; i > 0; i--)
        {
            Console.Write("\rStarting in: " + i + "   ");
            Thread.Sleep(800);
        }

        }
        Console.WriteLine("Welcome Developers to This Amazing game of cricket:");
        Console.ReadLine();
        Console.WriteLine("Starting Game ...");
        Load();
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue:");
        Console.ReadLine();
        //Thread.Sleep(2000);
        Team team1 = Team.CreateTeamIndia();
        Team team2 = Team.CreateTeamAustralia();
        Team team3 = Team.CreateTeamEngland();
        Console.WriteLine(" FIRST MATCH");
        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Match between {team1.TeamName} vs {team2.TeamName}");
        Console.ResetColor();
        Console.WriteLine($"Team : {team1.TeamName}:");
        Team.GetTeamInfo(team1);
        Console.ReadLine();
        Console.WriteLine($"Team : {team2.TeamName}");
        Team.GetTeamInfo(team2);
        Console.ReadLine();
        //Console.Clear();
        Team winner1 = Match.PlayMatch(team1, team2);
        //finalist team
        Team finalist = team3;
        Console.ReadLine();
        //Console.Clear();
        Console.WriteLine("\n FINAL MATCH");
        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Match between {winner1.TeamName.ToUpper()} vs {finalist.TeamName}");
        Console.ResetColor();
        Console.WriteLine($"Team : {winner1.TeamName}:");
        Team.GetTeamInfo(winner1);
        Console.ReadLine();
        Console.WriteLine($"Team : {finalist.TeamName}");
        Team.GetTeamInfo(finalist);
        Console.ReadLine();
        //Console.Clear();
        Team champion = Match.PlayMatch(winner1, finalist);

        Console.WriteLine($"\n TOURNAMENT WINNER: {champion.TeamName}");
        champion.DisplayChampions();
        Console.ReadLine();
        Console.WriteLine("Exiting game");
        Load();

    }
}