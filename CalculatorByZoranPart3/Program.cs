using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemStatements.WriteLinesTo(Console.Out);
        }

        static IEnumerable<ProblemStatement> ProblemStatements => 
            new ConsoleProblemsReader().ReadAll();
    }
}