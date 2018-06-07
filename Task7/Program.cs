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
        static bool[] visited;
        static int[,] graph;
        static int[] colors;
        static bool conflict;

        //Not works
        //Двудольные графы
        static void Main(string[] args)
        {
            graph = GenerateMatrix();
            visited = new bool[graph.GetLength(0)];
            colors = new int[graph.GetLength(0)];
            visited.Initialize();
            colors.Initialize();
            PrintMatr();

            bool conflict = false;
            colors[0] = 1;
            for (int i = 0; i < graph.GetLength(1); i++)
                if (!visited[i]) DFS(i);

            if (!conflict) Console.WriteLine("Граф двудольный");
            else Console.WriteLine("Граф не двудольный");

        }

        public static void DFS (int ver)                    //Начальная вершина
        {
            int color = colors[ver];
            visited[ver] = true;
            for (int i = 0; i < visited.Length; i++)
                if (!visited[i] && edgeExist(ver, i))
                {
                    if (color == colors[i])
                    {
                        conflict = true;
                        return;
                    }
                    else if (color == 1) colors[i] = 0;
                    else colors[i] = 1;
                    DFS(i);
                }
        }

        static int [,] GenerateMatrix()
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
        static bool edgeExist(int ver1, int ver2)
        {
            for (int i = 0; i<graph.GetLength(1); i++)
            {
                if (graph[ver1, i] == 1 && graph[ver2, i] == 1) return true;
            }
            return false;
        }
    }
}
