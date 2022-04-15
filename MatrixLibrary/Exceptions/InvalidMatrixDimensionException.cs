using System;

namespace MatrixLibrary.Exceptions
{
    public class InvalidMatrixDimensionException : Exception
    {
        public InvalidMatrixDimensionException()
        {

        }

        public InvalidMatrixDimensionException(string message) : base(message)
        {

        }

        public InvalidMatrixDimensionException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
