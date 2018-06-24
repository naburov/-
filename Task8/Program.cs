using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static int Menu()
        {
            Console.WriteLine("Введите номер команды:");
            Console.WriteLine("1 - Добавить элемент в список");
            Console.WriteLine("2 - Удалить элемент из списка по значению");
            Console.WriteLine("3 - Вывести список");
            Console.WriteLine("4 - Выход");
            int comand;
            do
            {
                comand = InputNumber();
                if (comand < 1 && comand > 4) Console.WriteLine("Номер команды введен неверно, повторите ввод");
            } while (comand < 1 && comand > 4);

            return comand;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов циклческого списка: ");
            int capacity = InputNumber();
            CycleList list = new CycleList(capacity);
            bool exit = false;
            do
            {
                int choice = Menu();
                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Введите значение элемента, который нужно добавить (целое число)");
                        int value = InputNumber();
                        list.Add(value);
                        break;
                    case 2:
                        Console.WriteLine("Введите значение элемента, который нужно удалить (целое число)");
                        value = InputNumber();
                        list.Remove(value);
                        break;
                    case 3:
                        Console.WriteLine(list);
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            } while (!exit);

            Console.WriteLine("Нажимите любую клавишу для продолжения");
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
