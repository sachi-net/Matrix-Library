using System;

namespace MatrixLibrary.Exceptions
{
    /// <summary>
    /// Exception when the matrix dimension is unrealistic to initialize the matrix.
    /// </summary>
    public class InvalidMatrixDimensionException : Exception
    {
        /// <summary>
        /// Initialize an instance of InvalidMatrixDimensionException.
        /// </summary>
        public InvalidMatrixDimensionException()
        {

        }

        /// <summary>
        /// Initialize an instance of InvalidMatrixDimensionException with specified message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public InvalidMatrixDimensionException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize an instance of InvalidMatrixDimensionException with specified message and exception that cause this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference.</param>
        public InvalidMatrixDimensionException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
