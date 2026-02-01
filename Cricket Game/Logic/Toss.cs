using System;
using System.Collections.Generic;
using System.Text;
using Cricket_Game.Models;
namespace Cricket_Game.Logic
{
    internal class Toss
    {
        public static Team DoToss(Team teamA, Team teamB)
        {
            Random random = new Random();
            int tossResult = random.Next(0, 2); // 0 or 1
            if (tossResult == 0)
            {
                Console.WriteLine($"{teamA.TeamName} won the toss and will bat first.");
                Console.ReadLine();
                return teamA;
            }
            else
            {
                Console.WriteLine($"{teamB.TeamName} won the toss and will bat first.");
                Console.ReadLine();
                return teamB;
            }
        }
    }
}
