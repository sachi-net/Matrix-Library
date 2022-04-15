using System;

namespace MatrixLibrary.Exceptions
{
    public class MatrixNotInvertibleException : Exception
    {
        public MatrixNotInvertibleException()
        {

        }

        public MatrixNotInvertibleException(string message) : base(message)
        {

        }

        public MatrixNotInvertibleException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
