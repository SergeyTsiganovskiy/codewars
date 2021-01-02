using System.Collections.Generic;
using System.Linq;

namespace CalculatorWrongByZoran
{
    internal class ProblemStatement
    {
        public IEnumerable<int> InputNumbers { get; }
        public int DesiredResult { get; }

        public ProblemStatement(IEnumerable<int> inputNumbers, int desiredResult)
        {
            this.InputNumbers = inputNumbers.ToList();
            this.DesiredResult = desiredResult;
        }
    }
}
