using System;
using System.Collections.Generic;

namespace Assignment3
{
    class Program
    {


        static void Main(string[] args)
        {
            (int ROCK, int PAPER, int SCISSORS) values = (20, 10, 15);
            Player human = new Player();
            Player computer = new Player("Computer");
            PrintWelcome(values);
            int round = 0;
            string userChoice;

            bool runFlag = true;
            while (runFlag)
            {
                userChoice = GetUserChoice().ToLower();
                if (CheckUserChoice(userChoice))
                {
                    human.LastMove = userChoice;
                    computer.LastMove = GetComputerChoice();
                    //EvaluateRound (tuple)
                    //CalculateHealthPoints
                    if (GameIsOver)
                    {
                        //runFlag = continuePrompt()
                    }
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
        }

        public struct RPSValues
        {
            (string name, int damage, int ordinal) ROCK;
            (string name, int damage, int ordinal) PAPER;
            (string name, int damage, int ordinal) SCISSORS;

            public RPSValues(int rockDmg = 20, int pprDmg = 10, int scrDmg =15)
            {
                ROCK = ("rock", rockDmg, 1);
                PAPER = ("paper", pprDmg, 3);
                SCISSORS = ("scissors", scrDmg, 2);
            }
            public int GetDamageByName(string name)
            {
                switch (name)
                {
                    case "rock":
                        return ROCK.damage;
                    case "paper":
                        return PAPER.damage;
                    case "scissors":
                        return SCISSORS.damage;
                    default:
                        throw new ArgumentException($"{name} is not a valid type!");
                }
            }

            public int GetOrdinalByName(string name)
            {
                if (ROCK.name.Equals(name))
                {
                    return ROCK.ordinal;
                }
                else if (PAPER.name.Equals(name))
                {
                    return PAPER.ordinal;
                }
                else if (SCISSORS.name.Equals(name))
                {
                    return SCISSORS.ordinal;
                }
                else
                {
                    throw new ArgumentException($"'{name}' is not a valid option!");
                }
            }

        }


        public static void PrintWelcome((int ROCK, int PAPER, int SCISSORS) values)
        {
            Console.Out.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.Out.WriteLine("You will face the computer, each of you has 100 health.");
            Console.Out.WriteLine("If you run out of health, you lose!");
            Console.Out.WriteLine($"Damage from each type: ");
            Console.Out.WriteLine($"Rock{values.ROCK}, Paper{values.PAPER}, Scissors{values.SCISSORS}");
        }

        public static string GetUserChoice()//TODO Out
        {
            Console.Out.Write("Pick your choice; rock, paper, or scissors: ");
            return Console.ReadLine();
        }

        public static bool CheckUserChoice(string choice)//TODO out
        {
            List<string> validOptions = new List<string> { "rock", "paper", "scissors" };
            if (string.IsNullOrEmpty(choice))
            {
                return false;
            }
            if (validOptions.Contains(choice.ToLower()))
            {
                return true;
            }
            return false;
        }

        public static string GetComputerChoice()
        {
            string[] validOptions = { "rock", "paper", "scissors" };
            Random rdm = new Random(3);
            return validOptions[rdm.Next()];
        }

        public static (Player winner, Player loser, int damageTaken) EvaluateRound(Player human, Player computer)
        {
            if (human.LastMove.Equals(computer.LastMove))
            {
                return (human, computer, 0);
            }
            else
            {
                RPSValues rps = new RPSValues();
                if(rps.GetOrdinalByName(human.LastMove) < 
                    (rps.GetOrdinalByName(computer.LastMove) + 1) % 3)
                {
                    return (human, computer, rps.GetDamageByName(human.LastMove));
                }
                else
                {
                    return (computer, human, rps.GetDamageByName(computer.LastMove)); 
                }
                
            }

        }

    }
}
