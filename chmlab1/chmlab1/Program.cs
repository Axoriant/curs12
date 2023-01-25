using System;

namespace chmlab1
{
    internal class Program
    {
        public static Tuple<decimal[], decimal[,]> Matrix()
        {
            decimal[,] matrix = new decimal[3, 3];
            decimal[] FreeMember = new decimal[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Множитель x{j + 1}");

                    decimal num = decimal.Parse(Console.ReadLine());
                    matrix[i, j] = num;
                }
                Console.WriteLine("Свободный член");
                FreeMember[i] = decimal.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] = -matrix[i, j];
                    }
                }
            }

            return Tuple.Create(FreeMember, matrix);
        }
        public static decimal[] Zapproximation(decimal[,] matrix, decimal[] free)
        {
            decimal[] approachv = new decimal[3];
            for (int i = 0; i < free.Length; i++)
            {
                approachv[i] = free[i] / matrix[i, i];
            }
            return approachv;
        }
        public static void Yakobi(decimal[] zp, decimal[,] matrix)
        {
            decimal[] z = new decimal[3];
            for (int i = 0; i < zp.Length; i++)
            {
                z[i] = zp[i];
            }
            int c = 0;
            int count = 0;
            decimal[] furtherapproximation = new decimal[3];
            decimal[] q = new decimal[3];
            while (count < 3)
            {
                for (int i = 0; i < zp.Length; i++)
                {

                    for (int j = 0; j < zp.Length; j++)
                    {
                        if (i != j)
                        {
                            furtherapproximation[i] += matrix[i, j] * z[j];
                        }

                    }
                    furtherapproximation[i] += matrix[i, i];
                }
                int k = 0;
                count = 0;
                while (k < 3 && count < 3)
                {
                    q[k] = Math.Abs(furtherapproximation[k] - z[k]);
                    if (Math.Round(q[k], 3) < 0.01M)
                        count++;
                    k++;
                }
                for (int i = 0; i < z.Length; i++)
                {
                    z[i] = furtherapproximation[i];
                }

                for (int i = 0; i < furtherapproximation.Length; i++)
                {
                    Console.WriteLine(furtherapproximation[i]);
                    furtherapproximation[i] = 0;
                }
                Console.WriteLine();
                c++;
            }
            Console.WriteLine("Количество итераций {0}", c);
        }
        public static void Seidel(decimal[,] matrix)
        {
            decimal[] z = new decimal[3];
            decimal[] q = new decimal[3];

            int c = 0;
            int count = 0;
            decimal[] furtherapproximation = new decimal[3];
            while (count < 3)
            {
                for (int i = 0; i < z.Length; i++)
                {
                    for (int j = 0; j < z.Length; j++)
                    {
                        if (i != j)
                        {
                            if (i < j)
                            { furtherapproximation[i] += matrix[i, j] * z[j]; }
                            else
                            { furtherapproximation[i] += matrix[i, j] * furtherapproximation[j]; }
                        }
                    }
                    furtherapproximation[i] += matrix[i, i];

                }
                int k = 0;
                count = 0;
                while (k < 3 && count < 3)
                {
                    q[k] = Math.Abs(furtherapproximation[k] - z[k]);
                    if (Math.Round(q[k], 3) < 0.01M)
                        count++;
                    k++;
                }
                for (int i = 0; i < z.Length; i++)
                {
                    z[i] = furtherapproximation[i];
                }

                for (int i = 0; i < furtherapproximation.Length; i++)
                {
                    Console.WriteLine(furtherapproximation[i]);
                    furtherapproximation[i] = 0;
                }
                Console.WriteLine();
                c++;
            }
            Console.WriteLine("Количество итераций {0}", c);

        }
        static void Main(string[] args)
        {
            var m = Matrix();
            var freeP = m.Item1;
            var matrix = m.Item2;
            decimal[] zp = Zapproximation(matrix, freeP);
            decimal[] mult = new decimal[3];

            for (int i = 0; i < freeP.Length; i++)
            {
                mult[i] = matrix[i, i];
                matrix[i, i] = freeP[i];
            }

            for (int i = 0; i < freeP.Length; i++)
            {
                for (int j = 0; j < freeP.Length; j++)
                {
                    matrix[i, j] = matrix[i, j] / mult[i];
                }
            }
            Console.WriteLine("Метод Якоби");
            Yakobi(zp, matrix);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Метод Зейделя");
            Seidel(matrix);
        }
    }
} 

