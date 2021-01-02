using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class ProblemStatement
    {
        private IEnumerable<int> InputNumbers;

        public ProblemStatement(IEnumerable<int> inputNumbers)
        {
            this.InputNumbers = inputNumbers;
        }

        public override string ToString() =>
            $"Problem statement: [{this.InputNumbersFormattedList}]";

        private string InputNumbersFormattedList =>
            string.Join(", ", this.InputNumbers.Select(number => $"{number}").ToArray());
    }
}
