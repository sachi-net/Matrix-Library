using System;

namespace MatrixLibrary.Exceptions
{
    public class MatrixDimesionNotMatch : Exception
    {
        public MatrixDimesionNotMatch()
        {

        }

        public MatrixDimesionNotMatch(string message) : base(message)
        {

        }

        public MatrixDimesionNotMatch(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
