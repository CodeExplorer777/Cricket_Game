using System;
using System.Collections.Generic;
using System.Text;

namespace Cricket_Game.Utilities
{
    internal class RandomHelper
    {
        static Random rnd =new Random();
        public static string GetBallResult()
        {
            string[] outcomes = { "0", "1", "2", "3", "4", "6", "Wicket", "NoBall", "Wide" };
            return outcomes[rnd.Next(outcomes.Length)];
        }
    }
}
