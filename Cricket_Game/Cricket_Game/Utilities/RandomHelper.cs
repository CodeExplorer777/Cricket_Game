using System;
using System.Collections.Generic;
using System.Text;

namespace Cricket_Game.Utilities
{
    public interface IRandomHelper
    {
        string GetBallResult();
        string GetNoBallResult();
    }
    public class RandomHelper: IRandomHelper
    {
        static Random rnd = new Random();
        public  string GetBallResult()
        {
            string[] outcomes = { "0", "1", "2", "3", "4", "6", "Wicket", "NoBall", "Wide" };
            return outcomes[rnd.Next(outcomes.Length)];
        }
        public string GetNoBallResult()
        {
            string[] noBallOutcomes = { "0", "1", "2", "3", "4", "6","Wide","NoBall"};
            return noBallOutcomes[rnd.Next(noBallOutcomes.Length)];
        }
    }
}