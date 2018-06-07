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

        static void Main(string[] args)
        {
            Console.WriteLine("Введите М: ");
            M = InputNumber();
            Console.WriteLine("Введите N: ");
            N = InputNumber();
            Console.WriteLine("Введите первый член ряда: ");
            int a1 = InputNumber();
            Console.WriteLine("Введите второй член ряда: ");
            int a2 = InputNumber();
            Console.WriteLine("Введите третий член ряда: ");
            int a3 = InputNumber();

            int countNumber = 0; 
            int countLimit = 0;
            //double ak1 = a3, ak2 = a2, ak3 = a1;  //Предыдущие члены последовательности  

            Sequence(a1, a2, a3, ref countNumber, ref countLimit);
            //do
            //{
            //    double newA = ak1 + (ak2 * ak3) / 2;
            //    if (newA % 2 == 0) countNumber++;
            //    if (newA >= M) countLimit++;


            //    ak3 = ak2;
            //    ak2 = ak1;
            //    ak1 = newA;

            //    Console.Write("{0}  ", newA);
            //} while (countNumber < N);

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

        static void Sequence(double ak3, double ak2, double ak1, ref int countNumber , ref int countLimit)
        {
            if (countNumber >= N) return;
            double newA = ak1 + (ak2 * ak3) / 2;
            if (newA % 2 == 0) countNumber++;
            if (newA >= M) countLimit++;
            Console.Write("{0}  ", newA);
            Sequence(ak2, ak1, newA, ref countNumber, ref countLimit);
        }
    }
}
