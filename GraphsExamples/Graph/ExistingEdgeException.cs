using System;

namespace GraphsExamples
{
    public class ExistingEdgeException : Exception
    {
        public ExistingEdgeException()
        {

        }

        public ExistingEdgeException(string message)
            :base(message)
        {

        }

        public ExistingEdgeException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
