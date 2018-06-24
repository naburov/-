using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static Random rnd = new Random();
        static int[,] graph;
        static int[] colors;
        static bool conflict;

        //Not works
        //Двудольные графы
        static void Main(string[] args)
        {
            graph = GenerateMatrix();
            //Двудольные графы
            //graph = new int[,] { { 1, 1, 0, 0, 0, 0 }, { 0, 0, 1, 1, 0, 0 }, { 0, 0, 0, 0, 1, 1 }, { 1, 0, 1, 0, 0, 1 }, { 0, 1, 0, 1, 1, 0 } };
            //graph = new int[,] { { 1, 1, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 1, 1 }, { 1, 0, 0, 0, 1 }, { 0, 1, 0, 1, 0 }, { 0, 0, 1, 0, 0 } };


            //Недвудольные графы
            //graph = new int[,] { { 1, 0, 1 }, { 1, 1, 0 }, { 0, 1, 1 } };
            //graph = new int[,] { { 1, 0, 0, 1, 1, 0 }, { 1, 1, 0, 0, 0, 1 }, { 0, 1, 1, 0, 1, 0 }, { 0, 0, 1, 1, 0, 1 } };
            //graph = new int[,] { { 1, 0, 1, 0, 0, 1, 0, 0, 0 }, { 1, 1, 0, 1, 0, 0, 0, 0, 0 }, { 0, 1, 1, 0, 1, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 1, 0, 1, 1 }, { 0, 0, 0, 1, 0, 0, 1, 0, 1 }, { 0, 0, 0, 0, 1, 0, 1, 1, 0 } };


            colors = new int[graph.GetLength(0)];
            colors.Initialize();
            PrintMatr();

            bool conflict = false;
            for (int i = 0; i < graph.GetLength(0); i++)
                if (colors[i] == 0)
                {
                    colors[i] = 1;
                    DFS(i, ref conflict);
                }

            /*
            for (int i = 0; i < graph.GetLength(1) && !conflict; i++)
            {
                int index1 = -1, index2 = -1;

                for (int k = 0; k < graph.GetLength(0); k++)
                    if (index1 < 0 && index2 < 0 && graph[k, i] == 1) index1 = k;
                    else if (index1 >= 0 && graph[k, i] == 1) index2 = k;

                if (colors[index1] == colors[index2]) conflict = true;
            }
            */
            if (!conflict) Console.WriteLine("Граф двудольный");
            else Console.WriteLine("Граф не двудольный");

            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();

        }

        public static void DFS(int ver, ref bool conflict)                    //Начальная вершина
        {
            if (conflict) return;
            int color = colors[ver];
            for (int i = 0; i < colors.Length && !conflict; ++i)
                if (EdgeExist(ver, i))
                    if (colors[i] == 0)
                    {
                        colors[i] = 3 - color;
                        DFS(i, ref conflict);
                    }
                    else if (colors[ver] == colors[i]) conflict = true;
        }

        static int[,] GenerateMatrix()
        {
            int x = rnd.Next(2, 11);
            int y = rnd.Next(1, 11);

            int[,] matr = new int[x, y];
            matr.Initialize();

            for (int i = 0; i < y; i++)
            {
                int index1 = rnd.Next(0, x);
                int index2;
                do
                {
                    index2 = rnd.Next(0, x);
                } while (index2 == index1);

                matr[index1, i] = 1;
                matr[index2, i] = 1;
            }

            return matr;

        }

        static void PrintMatr()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
                for (int j = 0; j < graph.GetLength(1); j++)
                    if (j == graph.GetLength(1) - 1) Console.WriteLine(graph[i, j]);
                    else Console.Write(graph[i, j] + " ");

        }
        static bool EdgeExist(int ver1, int ver2)
        {
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[ver1, i] == 1 && graph[ver2, i] == 1 && ver1 != ver2) return true;
            }
            return false;
        }
    }
}
