using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOlab2
{
    internal class Program
    {
        public static double D(double a, double b)
        {
            return b - a;
        }
        private static double DeFfirst(double X1, double X2)
        {
            //return 4 * X1 - 36;
            return 1602 * X1 + 400 * X2 - 2404;
        }
        private static double DeFsecond(double X1, double X2)
        {
            //return 10 * X2 - 40;
            return 400 * X1 + 102 * X2 - 618;
        }
        private static double Function(double X1, double X2)
        {
            //return 2 * (X1 - 9) * (X1 - 9) + 5 * (X2 - 4) * (X2 - 4);
            return (X1 - 2)* (X1 - 2) + (X2 - 9) * (X2 - 9) + 50 * ((X2 + 4 * X1 - 6)* (X2 + 4 * X1 - 6)) + 7.7;
        }
        private static void FastDown()
        {
            double X11 = 0;
            double X12 = 0;
            double epsilon = 0.001;
            double border_a = 0;
            double border_b = 0.432;
            double Alfa = 0.618;
            double Beta = 0.382;
            int count = 0;
            do
            {
                double t = Gold(border_a, border_b, Alfa, Beta, X11, X12);
                double tempX1 = X11;
                double tempX2 = X12;
                X11 = X11 - t * DeFfirst(tempX1, tempX2);
                X12 = X12 - t * DeFsecond(tempX1, tempX2);
                count++;
                Console.WriteLine(Math.Round(X11, 3) + " " + Math.Round(X12, 3) + " " + Math.Round(Function(X11, X12), 3) + " " + Math.Round(t, 3) + " " + count);
            } while (Math.Abs(DeFfirst(X11, X12)) > epsilon && Math.Abs(DeFsecond(X11, X12)) > epsilon);
        }
        private static void GelfCeit()
        {
            double t1, t2, X01 = 0, X02 = 0, GlobalCount = 0, Count1 = 0, Count2 = 0, G1, G2, Alf = 0.618, Bet = 1 - Alf;
            do
            {
                do
                {
                    if (Math.Abs(DeFfirst(X01, X02)) > 0.01)
                    {
                        G1 = DeFfirst(X01, X02);
                    }
                    else
                        G1 = 0;
                    if (Math.Abs(DeFsecond(X01, X02)) > 0.01)
                    {
                        G2 = DeFsecond(X01, X02);
                    }
                    else
                        G2 = 0;
                    t1 = 0.0004123;  // 0.12
                    X01 -= t1 * G1;
                    X02 -= t1 * G2;
                    Count1++;
                } while (Count1 < 10);
                Count1 = 0;
                do
                {
                    if (Math.Abs(DeFfirst(X01, X02)) < 0.01)
                    {
                        G1 = DeFfirst(X01, X02);
                    }
                    else
                        G1 = 0;
                    if (Math.Abs(DeFsecond(X01, X02)) < 0.01)
                    {
                        G2 = DeFsecond(X01, X02);
                    }
                    else
                        G2 = 0;
                    t2 = 0.00005; // 0.05
                    X01 -= t2 * G1;
                    X02 -= t2 * G2;
                    Count2++;
                } while (Count2 < 10);
                Count2 = 0;
                GlobalCount++;
                Console.WriteLine(Math.Round(X01, 6) + " " + Math.Round(X02, 6) + " "+ Math.Round(Function(X01, X02), 6) + " " + Math.Round(G1, 6) + " " + Math.Round(G2, 6) + " " + GlobalCount);
            } while (GlobalCount < 50);
        }
        public static double Gold(double a, double b, double Alf, double Bet, double
       X11, double X12)
        {
            var count = 0;
            double XB;
            double XA;
            do
            {
                XB = a + Bet * D(a, b);
                XA = a + Alf * D(a, b);
                if (T(X11, X12, XB) >= T(X11, X12, XA))
                {
                    a = XB;
                }
                else
                {
                    b = XA;
                }
                count++;
                //Console.WriteLine("Итерация #{0}, граница: [{1};{2}], длина отрезка
                ///{ 3}
                //",count,a,b, D(a,b));
            } while (D(a, b) >= 0.01);
            if (T(X11, X12, XA) <= T(X11, X12, XB))
            {
                return XA;
            }
            else
            {
                return XB;
            }
        }
        private static void Main(string[] args)
        {
            NelderMid();
            Console.WriteLine("*********************");
            FastDown();
            Console.WriteLine("*********************");
            GelfCeit();
        }
        private static void NelderMid()
        {
            var n = 2;
            var count = 1;
            double Xh = 0, Xh1, Xh2, Xl = 0, Xl1, Xl2, t = 5, X11, X12, X21, X22, X31, X32, X61, X62, X71, X72, A, X51, X52, X41, X42, Max, Min;
            var d2 = t * (Math.Pow(n + 1, 0.5) - 1) / (Math.Pow(2, 0.5) * n);
            var d1 = t * (Math.Pow(n + 1, 0.5) + n - 1) / (Math.Pow(2, 0.5) * n);
            X11 = 0;
            X12 = 0;
            X21 = d1;
            X22 = d2;
            X31 = d2;
            X32 = d1;
            Max = double.MinValue;
            Min = double.MaxValue;
            if (Function(X11, X12) > Function(X21, X22) && Function(X11, X12) > Function(X31, X32))
            {
                Xh = Function(X11, X12);
                Xh1 = X11;
                Xh2 = X12;
            }
            else if (Function(X21, X22) > Function(X11, X12) && Function(X21, X22) > Function(X31, X32))
            {
                Xh = Function(X21, X22);
                Xh1 = X21;
                Xh2 = X22;
            }
            else
            {
                Xh = Function(X31, X32);
                Xh1 = X31;
                Xh2 = X32;
            }
            if (Function(X11, X12) < Function(X21, X22) && Function(X11, X12) < Function(X31, X32))
            {
                Xl = Function(X11, X12);
                Xl1 = X11;
                Xl2 = X12;
            }
            else if (Function(X21, X22) < Function(X11, X12) && Function(X21, X22) < Function(X31, X32))
            {
                Xl = Function(X21, X22);
                Xl1 = X21;
                Xl2 = X22;
            }
            else
            {
                Xl = Function(X31, X32);
                Xl1 = X31;
                Xl2 = X32;
            }
            do
            {
                Console.Write("(" + Math.Round(X11, 2) + ";" + Math.Round(X12, 2) + ")" + Math.Round(Function(X11, X12), 2) + " ");
               
                Console.Write("(" + Math.Round(X21, 2) + ";" + Math.Round(X22, 2) + ")" + Math.Round(Function(X21, X22), 2) + " ");
               
                Console.Write("(" + Math.Round(X31, 2) + ";" + Math.Round(X32, 2) + ")" + Math.Round(Function(X31, X32), 2) + " ");
               
                Console.WriteLine(count);
                //смещенный центр тяжести
                if (Xh == Function(X11, X12))
                {
                    X41 = (X21 + X31) / n;
                    X42 = (X22 + X32) / n;
                }
                else if (Xh == Function(X21, X22))
                {
                    X41 = (X11 + X31) / n;
                    X42 = (X12 + X32) / n;
                }
                else
                {
                    X41 = (X11 + X21) / n;
                    X42 = (X12 + X22) / n;
                }
                //точка отражения
                X51 = 2 * X41 - Xh1;
                X52 = 2 * X42 - Xh2;
                if (Function(X51, X52) < Xl)
                {
                    //точка растяжения
                    X61 = 2 * X51 - X41;
                    X62 = 2 * X52 - X42;
                    if (Function(X61, X62) < Xl)
                    {
                        Xh1 = X61;
                        Xh2 = X62;
                        Xh = Function(Xh1, Xh2);
                    }
                    else
                    {
                        Xh1 = X51;
                        Xh2 = X52;
                        Xh = Function(Xh1, Xh2);
                    }
                }
                else
                {
                    if (Function(X51, X52) > Function(X11, X12) && Function(X51, X52) > Function(X21, X22) && Function(X51, X52) > Function(X31, X32))
                    {
                        if (Function(X51, X52) > Xh)
                        {
                            //редукция
                            X11 = 0.5 * Xl1 + 0.5 * X11;
                            X12 = 0.5 * Xl2 + 0.5 * X12;
                            X21 = 0.5 * Xl1 + 0.5 * X21;
                            X22 = 0.5 * Xl2 + 0.5 * X22;
                            X31 = 0.5 * Xl1 + 0.5 * X31;
                            X32 = 0.5 * Xl2 + 0.5 * X32;
                            if (Function(X11, X12) > Function(X21, X22) && Function(X11, X12) > Function(X31, X32) && Function(X11, X12) > Max)
                            {
                                Xh = Function(X11, X12);
                                Xh1 = X11;
                                Xh2 = X12;
                            }
                            else if (Function(X21, X22) > Function(X11, X12) && Function(X21, X22) > Function(X31, X32) && Function(X21, X22) > Max)
                            {
                                Xh = Function(X21, X22);
                                Xh1 = X21;
                                Xh2 = X22;
                            }
                            else
                            {
                                Xh = Function(X31, X32);
                                Xh1 = X31;
                                Xh2 = X32;
                            }
                            if (Function(X11, X12) < Function(X21, X22) && Function(X11, X12) < Function(X31, X32) && Function(X11, X12) < Min)
                            {
                                Xl = Function(X11, X12);
                                Xl1 = X11;
                                Xl2 = X12;
                            }
                            else if (Function(X21, X22) < Function(X11, X12) && Function(X21, X22) < Function(X31, X32) && Function(X21, X22) < Min)
                            {
                                Xl = Function(X21, X22);
                                Xl1 = X21;
                                Xl2 = X22;
                            }
                            else
                            {
                                Xl = Function(X31, X32);
                                Xl1 = X31;
                                Xl2 = X32;
                            }
                        }
                        else
                        {
                            //Сжатие
                            X71 = 0.5 * X51 - X41;
                            X72 = 0.5 * X52 - X42;
                            if (Function(X71, X72) > Xh)
                            {
                                //редукция
                                X11 = 0.5 * Xl1 + 0.5 * X11;
                                X12 = 0.5 * Xl2 + 0.5 * X12;
                                X21 = 0.5 * Xl1 + 0.5 * X21;
                                X22 = 0.5 * Xl2 + 0.5 * X22;
                                X31 = 0.5 * Xl1 + 0.5 * X31;
                                X32 = 0.5 * Xl2 + 0.5 * X32;
                                if (Function(X11, X12) > Function(X21, X22) && Function(X11, X12) > Function(X31, X32) && Function(X11, X12) > Max)
                                {
                                    Xh = Function(X11, X12);
                                    Xh1 = X11;
                                    Xh2 = X12;
                                }
                                else if (Function(X21, X22) > Function(X11, X12) && Function(X21, X22) > Function(X31, X32) && Function(X21, X22) > Max)
                                {
                                    Xh = Function(X21, X22);
                                    Xh1 = X21;
                                    Xh2 = X22;
                                }
                                else
                                {
                                    Xh = Function(X31, X32);
                                    Xh1 = X31;
                                    Xh2 = X32;
                                }
                                if (Function(X11, X12) < Function(X21, X22) && Function(X11, X12) < Function(X31, X32) && Function(X11, X12) < Min)
                                {
                                    Xl = Function(X11, X12);
                                    Xl1 = X11;
                                    Xl2 = X12;
                                }
                                else if (Function(X21, X22) < Function(X11, X12) && Function(X21, X22) < Function(X31, X32) && Function(X21, X22) < Min)
                                {
                                    Xl = Function(X21, X22);
                                    Xl1 = X21;
                                    Xl2 = X22;
                                }
                                else
                                {
                                    Xl = Function(X31, X32);
                                    Xl1 = X31;
                                    Xl2 = X32;
                                }
                            }
                            else
                            {
                                Xh1 = X71;
                                Xh2 = X72;
                                Xh = Function(Xh1, Xh2);
                            }
                        }
                    }
                    else
                    {
                        Xh1 = X51;
                        Xh2 = X52;
                        Xh = Function(Xh1, Xh2);
                    }
                }
                count++;
                A = (Math.Pow(Function(X11, X12) - Function(X41, X42), 2) + Math.Pow(Function(X21, X22) - Function(X41, X42), 2) + Math.Pow(Function(X31, X32) - Function(X41, X42), 2)) / (n + 1);
            } while (A >= 0.01);
            Console.WriteLine();
        }
        public static double T(double X11, double X12, double t)
        {
            //return (2*(X11 - t * DeFfirst(X11, X12)) - 9) * ((X11 - t * DeFfirst(X11,X12)) -9) +5 * ((X12 - t * DeFsecond(X11, X12)) - 4) * ((X12 - t * DeFsecond(X11, X12)) - 4);
            return (X11 - t * DeFfirst(X11, X12) - 2) * (X11 - t * DeFfirst(X11, X12)- 2) + (X12 - t * DeFsecond(X11, X12) - 9) * (X12 - t * DeFsecond(X11, X12) - 9) + 50* (X12 - t * DeFsecond(X11, X12) + 4 * (X11 - t * DeFfirst(X11, X12)) - 6) * (X12 - t* DeFsecond(X11, X12) + 4 * (X11 - t * DeFfirst(X11, X12)) - 6) + 7.7;

        }
        //(X11 - t* DeFfirst(X11, X12) - 1) * (X11 - t* DeFfirst(X11, X12) - 1) + (X12 - t* DeFsecond(X11, X12) - 4)* (X12 - t* DeFsecond(X11, X12) - 4) + 50* (X12 - t* DeFsecond(X11, X12) + 4 * (X11 - t* DeFfirst(X11, X12)) - 6)* (X12 - t* DeFsecond(X11, X12) + 4 * (X11 - t* DeFfirst(X11, X12)) - 6) + 4.3;
    }
}

