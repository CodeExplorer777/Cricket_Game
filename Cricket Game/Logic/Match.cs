using Cricket_Game.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Cricket_Game.Utilities;
using Cricket_Game.Logic;

namespace Cricket_Game.Logic
{
    class Match
    {
        public static Team PlayMatch(Team t1, Team t2)
        {
            t1.Score = t2.Score = 0;
            t1.WicketsLost = 0;
            t2.WicketsLost = 0;

            Team tossWinner = Toss.DoToss(t1, t2);

            Team battingFirst = tossWinner;


            Team bowlingFirst = (tossWinner == t1) ? t2 : t1;
            Console.WriteLine("First Innings");
            Console.ReadLine();
            Innings.StartInnings(battingFirst, bowlingFirst, 0, int.MaxValue);
            int target = battingFirst.Score + 1;
            int maxBalls = battingFirst.BallsPlayed;
            Console.WriteLine($"\n Target: {target} runs in {maxBalls} balls");
            Console.WriteLine("Second Innings");

            Innings.StartInnings(bowlingFirst, battingFirst,target,maxBalls);
            Team winner;
            if (bowlingFirst.Score>=target)
            {
                winner = bowlingFirst;
            }
            else
            {
                winner = battingFirst;
            }
                winner = (t1.Score > t2.Score) ? t1 : t2;
            Console.WriteLine($"\n Match Winner: {winner.TeamName}");

            return winner;
        }
    }

}
