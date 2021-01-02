using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.Common
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

        public static bool AllNonEmpty<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            bool any = false;

            foreach (T obj in sequence)
            {
                if (!predicate(obj)) return false;
                any = true;
            }

            return any;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> sequence) => !sequence.Any();
    }
}
