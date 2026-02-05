using Cricket_Game.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Cricket_Game.Utilities;
using Cricket_Game.Logic;
using System.Security.Cryptography.X509Certificates;

namespace Cricket_Game.Logic
{
    class Match
    {
        public static void SaveScore(Team t1, Team t2)
        {
            foreach (var item in t1.Players)
            {
                item.PermanantRuns += item.Runs;
                item.PermanantRunsConceded += item.RunsConceded;
                item.PermanantBowlerBallsBowled += item.BowlerBallsBowled;
                item.PermanantBallsFaced += item.BallsFaced;
                item.PermanantWicketsTaken += item.WicketsTaken;
                item.PermanantBowlerExtras += item.BowlerExtras;
            }
            foreach (var item in t2.Players)
            {
                item.PermanantRuns += item.Runs;
                item.PermanantRunsConceded += item.RunsConceded;
                item.PermanantBowlerBallsBowled += item.BowlerBallsBowled;
                item.PermanantBallsFaced += item.BallsFaced;
                item.PermanantWicketsTaken += item.WicketsTaken;
                item.PermanantBowlerExtras += item.BowlerExtras;
            }
        }
        public static void ClearScore(Team t1, Team t2)
        {
            foreach (var item in t1.Players)
            {
                item.Runs = 0;
                item.RunsConceded = 0;
                item.BowlerBallsBowled = 0;
                item.BallsFaced = 0;
                item.WicketsTaken = 0;
                item.BowlerExtras = 0;
            }
            foreach (var item in t2.Players)
            {
                item.Runs = 0;
                item.RunsConceded = 0;
                item.BowlerBallsBowled = 0;
                item.BallsFaced = 0;
                item.WicketsTaken = 0;
                item.BowlerExtras = 0;
            }
        }
        public static Team PlayMatch(Team t1, Team t2)
        {
            ClearScore(t1, t2);

            t1.Score = t2.Score = 0;
            t1.WicketsLost = 0;
            t2.WicketsLost = 0;

            Team tossWinner = Toss.DoToss(t1, t2);

            Team battingFirst = tossWinner;


            Team bowlingFirst = (tossWinner == t1) ? t2 : t1;
            int maxBalls = 18;
            Console.WriteLine("First Innings");
            Console.ReadLine();
            Iinnnings innings = new Innings();
            innings.StartInnings(battingFirst, bowlingFirst, 0, maxBalls);
            int target = battingFirst.Score + 1;
            //int maxBalls = battingFirst.BallsPlayed;
            Console.WriteLine($"\n Target: {target} runs in {maxBalls} balls");
            Console.WriteLine("Second Innings");
            innings.StartInnings(bowlingFirst, battingFirst, target, maxBalls);
            Team winner;
            if (bowlingFirst.Score >= target)
            {
                winner = bowlingFirst;
                Console.ReadLine();
                Console.WriteLine($"{winner.TeamName} Won By {7 - winner.WicketsLost} Wickets");
            }
            else
            {

                winner = battingFirst;
                Console.WriteLine($"{winner.TeamName} Won By {target-bowlingFirst.Score} runs");
            }
            winner = (t1.Score > t2.Score) ? t1 : t2;
            Console.WriteLine($"\n Match Winner: {winner.TeamName}");
            SaveScore(bowlingFirst, battingFirst);
            return winner;
        }
    }
}