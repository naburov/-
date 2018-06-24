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
            Console.WriteLine("Программа предназначена для шифрования/дешифрования сообщений, через перестановку символов\n");

            InputReplace(out int k, out int [] replaceArr);

            string begString, resultString = null; 
            begString = InputString();

            if (begString.Length % k != 0)
                do
                {
                    begString += " ";
                } while (begString.Length % k != 0);

            Console.WriteLine("1 - Зашифровать строку");
            Console.WriteLine("2 - Дешифровать строку");
            int comand = InputComand();

            switch (comand)
            {
                case 1:
                    resultString = EncryptString(k, replaceArr, begString);
                    break;
                case 2:
                    resultString = DecryptString(k, replaceArr, begString);
                    break;
            }

            Console.WriteLine("Результат: {0}", resultString);
            Console.WriteLine("Намите любую клавишу для продолжения");
            Console.ReadKey();
        }

        //Зашифровать строку
        private static string EncryptString(int k, int[] replaceArr, string begString)
        {
            string resultString = "";
            for (int i = 0; i < begString.Length; i += k)
            {
                string block = begString.Substring(i, k);
                for (int j = 0; j < k; j++)
                    resultString += block[replaceArr[j] - 1];
            }
            return resultString;
        }

        //Дешифровать строку
        private static string DecryptString(int k, int[] replaceArr, string begString)
        {
            char[] result = new char[begString.Length];
            for (int i = 0; i < begString.Length; i += k)
            {
                string block = begString.Substring(i, k);
                for (int j = 0; j < block.Length; j++)
                    result[i + replaceArr[j] - 1] = block[j];
            }
            return result.ToString();
        }

        private static string InputString()
        {
            string begString;
            Console.WriteLine("Введите шифруемую/дешифруемую строку строку");
            do
            {
                begString = Console.ReadLine();
                if (begString.Length == 0) Console.WriteLine("Начальная строка не может быть пустой, повторите ввод");
            } while (begString.Length == 0);
            return begString;
        }

        private static void InputReplace(out int k, out int[] replaceArr)
        {
            Console.WriteLine("Введите число k");
            k = InputNumber();
            replaceArr = new int[k];
            Console.WriteLine("Введите числа перестановки по одному");
            for (int i = 0; i < k; i++)
                do
                {
                    bool ok = true;
                    int f = 0;
                    do
                    {
                        replaceArr[i] = InputNumber();
                        if (replaceArr[i] > k) Console.WriteLine("Число перестановок должно находиться в пределах от 1 до {0}", k);

                        //Проверка на повторяющиеся цифры в перестановочном массиве
                        ok = false;
                        for (f = 0; f<k;f++)
                            if (replaceArr[f] == replaceArr[i] && i!=f)
                            {
                                Console.WriteLine("Числа перестановки не должны повторяться, повторите ввод");
                                ok = true;
                            }
                    } while (ok);
                } while (replaceArr[i] > k);
            Console.Write("Перестановочный массив: ");

            foreach (int a in replaceArr)
                Console.Write(a + " ");
            Console.WriteLine();
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
                    Console.WriteLine("Должно быть введено целое число, повторите ввод");
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
