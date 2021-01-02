using Codewars.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars
{
    internal class ConsoleReader
    {

        // delegate part of responsibility to property RawSequence and part to constructor of Expression
        // the only responsibility which is left is a glue => how exacty map raw sequence to expression (operator Select)
        // that is why two components operate together even not knowing about each other
        // never leave property not setted
        // finally the task ReadAll is reduced because of delegation !!! IT IS FUNDAMENTAL PROCCES IN EMERGETN DESIGN
        // even if delegation is to one line func on next line => it is delegation, reducing complexiti and increasing of maintanability
        // again and again I refuse to do anuthing which is not my immediate duty
        // some third party API tends to return null as the indicator of end of proccess or empty string whatever. Our responsibility to 
        // incapsulate it in object to protect agains NullReference of upper level code
        // beware of cycle eaters => code which is needlessly slow, repet some action many times for instance
        // if we transform one line at time compiler will guid what to do
        // when programm is organized as sets of pipelines -> it is easy to modify some stage without changing other parts !!
        // it is especially important in business logic while maintaining
        public IEnumerable<string> RawSequence =>
            NullableRawSequence(this.PromptInputExpression)
            .TakeWhile(line => !ReferenceEquals(line, null))
            .CorrectSequences();

        private void PromptInputExpression() =>
            Console.Write("Input expression: ");

        private static IEnumerable<string> NullableRawSequence(Action promt)
        {
            while (true)
            {
                promt();
                yield return Console.In.ReadLine();
            }
        }

        internal IEnumerable<Expression> ReadAll() =>
             this.RawSequence.Select(inputs => new Expression(inputs));
    }
}