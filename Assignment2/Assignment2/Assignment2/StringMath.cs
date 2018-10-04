using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace StringMath
{
    public class StringMath
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter 'exit' to end program.");
            bool runFlag = true;
            while (runFlag) {
                Console.Write("Enter math operation to solve (e.g. 2*5): ");

                String line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    runFlag = line.ToLower().Equals("exit") ? false : true;
                    if (runFlag && !(line.Length == 0 || line.Length < 3))
                    {
                        MatchCollection operands = parseOneLine(line);
                        char op = findOperator(line, operands);
                        double result = evaluateExpression(operands, op);
                        printFormattedResult(result);
                    }
                }
            }
            Console.WriteLine("Program complete.");
        }

        private static MatchCollection parseOneLine(string line)
        {
            line = System.Text.RegularExpressions.Regex.Replace(line, " ", "");
            //0-1 minus signs followed by 1+ digits, optional decimal point and precision digits
            Regex regex = new Regex(@"(?<!\d)-?\d+(\.\d+)?"); 
            MatchCollection matches = regex.Matches(line);

            if (matches.Count != 2)
                throw new ArgumentException($"Invalid expression {line}");
            return matches;
        }

        private static char findOperator(string line, MatchCollection operands)
        {
            List<char> delimiters = new List<char> { '+', '-', '/', '*', '%', '^', };
            IEnumerator<Match> en = (IEnumerator < Match >) operands.GetEnumerator();
            en.MoveNext();
            Match lhs = en.Current;
            char c = line[lhs.Index + lhs.Length];
            if (delimiters.Contains(c))
                return c;
            throw new ArgumentException($"Incorrect format cannot find operator: {line}");
        }


        private static double evaluateExpression(MatchCollection operands, char op)
        {
            string lhsString = operands[0].Value;
            string rhsString = operands[1].Value;
            bool lDec = lhsString.Contains(".");
            bool rDec = rhsString.Contains(".");
            double lhs, rhs;
            if (lDec || rDec)
            {
                Double.TryParse(lhsString, out lhs);
                Double.TryParse(rhsString, out rhs);
            }
            else
            {
                long.TryParse(lhsString, out long lTemp);
                long.TryParse(rhsString, out long rTemp);
                lhs = Convert.ToDouble(lTemp);
                rhs = Convert.ToDouble(rTemp);
            }
            return evaluateOperands(lhs, rhs, op);
        }

        private static double evaluateOperands(double lhs, double rhs, char op)
        {
            switch (op)
            {
                case '+':
                    return lhs + rhs;
                case '-':
                    return lhs - rhs;
                case '*':
                    return lhs * rhs;
                case '/':
                    return lhs / rhs;
                case '%':
                    return lhs % rhs;
                case '^':
                    try
                    {
                        return Math.Pow(lhs, rhs);
                    }
                    catch(OverflowException ex)
                    {
                        Console.WriteLine($"Exception: answer too large! {lhs}{op}{rhs}");
                        return 0;
                    }
                default:
                    throw new ArgumentException("Unsupported operator");
            }
       
        }

        private static void printFormattedResult(double result)
        {
            double precision = .00001;
            if (Math.Abs(result - Math.Truncate(result)) < precision)
            {
                Console.WriteLine($"{result:0F}");
            }
            else{
                Console.WriteLine($"{result:4F}");
            }
        }

    }
}
