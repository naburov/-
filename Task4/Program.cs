using System;

namespace Task4
{
    class Program
    {

        static int MAX_RECURSIVE_CALLS = 2000; //Максимальное количество вызовов рекурсии
        static int Factorial(int k, ref int callCount)
        {
            if (k == 1 || callCount++>=MAX_RECURSIVE_CALLS) return 1;
            else return k * Factorial(k - 1, ref callCount);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вычисляет сумму ряда (-1)^i/i! с заданной с клавиатуры точностью e");
            double number = InputNumber();

            double sum = 0, tek = 0;
            int i = 1;

            do
            {
                int callCount = 0;
                tek = Math.Pow(-1, i) / Factorial(i, ref callCount);
                sum += tek;
                Console.WriteLine("{0} член ряда: {1}", i, tek);
                i++;
            } while (Math.Abs(tek) > number);

            Console.WriteLine("Итоговая сумма: {0}", sum);
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        private static double InputNumber()
        {
            double number = 0; bool ok = false;
            Console.WriteLine("Введите точность");
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    if (number < 0) throw new Exception();
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Число введено неверно");
                }
            } while (!ok);
            return number;
        }
    }
}
