using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo
{
    static class EnumerableExtensions
    {
        public static void WriteLinesTo<T>(this IEnumerable<T> sequence, TextWriter destination) =>
            sequence.Select(obj => $"{obj}").WriteLinesTo(destination);
    
        public static void WriteLinesTo(this IEnumerable<string> lines, TextWriter destination)
        {
            foreach (string line in lines)
                destination.WriteLine(line);
        }
    }
}
