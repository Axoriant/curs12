using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace cmlab2
{
    internal class Program
    {
        static void Otdel(double x, double[] h, double a, double b, double c, ref double
       x1, ref double x2)
        {
            double i;
            double per, vtor;
            for (int k = 0; k < h.Length; k++)
            {
                Console.WriteLine(h[k]);
                i = x;
                while (i - h[k] > -10000)
                {
                    per = a * Math.Pow(i, 2) + b * i + c;
                    vtor = a * Math.Pow(i - h[k], 2) + b * (i - h[k]) + c;
                    if ((per <= 0 && vtor >= 0) || (per >= 0 && vtor <= 0))
                    {
                        Console.Write(Math.Round(i, 3));
                        Console.Write(" ");
                        Console.WriteLine(Math.Round(i - h[k], 3));
                        if (h[k] == 0.01)
                        {
                            x1 = Math.Round(i, 2);
                            Console.WriteLine("*********************************");
                            Console.WriteLine(x1);
                        }
                    }
                    i -= h[k];
                }
            }
            Console.WriteLine("*********************************");
            double j;
            j = x;
            for (int k = 0; k < h.Length; k++)
            {
                Console.WriteLine(h[k]);
                j = x;
                while (j + h[k] < 10000)
                {
                    per = a * Math.Pow(j, 2) + b * j + c;
                    vtor = a * Math.Pow(j + h[k], 2) + b * (j + h[k]) + c;
                    if ((per <= 0 && vtor >= 0) || (per >= 0 && vtor <= 0))
                    {
                        Console.Write(Math.Round(j, 3));
                        Console.Write(" ");
                        Console.WriteLine(Math.Round(j + h[k], 3));
                        if (h[k] == 0.01)
                        {
                            x2 = Math.Round(j, 2);
                            Console.WriteLine("*********************************");
                            Console.WriteLine(x2);
                        }
                    }
                    j += h[k];
                }
            }
            Console.WriteLine("*********************************");
        }
        static void Easy(double a, double b, double c)
        {
            Console.WriteLine("простая");
            double c1 = -0.689, c2 = -1.689;
            double x0 = (c1 + c2) / 2;
            double x1 = x0;
            double x2 = 0, f = 0;
            double L = -2 / (2 * a * x0 + b * x0);
            int count = 0;
            do
            {
                x0 = x1;
                x1 = (a * Math.Pow(x0, 2) + b * x0 + c) * L + x0;
                f = a * Math.Pow(x1, 2) + b * x1 + c;
                count++;
            }
            while (Math.Abs(x1 - x0) > 0.001 && Math.Abs(f) > 0.001);
            c1 = -0.689; c2 = 0.311;
            x0 = (c2 - c1) / 2;
            x2 = x0;
            L = -2 / (2 * a * x0 + b * x0);
            do
            {
                x0 = x2;
                x2 = (a * Math.Pow(x0, 2) + b * x0 + c) * L + x0;
                f = a * Math.Pow(x2, 2) + b * x2 + c;
                count++;
            }
            while (Math.Abs(x2 - x0) > 0.001 && Math.Abs(f) > 0.001);
            Console.WriteLine(Math.Round(x1, 2));
            Console.WriteLine(Math.Round(x2, 2));
            Console.WriteLine(count);
        }
        static void Dihot(double a, double b, double c)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("Дихотомия");
            double c1 = -0.689, c2 = -1.689;
            double x0 = (c1 + c2) / 2;
            double f_c1, f_c2, f_x0, x1 = x0, count = 0;
            do
            {
                f_c1 = a * Math.Pow(c1, 2) + b * c1 + c;
                f_c2 = a * Math.Pow(c2, 2) + b * c2 + c;
                f_x0 = a * Math.Pow(x0, 2) + b * x0 + c;
                if ((f_c1 <= 0 && f_x0 >= 0) || (f_c1 >= 0 && f_x0 <= 0))
                {
                    c2 = x0;
                }
                else if ((f_x0 <= 0 && f_c2 >= 0) || (f_x0 >= 0 && f_c2 <= 0))
                {
                    c1 = x0;
                }
                x1 = x0;
                x0 = (c1 + c2) / 2;
                count++;
            }
            while (Math.Abs(x1 - x0) > 0.01 && Math.Abs(f_x0) > 0.01);
            Console.WriteLine(Math.Round(x0, 2));
            c1 = -0.689; c2 = 0.311;
            x0 = (c2 + c1) / 2;
            x1 = x0;
            do
            {
                f_c1 = a * Math.Pow(c1, 2) + b * c1 + c;
                f_c2 = a * Math.Pow(c2, 2) + b * c2 + c;
                f_x0 = a * Math.Pow(x0, 2) + b * x0 + c;
                if ((f_c1 <= 0 && f_x0 >= 0) || (f_c1 >= 0 && f_x0 <= 0))
                {
                    c2 = x0;
                }
                else if ((f_x0 <= 0 && f_c2 >= 0) || (f_x0 >= 0 && f_c2 <= 0))
                {
                    c1 = x0;
                }
                x1 = x0;
                x0 = (c1 + c2) / 2;
                count++;
            }
            while (Math.Abs(x1 - x0) > 0.01 && Math.Abs(f_x0) > 0.01);
            Console.WriteLine(Math.Round(x0, 2));
            Console.WriteLine(count);
        }
        static void Nyut(double a, double b, double c)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("Ньютон");
            double c1 = -0.689, c2 = -1.689;
            double x0 = (c1 + c2) / 2;
            double x1 = x0;
            double f = 0, f_ = 0;
            int count = 0;
            do
            {
                x0 = x1;
                f = a * Math.Pow(x0, 2) + b * x0 + c;
                f_ = 2 * a * x0 + b;
                x1 = x0 - f / f_;
                count++;
            }
            while (Math.Abs(x1 - x0) > 0.01 && Math.Abs(f) > 0.01);
            Console.WriteLine(Math.Round(x0, 2));
            c1 = -0.689; c2 = 0.311;
            x0 = (c2 + c1) / 2;
            x1 = x0;
            do
            {
                x0 = x1;
                f = a * Math.Pow(x0, 2) + b * x0 + c;
                f_ = 2 * a * x0 + b;
                x1 = x0 - f / f_;
                count++;
            }
            while (Math.Abs(x1 - x0) > 0.01 && Math.Abs(f) > 0.01);
            Console.WriteLine(Math.Round(x0, 2));
            Console.WriteLine(count);
        }
        static void Main()
        {
            double x1 = 0, x2 = 0;
            double a, b, c, a1, x;
            double[] h = { 100, 10, 1, 0.1, 0.01 };
            Console.WriteLine("Введите уравнение");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
            Console.WriteLine("*********************************");
            a1 = a * 2;
            x = -b / a1;
            Otdel(x, h, a, b, c, ref x1, ref x2);
            Easy(a, b, c);
            Dihot(a, b, c);
            Nyut(a, b, c);
        }
    }
}