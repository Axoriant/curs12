using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MOlab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значения отрезка");
            Console.WriteLine("а = ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("b = ");
            double b = double.Parse(Console.ReadLine());
            double Alpha = 0.618;
            double Beta = 0.382;
            GoldenS(a, b, Alpha, Beta);
            Dihotomia(a, b);
            Fibonach(a, b);

        }
       
        public static double F(double X)
        {
            return 2 - 9 * Math.Exp(-Math.Pow((X - 5) / 4, 2));
        }
        public static double Delta(double a, double b)
        {
            return b - a;
        }

        public static void GoldenS(double a, double b, double Alpha, double Beta)
        {
            double X1;
            double X2;
            int count = 0;
            double E = 0.01;
            while (Math.Abs(Delta(a, b)) > E)
            {
                X1 = a + Beta * Delta(a, b);
                X2 = a + Alpha * Delta(a, b);
                if (F(X1) >= F(X2))
                {
                    a = X1;
                }
                else
                {
                    b = X2;
                }
                count++;
                Console.WriteLine("\nИтерация #{0}, длина отрезка {1}, граница: [{2};{3}]", count, Delta(a, b), a, b);
                
            }
            double x = (a + b) / 2;
            Console.WriteLine("\nМинимум функции равен {0}", x);
        }
        public static void Dihotomia(double a, double b)
        {
            double X1;
            double X2;
            int count = 0;
            double E = 0.01;
            while (Math.Abs(Delta(a, b)) >= E)
            {
                X1 = (a + b - 0.009) / 2;
                X2 = (a + b + 0.009) / 2;
                if (F(X1) <= F(X2))
                {
                    b = X2;
                }
                else
                {
                    a = X1;
                }
                count++;
                Console.WriteLine("\nИтерация #{0}, длина отрезка {1}, граница: [{2};{3}]", count, Delta(a, b), a, b);

            }
            double x = (a + b) / 2;
            Console.WriteLine("\nМинимум функции равен {0}", x);

        }
        public static double Bine(double n)
        {
            return Math.Pow(((1 + Math.Sqrt(5)) / 2), n) / Math.Sqrt(5);

        }
        public static int Fibonachi(double a, double b)
        {
            int x = 1;
            double E = 0.01;
            double k = Math.Abs(a - b);
            while (true)
            {
                if (k / E < Bine(x + 2))
                {
                    return x;
                }
                else
                {
                    x++;
                }
            }
        }
        public static void Fibonach(double a, double b)
        {
            double X1;
            double X2;
            double E = 0.01; 
            int count = 0;
            double d = Math.Abs(a - b);
            int n = Fibonachi(a, b);
            do
            {
                count++;
                
                X1 = a + (Bine(n - count + 1) / Bine(n + 2)) * d;
                X2 = a + (Bine(n - count + 2) / Bine(n + 2)) * d;
                if (F(X1) > F(X2))
                {
                    a = X1;
                }
                else
                {
                    b = X2;
                }
                Console.WriteLine("\nИтерация #{0}, длина отрезка {1}, граница: [{2};{3}]", count, Delta(a, b), a, b);
            } while ((b - a) > E);
            
            double x = (a + b) / 2;
            Console.WriteLine("\nМинимум функции равен {0}", x);
        }
    }
}
