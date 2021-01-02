using System.Collections.Generic;
using System.Linq;
using Demo.Domain.Expressions;

namespace Demo.Domain
{
    static class ExpressionExtensions
    {
        public static Expression Add(this Expression head, IEnumerable<Expression> others) =>
            others.Aggregate(head, (current, other) => new Add(current, other));

        public static Expression Subtract(this Expression head, IEnumerable<Expression> others) =>
            others.Aggregate(head, (current, other) => new Subtract(current, other));
    }
}
