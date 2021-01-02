using System.Collections.Generic;
using System.Linq;

namespace CalculatorWrongByZoran
{
    class Expression
    {
        public int Value { get; }
        private char Operator { get; }
        private Expression LeftChild { get; }
        private Expression RightChild { get; }
        public IEnumerable<int> UsedNumbers { get; }

        public Expression(int value)
        {
            this.Value = value;
            this.UsedNumbers = new[] { value };
            this.Operator = '\0';
        }

        private Expression(
            int value, char @operator,
            Expression leftChild, Expression rightChild)
        {
            this.Value = value;
            this.Operator = @operator;
            this.UsedNumbers = leftChild.UsedNumbers.Union(rightChild.UsedNumbers);
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public Expression CombineWith(Expression other, char @operator, int value) =>
            new Expression(value, @operator, this, other);

        public override string ToString() =>
            $"{this.PlainToString(this)} = {this.Value}";

        private string PlainToString(Expression expr) => this.Operator == '\0' ? $"{expr.Value}" : $"{expr.Parenthesize(expr.LeftChild)} {expr.Operator} {expr.Parenthesize(expr.RightChild)}";

        private string Parenthesize(Expression child) => child.Operator == '\0' ? $"{child.Value}" : $"({this.PlainToString(child)})";
    }
}