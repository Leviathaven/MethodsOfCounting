using System;
using System.Collections.Generic;
using System.Linq;
using MethodsOfCounting_Ex1;

class MainProgram {   
    

    public static int Main()
    {
        //КОД ДЛЯ ТЕСТИРОВАНИЯ ПОДСЧЁТА МНОГОЧЛЕНА ЛАГРАНЖА
        /*Dictionary<double, double> nums = new Dictionary<double, double>();
        Console.WriteLine("Введите число узлов:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите данные следующим образом: в первой строчке - значение x, во второй - f(x) и так далее до конца");
        for (int i = 1; i <= n; i++)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double fx = Convert.ToDouble(Console.ReadLine());
            nums.Add(x, fx);
        }
        Console.WriteLine("Введите число, от которого должна будет быть посчитана функция или -1 для завершения:");
        double x_curr = Convert.ToDouble(Console.ReadLine());
        while (x_curr != -1.0)
        {
            Console.WriteLine("Значение многочлена Лагранжа в точке x = " + x_curr + " - " + SLAUSolution.countFuncL(x_curr, nums));
            x_curr = Convert.ToDouble(Console.ReadLine());
        }*/

        //КОД ДЛЯ ТЕСТИРОВАНИЯ ПОДСЧЁТА МНОГОЧЛЕНА НЬЮТОНА
        /*Dictionary<double, double> nums = new Dictionary<double, double>();
        Console.WriteLine("Введите число узлов:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите данные следующим образом: в первой строчке - значение x, во второй - f(x) и так далее до конца");
        for (int i = 1; i <= n; i++)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double fx = Convert.ToDouble(Console.ReadLine());
            nums.Add(x, fx);
        }
        Console.WriteLine("Введите число, от которого должна будет быть посчитана функция или -1 для завершения:");
        double x_curr = Convert.ToDouble(Console.ReadLine());
        while (x_curr != -1.0)
        {
            SLAUSolution.Njuton(x_curr, nums, n);
            x_curr = Convert.ToDouble(Console.ReadLine());
        }*/

        //КОД ДЛЯ ТЕСТИРОВАНИЯ ПОДСЧЁТА МАТРИЦЫ ДЛЯ МЕТОДА СПЛАЙНОВ
        /*Dictionary<double, double> nums = new Dictionary<double, double>();
        Console.WriteLine("Введите число узлов:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите данные следующим образом: в первой строчке - значение x, во второй - f(x) и так далее до конца");
        for (int i = 1; i <= n; i++)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double fx = Convert.ToDouble(Console.ReadLine());
            nums.Add(x, fx);
        }
        Console.WriteLine("Введите число, от которого должна будет быть посчитана функция или -1 для завершения:");
        double x_curr = Convert.ToDouble(Console.ReadLine());
        while (x_curr != -1.0)
        {
           SLAUSolution.Splines(nums, n, x_curr);
           x_curr = Convert.ToDouble(Console.ReadLine());
        }*/

        //КОД ДЛЯ ТЕСТИРОВАНИЯ МЕТОДА ГАУССА
        /*List<List<double>> myM = new List<List<double>>();

        double V = 8.0;
        int razm = 5;
        List<List<double>> mV = new List<List<double>>();
        for (int i = 0; i < razm; i++)
        {
            myM.Add(new List<double>(razm));
            for (int j = 0; j < razm; j++)
                if (i == j)
                    myM[i].Add(V);
                else myM[i].Add(V / 100);
            mV.Add(new List<double>());
            mV[i].Add(V);
            V++;
        }

        Console.WriteLine("Выводим матрицу, соответствующую варианту: ");
        for (int i = 0; i < razm; i++)
        {
            for (int j = 0; j < razm; j++)
                Console.Write(myM[i][j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine("Выводим матрицу ответов x: ");
        for (int i = 0; i < razm; i++)
        {
           
                Console.Write(mV[i][0] + " ");
            Console.WriteLine();
        }

        List<List<double>> b = SLAUSolution.MatrixMultiplication(myM, mV);

        Console.WriteLine("Выводим матрицу b: ");
        for (int i = 0; i < razm; i++)
        {
                Console.Write(b[i][0] + " ");
            Console.WriteLine();
        }

        for (int i = 0; i < razm; i++)
            myM[i].Add(b[i][0]);

        List<List<double>> GaussMatrix = SLAUSolution.GetGaussMatrix(myM);

        Console.WriteLine("Выведем матрицу, полученную после прямого прохода методом Гаусса:");
        foreach (List<double> g1 in GaussMatrix)
        {
            foreach (double g2 in g1)
                Console.Write(g2 + " ");
            Console.WriteLine();
        }

        List<List<double>> Answer = SLAUSolution.GetAnswerFromGauss(GaussMatrix);

        Console.WriteLine("Выведем матрицу, полученную после обратного прохода методом Гаусса (ответ задачи):");
        foreach (List<double> g1 in Answer)
        {
            foreach (double g2 in g1)
                Console.Write(g2 + " ");
            Console.WriteLine();
        }*/

        //ТЕСТИРОВАНИЕ НАХОЖДЕНИЯ РЕШЕНИЯ УРАВНЕНИЯ ЧЕРЕЗ ОБРАТНУЮ МАТРИЦУ
        /*List<List<double>> myM = new List<List<double>>();

        double V = 8.0;
        int razm = 3;
        List<List<double>> mV = new List<List<double>>();
        for (int i = 0; i < razm; i++)
        {
            myM.Add(new List<double>(razm));
            for (int j = 0; j < razm; j++)
                if (i == j)
                    myM[i].Add(V);
                else myM[i].Add(V / 100);
            mV.Add(new List<double>());
            mV[i].Add(V);
            V++;
        }

        Console.WriteLine("Выводим матрицу, соответствующую варианту: ");
        for (int i = 0; i < razm; i++)
        {
            for (int j = 0; j < razm; j++)
                Console.Write(myM[i][j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine("Выводим матрицу ответов x: ");
        for (int i = 0; i < razm; i++)
        {

            Console.Write(mV[i][0] + " ");
            Console.WriteLine();
        }

        List<List<double>> b = SLAUSolution.MatrixMultiplication(myM, mV);

        Console.WriteLine("Выводим матрицу b: ");
        for (int i = 0; i < razm; i++)
        {
            Console.Write(b[i][0] + " ");
            Console.WriteLine();
        }

        Console.WriteLine("Детерминанта текущей матрицы A detA = " + SLAUSolution.Determinant(myM));

        List<List<double>> myMObr = SLAUSolution.GetObrMatrix(myM);

        Console.WriteLine("Выводим обратную матрицу A^-1");
        foreach (List<double> a1 in myMObr)
        {
            foreach (double a2 in a1)
                Console.Write(a2 + " ");
            Console.WriteLine();
        }

        List<List<double>> Ans = SLAUSolution.MatrixMultiplication(myMObr, b);

        Console.WriteLine("Выводим ответ:");
        foreach (List<double> a1 in Ans)
        {
            foreach (double a2 in a1)
                Console.Write(a2 + " ");
            Console.WriteLine();
        }*/

        //ТЕСТИРОВАНИЕ МЕТОДА ПРОГОНКИ
        /*double V = 8.0;
        double Q = V;
        List<List<double>> myM = new List<List<double>>();
        int razm = 5;
        int k = 0;
        for (int i = 0; i < razm; i++)
        {
            myM.Add(new List<double>());
            if (i == 0)
            {
                myM[i].Add(Q);
                myM[i].Add(Q / 10);
                myM[i].Add(0.0);
                myM[i].Add(0.0);
                myM[i].Add(0.0);
            }
            else if (i == 4)
            {
                myM[i].Add(0.0);
                myM[i].Add(0.0);
                myM[i].Add(0.0);
                myM[i].Add(Q / 10);
                myM[i].Add(Q);                
            }
            else
            {
                for (int l = 0; l < razm; l++)
                {
                    if ((l >= k) && (l <= k + 2))
                    {
                        if (l == i)
                            myM[i].Add(Q);
                        else
                            myM[i].Add(Q / 10);
                    }
                    else
                        myM[i].Add(0);
                }

                k++;
            }
            Q++;
        }
        myM[3][2] = 1.1;

        Console.WriteLine("Выводим матрицу, соответствующую варианту: ");
        for (int i = 0; i < razm; i++)
        {
            for (int j = 0; j < razm; j++)
                Console.Write(myM[i][j] + " ");
            Console.WriteLine();
        }

        List<List<double>> mV = new List<List<double>>();

        Q = V;
        for(int i = 0; i < razm; i++)
        {
            mV.Add(new List<double>());
            mV[i].Add(Q);
            Q++;
        }

        Console.WriteLine("Ответами системы должны быть: ");
        foreach (List<double> m1 in mV)
            foreach (double m2 in m1)
                Console.Write(m2 + " ");

        List<List<double>> b = SLAUSolution.MatrixMultiplication(myM, mV);
        Console.WriteLine();
        Console.WriteLine("Столбец d: ");
        foreach (List<double> m1 in b)
            foreach (double m2 in m1)
                Console.Write(m2 + " ");

        for (int i = 0; i < razm; i++)
            myM[i].Add(b[i][0]);

        List<double> ans = SLAUSolution.SweepMethod(myM);

        Console.WriteLine("Решение системы:");
        foreach (double a1 in ans)
            Console.Write(a1 + " "); */

        // ТЕСТИРОВАНИЕ МЕТОДА ПРОСТЫХ ИТЕРАЦИЙ

        /*List<List<double>> myM = new List<List<double>>();

        double V = 8.0;
        int razm = 5;
        List<List<double>> mV = new List<List<double>>();
        for (int i = 0; i < razm; i++)
        {
            myM.Add(new List<double>(razm));
            for (int j = 0; j < razm; j++)
                if (i == j)
                    myM[i].Add(V);
                else myM[i].Add(V / 100);
            mV.Add(new List<double>());
            mV[i].Add(V);
            V++;
        }

        Console.WriteLine("Выводим матрицу, соответствующую варианту: ");
        for (int i = 0; i < razm; i++)
        {
            for (int j = 0; j < razm; j++)
                Console.Write(myM[i][j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine("Выводим матрицу ответов x: ");
        for (int i = 0; i < razm; i++)
        {

            Console.Write(mV[i][0] + " ");
            Console.WriteLine();
        }

        List<List<double>> b = SLAUSolution.MatrixMultiplication(myM, mV);
        List<double> tmpB = new List<double>();

        Console.WriteLine("Выводим матрицу b: ");
        for (int i = 0; i < razm; i++)
        {
            Console.Write(b[i][0] + " ");
            Console.WriteLine();
            tmpB.Add(b[i][0]);
        }     

        SLAUSolution.SimpleIterations(myM, tmpB); */

        //ТЕСТИРОВАНИЕ МЕТОДА ЭЙЛЕРА ДЛЯ РЕШЕНИЯ ЗАДАЧИ КОШИ ДЛЯ ОДУ 1-ГО ПОРЯДКА

        /*Differentials.KoshiEjler(10, 0.01, 1.0, 8.0);
        Console.WriteLine();
        Differentials.KoshiUpgEjler(10, 0.01, 1.0, 8.0);
        Console.WriteLine();
        Differentials.KoshiPredKorr(10, 0.01, 1.0, 8.0);*/

        //ТЕСТИРОВАНИЕ РАЗНОСТНОГО МЕТОДА РЕШЕНИЯ ЗАДАЧИ КОШИ ДЛЯ ОДУ 2-ГО ПОРЯДКА

        //DifferentialsPart2.DifferentialMethod(10, 8.0);

        //ТЕСТИРОВАНИЕ СВЕДЕНИЯ КРАЕВОЙ ЗАДАЧИ С НЕОДНОРОДНЫМИ УСЛОВИЯМИ К ОДНОРОДНЫМ

        DifferentialsPart2.ODNZad(10, 1.0);

        //ТЕСТИРОВАНИЕ СВЕДЕНИЯ КРАЕВОЙ ЗАДАЧИ МЕТОДОМ НЕОПРЕДЕЛЁННЫХ КОЭФФИЦИЕНТОВ
        //DifferentialsPart2.UndefinedCoeff(10, 8.0);

        //ТЕСТИРОВАНИЕ РЕШЕНИЯ ИНТЕГРАЛЬНЫХ УРАВНЕНИЙ МЕТОДОМ ФРЕДМАНА
        //Integrals.Fredman();

        //ТЕСТИРОВАНИЕ РЕШЕНИЯ ИНТЕГРАЛЬНЫХ УРАВНЕНИЙ МЕТОДОМ КВАДРАТУР
        //Integrals.Kvadratura();

        Console.ReadKey();
        return 0;
    }
}
