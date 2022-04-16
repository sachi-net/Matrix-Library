using MatrixLibrary.Exceptions;
using MatrixLibrary.MessageTemplates;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary
{
    /// <summary>
    /// Defines a matrix with common matrix properties and operations.
    /// </summary>
    public class Matrix
    {
        private double[,] _data;

        /// <summary>
        /// Get number of rows in matrix dimension.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Get number of columns in matrix dimension.
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Initialize new matrix with given dimension.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of rows.</param>
        /// <exception cref="InvalidMatrixDimensionException">Throws when matrix dimension is negative or zero.</exception>
        public Matrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new InvalidMatrixDimensionException(Message.INVAID_DIMENSION);
            }

            Rows = rows;
            Columns = columns;
            _data = new double[rows, columns];
        }

        /// <summary>
        /// Set elements to this matrix using linear dataset.
        /// </summary>
        /// <param name="values">All matrix elements as a single-dimensional linear array.</param>
        /// <exception cref="ArgumentNullException">Throws when values array is null.</exception>
        /// <exception cref="MatrixDimesionNotMatchException">Throws when matrix dimension not match with element counts in values array.</exception>
        public void SetMatrix(double[] values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values), Message.ARGUMENT_NULL);
            }

            if (Rows * Columns != values.Length)
            {
                throw new MatrixDimesionNotMatchException(Message.DIMENSION_NOT_MATCH);
            }

            for (int i = 0; i < values.Length; i++)
            {
                int row = Convert.ToInt32(Math.Floor((double)i / Columns));
                int col = Convert.ToInt32(Math.Floor((double)i % Columns));
                _data[row, col] = values[i];
            }
        }

        /// <summary>
        /// Set elements to this matrix using two-dimensional dataset.
        /// </summary>
        /// <param name="values">All matrix elements as a two-dimensional array.</param>
        /// <exception cref="ArgumentNullException">Throws when values array is null.</exception>
        /// <exception cref="MatrixDimesionNotMatchException">Throws when matrix dimension not match with element counts in values array.</exception>
        public void SetMatrix(double[,] values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values), Message.ARGUMENT_NULL);
            }

            if (Rows * Columns != values.Length)
            {
                throw new MatrixDimesionNotMatchException(Message.DIMENSION_NOT_MATCH);
            }

            _data = values;
        }

        /// <summary>
        /// Set matrix element at specific location with 1-based indexing.
        /// </summary>
        /// <param name="i">1-based row index of the element.</param>
        /// <param name="j">1-based column index of the element.</param>
        /// <param name="value">The value to be set.</param>
        /// <exception cref="IndexOutOfRangeException">Throws when i and j indexes are 0 or negative or higher than the matrix dimension.</exception>
        public void SetValueAt(int i, int j, double value)
        {
            if (i < 1 || j < 1 || i > Rows || j > Columns)
            {
                throw new IndexOutOfRangeException(Message.DIMENSION_OUT_OF_RANGE);
            }

            _data[i - 1, j - 1] = value;
        }

        /// <summary>
        /// Get matrix element at specific location with 1-based indexing.
        /// </summary>
        /// <param name="i">1-based row index of the element.</param>
        /// <param name="j">1-based column index of the element.</param>
        /// <exception cref="IndexOutOfRangeException">Throws when i and j indexes are 0 or negative or higher than the matrix dimension.</exception>
        /// <returns>The value at the specified location.</returns>
        public double GetValueAt(int i, int j)
        {
            if (i < 1 || j < 1 || i > Rows || j > Columns)
            {
                throw new IndexOutOfRangeException(Message.DIMENSION_OUT_OF_RANGE);
            }

            return _data[i - 1, j - 1];
        }

        /// <summary>
        /// Verify whether the matrix is a square matrix.
        /// </summary>
        /// <returns>True if a square matrix or otherwise False.</returns>
        public bool IsSquare()
        {
            return Rows == Columns;
        }

        /// <summary>
        /// Determine whether this instance and the specified Matrix object have the same dimension and values.
        /// </summary>
        /// <param name="matrix">The matrix to be compared with this instance.</param>
        /// <returns>True if the specified matrix has same dimension and values or otherwise False. If the matrix null, the function returns False.</returns>
        private bool Equals(Matrix matrix)
        {
            if (matrix is null)
            {
                return false;
            }

            if (ReferenceEquals(this, matrix))
            {
                return true;
            }

            if (ReferenceEquals(matrix, null))
            {
                return false;
            }

            bool isEquals = Rows == matrix.Rows && Columns == matrix.Columns;

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Columns; j++)
                {
                    isEquals &= GetValueAt(i, j) == matrix.GetValueAt(i, j);

                    if (!isEquals)
                        return isEquals;
                }
            }

            return isEquals;
        }

        /// <summary>
        /// Get the elements in the matrix as formated with row and column structure.
        /// </summary>
        /// <param name="precision">Decimal precision when displaying the matrix. Default is 5.</param>
        /// <param name="paddingLeft">Left-padding for each element before displaying the matrix. Default is 5.</param>
        /// <param name="paddingChar">Character to use when padding. Default is a single space.</param>
        /// <returns>Matrix elements as a string value.</returns>
        public string Print(int precision = 5, int paddingLeft = 5, char paddingChar = ' ')
        {
            StringBuilder matrix = new();
            for (int i = _data.GetLowerBound(0); i <= _data.GetUpperBound(0); i++)
            {
                for (int j = _data.GetLowerBound(1); j <= _data.GetUpperBound(1); j++)
                    matrix.Append($"{Math.Round(_data[i, j], precision)} ".PadLeft(paddingLeft, paddingChar));
                matrix.AppendLine();
            }
            return matrix.ToString();
        }

        /// <summary>
        /// Convert this matrix to a multi-dimensional array cosists with all elements.
        /// </summary>
        /// <returns>Multi-dimensional array with all matrix elements.</returns>
        public double[,] ToArray()
        {
            return _data;
        }

        private double[,] Swap(double[,] matrix, int i1, int j1, int i2, int j2)
        {
            double temp = matrix[i1, j1];
            matrix[i1, j1] = matrix[i2, j2];
            matrix[i2, j2] = temp;
            return matrix;
        }

        /// <summary>
        /// Calculate the determinant of the matrix.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <returns>Determinant value of the matrix as a double value.</returns>
        public double Determinant()
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            double[,] mx = _data.Clone() as double[,];
            int index;
            double num1, num2, det = 1, total = 1;
            double[] row = new double[Rows + 1];

            for (int i = 0; i < Rows; i++)
            {
                index = i;

                while (index < Rows && mx[index, i] == 0)
                {
                    index++;
                }

                if (index == Rows)
                {
                    continue;
                }

                if (index != i)
                {
                    for (int j = 0; j < Rows; j++)
                    {
                        Swap(mx, index, j, i, j);
                    }
                    det *= Math.Pow(-1, index - i);
                }

                for (int j = 0; j < Rows; j++)
                {
                    row[j] = mx[i, j];
                }

                for (int j = i + 1; j < Rows; j++)
                {
                    num1 = row[i];
                    num2 = mx[j, i];

                    for (int k = 0; k < Rows; k++)
                    {
                        mx[j, k] = (num1 * mx[j, k]) - (num2 * row[k]);
                    }
                    total *= num1;
                }
            }

            for (int i = 0; i < Rows; i++)
            {
                det *= mx[i, i];
            }

            return det / total;
        }

        /// <summary>
        /// Get transposed matrix of this matrix.
        /// </summary>
        /// <returns>Transposed matrix.</returns>
        public Matrix Transpose()
        {
            Matrix result = new(Columns, Rows);

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Columns; j++)
                    result.SetValueAt(j, i, GetValueAt(i, j));
            }

            return result;
        }

        private Matrix AddTo(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), Message.ARGUMENT_NULL);
            }

            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new InvalidMatrixOrderException(Message.INVALID_MATRIX_ORDER);
            }

            Matrix result = new(Rows, Columns);

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Columns; j++)
                {
                    result.SetValueAt(i, j, GetValueAt(i, j) + matrix.GetValueAt(i, j));
                }
            }

            return result;
        }

        private Matrix SubtractFrom(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), Message.ARGUMENT_NULL);
            }

            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new InvalidMatrixOrderException(Message.INVALID_MATRIX_ORDER);
            }

            Matrix result = new(Rows, Columns);

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Columns; j++)
                {
                    result.SetValueAt(i, j, matrix.GetValueAt(i, j) - GetValueAt(i, j));
                }
            }

            return result;
        }

        private Matrix MultiplyByScalar(double scalar)
        {
            Matrix result = new(Rows, Columns);

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Columns; j++)
                {
                    var val = scalar * GetValueAt(i, j);
                    result.SetValueAt(i, j, val == 0 ? 0 : val);
                }
            }

            return result;
        }

        private Matrix Multiply(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), Message.ARGUMENT_NULL);
            }

            if (Columns != matrix.Rows)
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_MULT);
            }

            Matrix result = new(Rows, matrix.Columns);

            int i, j, k;

            for (i = 1; i <= Rows; i++)
            {
                for (j = 1; j <= matrix.Columns; j++)
                {
                    double sum = 0;
                    for (k = 1; k <= Columns; k++)
                    {
                        sum += GetValueAt(i, k) * matrix.GetValueAt(k, j);
                    }
                    result.SetValueAt(i, j, sum);
                }
            }

            return result;
        }

        /// <summary>
        /// Get the minor value of the element found at given location with 1-based indexing.
        /// </summary>
        /// <param name="i">1-based row index of the element to be found the minor value.</param>
        /// <param name="j">1-based column index of the element to be found the minor value.</param>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <exception cref="IndexOutOfRangeException">Throws when i and j indexes are 0 or negative or higher than the matrix dimension.</exception>
        /// <returns>Minor value of the element found at given location.</returns>
        public double GetMinorAt(int i, int j)
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            if (i < 1 || j < 1 || i > Rows || j > Columns)
            {
                throw new IndexOutOfRangeException(Message.DIMENSION_OUT_OF_RANGE);
            }

            Matrix m = new(Rows - 1, Columns - 1);
            List<double> values = new();

            for (int _i = 1; _i <= Rows; _i++)
            {
                for (int _j = 1; _j <= Columns; _j++)
                {
                    if (_i == i || _j == j)
                        continue;

                    values.Add(GetValueAt(_i, _j));
                }
            }

            m.SetMatrix(values.ToArray());
            var minor = m.Determinant();
            return minor == 0 ? 0 : minor;
        }

        /// <summary>
        /// Get the cofactor value of the element found at given location with 1-based indexing.
        /// </summary>
        /// <param name="i">1-based row index of the element to be found the minor value.</param>
        /// <param name="j">1-based column index of the element to be found the minor value.</param>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <exception cref="IndexOutOfRangeException">Throws when i and j indexes are 0 or negative or higher than the matrix dimension.</exception>
        /// <returns>Minor value of the element found at given location.</returns>
        public double GetCoFactorAt(int i, int j)
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            if (i < 1 || j < 1 || i > Rows || j > Columns)
            {
                throw new IndexOutOfRangeException(Message.DIMENSION_OUT_OF_RANGE);
            }

            var cofac = Math.Pow(-1, i + j) * GetMinorAt(i, j);
            return cofac == 0 ? 0 : cofac;
        }

        /// <summary>
        /// Construct the minor matrix for this matrix.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <returns>Minor matrix for this matrix.</returns>
        public Matrix MinorMatrix()
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            Matrix result = new(Rows, Columns);

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Rows; j++)
                {
                    result.SetValueAt(i, j, GetMinorAt(i, j));
                }
            }

            return result;
        }

        /// <summary>
        /// Construct the cofactor matrix for this matrix.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <returns>Cofactor matrix for this matrix.</returns>
        public Matrix CoFactorMatrix()
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            Matrix result = new(Rows, Columns);

            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Rows; j++)
                {
                    result.SetValueAt(i, j, GetCoFactorAt(i, j));
                }
            }

            return result;
        }

        /// <summary>
        /// Construct the adjoint (adjugate) matrix for this matrix.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <returns>Adjoint (adjugate) matrix for this matrix.</returns>
        public Matrix AdjointMatrix()
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            Matrix result = CoFactorMatrix();

            return result.Transpose();
        }

        /// <summary>
        /// Construct the inverse matrix for this matrix.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <exception cref="MatrixNotInvertibleException">Throws when the determinant of this matrix is zero.</exception>
        /// <returns>Inverse matrix of this matrix.</returns>
        public Matrix InverseMatrix()
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            double det = Determinant();

            if (det == 0)
            {
                throw new MatrixNotInvertibleException(Message.NOT_INVERTIBLE);
            }

            Matrix result = AdjointMatrix();

            return result.MultiplyByScalar((1 / det));
        }

        /// <summary>
        /// Construct the identity matrix based on the dimension of this matrix.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the matrix is not a square matrix.</exception>
        /// <returns>Identity matrix based on this matrix</returns>
        public Matrix IdentityMatrix()
        {
            if (!IsSquare())
            {
                throw new InvalidOperationException(Message.INVALID_OPERATION_NONSQ);
            }

            Matrix result = new(Rows, Columns);

            for (int i = 1; i <= Columns; i++)
            {
                result.SetValueAt(i, i, 1);
            }

            return result;
        }

        #region Matrix Generic Operations
        /// <summary>
        /// Add matrix a to matrix b.
        /// </summary>
        /// <param name="a">Matrix a as left operand.</param>
        /// <param name="b">Matrix b as right operand.</param>
        /// <returns>Resultant matrix of addition.</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a is null)
            {
                throw new MatrixNotInitializedException(nameof(a), Message.ARGUMENT_NULL);
            }

            if (b is null)
            {
                throw new MatrixNotInitializedException(nameof(b), Message.ARGUMENT_NULL);
            }

            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new InvalidMatrixOrderException(Message.INVALID_MATRIX_ORDER);
            }

            return a.AddTo(b);
        }

        /// <summary>
        /// Subtract matrix b from matrix a.
        /// </summary>
        /// <param name="a">Matrix a as left operand.</param>
        /// <param name="b">Matrix b as right operand.</param>
        /// <returns>Resultant matrix of subtraction.</returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a is null)
            {
                throw new MatrixNotInitializedException(nameof(a), Message.ARGUMENT_NULL);
            }

            if (b is null)
            {
                throw new MatrixNotInitializedException(nameof(b), Message.ARGUMENT_NULL);
            }

            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new InvalidMatrixOrderException(Message.INVALID_MATRIX_ORDER);
            }

            return b.SubtractFrom(a);
        }

        /// <summary>
        /// Maultiply the matrix with provided scalar value.
        /// </summary>
        /// <param name="scalar">Scalar value</param>
        /// <param name="matrix">Matrix to be multiplied with the scalar.</param>
        /// <returns>Resultant matrix of scalar multiplication.</returns>
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            if (matrix is null)
            {
                throw new MatrixNotInitializedException(nameof(matrix), Message.MATRIX_NOT_INITIALIZED);
            }

            return matrix.MultiplyByScalar(scalar);
        }

        /// <summary>
        /// Multiply matrix a with matrix b.
        /// </summary>
        /// <param name="a">Matrix a as left operand.</param>
        /// <param name="b">Matrix b as right operand.</param>
        /// <returns>Resultant matrix of multiplication.</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a is null)
            {
                throw new MatrixNotInitializedException(nameof(a), Message.MATRIX_NOT_INITIALIZED);
            }

            if (b is null)
            {
                throw new MatrixNotInitializedException(nameof(b), Message.MATRIX_NOT_INITIALIZED);
            }

            if (a.Columns != b.Rows)
            {
                throw new InvalidMatrixOrderException(Message.INVALID_OPERATION_MULT);
            }

            return a.Multiply(b);
        }


        /// <summary>
        /// Compare whether the matrix a is equal to matrix b.
        /// </summary>
        /// <param name="a">Matrix a as left operand.</param>
        /// <param name="b">Matrix b as right operand.</param>
        /// <returns>Return True if equals, otherwise False. If any matrix is null, it returns False.</returns>
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        /// <summary>
        /// Compare whether the matrix a is not equal to matrix b.
        /// </summary>
        /// <param name="a">Matrix a as left operand.</param>
        /// <param name="b">Matrix b as right operand.</param>
        /// <returns>Return True if not equals, otherwise False.</returns>
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !a.Equals(b);
        }
        #endregion

        /// <summary>
        /// Determine whether this instance and the specified object (which should be a Matrix) have the same dimension and values.
        /// </summary>
        /// <param name="obj">The matrix object to be compared with this instance.</param>
        /// <returns>True if the specified matrix has same dimension and values or otherwise False. If the matrix null, the function returns False.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix);
        }

        /// <summary>
        /// Get the hash code for this matrix.
        /// </summary>
        /// <returns>A 32-bit integer hash code.</returns>
        public override int GetHashCode()
        {
            return _data.GetHashCode() * Rows.GetHashCode() * Columns.GetHashCode();
        }
    }
}
