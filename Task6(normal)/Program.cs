using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_normal_
{
    class Program
    {
        static int N;
        static int M;
        static int MAX_RECURSIVE_CALLS = 2000;
        static void Main(string[] args)
        {
            Console.WriteLine("Программа строит последовательность чисел ак = ак–1 +( ак-2 * ак–3)/2\n" +
                "по введенным с клавиатуры a1, a2, a3 и количеству четных членов в последовтальности - N \n" +
                "Также программа проверяет, сколько чисел в последовательности больше с введенного с клавиатуры числа М");
            Console.WriteLine("Введите М: ");
            M = InputNumber();
            Console.WriteLine("Введите N: ");
            do
            {
                N = InputNumber();
            } while (N <= 0);
            Console.WriteLine("Введите первый член ряда: ");
            int a1 = InputNumber();
            Console.WriteLine("Введите второй член ряда: ");
            int a2 = InputNumber();
            Console.WriteLine("Введите третий член ряда: ");
            int a3 = InputNumber();

            int countNumber = 0; 
            int countLimit = 0;
            int countCalls = 0;

            Sequence(a1, a2, a3, ref countNumber, ref countLimit, ref countCalls);
            Console.WriteLine();
            Console.WriteLine("{0} - количество четных чисел последовательности , {1} - количество чисел, больших M ", countNumber, countLimit);
            Console.WriteLine("Для продолжения нажмите любую клавишу");
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

        static void Sequence(double ak3, double ak2, double ak1, ref int countNumber , ref int countLimit, ref int countCalls)
        {
            if (countNumber >= N) return;
            if (countCalls++ >= MAX_RECURSIVE_CALLS)
            {
                Console.WriteLine("Программа достигла максимальной глубины рекурсии");
                return;
            }
            double newA = ak1 + (ak2 * ak3) / 2;
            if (newA % 2 == 0) countNumber++;
            if (newA >= M) countLimit++; 
            Console.Write("{0}  ", newA);
            Sequence(ak2, ak1, newA, ref countNumber, ref countLimit, ref countCalls);
        }
    }
}
