using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsOfCounting_Ex1
{
    class SLAUSolution
    {
        public static double countFuncL(double x, Dictionary<double, double> nums)
        {
            double summary = 0.0;
            foreach (KeyValuePair<double, double> vals1 in nums)
            {
                double slag = vals1.Value;

                foreach (KeyValuePair<double, double> vals2 in nums)
                {
                    if (vals1.Key != vals2.Key)

                        slag *= (x - vals2.Key) / (vals1.Key - vals2.Key);
                }
                summary += slag;
            }
            return summary;
        }

        public static void Njuton(double x, Dictionary<double, double> nums, int n)
        {

            List<double> Lx = new List<double>();
            foreach (double key in nums.Keys)
                Lx.Add(key);

            List<List<double>> Table = new List<List<double>>(n);

            for (int i = 0; i < n; i++)
            {
                Table.Add(new List<double>());
            }

            foreach (KeyValuePair<double, double> pair in nums)
            {
                Table[0].Add(pair.Value);
            }
            int t = n - 1;

            Console.WriteLine(n);
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    Table[i].Add((Table[i - 1][j + 1] - Table[i - 1][j]) / (Lx[j + i] - Lx[j]));
                }
                t--;
            }
            Console.WriteLine("Далее будет выведена полученная таблица значений функций: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < Table[i].Count; j++)
                {
                    Console.Write(Table[i][j] + " ");
                }
                Console.WriteLine();
            }
            double Result = 0.0;
            double DeltaX = 1.0;

            for (int i = 0; i < n; i++)
            {
                Result += Table[i][0] * DeltaX;
                DeltaX *= x - Lx[i];
            }

            Console.WriteLine("Njuton (" + x + ") = " + Result);
        }

        public static void Splines(Dictionary<double, double> nums, int n, double x0)
        {
            List<List<double>> Matrix = new List<List<double>>();
            for (int i = 0; i < 4 * n; i++)
            {
                List<double> test = new List<double>();
                for (int j = 0; j < 4 * n + 1; j++)
                    test.Add(0);
                Matrix.Add(test);
            }
            Console.WriteLine(Matrix.Count);

            int k = 2;
            Matrix[0][2] = 1;
            Matrix[1][4 * n - 2] = 2;
            List<double> keysList = nums.Keys.ToList();
            int q = keysList.Count;
            double prevF = 0.0;
            double prevX = 0.0;
            double dif = keysList[q - 1] - keysList[q - 2];
            double mul = dif;
            Matrix[1][4 * n - 1] = 6 * dif;
            List<double> valueList = nums.Values.ToList();
            int l = valueList.Count;
            Matrix[4 * n - 2][4 * n - 4] = 1;
            Matrix[4 * n - 2][4 * n] = valueList[l - 2];
            Matrix[4 * n - 1][4 * n - 4] = 1;
            Matrix[4 * n - 1][4 * n - 3] = dif;
            mul *= dif;
            Matrix[4 * n - 1][4 * n - 2] = mul;
            mul *= dif;
            Matrix[4 * n - 1][4 * n - 1] = mul;
            Matrix[4 * n - 1][4 * n] = valueList[l - 1];
            foreach (KeyValuePair<double, double> XandF in nums)
            {
                if (XandF.Key != x0)
                {
                    double h = XandF.Key - prevX;
                    double hMn = h;
                    Matrix[k][(k - 2)] = 1;
                    Matrix[k][4 * n] = prevF;
                    Matrix[k + 1][(k - 2)] = 1;
                    Matrix[k + 1][(k - 2) + 1] = hMn;
                    hMn *= h;
                    Matrix[k + 1][(k - 2) + 2] = hMn;
                    hMn *= h;
                    Matrix[k + 1][(k - 2) + 3] = hMn;
                    Matrix[k + 1][4 * n] = XandF.Value;
                    hMn = h;
                    Matrix[k + 2][(k - 2) + 1] = hMn;
                    hMn *= h;
                    Matrix[k + 2][(k - 2) + 2] = 2 * hMn;
                    hMn *= h;
                    Matrix[k + 2][(k - 2) + 3] = 3 * hMn;
                    Matrix[k + 2][(k - 2) + 5] = -1;
                    Matrix[k + 3][(k - 2) + 2] = 2;
                    Matrix[k + 3][(k - 2) + 3] = 6 * h;
                    Matrix[k + 3][(k - 2) + 6] = -2;
                    k += 4;
                }

                prevF = XandF.Value;
                prevX = XandF.Key;
            }
            Console.WriteLine("Выводим полученную матрицу: ");
            foreach (List<double> m1 in Matrix)
            {
                foreach (double m2 in m1)
                    Console.Write(m2 + " ");
                Console.WriteLine();
            }
            

        }

        public static List<List<double>> MatrixMultiplication(List<List<double>> matrixA, List<List<double>> matrixB)
        {
            if (matrixA.Count != matrixB.Count)
            {
                throw new Exception("Умножение невозможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            List<List<double>> matrixC = new List<List<double>>(matrixA.Count);
            for (int i = 0; i < matrixA.Count; i++)
                matrixC.Add(new List<double>(matrixB[i].Count));

            for (int i = 0; i < matrixA.Count; i++)
            {
                matrixC[i].Add(0.0);

                for (var k = 0; k < matrixA.Count; k++)
                {
                    matrixC[i][0] += matrixA[i][k] * matrixB[k][0];
                }

            }

            return matrixC;
        }

        public static List<List<double>> GetGaussMatrix(List<List<double>> ish)
        {
            List<List<double>> res = ish;
            int i = 0;
            int size = ish.Count;
            while (i < size)
            {
                double del = res[i][i];
                if (del != 0.0)
                {
                    for (int j = 0; j < size + 1; j++)
                        res[i][j] /= del;
                    for (int k = i + 1; k < size; k++)
                    {
                        double del1 = res[k][i];
                        for (int j = 0; j < size + 1; j++)
                        {
                            res[k][j] -= del1 * res[i][j];
                        }
                    }
                    i++;
                }
                else
                {
                    double max = Double.MinValue;
                    int maxi = -1;
                    for (int k = i + 1; k < size; k++)
                        if (Math.Abs(res[k][i]) > max)
                        {

                            max = res[k][i];
                            maxi = k;
                        }
                    if ((max != 0) && (max != Double.MinValue))
                    {
                        List<double> tmp = res[maxi];
                        res[maxi] = res[i];
                        res[i] = tmp;
                    }
                    else return null;
                }

            }
            return res;
        }

        public static List<List<double>> GetAnswerFromGauss(List<List<double>> matrix)
        {
            int razm = matrix.Count;
            List<List<double>> res = new List<List<double>>(razm);
            for (int i = 0; i < razm; i++)
                res.Add(new List<double>());
            res[0].Add(matrix[razm - 1][razm]);
            int count = 1;
            for (int i = razm - 2; i >= 0; i--)
            {
                double newx = matrix[i][razm];
                int k = 0;
                for (int j = razm - 1; j > i; j--)
                {
                    newx -= res[k][0] * matrix[i][j];
                    k++;
                }
                res[count].Add(newx);
                count++;
            }

            res.Reverse();
            return res;
        }

        public static void copy (List<List<double>> ish, List<List<double>> other)
        {
            int cnt = 0;
            foreach (List<double> i1 in ish)
            {
                other.Add(new List<double>());
                foreach (double i2 in i1)
                    other[cnt].Add(i2);
                cnt++;
            }
        }

        public static double Determinant(List<List<double>> ish)
        {
            List<List<double>> res = new List<List<double>>();
            copy(ish, res);
            int i = 0;
            int size = ish.Count;
            double peremn = 1.0;
            int count = 0;
            while (i < size)
            {
                double del = res[i][i];
                peremn *= del;
                count++;
                if (del != 0.0)
                {
                    for (int j = 0; j < size; j++)
                        res[i][j] /= del;
                    for (int k = i + 1; k < size; k++)
                    {
                        double del1 = res[k][i];
                        for (int j = 0; j < size; j++)
                        {
                            res[k][j] -= del1 * res[i][j];
                        }
                    }
                    i++;
                }
                else
                {
                    double max = Double.MinValue;
                    int maxi = -1;
                    for (int k = i + 1; k < size; k++)
                        if (Math.Abs(res[k][i]) > max)
                        {

                            max = res[k][i];
                            maxi = k;
                        }
                    if ((max != 0) && (max != Double.MinValue))
                    {
                        List<double> tmp = res[maxi];
                        res[maxi] = res[i];
                        res[i] = tmp;
                    }
                    else return Double.MinValue;
                }

            }
            double det = peremn;
            if (count % 2 != 0)
                return det;
            else return -det;
        }

        public static List<List<double>> GetObrMatrix(List<List<double>> matrix)
        {
            List<List<double>> result = new List<List<double>>();
            int razm = matrix.Count;
            for (int i = 0; i < razm; i++)
                result.Add(new List<double>());
            for (int i = 0; i < razm; i++)
            {
                List<List<double>> tmp = new List<List<double>>(razm);
                for (int q = 0; q < razm; q++)
                    tmp.Add(new List<double>());
                for (int k = 0; k < razm; k++)
                    for (int l = 0; l < razm; l++)
                        tmp[k].Add(matrix[k][l]);


                for (int j = 0; j < razm; j++)
                    if (j != i)
                        tmp[j].Add(0);
                    else tmp[j].Add(1);



                List<List<double>> stolbets = GetAnswerFromGauss(GetGaussMatrix(tmp));
                for (int j = 0; j < razm; j++)
                    result[j].Add(stolbets[j][0]);
            }


            return result;
        }

        public static List<double> SweepMethod(List<List<double>> matrix)
        {
            List<double> P = new List<double>();
            List<double> Q = new List<double>();
            int sizeRow = matrix[0].Count;
            int sizeColumn = matrix.Count;
            P.Add(matrix[0][1] / (-matrix[0][0]));
            Q.Add(-matrix[0][sizeRow - 1] / (-matrix[0][0]));
            for (int i = 1; i < sizeColumn - 1; i++)
            {
                double koeff = (-matrix[i][i] - matrix[i][i - 1] * P[i - 1]);
                double qznam = (matrix[i][i - 1] * Q[i - 1] - matrix[i][sizeRow - 1]);

                P.Add(matrix[i][i + 1] / koeff);
                Q.Add(qznam / koeff);
            }

            /*Console.WriteLine();
            Console.WriteLine("Выведем P:");
            foreach (double p1 in P)
                Console.Write(p1 + " ");
            Console.WriteLine();
            Console.WriteLine("Выведем Q:");
            foreach (double q1 in Q)
                Console.Write(q1 + " "); */
            int sc = sizeRow - 1;
            int sr = sizeColumn - 1;
            double a = matrix[sr][sc - 2];
            double b = -matrix[sr][sc - 1];
            double d = matrix[sr][sc];
            double q = Q[sr - 1];
            double p = P[sr - 1];
            Q.Add((a * q - d) / (b - a * p));
            List<double> ans = new List<double>();
            Console.WriteLine();
            ans.Add(Q[sr]);
            for (int i = 1; i <= sr; i++)
                ans.Add(ans[i - 1] * P[sr - i] + Q[sr - i]);
            ans.Reverse();
            return ans;
        }

        public static List<List<double>> SimpleIterations(List<List<double>> matrix, List<double> b)
        {
            int razm = matrix.Count;
            List<List<double>> x = new List<List<double>>();

            for (int i = 0; i < razm; i++)
            {
                x.Add(new List<double>());
                x[i].Add(1.0);
            }
            List<List<double>> alpha = new List<List<double>>();
            List<List<double>> beta = new List<List<double>>();
            for (int i = 0; i < razm; i++)
            {
                alpha.Add(new List<double>());
                beta.Add(new List<double>());
                double aii = matrix[i][i];
                beta[i].Add(b[i] / aii);
                for (int j = 0; j < razm; j++)
                {
                    if (i == j)
                        alpha[i].Add(0);
                    else
                        alpha[i].Add(-matrix[i][j] / aii);
                }
            }
            double eps = 1E-05;
            bool flag = true;
            int countX = razm;
            List<List<double>> xprev = new List<List<double>>();
            for (int i = 0; i < razm; i++)
            {
                xprev.Add(new List<double>());
                xprev[i].Add(x[i][0]);
            }
            x = MatrixMultiplication(alpha, x);
            for (int i = 0; i < razm; i++)
                x[i][0] += beta[i][0];
            int cnt = 0;
            int iterNum = 1;
            while (flag)
            {
                for (int i = 0; i < razm; i++)
                    if (Math.Abs(xprev[i][0] - x[i][0]) < eps)
                        cnt++;
                if (cnt == countX)
                {
                    flag = false;
                    break;
                }
                else
                {
                    xprev = new List<List<double>>();
                    for (int i = 0; i < razm; i++)
                    {
                        xprev.Add(new List<double>());
                        xprev[i].Add(x[i][0]);
                    }
                    x = MatrixMultiplication(alpha, x);
                    for (int i = 0; i < razm; i++)
                        x[i][0] += beta[i][0];
                }
                iterNum++;
            }
            Console.WriteLine("При погрешности eps = " + eps);
            Console.WriteLine("Выведем решение: ");
            foreach (List<double> l in x)
            {
                foreach (double k in l)
                    Console.Write(k + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Это решение получено на " + iterNum + "-й итерации алгоритма");
            Console.WriteLine();
            return x;
        }
    }
}
