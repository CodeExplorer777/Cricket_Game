using Cricket_Game.Models;
using Cricket_Game.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace Cricket_Game.Logic
{
    public interface Iinnnings
    {
        void StartInnings(Team battingTeam, Team bowlingTeam, int target, int maxBalls);
    }
    internal class Innings : Iinnnings
    {
        public void StartInnings(Team battingTeam, Team bowlingTeam, int target, int maxBalls)
        {
            Player lastBowler = new Player();
            Player currentBowler = new Player();

            int ballsBowled = 0;

            var batsmen = battingTeam.GetBatsmen();
            Player striker = batsmen[0];
            Player nonStriker = batsmen[1];
            int batsmanIndex = 2;
            while (ballsBowled < maxBalls && battingTeam.WicketsLost < batsmen.Count)
            {
                //Console.Clear();
                if (ballsBowled > 0)
                {
                    Console.WriteLine($"Score: {battingTeam.Score}\t|\tWickets:{battingTeam.WicketsLost}");
                    Console.ReadLine();
                }
                Console.WriteLine($"\n--- Over {(ballsBowled / 6) + 1} ---");

                var allBowlers = bowlingTeam.GetBowlers();

                var availableBowlers = lastBowler == null
                    ? allBowlers
                    : allBowlers.Where(b => b != lastBowler).ToList();

                for (int i = 0; i < availableBowlers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableBowlers[i].PlayerName}");
                }

            choice:

                try
                {
                    while (true)
                    {
                        Console.Write("Select Bowler (number): ");
                        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= availableBowlers.Count)
                        {
                            currentBowler = availableBowlers[choice - 1];
                            break;
                        }

                        Console.WriteLine("Invalid selection. Try again.");
                    }

                    int ballsThisOver = 0;

                    while (ballsThisOver < 6 &&
                           ballsBowled < maxBalls &&
                           battingTeam.WicketsLost < batsmen.Count)
                    {
                        Console.WriteLine("Press ENTER to bowl");
                        Console.ReadLine();
                        IRandomHelper iRandomHelper = new RandomHelper();
                        string result = iRandomHelper.GetBallResult();
                        Console.Write($"{currentBowler.PlayerName} bowls to {striker.PlayerName} -> ");

                        if (int.TryParse(result, out int runs))
                        {
                            battingTeam.Score += runs;
                            ballsThisOver++;
                            ballsBowled++;
                            //UPDATING PLAYER INFO
                            //====================
                            striker.Runs += runs;
                            striker.BallsFaced++;
                            currentBowler.BowlerBallsBowled++;
                            currentBowler.RunsConceded += runs;
                            //====================

                            if (runs == 6 || runs == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{runs} run(s)");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine($"{runs} run(s)");
                            }
                            //  Strike change on odd runs
                            if (runs % 2 == 1)
                            {
                                (striker, nonStriker) = (nonStriker, striker);
                            }
                        }
                        else if (result == "Wide" || result == "NoBall")
                        {
                            if (result == "NoBall")
                            {

                            
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(result);
                                Console.ResetColor();
                                battingTeam.Score++;
                                striker.BallsFaced++;
                                currentBowler.BallsFaced++;
                                currentBowler.BowlerBallsBowled++;
                                //currentBowler.RunsConceded++;
                                currentBowler.BowlerExtras++;
                                //Console.WriteLine("Its a No Ball and score:");
                                IRandomHelper rnd = new RandomHelper();
                                string noBallresult = rnd.GetNoBallResult();
                                if (int.TryParse(noBallresult, out int noBallruns))
                                {
                                    battingTeam.Score += noBallruns;
                                    //ballsThisOver++;
                                    //ballsBowled++;
                                    //UPDATING PLAYER INFO
                                    //====================
                                    striker.Runs += noBallruns;
                                    striker.BallsFaced++;
                                    currentBowler.BowlerBallsBowled++;
                                    //battingTeam.Score++;
                                    currentBowler.RunsConceded += noBallruns;
                                    //====================

                                    if (noBallruns == 6 || noBallruns == 4)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"{noBallruns} run(s)");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write($"{noBallruns} run(s)");
                                        Console.ResetColor();
                                    }

                                    //  Strike change on odd runs
                                    if (noBallruns % 2 == 1)
                                    {
                                        (striker, nonStriker) = (nonStriker, striker);
                                    }
                                }
                                else if (noBallresult == "Wide")
                                {
                                    currentBowler.BowlerExtras++;
                                    //currentBowler.RunsConceded++;
                                    striker.BallsFaced++;
                                    battingTeam.Score++;
                                    currentBowler.BowlerBallsBowled++;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine(result);
                                    Console.ResetColor();

                                }
                                //else if (noBallresult == "NoBall")
                                //{
                                //    goto noBall;
                                //}
                            }

                            else if (result == "Wide")
                            {
                                //UPDATING PLAYER INFO
                                //=====================
                                currentBowler.BowlerExtras++;
                                striker.BallsFaced++;
                                //=====================
                                battingTeam.Score += 1;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(result);
                                Console.ResetColor();
                            }

                        }
                        else // WICKET
                        {
                            battingTeam.WicketsLost++;

                            ballsThisOver++;
                            ballsBowled++;

                            //player info update
                            currentBowler.BowlerBallsBowled++;
                            currentBowler.WicketsTaken++;
                            striker.isOut = true;
                            striker.BallsFaced++;

                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine($"WICKET! {striker.PlayerName} is out.");
                            Console.ResetColor();

                            if (batsmanIndex < batsmen.Count)
                            {
                                striker = batsmen[batsmanIndex];
                                batsmanIndex++;
                                Console.WriteLine($"{striker.PlayerName} comes to bat");
                            }
                            else
                            {
                                break;
                            }
                        }

                        //  Target check (second innings)
                        if (target > 0 && battingTeam.Score >= target)
                        {
                            battingTeam.BallsPlayed = ballsBowled;
                            Console.WriteLine("\n TARGET ACHIEVED!");

                            Console.ReadLine();
                            battingTeam.DisplayBatsmanInfo();
                            Console.ReadLine();
                            bowlingTeam.DisplayBowlersInfo();
                            Console.ReadLine();
                            return;
                        }

                    }

                    // Strike change at END of over
                    lastBowler = currentBowler;
                    (striker, nonStriker) = (nonStriker, striker);
                }
                catch
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto choice;
                }

            }
            //Console.Clear();
            battingTeam.BallsPlayed = ballsBowled;

            Console.WriteLine($"\n{battingTeam.TeamName} Score: {battingTeam.Score}/{battingTeam.WicketsLost}");
            Console.ReadLine();

            battingTeam.DisplayBatsmanInfo();
            Console.ReadLine();
            bowlingTeam.DisplayBowlersInfo();
            Console.ReadLine();
        }
    }


}