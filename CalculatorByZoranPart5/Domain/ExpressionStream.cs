using System.Collections.Generic;
using System.Linq;

namespace Demo.Domain
{
    class ExpressionStream
    {
        public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
            Enumerable.Empty<Expression>();
    }
}
