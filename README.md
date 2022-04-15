# Matrix-Library
Matrix-Library is .NET 5.0 based reusable library designed perform manipulate matrix properties and common matrix operations. Any .NET 5.0 or above application can utilize the functionalities of Matrix-Library by referring it in the project dependencies.

## Prerequisites
Currently, Matrix-Library dependency is available for local installation only.  
Matrix-Library requires [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) (v5.#.#) or [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (v6.#.#).

## Get Started
Add `MatrixLibrary.dll` to project dependencies.  
Refer the content from the code by adding `using MatrixLibrary;` at the top.

## Implementation Overview
Following table indicates the implementation structure of MatrixLibray.

### Properties
|Name|Type|Description|
|---|---|---|
|Columns|`int`|Get number of rows in matrix dimension|
|Rows|`int`|Get number of columns in matrix dimension|

### Constructors
|Name|Description|
|---|---|
|`Matrix(int rows, int columns)`|Initialize new matrix with given dimension `rows` and `columns`|

### Methods
|Name|Return Type|Description|
|---|---|---|
|`AdjointMatrix()`|`Matrix`|Construct the adjoint (adjugate) matrix for this matrix|
|`CoFactorMatrix()`|`Matrix`|Construct the cofactor matrix for this matrix|
|`Determinant()`|`double`|Calculate the determinant of the matrix|
|`GetCoFactorAt(int i, int j)`|`double`|Get the cofactor value of the element found at given location with 1-based indexing|
|`GetMinorAt(int i, int j)`|`double`|Get the minor value of the element found at given location with 1-based indexing|
|`GetValueAt(int i, int j)`|`double`|Get matrix element at specific location with 1-based indexing|
|`IdentityMatrix()`|`Matrix`|Construct the identity matrix based on the dimension of this matrix|
|`InverseMatrix()`|`Matrix`|Construct the inverse matrix for this matrix|
|`IsSquare`|`bool`|Verify whether the matrix is a square matrix|
|`MinorMatrix()`|`Matrix`|Construct the minor matrix for this matrix|
|`Print([int precision], [int paddingLeft], [char paddingChar])`|`string`|Get the elements in the matrix as formated with row and column structure|
|`SetMatrix(double[,] values)`|`void`|Set elements to this matrix using two-dimensional dataset|
|`SetMatrix(double[] values)`|`void`|Set elements to this matrix using linear dataset|
|`SetValueAt(int i, int j, double value)`|`void`|Set matrix element at specific location with 1-based indexing|
|`ToArray()`|`double[,]`|Convert this matrix to a multi-dimensional array cosists with all elements|
|`Transpose()`|`Matrix`|Get transposed matrix of this matrix|

### Operators
|Name|Symbol|Operands|Description|
|---|---|---|---|
|Add|+ |`Matrix a`, `Matrix b`|Addition of matrix `a` and `b`|
|Subtract|- |`Matrix a`, `Matrix b`|Subtraction of matrix `a` and `b`|
|Multiply|* |`double scalar`, `Matrix matrix`|Multiplication of `matrix` and `scalar`|
|Multiply|* |`Matrix a`, `Matrix b`|Multiplication of matrix `a` and `b`|
|Equality|== |`Matrix a`, `Matrix b`|Equality of matrix `a` and `b`|
|Inequality|!= |`Matrix a`, `Matrix b`|Inequality of matrix `a` and `b`|

## Usage
Following section describe the general usage of `MatrixLibrary` to perform matrix operations.

### Initialize New Matrix
Define order of 3x3 matrix `m`
```C#
Matrix m = new(3, 3);
```

After defined a matrix, there are two ways to set element to the matrix.  
To set elements to the above matrix `m`, pass the value set as a `double[]` array. Here in the value set array, the element count must match matrix order. Therefore, the element array must contain `9` elements to match with `3x3` order. Otherwise the function throws `MatrixDimesionNotMatchException`.
```C#
m.SetMatrix(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
```
The value set can be passed as a multi-dimensional array `double[,]` as well. Here also the element count must match with matrix order.
```C#
m.SetMatrix(new double[3, 3] {
  { 1, 2, 3 },
  { 4, 5, 6 },
  { 7, 8, 9 }
});
```

### Set and Get Values
Matrix elements can be changed at a specific location of the matrix even after it is defined. Set or change value at `i = 2,` and `j = 3` with new value -10.
```C#
m.SetValueAt(2, 3, -10);
```
Get the value at `i = 1` and `j = 3`.
```C#
double value = m.GetValueAt(1, 3);
```
To get all values as a multi-dimensional array, the matrix can be converted to an array `double[,]`.
```C#
double[,] values = m.ToArray();
```
All elements of the matrix can be returned as a `string` formatted with matrix tubular format.
```C#
string matrix = m.Print()
```
In here, the decimal precision, left-padding offset and padding character can be applied when returning it using `Print` function. These settings are optional. Print the matrix with `5` decimal precision, `8` left-padding offset, `*` padding character.
```C#
string matrix = m.Print(precision: 5, paddingLeft: 8, paddingChar: '*');
```

### Matrix Transpose
Transpose of a matrix will flip the values over its diagonal from rows to columns.
```C#
Matrix transposedMatrix = m.Transpose();
```

### Matrix Determinant
The determinant of the matrix can be computed with `Determinant` function. To perform this operation, the matrix must be a square matrix, otherwise the function throws `InvalidOperationException`. The `IsSquare` function can be used to verify whether the matrix order square or not.
```C#
double value = m.Determinant();
```

### Minors and Cofactors
The minor and cofactor values of a specific element in the matrix can be read by providing the location indexes of the element using `GetMinorAt` and `GetCoFactorAt` functions. To perform these operations, the matrix must be a square matrix, otherwise the function throws `InvalidOperationException`. If the indexes are out of reach from matrix dimension, the function throws `IndexOutOfRangeException`.  
To get minor value and cofactor value of the element located at `i = 2` and `j = 3` in matrix `m`.
```C#
double minorValue = m.GetMinorAt(2, 3);
double cofactorValue = m.GetCoFactorAt(2, 3);
```

The entire minor matrix and cofactor matrix for any square matrix can also be constructed.
```C#
Matrix minorMatrix = m.MinorMatrix();
Matrix cofactorMatrix = m.CoFactorMatrix();
```

### Adjoint (Adjugate) and Inverse
The adjoint and inverse matrix can be constructed for a square matrix. To perform these operations, the matrix must be a square matrix, otherwise the function throws `InvalidOperationException`. In `InverseMatrix` function, if the determinant is `0`, the function throws `MatrixNotInvertibleException`.
```C#
Matrix adjointMatrix = m.AdjointMatrix();
Matrix inverseMatrix = m.InverseMatrix();
```

### Identity
For any square matrix can construct its identity matrix. To perform this operation, the matrix must be a square matrix, otherwise the function throws `InvalidOperationException`. The resultant matrix will have the same dimension as the original matrix.
```C#
Matrix identity = m.IdentityMatrix();
```

## Matrix Operations
Matrix object can perform following binary operations.

### Addition
Add two same-dimensional matrices `a` and `b`. The function throws `MatrixNotInitializedException` if matrix `a` or `b` is `null` and throws `InvalidMatrixOrderException` if the order of both matrices do not match.
```C#
Matrix a = new(2, 2);
Matrix b = new(2, 2);
a.SetMatrix(new double[] { 1, 2, 3, 4 });
b.SetMatrix(new double[] { 5, 6, 7, 8 });

Matrix result = a + b;
```

### Subtraction
Subtract two same-dimensional matrices `a` and `b`. The function throws `MatrixNotInitializedException` if matrix `a` or `b` is `null` and throws `InvalidMatrixOrderException` if the order of both matrices do not match.
```C#
Matrix a = new(2, 2);
Matrix b = new(2, 2);
a.SetMatrix(new double[] { 1, 2, 3, 4 });
b.SetMatrix(new double[] { 5, 6, 7, 8 });

Matrix result = a - b;
```

### Multiply by Scalar
Multiply matrix `m` by scalar value. The function throws `MatrixNotInitializedException` if matrix `m` is `null`.
```C#
Matrix m = new(2, 2);
double k = 3;
m.SetMatrix(new double[] { 1, 2, 3, 4 });

Matrix result = k * m;
```

### Multiply by Matrix
Multiply matrix `a` with matrix `b`. The function throws `MatrixNotInitializedException` if matrix `a` or `b` is `null` and throws `InvalidMatrixOrderException` if the order of both matrices do not match for the multiplication. The number of columns of first operand `a` must be same for the number of rows in operand `b` in order to perform matrix multiplication.
```C#
Matrix a = new(2, 2);
Matrix b = new(2, 2);
a.SetMatrix(new double[] { 1, 2, 3, 4 });
b.SetMatrix(new double[] { 5, 6, 7, 8 });

Matrix result = a * b;
```

### Matrix Comparison
If the number of rows, columns and the elements are same for another matrix, then the matrix are equals to each other.
```C#
Matrix m = new(2, 2);
m.SetMatrix(new double[] { 1, 2, 3, 4 });
Matrix i = m.IdentityMatrix(); // Construct identity matrix of m
Matrix v = m.InverseMatrix(); // Construct inverse matrix of m

// Verifying whether the product of matrix and its inverse is equals to identity
Console.WriteLine((m * v) == i); // This results as True because this is the law of matrix invertibility

// Verifying matrix m is not equals to its identity
Console.WriteLine(m != i); // This results as True
```
