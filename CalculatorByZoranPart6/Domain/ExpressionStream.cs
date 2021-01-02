using System.Collections.Generic;
using System.Linq;
using Demo.Common;

namespace Demo.Domain
{
    class ExpressionStream
    {
        public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
            inputNumbers.IsEmpty() ? Enumerable.Empty<Expression>()
            : new[] {this.Add(inputNumbers)};

        private Expression Add(IEnumerable<int> numbers) =>
            numbers.Select<int, Expression>(number => new Literal(number))
                .Aggregate((left, next) => new Add(left, next));
    }
}