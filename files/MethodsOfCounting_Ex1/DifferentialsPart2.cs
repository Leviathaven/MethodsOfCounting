using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOfCounting_Ex1
{
    class DifferentialsPart2
    {
        // Задача коши для ОДУ 1 порядка закончилась пошли ОДУ 2 порядка

        public static List<double> DifferentialMethod(int n, double T)
        {
            List<double> p = new List<double>();
            List<double> q = new List<double>();
            List<double> f = new List<double>();
            double V = T;
            double h = T / n;

            List<double> x = new List<double>();
            double x_curr = 0;
            for (int i = 0; i <= n; i++)
            {
                x.Add(x_curr);
                p.Add(x_curr * x_curr);
                q.Add(x_curr);
                double f1 = x[i] * x[i] * x[i] * x[i] * 4 * V;
                double f2 = 3 * V * x[i] * x[i] * x[i] * T;
                double f3 = 6 * V * x[i];
                double f4 = 2 * V * T;
                f.Add(f1 - f2 + f3 - f4);
                x_curr += h;
            }

            List<List<double>> m = new List<List<double>>();

            for (int i = 0; i <= n; i++)
            {
                m.Add(new List<double>());
                for (int j = 0; j <= n + 1; j++)
                    m[i].Add(0.0);
            }

            for (int i = 1; i < n; i++)
                m[i][n + 1] = f[i];
            m[0][0] = 1;
            m[n][n] = 1;

            for (int i = 1; i <= n - 1; i++)
            {
                double k1 = (1 / (h * h)) - (p[i] / (2 * h));
                m[i][i - 1] = k1;
                double k2 = (-2 / (h * h)) + q[i];
                m[i][i] = k2;
                double k3 = (1 / (h * h)) + (p[i] / (2 * h));
                m[i][i + 1] = k3;
            }


            List<double> ans = SLAUSolution.SweepMethod(m);

            List<double> y_exact = new List<double>();
            for (int i = 0; i <= n; i++)
            {
                double k1 = V * x[i] * x[i];
                double k2 = x[i] - T;
                y_exact.Add(k1 * k2);
            }
            Console.WriteLine();
            Console.Write("{0,8}", "x:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,10}", x[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            for (int i = 0; i < n; i++)
                Console.Write("{0,10}", Math.Round(ans[i], 4) + " ");
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            for (int i = 0; i < n; i++)
                Console.Write("{0,10}", Math.Round(y_exact[i], 4) + " ");
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i < n; i++)
                Console.Write("{0,10}", Math.Round(Math.Abs(ans[i] - y_exact[i]), 4) + " ");
            return ans;
        }

        public static List<double> ODNZadSpec(int n, double T, double a, double b)
        {
            List<double> p = new List<double>();
            List<double> q = new List<double>();
            List<double> f = new List<double>();
            double V = T;
            double h = V / n;

            List<double> x = new List<double>();
            double x_curr = 0;
            for (int i = 0; i <= n; i++)
            {
                x.Add(x_curr);
                p.Add(x_curr * x_curr);
                q.Add(x_curr);
                double f1 = x[i] * x[i] * x[i] * x[i] * 4 * V;
                double f2 = (6 * V + 1) * x[i];
                f.Add(f1 + f2 - p[i] * makeZ1(a, b, T) - q[i] * makeZ(x[i], a, b, T));
                x_curr += h;
                
            }

            List<List<double>> m = new List<List<double>>();

            for (int i = 0; i <= n; i++)
            {
                m.Add(new List<double>());
                for (int j = 0; j <= n + 1; j++)
                    m[i].Add(0.0);
            }

            for (int i = 1; i < n; i++)
                m[i][n + 1] = f[i];
            m[0][0] = 1;
            m[n][n] = 1;

            for (int i = 1; i <= n - 1; i++)
            {
                double k1 = (1 / (h * h)) - (p[i] / (2 * h));
                m[i][i - 1] = k1;
                double k2 = (-2 / (h * h)) + q[i];
                m[i][i] = k2;
                double k3 = (1 / (h * h)) + (p[i] / (2 * h));
                m[i][i + 1] = k3;
            }


            List<double> ans = SLAUSolution.SweepMethod(m);

            List<double> y_exact = new List<double>();
            for (int i = 0; i <= n; i++)
            {
                double k1 = V * x[i] * x[i] * x[i] + 1;
                y_exact.Add(k1);
            }
            return ans;
        }

        public static double makeZ(double x, double a, double b, double T)
        {
            return ((b - a) / T) * x + a;
        }

        public static double makeZ1(double a, double b, double T)
        {
            return (b - a) / T;
        }


        public static List<double> ODNZad(int n, double T)
        {

            List<double> x = new List<double>();
            List<double> z_f = new List<double>();
            double V = 4.0;
            double h = T / n;
            double a = 1.0;
            double b = V + 1.0;
            double x_curr = 0;
            for (int i = 0; i <= n; i++)
            {
                x.Add(x_curr);
                double z_curr = makeZ(x[i], a, b, T);
                z_f.Add(z_curr);
                x_curr += h;
            }
            List<double> y0 = ODNZadSpec(n, T, a, b);

            List<double> ans = new List<double>();
            List<double> y_exact = new List<double>();

            for (int i = 0; i <= n; i++)
            {
                ans.Add(y0[i] + z_f[i]);
                y_exact.Add(V * x[i] * x[i] * x[i] + 1);
            }
            Console.WriteLine();
            Console.Write("{0,8}", "x:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("{0,10}", x[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            for (int i = 0; i <= n; i++)
                Console.Write("{0,10}", Math.Round(ans[i], 4) + " ");
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            for (int i = 0; i <= n; i++)
                Console.Write("{0,10}", Math.Round(y_exact[i], 4) + " ");
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i <= n; i++)
                Console.Write("{0,10}", Math.Round(Math.Abs(ans[i] - y_exact[i]), 4) + " ");

            return ans;
        }


        public static double getFi2(double xj, int k, double T)
        {
            return (k + 1) * k * Math.Pow(xj, k - 1)
                    - T * k * (k - 1) * Math.Pow(xj, k - 2);
        }

        public static double getFi1(double xj, int k, double T)
        {
            return (k + 1) * Math.Pow(xj, k)
                    - T * k * Math.Pow(xj, k - 1);
        }

        public static double getFi(double xj, int k, double T)
        {
            return Math.Pow(xj, k) * (xj - T);
        }

        public static void UndefinedCoeff(int n, double T)
        {
            List<double> f = new List<double>();
            List<double> x = new List<double>();
            double V = T;
            double h = T / n;
            double x_curr = h;
            for (int i = 1; i <= n; i++)
            {
                x.Add(x_curr);
                f.Add(4.0 * T * x_curr * x_curr * x_curr * x_curr - 3.0 * V * T * x_curr * x_curr * x_curr + 6.0 * T * x_curr - 2.0 * T * V);
                x_curr += h;
            }

            List<List<double>> ak = new List<List<double>>();

            for (int j = 1; j <= n; j++)
            {
                ak.Add(new List<double>());
                double xj = x[j - 1];
                for (int k = 1; k <= n; k++)
                {
                    ak[j - 1].Add(getFi2(xj, k, T) + xj * xj * getFi1(xj, k, T) + xj * getFi(xj, k, T));
                }
                ak[j - 1].Add(f[j - 1]);
            }

            f.RemoveAt(0);

            List<List<double>> akAns = SLAUSolution.GetAnswerFromGauss(SLAUSolution.GetGaussMatrix(ak));

            List<double> y_ans = new List<double>();

            for (int j = 1; j <= n; j++)
            {
                double xj = x[j - 1];
                double yj = 0.0;
                for (int k = 1; k <= n; k++)
                {
                    yj += akAns[k - 1][0] * getFi(xj, k, T);
                }
                y_ans.Add(yj);
            }

            List<double> y_exact = new List<double>();
            for (int i = 1; i <= n; i++)
            {
                double k1 = V * x[i - 1] * x[i - 1];
                double k2 = x[i - 1] - T;
                y_exact.Add(k1 * k2);
            }
            Console.Write("{0,8}", "x:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,10}", x[i] + " ");
            }
            Console.WriteLine();
            Console.Write("{0,8}", "y(мет):");
            for (int i = 0; i < n; i++)
                Console.Write("{0,10}", Math.Round(y_ans[i], 4) + " ");
            Console.WriteLine();
            Console.Write("{0,8}", "y(точн):");
            for (int i = 0; i < n; i++)
                Console.Write("{0,10}", Math.Round(y_exact[i], 4) + " ");
            Console.WriteLine();
            Console.Write("{0,8}", "погр:");
            for (int i = 0; i < n; i++)
                Console.Write("{0,10}", Math.Round(Math.Abs(y_ans[i] - y_exact[i]), 4) + " ");
        }

    }
}
