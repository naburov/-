using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Program
    {
        //Шифрование строк
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число k");
            int k = InputNumber();

            int[] replaceArr = new int[k];
            Console.WriteLine("Введите числа перестановки по одному");
            for (int i = 0; i < k; i++)
                replaceArr[i] = InputNumber();

            string begString, resultString = "";
            Console.WriteLine("Введите шифруемую/дешифруемую строку");
            do
            {
                begString = Console.ReadLine();
                if (begString.Length == 0) Console.WriteLine("Начальная строка не может быть пустой, повторите ввод");
            } while (begString.Length == 0);

            if (begString.Length % k != 0)
                do
                {
                    begString += " ";
                } while (begString.Length % k != 0);

            for (int i = 0; i < begString.Length; i += k)
            {
                string repBegString = begString.Substring(i, k);
                string repString = "";
                for (int j = 0; j < replaceArr.Length; j++)
                    repString += repBegString[replaceArr[j] - 1];
                resultString += repString;
            }

            Console.WriteLine("Результат: {0}", resultString);
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
                    if (number <= 0) throw new Exception();
                    ok = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("Число введено неверно");
                }
            } while (!ok);
            return number;
        }

        static int InputComand()
        {
            int number = 0; bool ok = false;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number != 1 && number != 2) throw new Exception();
                    ok = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("Команда введена неверно, повторите ввод");
                }
            } while (!ok);
            return number;
        }
    }
}
