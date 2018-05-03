using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {

        //Looks like this task works
        static int Factorial (int k)
        {
            if (k == 1) return 1;
            else return k*Factorial(k - 1);
        }
        static void Main(string[] args)
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
            }while(!ok);

            double sum = 0, prevSum = 0;
            int i = 1;

            do
            {
                prevSum = sum;
                sum = Math.Pow(-1, i) / Factorial(i);
                i++;
            } while (Math.Abs(Math.Abs(sum) - Math.Abs(prevSum)) > number);

            Console.WriteLine("Итоговая сумма: {0}", sum);
            Console.ReadKey();
        }
    }
}
