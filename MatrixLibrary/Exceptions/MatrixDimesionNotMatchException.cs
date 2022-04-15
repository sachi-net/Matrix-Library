using System;

namespace MatrixLibrary.Exceptions
{
    public class MatrixDimesionNotMatchException : Exception
    {
        public MatrixDimesionNotMatchException()
        {

        }

        public MatrixDimesionNotMatchException(string message) : base(message)
        {

        }

        public MatrixDimesionNotMatchException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
