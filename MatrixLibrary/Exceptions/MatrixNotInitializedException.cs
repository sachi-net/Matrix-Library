using System;

namespace MatrixLibrary.Exceptions
{
    public class MatrixNotInitializedException : ArgumentNullException
    {
        public MatrixNotInitializedException()
        {

        }

        public MatrixNotInitializedException(string message) : base(message)
        {

        }

        public MatrixNotInitializedException(string message, Exception inner) : base(message, inner)
        {

        }

        public MatrixNotInitializedException(string matrixName, string message) : base(matrixName, message)
        {

        }
    }
}
