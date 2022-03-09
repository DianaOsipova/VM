using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp2
{
    class FullSqr
    {

        public static double[] Calc (double[][] matrix, double[] b)
        {
            double[][] a = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                { 
                    a[j] = new double[matrix[i].Length];
                    a[j][i] = 0;
                }
            }
            a = MultMatrix(matrix, MatrixTransport(matrix));

            //Console.WriteLine($"Ответ: x{4}: ");
            return BackTurn(RightTurn(a), b);
        }
        public static double[] MultMatrixByVector(double[][] matrix, double[] arr)
        {
            double[] result = new double[arr.Length];

            if (matrix.Length != arr.Length)
                throw new Exception("невозможно умножить матрицу на вектор");

            for (int i = 0; i < matrix.Length; i++)
            {
               double sum = 0.0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sum += matrix[i][j] * arr[j];
                }
                result[i] = sum;
            }
            return result;
        }

        public static void PrintArrayAtConsole(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("   " + Math.Round( arr[i], 5));
            }
            Console.WriteLine();
        }
        public static double[][] MatrixTransport(double[][] matrix)
        {
          double[][] result = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0)
                        result[j] = new double[matrix[i].Length];
                    result[j][i] = matrix[i][j];
                }
            }
            return result;
        }

        public static Complex[][] RightTurn(double[][] matrix)
        {
            Complex[][] t = new Complex[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    
                        t[j] = new Complex[matrix[i].Length];
                    t[j][i] = 0.0;
                }
            }

            t[0][0] = Complex.Sqrt(matrix[0][0]);
            for (int j =1; j < matrix.Length; j++)
            {
                t[0][j] = matrix[0][j]/ t[0][0];
            }
            Complex sum1 = 0.0;
            Complex sum2 = 0.0;
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int k = 0; k < i-1; k++)
                {
                    sum1 += t[k][i] * t[k][i];
                }
                t[i][i] = Complex.Sqrt(matrix[i][i] - sum1);
                sum1 = 0.0;

                for (int j = i + 1; j < matrix.Length; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < i - 1; k++)
                        {
                            sum2+= t[k][i] * t[k][j];
                        }
                        t[i][j] = (matrix[i][j] - sum2) / t[i][i];
                        sum2 = 0;
                    }
                }
            }
            return t;
        }

        public static double[] BackTurn(Complex[][] t, double[] b)
        {
            Complex[] y = new Complex[t.Length];
            double[] x = new double[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                y[i] = 0.0;
                x[i] = 0.0;
            }

            Complex sum1 = 0;
            // sum1 = 0.0;
            Complex sum2 = 0;
            //sum2 = 0.0;
            y[0] = b[0] / t[0][0];
            for (int i = 1; i < t.Length; i++)
            {
                for(int k = 0; k < i-1; k++)
                {
                    sum1 += t[k][i] * y[k];
                }
                y[i] = (b[i] - sum1) / t[i][i];
                sum1 = 0.0;
            }

            x[t.Length-1] = (y[t.Length -1] / t[t.Length - 1][t.Length - 1]).Real;
            for (int i = t.Length - 2; i >= 0; i--)
            {
                for (int k = i+1; k < t.Length; k++)
                {
                    sum2 += t[i][k] * x[k];
                    
                }
                x[i] = ((y[i] - sum2) / t[i][i]).Real;
                sum2 = 0.0;
            }

            return x;
        }



        public static double[][] MultMatrix(double[][] matrix1, double[][] matrix2)
        {
            double[][] resultMatrix = new double[matrix1.Length][];
            
            for (int i = 0; i < matrix1.Length; i++)
            {
                resultMatrix[i] = new double[matrix1.Length];
                for (int j =0; j< matrix1.Length; j++)
                resultMatrix[i][j] = 0.0;
            }

            //throw new Exception();



            //var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrix1.Length; i++)
            {
                for (var j = 0; j < matrix1[i].Length; j++)
                {
                    resultMatrix[i][j] = 0;

                    for (var k = 0; k < matrix1[j].Length; k++)
                    {
                        resultMatrix[i][j] += matrix1[i][k] * matrix2[k][j];
                    }
                }

            }
            return resultMatrix;
        }
    }
}
