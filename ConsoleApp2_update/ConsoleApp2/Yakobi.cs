using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Yakobi
    {
     
        public static double[] Calc(double[][] a, double[] b, double eps)
        {
            double[][] B = AToB(a);
            double[] d = ChangeB(b, a);
            double q = MaxOfMatrix(B);



            double[] x0 = new double[b.Length]; //по умолчанию инициализируется нулями(значимый тип)
                                                //Console.WriteLine("x0:");
                                                //PrintArrayAtConsole(x0);


            double[] x1 = SumVectors(MultMatrixByVector(B, x0), d);
            //Console.WriteLine("x1:");
            //PrintArrayAtConsole(x1);
            //вычисления
            double[] now = x1;
            double[] pred = x0;
            int count = 1; //счётчик какой сейчас х (x{count})
            while (MaxAbsOfVector(SubVectorsByAbsolute(now, pred)) > ((1 - q) / q) * eps)
            {
                pred = now;
                now = SumVectors(MultMatrixByVector(B, pred), d);
                count++;
            }
            ///////

            //double[] x2 = SumVectors( MultMatrixByVector(B, x1), d);
            //Console.WriteLine("x2:");
            //PrintArrayAtConsole(x2);

            //Console.WriteLine($"Ответ: x{count}: ");
            //PrintArrayAtConsole( now);
            return now;

        }

        public static double[] ChangeB(double[] b, double[][] a)
        {
            double[] result = new double[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                result[i] = b[i] / a[i][i];
            }

            return result;
        }

        public static double[][] AToB(double[][] a)
        {
            double[][] b = new double[a.Length][];

            for (int i = 0; i < a.Length; i++)
            {
                b[i] = new double[a[i].Length];
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (i == j)
                        continue;
                    b[i][j] = -a[i][j] / a[i][i];

                }
            }
            return b;
        }

        public static double MaxOfMatrix(double[][] arr)
        {
            double max = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sum += arr[i][j];
                }
                if (sum > max)
                    max = sum;
            }
            return max;
        }

        public static double MaxAbsOfVector(double[] arr)
        {
            double max = Math.Abs(arr[0]);
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > max)
                {
                    max = Math.Abs(arr[i]);
                }
            }
            return max;

        }

        public static void PrintArrayAtConsole(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("   " + Math.Round(arr[i], 5));
            }
            Console.WriteLine();
        }
        public static void PrintMatrixAtConsole(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write("{0,10}", matrix[i][j]);
                }

            }
            Console.WriteLine();
        }

        public static double[][] MultMatrix(double[][] matrix1, double[][] matrix2)
        {
            double[][] resultMatrix = new double[matrix1.Length][];

            for (int i = 0; i < matrix1.Length; i++)
            {
                resultMatrix[i] = new double[] { 0, 0, 0, 0, 0 };
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

        public static double[] MultMatrixByVector(double[][] matrix, double[] arr)
        {
            double[] result = new double[arr.Length];

            if (matrix.Length != arr.Length)
                throw new Exception("невозможно умножить матрицу на вектор");

            for (int i = 0; i < matrix.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sum += matrix[i][j] * arr[j];
                }
                result[i] = sum;
            }
            return result;
        }

        private static double[] SumVectors(double[] arr1, double[] arr2)
        {
            double[] result = new double[arr1.Length];
            if (arr1.Length != arr2.Length)
                throw new Exception("невозможно сложить вектора");
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }

            return result;
        }

        private static double[] SubVectorsByAbsolute(double[] arr1, double[] arr2)
        {
            double[] result = new double[arr1.Length];
            if (arr1.Length != arr2.Length)
                throw new Exception("невозможно вычесть вектор из вектора");
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = Math.Abs(arr1[i]) - Math.Abs(arr2[i]);
            }

            return result;
        }
    }
}
