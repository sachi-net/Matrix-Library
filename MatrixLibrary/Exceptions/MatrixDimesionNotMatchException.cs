using System;

namespace MatrixLibrary.Exceptions
{
    /// <summary>
    /// Exception when the matrix dimension is not compatible with dataset.
    /// </summary>
    public class MatrixDimesionNotMatchException : Exception
    {
        /// <summary>
        /// Initialize an instance of MatrixDimesionNotMatchException.
        /// </summary>
        public MatrixDimesionNotMatchException()
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixDimesionNotMatchException with specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public MatrixDimesionNotMatchException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize an instance of MatrixDimesionNotMatchException with specified message and exception that cause this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference.</param>
        public MatrixDimesionNotMatchException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
