using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public class RockPaperScissors
    {
        public (string name, int damage, int ordinal) ROCK;
        public (string name, int damage, int ordinal) PAPER;
        public (string name, int damage, int ordinal) SCISSORS;

        public RockPaperScissors(int rockDmg = 20, int pprDmg = 10, int scrDmg = 15)
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
            switch (name.ToLower())
            { 
            case "rock" :
                return ROCK.ordinal;
            case "paper":
                return PAPER.ordinal;
            case "scissors":
                return SCISSORS.ordinal;
            default:
                throw new ArgumentException($"'{name}' is not a valid option!");
            }
        }

        public static int Compare(int lhsOrdinal, int rhsOrdinal)
        {
            if (lhsOrdinal == rhsOrdinal)
            {
                return 0;
            }
            switch (lhsOrdinal)
            {
                case 1:
                    if (rhsOrdinal == 3) //rock loses to paper
                    {
                        return 1;
                    }
                    break;
                case 3:
                    if (rhsOrdinal == 1) //rock loses to paper
                    {
                        return -1;
                    }
                    break;
            }
            return lhsOrdinal - rhsOrdinal;
        }

    }
}

