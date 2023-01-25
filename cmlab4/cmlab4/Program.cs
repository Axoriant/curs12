using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmlab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[4] { 4, 20, 100, 400 };
            Console.WriteLine("Введите нижний предел интегрирования: ");
            double a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите верхний предел интегрирования: ");
            double b = int.Parse(Console.ReadLine());
            Console.WriteLine("\t\tМЕТОД ЛЕВЫХ ПРЯМОУГОЛЬНИКОВ");
            Console.WriteLine($"При n = {numbers[0]} интеграл равен: {LeftRectangle(a, b,numbers[0])}");
            Console.WriteLine($"При n = {numbers[1]} интеграл равен: {LeftRectangle(a, b,numbers[1])}");
            Console.WriteLine($"При n = {numbers[2]} интеграл равен: {LeftRectangle(a, b,numbers[2])}");
            Console.WriteLine($"При n = {numbers[3]} интеграл равен: {LeftRectangle(a, b,numbers[3])}");
            Console.WriteLine();
            Console.WriteLine("\t\tМЕТОД ПРАВЫХ ПРЯМОУГОЛЬНИКОВ");
            Console.WriteLine($"При n = {numbers[0]} интеграл равен: {RightRectangle(a,b, numbers[0])}");
            Console.WriteLine($"При n = {numbers[1]} интеграл равен: {RightRectangle(a,b, numbers[1])}");
            Console.WriteLine($"При n = {numbers[2]} интеграл равен: {RightRectangle(a,b, numbers[2])}");
            Console.WriteLine($"При n = {numbers[3]} интеграл равен: {RightRectangle(a,b, numbers[3])}");
            Console.WriteLine();
            Console.WriteLine("\t\tМЕТОД ТРАПЕЦИЙ");
            Console.WriteLine($"При n = {numbers[0]} интеграл равен: {Trapezoid(a, b,numbers[0])}");
            Console.WriteLine($"При n = {numbers[1]} интеграл равен: {Trapezoid(a, b,numbers[1])}");
            Console.WriteLine($"При n = {numbers[2]} интеграл равен: {Trapezoid(a, b, numbers[2])}");
            Console.WriteLine($"При n = {numbers[3]} интеграл равен: {Trapezoid(a, b,numbers[3])}");
            Console.WriteLine();
            Console.WriteLine("\t\tМЕТОД СИМПСОНА");
            Console.WriteLine($"При n = {numbers[0]} интеграл равен: {Simpson(a, b,numbers[0])}");
            Console.WriteLine($"При n = {numbers[1]} интеграл равен: {Simpson(a, b,numbers[1])}");
            Console.WriteLine($"При n = {numbers[2]} интеграл равен: {Simpson(a, b, numbers[2])}");
            Console.WriteLine($"При n = {numbers[3]} интеграл равен: {Simpson(a, b, numbers[3])}");
            Console.WriteLine();
        }
        static double F(double x)
        {
            return Math.Sin(0.46 * x) * Math.Log(0.36 * x);
        }
        static double LeftRectangle(double a, double b, int n)
        {
            double sum = 0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                sum = sum + h * F(x);
            }
            return sum;
        }
        static double RightRectangle(double a, double b, double n)
        {
            double sum = 0;
            double h = (b - a) / n;
            for (int i = 1; i < n + 1; i++)
            {
                double x = a + i * h;
                sum = sum + h * F(x);
            }
            return sum;
        }
        static double Trapezoid(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = (F(a) + F(b)) / 2;
            for (int i = 1; i < n; i++)
            {
                sum = sum + F(a + i * h);
            }
            sum = sum * h;
            return sum;
        }
        static double Simpson(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = F(a) + F(b);
            int k;
            for (int i = 1; i < n; i++)
            {
                k = 2 + 2 * (i % 2);
                sum = sum + k * F(a + i * h);
            }
            sum = sum * (h / 3);
            return sum;
        }
    }
}
