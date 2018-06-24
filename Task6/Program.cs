using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа выводит все вектора булвых функций, которые не являются самодвойственными");
            for (int i = 0; i < 256; i++)
            {
                char [] vector = new char[8];             //Вектор булевой функции
                string doubleI = Convert.ToString(i, 2);  //Перевод в двоичную запись 
                int nullNumber = 8 - doubleI.Length;      //Количество нулей, которое нужно добавить в начало

                for (int j = 0; j < nullNumber; j++)      //Добавление нулей
                    vector[j] = '0';

                int index = 0;                           
                for (int j = nullNumber; j < 8; j++)      //Заполнение оставшейся части вектора
                    vector[j] = doubleI[index++];


                bool ok = false;
                for (int j = 0; j < 4 && !ok; j++)
                {
                    if (vector[j] == vector[7 - j])      //Проверка на самодвойственность
                    {
                        ok = true;
                        Console.WriteLine(vector);
                    }
                }                
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();

        }
    }
}
