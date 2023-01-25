using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmlab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tКоординаты точек: ");

            double[] xkor = Xi();
            Console.WriteLine();
            double[] ykor = Yi(xkor);
            double[,] arrayOfPoint = new double[14, 2];
            for (int i = 0; i < 14; i++)
            {
                arrayOfPoint[i, 0] = xkor[i];
                arrayOfPoint[i, 1] = ykor[i];
            }
            Console.WriteLine();
            Console.WriteLine("\tИнтерполяция полиномом Лагранжа: ");
            Console.WriteLine();
            Console.WriteLine(Lagrange(6.6, xkor, ykor));
            Console.WriteLine(Math.Round(Math.Sin(3.73 * 6.6 + 4.57), 4));
            Console.WriteLine();

            Console.WriteLine("\tАппроксимация методом наименьших квадратов: ");
            double x = 6.6;
            double[,] array_simple = SimpleSquare(arrayOfPoint);
            array_simple = Matrix(array_simple);
            double[] array_simpleZeidel = Zeidel(array_simple);
            Console.WriteLine("Коэффициенты функции апроксимации");
            Console.WriteLine("a = {0}", array_simpleZeidel[0]);
            Console.WriteLine("b = {0}", array_simpleZeidel[1]);
            Console.WriteLine("c = {0}", array_simpleZeidel[2]);
            Console.WriteLine("~f(x) = {0} * x^2 {1} * x + {2}", array_simpleZeidel[0], array_simpleZeidel[1], array_simpleZeidel[2]);
            Console.Write($"Аппроксимированное значение в точке {x}: ");
            Console.WriteLine(array_simpleZeidel[0] * x * x + array_simpleZeidel[1] * x + array_simpleZeidel[2]);

        }
        static double[] Xi()
        {
            double[] x = new double[14];
            double x0 = 0.2;
            for (int i = 0; i < 14; i++)
            {
                x[i] = x0 * i;
                Console.WriteLine($"x{i} = {x[i]}");
            }
            return x;
        }
        static double[] Yi(double[] x)
        {
            double[] y = new double[14];
            for (int i = 0; i < 14; i++)
            {
                y[i] = Math.Round(Math.Sin(3.73 * x[i] + 4.57), 4);
                Console.WriteLine($"y{i} = {y[i]}");
            }
            return y;
        }
        public static double Lagrange(double x, double[] masX, double[] masY)
        {
            double x0 = 0, x1 = 0, x2 = 0, y0 = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < 12; i++)
            {
                if (x >= masX[i])
                {
                    x0 = masX[i];
                    y0 = masY[i];
                    x1 = masX[i + 1];
                    y1 = masY[i + 1];
                    x2 = masX[i + 2];
                    y2 = masY[i + 2];
                }
            }
            double lagrage_point = ((x - x1) * (x - x2) * y0) / ((x0 - x1) * (x0 - x2)) + ((x - x0) * (x - x2) * y1) / ((x1 - x0) * (x1 - x2)) + ((x - x0) * (x - x1) * y2) / ((x2 - x0) * (x2 - x1));
            return lagrage_point;
        }
        public static double[,] SimpleSquare(double[,] arrayOfPoint)
        {
            
            double[,] matrix = new double[3, 4];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j != 3)
                    {
                        if (i == 2 && j == 2)
                        {
                            
                            matrix[i, j] = 14;
                        }
                        else
                        {
                            
                            for (int k = 0; k < 14; k++)
                            {
                                matrix[i, j] = matrix[i, j] +
                                Math.Pow(arrayOfPoint[k, 0], 4 - i - j);
                            }
                        }
                    }
                    else
                    {
                        
                        for (int k = 0; k < 14; k++)
                        {
                            matrix[i, j] = matrix[i, j] + Math.Pow(arrayOfPoint[k,
                            0], 2 - i) * arrayOfPoint[k, 1];
                        }
                    }
                }
            }
            return matrix;
        }

        static double[,] Matrix(double[,] A)
        {
            double temp;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((i != j) && (j != 3))
                    {
                        A[i, j] = A[i, j] * -1;
                    }
                    else if (j == 3)
                    {
                        temp = A[i, i];
                        A[i, i] = A[i, j];
                        A[i, j] = temp;
                    }
                }
            }
            double[,] Matrix = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Matrix[i, j] = A[i, j] / A[i, 3];
                }
            }
            return Matrix;
        }
        static double[] Zeidel(double[,] Matrix_A)
        {
            double[] Vector_first = new double[3];
            double[] Vector_second = new double[3];
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector_second[i] = 0;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != j)
                        {
                            if (i < j)
                            {
                                Vector_second[i] = Vector_second[i] + Matrix_A[i, j]
                                * Vector_first[j];
                            }
                            else
                            {
                                Vector_second[i] = Vector_second[i] + Matrix_A[i, j]
                                * Vector_second[j];
                            }
                        }
                    }
                    Vector_second[i] = Vector_second[i] + Matrix_A[i, i];
                }
                double error = 0.001;
                double V1 = (Math.Round(Math.Abs(Vector_second[0] -
                Vector_first[0]), 3));
                double V2 = (Math.Round(Math.Abs(Vector_second[1] -
                Vector_first[1]), 3));
                double V3 = (Math.Round(Math.Abs(Vector_second[2] -
                Vector_first[2]), 3));
                for (int i = 0; i < 3; i++)
                {
                    Vector_first[i] = Vector_second[i];
                }
                if ((V1 < error) && (V2 < error) && (V3 < error))
                {
                    break;
                }
            }
            return Vector_first;
        }
    }

}
