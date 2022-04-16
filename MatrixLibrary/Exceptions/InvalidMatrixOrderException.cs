using System;

namespace MatrixLibrary.Exceptions
{
    /// <summary>
    /// Exception when the matrix order is not compatible.
    /// </summary>
    public class InvalidMatrixOrderException : Exception
    {
        /// <summary>
        /// Initialize an instance of InvalidMatrixOrderException.
        /// </summary>
        public InvalidMatrixOrderException()
        {

        }

        /// <summary>
        /// Initialize an instance of InvalidMatrixOrderException with specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public InvalidMatrixOrderException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize an instance of InvalidMatrixOrderException with specified message and exception that cause this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference.</param>
        public InvalidMatrixOrderException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
