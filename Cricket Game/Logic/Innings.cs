using Cricket_Game.Models;
using Cricket_Game.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cricket_Game.Logic
{
    internal class Innings
    {
        public static void StartInnings(Team battingTeam, Team bowlingTeam, int target, int maxBalls)
        {
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

                var bowlers = bowlingTeam.GetBowlers();
                for (int i = 0; i < bowlers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {bowlers[i].PlayerName}");
                }

            choice:
                Console.Write("Select Bowler (number): ");
                try
                {
                    int choice = int.Parse(Console.ReadLine()!);
                    Player currentBowler = bowlers[choice - 1];

                    int ballsThisOver = 0;

                    while (ballsThisOver < 6 &&
                           ballsBowled < maxBalls &&
                           battingTeam.WicketsLost < batsmen.Count)
                    {
                        Console.WriteLine("Press ENTER to bowl");
                        Console.ReadLine();

                        string result = RandomHelper.GetBallResult();
                        Console.Write($"{currentBowler.PlayerName} bowls to {striker.PlayerName} → ");

                        if (int.TryParse(result, out int runs))
                        {
                            battingTeam.Score += runs;
                            ballsThisOver++;
                            ballsBowled++;
                            Console.WriteLine($"{runs} run(s)");

                            // 🔁 Strike change on odd runs
                            if (runs % 2 == 1)
                            {
                                (striker, nonStriker) = (nonStriker, striker);
                            }
                        }
                        else if (result == "Wide" || result == "NoBall")
                        {
                            battingTeam.Score += 1;
                            Console.WriteLine(result);
                        }
                        else // WICKET
                        {
                            battingTeam.WicketsLost++;
                            ballsThisOver++;
                            ballsBowled++;
                            Console.WriteLine($"WICKET! {striker.PlayerName} is out.");

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
                            Console.WriteLine("\n TARGET ACHIEVED!");
                            battingTeam.BallsPlayed = ballsBowled;
                            return;
                        }
                    }

                    // Strike change at END of over
                    (striker, nonStriker) = (nonStriker, striker);
                }
                catch
                {
                    Console.WriteLine("Invalid input. Try again.");
                    goto choice;
                }
                
            }

            battingTeam.BallsPlayed = ballsBowled;
            Console.WriteLine($"\n{battingTeam.TeamName} Score: {battingTeam.Score}/{battingTeam.WicketsLost}");
        }
    }


}
