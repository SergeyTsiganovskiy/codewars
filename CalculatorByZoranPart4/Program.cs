using System;
using System.Collections.Generic;
using Demo.Common;
using Demo.Domain;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemStatements.WriteLinesTo(Console.Out);
        }

        private static IEnumerable<ProblemStatement> ProblemStatements =>
            new ConsoleProblemsReader().ReadAll();
    }
}