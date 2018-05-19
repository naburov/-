using System;
using System.Diagnostics;
using System.IO;


class Program
{
    static void Main()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        StreamReader sr = new StreamReader("input.txt");
        string[] str = sr.ReadLine().Split(' ');

        int N = int.Parse(str[0]);   //How many sportsmen
        int M = int.Parse(str[1]);   //How many exercises
        int P = int.Parse(str[2]);   //How many tries

        int[,] arr = new int[N, M];

        int count = 0;
        for (int i = 0; i < P; i++)
        {
            str = sr.ReadLine().Split(' ');
            arr[int.Parse(str[0]) - 1, int.Parse(str[1]) - 1] = 1;
        }

        timer.Stop();
        Console.WriteLine(timer.ElapsedTicks);
        timer.Reset();

        timer.Start();
        for (int i = 0; i < N - 1; i++)
            for (int j = 1; j < M; j++)
                if (arr[i, j] != 0)
                {
                    for (int k = i + 1; k < N; k++)
                        for (int k2 = 0; k2 <= j - 1; k2++)
                            count += arr[k, k2];
                }

        timer.Stop();
        Console.WriteLine(timer.ElapsedTicks);
        timer.Reset();

        timer.Start();
        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(count);

        sw.Close();
        sr.Close();
        timer.Stop();

        Console.WriteLine(timer.ElapsedTicks);

        Console.ReadKey();
    }
}




