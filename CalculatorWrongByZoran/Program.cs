using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorWrongByZoran
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ProblemStatement problem = ReadProblem();
                if (problem == null)
                    break;

                Expression solution = Solve(problem);
                string report = solution?.ToString() ?? "No solution found.";
                Console.WriteLine(report);
                Console.WriteLine();
            }
        }

        private static Expression Solve(ProblemStatement problem)
        {
            Queue<Expression> combining = new Queue<Expression>(
                problem.InputNumbers.Select(number => new Expression(number)));

            List<Expression> known = new List<Expression>();

            while (combining.TryDequeue(out Expression current))
            {
                if (current.Value == problem.DesiredResult)
                    return current;

                IEnumerable<Expression> combinableWith = known.Where(
                    expr => !expr.UsedNumbers.Intersect(current.UsedNumbers).Any()).ToList();

                foreach (Expression existing in combinableWith)
                {
                    combining.Enqueue(
                        current.CombineWith(existing, '+', current.Value + existing.Value));
                }

                known.Add(current);
            }

            return null;
        }

        private static ProblemStatement ReadProblem()
        {
            Console.Write("Numbers to use (RETURN to exit): ");
            string line = Console.ReadLine() ?? string.Empty;
            string[] values = line.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            List<int> input = values
                .Where(value => Regex.IsMatch(value, @"^\d+$"))
                .Select(int.Parse)
                .ToList();

            if (input.Count == 0)
                return null;

            Console.Write("           Enter desired result: ");
            string rawNumber = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(rawNumber, out int desiredResult))
                desiredResult = 0;

            return new ProblemStatement(input, desiredResult);
        }
    }
}
