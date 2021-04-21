using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOfCounting_Ex1
{
    class Differentials
    {
        //ЗДЕСЬ КОНЧАЮТСЯ ЗАДАЧИ ПРО ЛИНЕЙНЫЕ УРАВНЕНИЯ И НАЧИНАЮТСЯ ЗАДАЧИ ПРО ДИФФЕРЕНЦИАЛЬНЫЕ УРАВНЕНИЯ
        public static double func(double x, double y, double V)
        {
            return 2.0 * V * x + V * x * x - y;
        }

        public static void KoshiEjler(int n, double h, double x0, double y0)
        {
            List<double> x = new List<double>();
            x.Add(x0);
            List<double> y = new List<double>();
            y.Add(y0);
            double V = y0;
            List<double> y_exact = new List<double>();
            y_exact.Add(y0);
            double x_current = x0;
            double y_current = y0;
            for (int i = 1; i <= n; i++)
            {

                y_current += h * func(x_current, y_current, V);
                x_current += h;
                x.Add(x_current);
                y.Add(y_current);
                y_exact.Add(V * x_current * x_current);
            }
            Console.Write("{0,8}", "x:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", x[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", Math.Round(y[i], 5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", y_exact[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", Math.Round(Math.Abs(y[i] - y_exact[i]), 5) + " ");
            }
            Console.WriteLine();
        }

        public static void KoshiUpgEjler(int n, double h, double x0, double y0)
        {
            List<double> x = new List<double>();
            x.Add(x0);
            List<double> y = new List<double>();
            y.Add(y0);
            double V = y0;
            List<double> y_exact = new List<double>();
            y_exact.Add(y0);
            double x_current = x0;
            double y_current = y0;
            for (int i = 1; i <= n; i++)
            {

                y_current += h * func(x_current + h / 2, y_current + h * func(x_current, y_current, V) / 2, V);
                x_current += h;
                x.Add(x_current);
                y.Add(y_current);
                y_exact.Add(V * x_current * x_current);
            }
            Console.Write("{0,8}","x:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", x[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", Math.Round(y[i],5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", y_exact[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", Math.Round(Math.Abs(y[i] - y_exact[i]), 5) + " ");
            }
            Console.WriteLine();
        }

        public static void KoshiPredKorr(int n, double h, double x0, double y0)
        {
            List<double> x = new List<double>();
            x.Add(x0);
            List<double> y = new List<double>();
            y.Add(y0);
            double V = y0;
            List<double> y_exact = new List<double>();
            y_exact.Add(y0);
            double x_current = x0;
            double y_current = y0;
            for (int i = 1; i <= n; i++)
            {

                y_current += h / 2 * (func(x_current, y_current, V) + func(x_current + h, y_current + h * func(x_current, y_current, V), V));
                x_current += h;
                x.Add(x_current);
                y.Add(y_current);
                y_exact.Add(V * x_current * x_current);
            }
            Console.Write("{0,8}", "x:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", x[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", Math.Round(y[i], 5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", y_exact[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,8}", Math.Round(Math.Abs(y[i] - y_exact[i]), 5) + " ");
            }
            Console.WriteLine();
        }

    }
}
