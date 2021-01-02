namespace Demo.Domain
{
    class Add : Expression
    {
        private Expression Left { get; }
        private Expression Right { get; }

        public override int Value => 
            this.Left.Value + this.Right.Value;

        public Add(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override string ToString() =>
            $"{this.Left} + {this.Right}";
    }
}
