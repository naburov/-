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

        int N = int.Parse(str[0]);   //How many sportsmen
        int M = int.Parse(str[1]);   //How many exercises
        int P = int.Parse(str[2]);   //How many tries

        int[,] arr = new int[N, M];
        int[,] sumArr = new int[N, M];
        sumArr.Initialize();
        int count = 0;
        for (int i = 0; i < P; i++)
        {
            str = sr.ReadLine().Split(' ');
            arr[int.Parse(str[0]) - 1, int.Parse(str[1]) - 1] = 1;
        }

        for (int i = 0; i < N - 1; i++)
            for (int j = 1; j < M; j++)
            {
                int columnSum = 0;
                for (int k = i + 1; k < N; k++)
                    columnSum += arr[k, j-1];
                if (j - 1 > 0)
                    sumArr[i, j] = sumArr[i, j - 1] + columnSum;
                else sumArr[i, j] = columnSum;
                if (arr[i, j] != 0)
                    count += sumArr[i, j];
            }


        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(count);

        sw.Close();
        sr.Close();
    }
}




