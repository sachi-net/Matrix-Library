using System;

namespace MatrixLibrary.Exceptions
{
    /// <summary>
    /// Exception when the matrix is not initialized before usage.
    /// </summary>
    public class MatrixNotInitializedException : ArgumentNullException
    {
        /// <summary>
        /// Initialize an instance of MatrixNotInitializedException.
        /// </summary>
        public MatrixNotInitializedException()
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixNotInitializedException with specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public MatrixNotInitializedException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixNotInitializedException with specified message and exception that cause this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference.</param>
        public MatrixNotInitializedException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixNotInitializedException with specified message and argument that cause this exception.
        /// </summary>
        /// <param name="matrixName">Name of the argunment that cause this exception.</param>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public MatrixNotInitializedException(string matrixName, string message) : base(matrixName, message)
        {

        }
    }
}
