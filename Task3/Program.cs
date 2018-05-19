using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координату х");
            int x = InputNumber();
            Console.WriteLine("Введите координату у");
            int y = InputNumber();

            double u;
            if (y > 0 &&
                (x < 0 && Math.Pow(x, 2) + Math.Pow(y, 2) < 1) &&
                (x > 0 && Math.Pow(x, 2) + Math.Pow(y, 2) > 0.09 &&
                Math.Pow(x, 2) + Math.Pow(y, 2) < 1))
                u = Math.Pow(x, 3) - 1;
            else
                u = Math.Sqrt(Math.Abs(x - 1));
            Console.WriteLine(u);
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
    }
}
