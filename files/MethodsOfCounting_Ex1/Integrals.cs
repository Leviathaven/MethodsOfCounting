using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOfCounting_Ex1
{
    class Integrals
    {
        //Начинаются интегральные задачи

        public static void Fredman()
        {
            double h = 0.1;
            double a = 0.0;
            double v = 8.0;
           

            List<List<double>> m = new List<List<double>>();
            m.Add(new List<double>());
            m[0].Add(1.0 + 1.0 / 3.0);
            m[0].Add(0.25);
            m[0].Add(0.2);
            m[0].Add(1969.0 / 450.0);

            m.Add(new List<double>());
            m[1].Add(0.25);
            m[1].Add(1.2);
            m[1].Add(1.0 / 6.0);
            m[1].Add(10.0 / 3.0);

            m.Add(new List<double>());
            m[2].Add(0.2);
            m[2].Add(1.0 / 6.0);
            m[2].Add(1.0 + 1.0 / 7.0);
            m[2].Add(283.0 / 105.0);


            List<List<double>> q = SLAUSolution.GetAnswerFromGauss(SLAUSolution.GetGaussMatrix(m));
            double x_curr = a;
            List<double> x = new List<double>();
            for (int i = 0; i <= 10; i++)
            {
                x.Add(x_curr);
                x_curr += h;
            }
            List<double> y = new List<double>();
            for (int i = 0; i <= 10; i++)
            {
                double slag = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    slag += q[j][0] * Math.Pow(x[i], j + 1);
                }
                double f = v * (4.0 / 3 * x[i] + 0.25 * x[i] * x[i] + 0.2 * x[i] * x[i] * x[i]);
                y.Add(f - slag);
            }
            List<double> y_exact = new List<double>();
            for (int i = 0; i <= 10; i++)
                y_exact.Add(v * x[i]);
            Console.Write("{0,8}", "x:");
            foreach(double x1 in x)
            {
                Console.Write("{0,8}", x1 + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            foreach (double y1 in y)
            {
                Console.Write("{0,8}", Math.Round(y1, 5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            foreach (double y1 in y_exact)
            {
                Console.Write("{0,8}", y1 + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i <= 10; i++)
            {
                Console.Write("{0,8}", Math.Round(Math.Abs(y[i] - y_exact[i]), 5) + " ");
            }
            Console.WriteLine();
        }

        public static double getA(double x, double t)
        {
            return x * t + x * x * t * t + x * x * x * t * t * t;
        }

        public static void Kvadratura()
        {
            double a = 0.0;
            double b = 1.0;
            double n = 10;
            double h = (b - a) / (n - 1);
            double v = 8.0;
            List<List<double>> m = new List<List<double>>();

            List<double> f = new List<double>();       

          
            double x_curr = a;
            List<double> x = new List<double>();
            for (int i = 0; i <= n - 1; i++)
            {
                x.Add(x_curr);
                f.Add(v * (4.0 / 3 * x[i] + 0.25 * x[i] * x[i] + 0.2 * x[i] * x[i] * x[i]));
                x_curr += h;
            }

            for (int k = 0; k <= n - 1 ; k++)
            {
                m.Add(new List<double>());
                for (int j = 0; j<= n - 1; j++)
                {
                    if (k == j)
                        m[k].Add(h * getA(x[k], x[j]) + 1);
                    else
                        m[k].Add(h * getA(x[k], x[j]));
                }
                m[k].Add(f[k]);
            }

            List<List<double>> y_prom = SLAUSolution.GetAnswerFromGauss(SLAUSolution.GetGaussMatrix(m));
            List<double> y = new List<double>();

            for (int i = 0; i <= n - 1; i++)
            {
                double slag = 0.0;
                for (int j = 0; j <= n - 1; j++)
                    slag += h * y_prom[j][0] * getA(x[i], x[j]);
                y.Add(f[i] - slag);
            }

            List<double> y_exact = new List<double>();
            for (int i = 0; i <= n - 1; i++)
                y_exact.Add(8 * x[i]);
            Console.Write("{0,8}", "x:");
            foreach (double x1 in x)
            {
                Console.Write("{0,8}", Math.Round(x1, 5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            foreach (double y1 in y)
            {
                Console.Write("{0,8}", Math.Round(y1, 5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            foreach (double y1 in y_exact)
            {
                Console.Write("{0,8}", Math.Round(y1, 5) + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i <= n - 1; i++)
            {
                Console.Write("{0,8}", Math.Round(Math.Abs(y[i] - y_exact[i]), 5) + " ");
            }
            Console.WriteLine();
        }
    }
}
