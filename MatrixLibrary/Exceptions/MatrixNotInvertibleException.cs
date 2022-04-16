using System;

namespace MatrixLibrary.Exceptions
{
    /// <summary>
    /// Exception when the matrix does not support inverse operation.
    /// </summary>
    public class MatrixNotInvertibleException : Exception
    {
        /// <summary>
        /// Initialize an instance of MatrixNotInvertibleException.
        /// </summary>
        public MatrixNotInvertibleException()
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixNotInvertibleException with specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public MatrixNotInvertibleException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixNotInvertibleException with specified message and exception that cause this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference.</param>
        public MatrixNotInvertibleException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
