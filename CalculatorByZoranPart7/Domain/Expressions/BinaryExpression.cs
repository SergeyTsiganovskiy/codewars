namespace Demo.Domain.Expressions
{
    abstract class BinaryExpression : Expression
    {
        private Expression Left { get; }
        private Expression Right { get; }

        public override int Value => 
            this.Combine(this.Left.Value, this.Right.Value);

        protected BinaryExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        protected abstract int Combine(int left, int right);
        protected abstract string OperatorToString { get; }

        public override string ToString() =>
            $"{this.Left} {this.OperatorToString} {this.Right}";
    }
}
