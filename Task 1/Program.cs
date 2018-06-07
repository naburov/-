using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
public class Program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader("input.txt");
        string[] str = sr.ReadLine().Split(' ');


        int length = int.Parse(str[0]);
        int k = int.Parse(str[1]);
        string seq = sr.ReadLine();
        int count = 0;

        //int length = 11;
        //int k = 2;
        //int count = 0;
        //string seq = "axppxyxpapx";

        List<char> lettres = new List<char>();
        for (int i = 0; i < length; i++)
            if (!lettres.Contains(seq[i])) lettres.Add(seq[i]);

        int letCount = lettres.Count;
        int[,] matrix = new int[letCount, length];

        for (int i = 0; i < letCount; i++)
        {
            count = 0;
            for (int j = 0; j < length; j++)
                if (seq[j] == lettres[i])
                    matrix[i, j] = ++count;
                else matrix[i, j] = count;
        }
        count = length;

        for (int i = 2; i <= k; i++)
            count += length - i + 1;

        for (int i = 0; i < length - k; i++)
        {
            bool ok = true;
            for (int j = i + k; j < length && ok; j++)
            {

                for (int l = 0; l < letCount; l++)
                    if (matrix[l, j] > k) ok = false;
                if (ok) count++;
            }

            for (int l = 0; l < letCount; l++)
                if (matrix[l, i]!=0)
                for (int x = i+1; x < length ; x++)
                {
                    matrix[l,x]--;
                }
        }

        StreamWriter sw = new StreamWriter("output.txt");
        sw.WriteLine(count);
        sw.Dispose();
        sr.Dispose();
    }
}
