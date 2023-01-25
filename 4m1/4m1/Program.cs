using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4m1
{
    internal class Program
    {
        static void Vvod(decimal[,] A, decimal[] B)
        {
            Console.WriteLine("Введите множители и свободные члены: ");
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (j < 3)
                    {
                        A[i, j] = decimal.Parse(Console.ReadLine());
                    }
                    else
                    {
                        B[i] = decimal.Parse(Console.ReadLine());
                    }
                }
        }
        static void Preobr(decimal[,] A, decimal[] B)
        {
            decimal temp;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((i != j) && (j < 3))
                    {
                        A[i, j] = -A[i, j];
                    }
                    if (j == 3)
                    {
                        temp = A[i, i];
                        A[i, i] = B[i];
                        B[i] = temp;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j < 3)
                    {
                        A[i, j] = A[i, j] / B[i];
                    }
                }
            }
        }

        static void Fast(ref decimal[,] A, ref decimal[] B, ref decimal[] X0, ref decimal[] X1, ref decimal[] XE)
        {
            for (int i = 0; i < 3; i++)
            {
                X0[i] = A[i, i];
            }

            var count = 0;
            int c = 0;
            bool flaq;
            do
            {
                decimal E = 0;
                for (int i = 0; i < 3; i++)
                {
                    X1[i] = 0;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != j)
                            X1[i] += A[i, j] * X0[j];
                    }
                    X1[i] += A[i, i];
                }

                int k = 0;
                c = 0;
                flaq = true;
                while (k < 3 && c < 3)
                {
                    XE[k] = Math.Abs(X1[k] - X0[k]);
                    if (Math.Round(XE[k], 3) < 0.01M)
                        //flaq = false;
                        c++;
                    k++;
                }

                for (int i = 0; i < 3; i++)
                {
                    X0[i] = X1[i];
                }
                Console.WriteLine(count);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("X1[" + i + "] = ");
                    Console.Write(X1[i]);
                    Console.WriteLine();
                }
                count++;
            }
            while (c < 3);

        }

        static void Seidel(ref decimal[,] A, ref decimal[] B, ref decimal[] X0, ref decimal[] X1, ref decimal[] XE)
        {
            var count = 1;
            int c = 0;
            for (int i = 0; i < 3; i++)
            {
                X0[i] = 0;
                X1[i] = 0;
                XE[i] = 0;
            }

            
            do
            {
                decimal E = 0;
                for (int i = 0; i < 3; i++)
                {
                    X1[i] = 0;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != j)
                        {
                            if (i < j)
                            {
                                X1[i] += A[i, j] * X0[j];
                            }
                            else
                            {
                                X1[i] += A[i, j] * X1[j];
                            }
                        }
                    }
                    X1[i] += A[i, i];
                }

                int k = 0;
                c = 0;
                while (k < 3 && c < 3)
                {
                    XE[k] = Math.Abs(X1[k] - X0[k]);
                    if (Math.Round(XE[k], 3) < 0.01M)
                        c++;
                    k++;
                }

                for (int i = 0; i < 3; i++)
                {
                    X0[i] = X1[i];
                }

                Console.WriteLine(count);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("X1[" + i + "] = ");
                    Console.Write(X1[i]);
                    Console.WriteLine();
                }
                count++;
            }
            while (c < 3);

        }

        static void Main(string[] args)
        {
            decimal[,] A = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            decimal[] B = { 0, 0, 0 };
            decimal[] X0 = { 0, 0, 0 };
            decimal[] X1 = { 0, 0, 0 };
            decimal[] XE = { 0, 0, 0 };
            Vvod(A, B);
            Preobr(A, B);
            Console.WriteLine("****************************************");
            Fast(ref A, ref B, ref X0, ref X1, ref XE);
            Console.WriteLine("****************************************");
            Seidel(ref A, ref B, ref X0, ref X1, ref XE);
            Console.WriteLine("****************************************");
        }
    }
}