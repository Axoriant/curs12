using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mo1lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Alf = 0.618;
            double Bet = 1 - Alf;
            Console.WriteLine("Введите отрезок");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Gold(a, b, Alf, Bet);
            Console.WriteLine("************************");
            Dihot(a, b);
            Console.WriteLine("************************");
            Fib(a, b);
        }

        public static double D(double a, double b)
        {
            return b - a;
        }

        public static double F(double X)
        {
            return (X - 7) * (X - 5) * (X - 4);
        }

        public static void Gold(double a, double b, double Alf, double Bet)
        {
            int count = 0;
            double XB;
            double XA;

            do
            {
                XB = a + Bet * D(a, b);
                XA = a + Alf * D(a, b);

                if (F(XB) >= F(XA))
                {
                    a = XB;
                }
                else
                {
                    b = XA;
                }

                count++;
                Console.WriteLine("Итерация #{0}, граница: [{1};{2}], длина отрезка {3}", count, a, b, D(a, b));
            } while (D(a, b) >= 0.01);

            if (F(XB) < F(XA))
            {
                Console.Write(F(XB));
                Console.Write(" ");
                Console.WriteLine(count);
            }
            else if (F(XB) > F(XA))
            {
                Console.Write(F(XA));
                Console.Write(" ");
                Console.WriteLine(count);
            }
        }

        public static void Dihot(double a, double b)
        {
            double X1;
            double X2;
            int count = 0;
            do
            {

                X1 = (a + b - 0.01 / 2) / 2;
                X2 = (a + b + 0.01 / 2) / 2;

                if (F(X1) <= F(X2))
                {
                    b = X2;
                }
                else
                {
                    a = X1;
                }

                count++;
                Console.WriteLine("Итерация #{0}, граница: [{1};{2}], длина отрезка {3}", count, a, b, D(a, b));
            } while (Math.Abs(D(a, b)) >= 0.01);


            Console.Write((a + b) / 2);
            Console.Write(" ");
            Console.Write(F((a + b) / 2));
            Console.Write(" ");
            Console.WriteLine(count);

        }

        public static double Ch(double n)
        {
            return ((Math.Pow((1 + Math.Sqrt(5)) / (2), n)) - (Math.Pow((1 - Math.Sqrt(5)) / (2), n))) / (Math.Sqrt(5));
        }

        public static void Fib(double a, double b)
        {
            double X1;
            double X2;
            double a1;
            double b1;
            double fs = 0;
            double n = 0;
            double count = 0;
            a1 = a;
            b1 = b;

            while (D(a1, b1) / 0.01 >= fs)
            {
                n++;
                fs = Ch(n + 2);

            }

            do
            {
                count++;

                X1 = a1 + (Ch(n - count + 1)) / (Ch(n + 2)) * D(a, b);
                X2 = a1 + (Ch(n - count + 2)) / (Ch(n + 2)) * D(a, b);

                if (F(X1) >= F(X2))
                {
                    a1 = X1;
                }
                else if (F(X2) >= F(X1))
                {
                    b1 = X2;
                }


                Console.WriteLine("Итерация #{0}, граница: [{1};{2}], длина отрезка {3}", count, a1, b1, D(a1, b1));
            } while (D(a1, b1) >= 0.01);

            if (F(X1) <= F(X2))
            {
                Console.Write(F(X1));
                Console.Write(" ");
                Console.Write(X1);
                Console.Write(" ");
                Console.WriteLine(count);
            }
            else
            {
                Console.Write(F(X2));
                Console.Write(" ");
                Console.Write(X2);
                Console.Write(" ");
                Console.WriteLine(count);
            }
        }
    }
}
