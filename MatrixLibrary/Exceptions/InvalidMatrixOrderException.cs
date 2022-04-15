using System;

namespace MatrixLibrary.Exceptions
{
    public class InvalidMatrixOrderException : Exception
    {
        public InvalidMatrixOrderException()
        {

        }

        public InvalidMatrixOrderException(string message) : base(message)
        {

        }

        public InvalidMatrixOrderException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
