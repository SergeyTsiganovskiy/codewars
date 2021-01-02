using System.Collections.Generic;

namespace Codewars
{
    internal class Expression
    {
        private string inputString { get; }

        public Expression(string inputString)
        {
            this.inputString = inputString;
        }

        public override string ToString() => inputString;
       }
}