using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars.Common
{
    static class StringExtensions
    { 
        // in pipilines intermediate data shouldn't be thrown away
        // in good pipelines on every step data is transformed in some way and is passed to the further step
        // every pipeline's step returns different object string -> int -> expresstion etc.
        // intermediate obj shouldn't be transformed twice (it is not efficient because garbage collector cann't delete them)
        // the whole program is just a single pipeline
        // for instance when we want to validate smth in pipeline we may use Select to create intermediate obj
        // like new {correst: int.TryParse(strench, out int value) && value >= 0 , value: 3}
        // 
        public static IEnumerable<string> CorrectSequences(this IEnumerable<string> lines) =>
            lines.Where(line => Regex.IsMatch(line, @"^[-()+*/\d\t]"));

    }
}
