﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
    class Program
    {
        //Шифрование строк
        static void Main(string[] args)
        {
            int k;
            int[] replaceArr;
            InputReplace(out k, out replaceArr);

            string begString, resultString = "";
            begString = InputStringForWork();

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
                    resultString = EncryptString(k, replaceArr, begString, resultString);
                    break;
                case 2:
                    resultString = DecryptString(k, replaceArr, begString, resultString);
                    break;
            }

            Console.WriteLine("Результат: {0}", resultString);
            Console.ReadKey();
        }

        private static string EncryptString(int k, int[] replaceArr, string begString, string resultString)
        {
            for (int i = 0; i < begString.Length; i += k)
            {
                string repBegString = begString.Substring(i, k);
                string repString = "";
                for (int j = 0; j < replaceArr.Length; j++)
                    repString += repBegString[replaceArr[j] - 1];
                resultString += repString;
            }

            return resultString;
        }

        private static string DecryptString(int k, int[] replaceArr, string begString, string resultString)
        {
            for (int i = 0; i < begString.Length; i += k)
            {
                string repBegString = begString.Substring(i, k);
                char[] repArr = new char[k];
                for (int j = 0; j < repBegString.Length; j++)
                    repArr[replaceArr[j] - 1] = repBegString[j];
                resultString += repArr.ToString();
            }

            return resultString;
        }

        private static string InputStringForWork()
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
                replaceArr[i] = InputNumber();
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
