using System;
using System.Numerics;

namespace ConsoleApp2
{

    class Program
    {

        static void Main(string[] args)
        {


            const int n = 5;
            const int m = 5;
            const int k = 21; //ОсиповаДианаАндреевна

            double[][] arr = new double[n][];
            arr[0] = new double[] { 12 + k, 2, m / 4.0, 1, 2 };
            arr[1] = new double[] { 4, 113 + k, 1, (m / 10.0), m - 4 };
            arr[2] = new double[] { 1, 2, -24 - k, 3, 4 };
            arr[3] = new double[] { 1, 2.0 / m, 4, 33 + k, 4 };
            arr[4] = new double[] { -1, 2, -3, 3 + m, -44 - k };

            double[] b = new double[n] { 1, 2, 3, 4, 5 };

            double eps = Math.Pow(10, -4);

            Console.WriteLine("Начальная матрица:");
            ConsoleApp2.Yakobi.PrintMatrixAtConsole(arr);
            Console.WriteLine();

            Console.WriteLine("Методом Якоби:");
            double[] x = ConsoleApp2.Yakobi.Calc(arr, b, eps);
            Console.WriteLine("Ответ : ");
            ConsoleApp2.Yakobi.PrintArrayAtConsole(x);
            Console.WriteLine("Проверка:");
            Console.WriteLine("A * X = ");
            ConsoleApp2.Yakobi.PrintArrayAtConsole(ConsoleApp2.Yakobi.MultMatrixByVector(arr, x));
            Console.WriteLine();

            Console.WriteLine("Методом квадратного корня:");
           /* Complex[][] arr2 = new Complex[n][];
            arr2[0] = new Complex[] { 12 + k, 2, m / 4.0, 1, 2 };
            arr2[1] = new Complex[] { 4, 113 + k, 1, (m / 10.0), m - 4 };
            arr2[2] = new Complex[] { 1, 2, -24 - k, 3, 4 };
            arr2[3] = new Complex[] { 1, 2.0 / m, 4, 33 + k, 4 };
            arr2[4] = new Complex[] { -1, 2, -3, 3 + m, -44 - k };*/

            //Complex[] b2 = new Complex[n] { 1, 2, 3, 4, 5 };
            b = ConsoleApp2.FullSqr.MultMatrixByVector(ConsoleApp2.FullSqr.MatrixTransport(arr), b);
            double[] x1 = ConsoleApp2.FullSqr.Calc(arr, b);
            Console.WriteLine("Ответ : ");
            ConsoleApp2.FullSqr.PrintArrayAtConsole(x1);
            Console.WriteLine("Проверка:");
            Console.WriteLine("A * X = ");
            ConsoleApp2.FullSqr.PrintArrayAtConsole(ConsoleApp2.FullSqr.MultMatrixByVector(arr, x1));

            // Console.WriteLine(Complex.Sqrt(-5));





            Console.WriteLine("Hello World!");
        }
    }
}
