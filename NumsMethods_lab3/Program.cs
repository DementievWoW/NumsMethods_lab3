using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

double[,] matrix = new double[,] {
  { 8, 7, 0, 0, 0, 0, 0, 0 },
  { 4, 9, 3, 0, 0, 0, 0, 0 },
  { 0, 6, 4, 4, 0, 0, 0, 0 },
  { 0, 0, 7, 4, 9, 0, 0, 0 },
  { 0, 0, 0, 8, 1, 4, 0, 0 },
  { 0, 0, 0, 0, 8, 3, 4, 0 },
  { 0, 0, 0, 0, 0, 8, 8, 6 },
  { 0, 0, 0, 0, 0, 0, 1, 9 }};


Console.WriteLine("Исходная матрица: ");
PrintMatrix(matrix);
double[] upperDiagonals = GetElementsUpperMainDiagonal(matrix);
Console.WriteLine("Выше главной диагонали: ");
PrintVector(upperDiagonals);
double[] mainDiagonals = GetElementsMainDiagonal(matrix);
Console.WriteLine("главной диагонали: ");
PrintVector(mainDiagonals);
double[] lowerDiagonals = GetElementsLowerMainDiagonal(matrix);
Console.WriteLine("ниже главной диагонали: ");
PrintVector(lowerDiagonals);

double[] vectorB = new double[] { 1, 2, 3, 4, 5, 6, 7, 8 };
Console.WriteLine("вектор B:");
PrintVector(vectorB);

var vectorX = MultiplicationMatrixVector(matrix, vectorB);
double[] result = GetRoot(upperDiagonals, mainDiagonals, lowerDiagonals, vectorX);
Console.WriteLine("Вектор ответов: ");
PrintVector(result);
double[] GetElementsLowerMainDiagonal(double[,] matrix)
{
    double[] tmp = new double[matrix.GetLength(0)];
    tmp[0] = 0;
    int vectorIndex = 1;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i > j && matrix[i, j] != 0)
            {
                tmp[vectorIndex++] = matrix[i, j];
            }
        }
    }
    return tmp;
}
void PrintVector(double[] vector)
{
    Console.WriteLine();
    foreach (var i in vector)
    {
        Console.WriteLine("{0}\t", i);

    }
    Console.WriteLine();
}
void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            Console.Write("{0}\t", matrix[i, j]);
        }

        Console.WriteLine();
    }
    Console.WriteLine();
}


double[] GetElementsUpperMainDiagonal(double[,] matrix)
{
    if (matrix.GetLength(0) != matrix.GetLength(1))
    {
        throw new ArgumentException("Матрица должна быть квадратной.");
    }
    double[] tmp = new double[matrix.GetLength(0)];

    int vectorIndex = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i < j && matrix[i, j] != 0)
            {
                tmp[vectorIndex++] = matrix[i, j];
            }
        }
    }
    tmp[matrix.GetLength(0)-1] = 0;
    return tmp;
}
double[] GetElementsMainDiagonal(double[,] matrix)
{
    if (matrix.GetLength(0) != matrix.GetLength(1))
    {
        throw new ArgumentException("Матрица должна быть квадратной.");
    }
    double[] tmp = new double[matrix.GetLength(0)];
    int vectorIndex = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        tmp[vectorIndex++] = matrix[i, i];
    }
    return tmp;
}



double[] GetRoot(double[] upperDiagonals, double[] mainDiagonals, double[] lowerDiagonals, double[] vectorB)
{
    int n = 8;
    double[] x = new double[n];
    double m;
    for (int i = 1; i < n; i++)
    {
        m = lowerDiagonals[i] / mainDiagonals[i - 1];
        mainDiagonals[i] = mainDiagonals[i] - m * upperDiagonals[i - 1];
        vectorB[i] = vectorB[i] - m * vectorB[i - 1];
    }

    x[n - 1] = vectorB[n - 1] / mainDiagonals[n - 1];

    for (int i = n - 2; i >= 0; i--)
    {
        x[i] = (vectorB[i] - upperDiagonals[i] * x[i + 1]) / mainDiagonals[i];
    }
    return x;
}



double[] MultiplicationMatrixVector(double[,] matrix, double[] vector)
{
    double[] result = new double[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            result[i] += matrix[i, j] * vector[j];

        }
    }
    return result;
}
