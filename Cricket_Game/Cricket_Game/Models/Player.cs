using System;
using System.Collections.Generic;
using System.Text;

namespace Cricket_Game.Models
{
    public interface IPlayer
    {

    }
    public class Player : IPlayer
    {
        public string PlayerName { get; set; }
        public string Role { get; set; } // Batsman, Bowler
        public int PermanantRuns {  get; set; }
        public int PermanantBallsFaced {  get; set; }
        public int PermanantWicketsTaken {  get; set; }
        public int PermanantBowlerBallsBowled {  get; set; }
        public int PermanantRunsConceded {  get; set; }
        public int PermanantBowlerExtras {  get; set; }
        // public batsman side
        public int Runs { get; set; }
        public int BallsFaced { get; set; }
        public bool isOut {  get; set; }
        //for bowler
        public int BowlerBallsBowled { get; set; }
        public int RunsConceded {  get; set; }
        public int WicketsTaken {  get; set; }
        public int BowlerExtras { get; set; }
        public Player() { }
        
        public Player(string playerName, string role)
        {
            PlayerName = playerName;
            Role = role;
            //Batsman
            Runs = 0;
            BallsFaced = 0;
            isOut = false;
            //Baller side
            BowlerBallsBowled = 0;
            RunsConceded = 0;
            WicketsTaken = 0;
        }
    }
}