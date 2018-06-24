using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа на основе вычисления принадлежности точке области\n" +
                "c координатами, заданными системой условий:\n" +
                "\tif (y > 0 &&\n" +
                "\t(x < 0 && Math.Pow(x, 2) + Math.Pow(y, 2) < 1) ||\n" +
                "\t(x > 0 && Math.Pow(x, 2) + Math.Pow(y, 2) > 0.09 &&\n" +
                "\tMath.Pow(x, 2) + Math.Pow(y, 2) < 1))\n\n" +
                "Вычисляет и выводит значение u\n" +
                "Если точка принадлежит области: u = x^2 - 1\n" +
                "Иначе: u = Sqrt(|x-1|)\n");
            Console.WriteLine("Введите координату х");
            double x = InputNumber();
            Console.WriteLine("Введите координату у");
            double y = InputNumber();

            double u;
            if (y >= 0 &&
                (x <= 0 && Math.Pow(x, 2) + Math.Pow(y, 2) <= 1) ||
                (x >= 0 && Math.Pow(x, 2) + Math.Pow(y, 2) >= 0.09 &&
                Math.Pow(x, 2) + Math.Pow(y, 2) <= 1))
            {
                Console.WriteLine("Точка принадлежит области");
                u = Math.Pow(x, 2) - 1;
            }
            else
            {
                Console.WriteLine("Точка не принадлежит области");
                u = Math.Sqrt(Math.Abs(x - 1));
            }

            Console.WriteLine("u = "+u);
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }

        static double InputNumber()
        {
            double number = 0; bool ok = false;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
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
