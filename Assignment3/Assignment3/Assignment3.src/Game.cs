using System;
using System.Collections.Generic;

namespace Assignment3
{
    public class Game
    {


        public static void Main(string[] args)
        {
            
            Player human = new Player("Human");
            Player computer = new Player("Computer");
            (Player winner, Player loser, int damageTaken) roundResult;
            RockPaperScissors rps = new RockPaperScissors();
            int round = 0;

            PrintWelcome(rps);
            PrintStatus(1, human, computer);
            bool runFlag = true;
            while (runFlag)
            {
                if (GetUserChoice(out string userChoice))
                {
                    round++;
                   
                    human.LastMove = userChoice;
                    computer.LastMove = GetComputerChoice();
                    roundResult = EvaluateRound(human, computer, rps);
                    UpdateHealth(roundResult, out human, out computer);
                    PrintRoundResult(roundResult);
                    if (GameIsOver(human, computer))
                    {
                        PrintStatus(round-1, human, computer);
                        Console.WriteLine($"\n{roundResult.winner.Name} has won!");
                        runFlag = ContinuePrompt();
                        round = 0;
                        human.Health = 100;
                        computer.Health = 100;
                    }
                    PrintStatus(round, human, computer);
                }
                else
                {
                    Console.WriteLine("Invalid option, please retry.");
                }

            }
            Console.WriteLine("\nGame complete.");
        }


        public struct Player
        {
            readonly string name;
            int health;
            string lastMove;

            public Player(string n = "Player", int h = 100, string lm = "")
            {
                name = n;
                health = h;
                lastMove = lm;
            }
            public int Health { get => health; set => health = value; }
            public string LastMove { get => lastMove; set => lastMove = value; }
            public string Name { get => name;}
        }


        public static void PrintWelcome(RockPaperScissors rps)
        {

            Console.Out.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.Out.WriteLine("You will face the computer, each of you has 100 health.");
            Console.Out.WriteLine("If you run out of health, you lose!");
            Console.Out.WriteLine($"Damage from each type: ");
            Console.Out.WriteLine($"Rock {rps.ROCK.damage}, Paper {rps.PAPER.damage}, Scissors {rps.SCISSORS.damage}\n");
        }

        public static bool GetUserChoice(out string line)
        {
            List<string> validOptions = new List<string> { "rock", "paper", "scissors" };
            
            Console.Out.Write("Pick your choice; rock, paper, or scissors: ");
            line = Console.ReadLine();
            
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }
            if (validOptions.Contains(line.ToLower()))
            {
                return true;
            }
            return false;
        }


        public static string GetComputerChoice()
        {
            string[] validOptions = { "rock", "paper", "scissors" };
            Random rdm = new Random();
            return validOptions[rdm.Next(3)];
        }

        public static (Player winner, Player loser, int damageTaken) 
            EvaluateRound(Player human, Player computer, RockPaperScissors rps)
        {
            if (human.LastMove.Equals(computer.LastMove))
            {
                return (human, computer, 0);
            }
            else
            {
                int humanOrdinal = rps.GetOrdinalByName(human.LastMove);
                int compOrdinal = rps.GetOrdinalByName(computer.LastMove);

                return (RockPaperScissors.Compare(compOrdinal, humanOrdinal) <  0) ?
                    (computer, human, rps.GetDamageByName(computer.LastMove)) :
                    (human, computer, rps.GetDamageByName(human.LastMove)); 
            }

        }


        public static void UpdateHealth((Player winner, Player loser, int damageTaken) result, out Player human, out Player computer)
        {
            result.loser.Health = result.loser.Health - result.damageTaken;
            human = (result.winner.Name.Equals("Computer"))? result.loser : result.winner;
            computer = (result.winner.Name.Equals("Computer")) ? result.winner : result.loser;
        }

       
        private static void PrintStatus(int round, Player human, Player computer)
        {
            Console.WriteLine($"\nRound {round}:");
            Console.WriteLine($"Round {human.Name}: {human.Health} health");
            Console.WriteLine($"Round {computer.Name}: {computer.Health} health");
        }

        private static void PrintRoundResult((Player winner, Player loser, int damageTaken) result)
        {
            Console.WriteLine($"{result.winner.Name} used {result.winner.LastMove} vs " +
                   $"{result.loser.Name}'s {result.loser.LastMove}.");
            if (result.damageTaken == 0)
            {          
                Console.WriteLine("Result: Draw!");
            }
            else
            {
                Console.WriteLine($"Result: {result.loser.Name} takes {result.damageTaken} damage from {result.winner.LastMove}!");
            }
            
        }

        public static bool GameIsOver(Player human, Player computer)
        {
            return human.Health<=0 || computer.Health <=0;
        }

        public static bool ContinuePrompt()
        {
            Console.Write("Do you wish to play again (y/n): ");
            string response = Console.ReadLine().ToLower();
            if (response.Equals("yes") || response.Equals("y"))
            {
                return true;
            }
            return false;
        }

    }
}
