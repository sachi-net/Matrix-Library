namespace MatrixLibrary.MessageTemplates
{
    internal static class Message
    {
        internal const string INVAID_DIMENSION = "Matrix dimensions cannot be zero or negative.";
        internal const string MATRIX_NOT_INITIALIZED = "Matrix is not initialized.";
        internal const string ARGUMENT_NULL = "Provided argument is not initialized.";
        internal const string DIMENSION_NOT_MATCH = "Matrix dimension does not match with the provided dataset.";
        internal const string DIMENSION_OUT_OF_RANGE = "Matrix dimension out of range.";
        internal const string INVALID_OPERATION_NONSQ = "The operation is invalid for a non-squre matrix.";
        internal const string INVALID_OPERATION_MULT = "The operation is invalid for non-matching column and row order of first and second operands.";
        internal const string INVALID_MATRIX_ORDER = "Matrix orders of the provided operands are not same.";
        internal const string NOT_INVERTIBLE = "Zero determinant matrix is not not invertible.";
    }
}
