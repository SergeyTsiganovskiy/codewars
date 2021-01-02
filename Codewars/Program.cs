using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Codewars
{
    class Program
    {
        private static IEnumerable<Expression> Expressions => new ConsoleReader().ReadAll();

        // In infinite loop user enter expression
        // Program shoud print out the result of expression
        // start from top level logic
        // if not clear what they shold retun => make them return nothing: Enumerable.Empty, empty lambda in foreach
        // all previous functionality should work as previous
        // avoid general name for exact classes
        // try to keep function a few lines of code and the rest delegate to more specific function
        // benefit from delegation => being in specific classes or function we dont care what is happening on previos level
        // in emergent design keep an eye on that classes be responsible for one particular responsibility
        // difficult function also divide on smaller clear peaces for reusing and better understanding

        static void Main(string[] args)
        {
            Expressions.WriteLinesTo(Console.Out);

            Console.ReadKey();
        }


        public static string Evaluate(string init)
        {
            //var signs = new []  { '*', '/', '+', '-' };

            var signs = new[] { '/' };

            double result = 0.0;
            string res = "";

            string expression = RemoveSpaces(init);

            signs.ToList().ForEach(sign =>
            {
                res = expression;

                var signIndex = expression.IndexOf(sign);
                double.TryParse(expression[signIndex - 1].ToString(), out double partition1);
                double.TryParse(expression[signIndex + 1].ToString(), out double partition2);

                result = sign == '/' ? partition1 / partition2 : partition1 + partition2;

                res = expression.Replace($"{partition1}{sign}{partition2}", $"{result}");

            });

            return res;
        }

        public static string RemoveSpaces(string initString)
        {
            return new string(initString.ToCharArray().Where(x => !char.IsWhiteSpace(x)).ToArray());
        }


    }
}

