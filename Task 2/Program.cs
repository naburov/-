using System;
using System.IO;

/*
* Общая идея задачи: после подсчета суммы для каждого члена матрицы
* её запоминают в отдельный массив, после чего при подсчёте последующих сумм
* считают только сумму последнего столбца и прибавляют уже посчитанное на 
* предыдущих шагах
*/

class Program
{

    static void Main()
    {

        StreamReader sr = new StreamReader("input.txt");
        string[] str = sr.ReadLine().Split(' ');

        int N = int.Parse(str[0]);     //Ввод количества спортсменов
        int M = int.Parse(str[1]);     //Ввод количества упражнений
        int P = int.Parse(str[2]);     //Сколько всего выходов

        int[,] arr = new int[N, M];    //Массив для хранения выходов каждого спортсмена
        int[,] sumArr = new int[N, M]; //Массив для хранения сумм
        sumArr.Initialize();
        int count = 0;                 //Количество удивлений

        //Заполнение матрицы выходов
        for (int i = 0; i < P; i++)
        {
            str = sr.ReadLine().Split(' ');
            arr[int.Parse(str[0]) - 1, int.Parse(str[1]) - 1] = 1;
        }

        //Подчсет удивлений
        for (int i = 0; i < N - 1; i++)
            for (int j = 1; j < M; j++)
            {
                int columnSum = 0;                
                for (int k = i + 1; k < N; k++)   //Цикл для вычисления суммы в столбце
                    columnSum += arr[k, j-1];
                if (j - 1 > 0)                    //Проверка на то, в первом ли столбце вычисляют сумму
                    sumArr[i, j] = sumArr[i, j - 1] + columnSum;
                else sumArr[i, j] = columnSum;
                if (arr[i, j] != 0)               //Если был выход спортсмена i, выполняющего упражнение j,
                    count += sumArr[i, j];        //то пколичество удивлений увеличивается на sumArr[i,j]
            }

        //Вывод
        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(count);

        sw.Close();
        sr.Close();
    }
}

