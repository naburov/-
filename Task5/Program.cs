using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix; int N;
            int sum = 0;
            Console.WriteLine("Введите размерноcть матрицы");
            do
            {
                N = InputNumber();
                if (N <= 0) Console.WriteLine("Размерность - натуральное число");
            } while (N <= 0);


            matrix = new int[N, N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    Console.WriteLine("Введите элемент матрицы с номером {0},{1}", i, j);
                    matrix[i, j] = InputNumber();
                }

            for (int i = 0; i < N; i++)
                sum += FindMaxInLine(matrix, i);

            Console.WriteLine("Сумма максимальных элементов кажой строки {0}", sum);
            Console.ReadKey();
        }

        static int InputNumber()
        {
            int number = 0; bool ok = false;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    ok = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("Число введено неверно");
                }
            } while (!ok);
            return number;
        }

        static int FindMaxInLine(int[,] arr, int index)
        {
            int max = arr[index, 0];
            for (int i = 0; i < arr.GetLength(1); i++)
                if (arr[index, i] > max) max = arr[index, i];
            return max;
        }
    }
}
