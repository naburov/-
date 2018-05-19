using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_normal_
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите М: ");
            int M = InputNumber();
            Console.WriteLine("Введите N: ");
            int N = InputNumber();
            Console.WriteLine("Введите первый член ряда: ");
            int a1 = InputNumber();
            Console.WriteLine("Введите второй член ряда: ");
            int a2 = InputNumber();
            Console.WriteLine("Введите третий член ряда: ");
            int a3 = InputNumber();

            int countNumber = 0; 
            int countLimit = 0;
            double ak1 = a3, ak2 = a2, ak3 = a1;  //Предыдущие члены последовательности  

            do
            {
                double newA = ak1 + (ak2 * ak3) / 2;
                if (newA % 2 == 0) countNumber++;
                if (newA >= M) countLimit++;


                ak3 = ak2;
                ak2 = ak1;
                ak1 = newA;

                Console.Write("{0}  ", newA);
            } while (countNumber < N);

            Console.WriteLine();
            Console.WriteLine("{0} , {1}", countNumber, countLimit);

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
    }
}
