using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {

        //Not works
        //Двудольные графы
        static void Main(string[] args)
        {
            //int[,] incMatr = CreateMatrix();
            int[,] incMatr = { { 1, 1, 0, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 0 },
                { 0, 1, 1, 0, 0, 1 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 1, 1 } };
            Graph gr = new Graph(incMatr);

            bool ok = true;

            gr[0] = 0;

            for (int i = 1; i<gr.VertexCount && ok; i++)
            {
                int[] connectedVertexes = FindConnectedVertexes(gr, i);
                int color = CheckColor(connectedVertexes);
                if (color != 2) gr[i] = color;
                else ok = false;
            }

            if (ok) Console.WriteLine("Граф двудольный");
            else Console.WriteLine("Граф не двудольный");

            Console.ReadKey();
        }

        public static int [] FindConnectedVertexes(Graph gr, int vNum)
        {
            int[,] arr = gr.incMatr;
            List<int> vertexes = new List<int>();

            for (int i = 0; i<arr.GetLength(1); i++)                      //For every edge of graph
            {
                if (arr[vNum,i] == 1)                                     //if the edge was found 
                    for (int j = 0; j < gr.VertexCount; j++)              //For every vertex
                        if (arr[j, i] == 1 && j != vNum) vertexes.Add(j); //find connected vertex and add to collection
            }
            return vertexes.ToArray();
        }

        public static int CheckColor(int [] arr)
        {
            bool ok1 = false; bool ok2 = false;
            int color = 0;
            for (int i = 0; i<arr.Length; i++)
            {
                if (arr[i] == 0) ok1 = true;
                if (arr[i] == 1) ok2 = true;
            }
            
            if (!ok1 && ok2) color = 1;
            if (ok1 && ok2) color = 2;
            return color;
                
        }

        public static int [,] CreateMatrix()
        {
            Console.WriteLine("Введите количество строк матрицы");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов матрицы");
            int columns = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[rows,columns];

            for (int i = 0; i<rows; i++) 
                for (int j = 0; j<columns; j++)
                {
                    Console.WriteLine("Введите элемент матрицы с номером {0}, {1}", i, j);
                    matrix[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            return matrix;
        }

    }

    class Graph
    {
        public int[,] incMatr { get; set; } 
        int[] vertexColors;
        public int VertexCount => vertexColors.Length;
        public int this[int i] { get => vertexColors[i]; set => vertexColors[i] = value; }

        public Graph(int [,] arr)
        {
            incMatr = arr;
            vertexColors = new int[incMatr.GetLength(0)];
            for (int i = 0; i < VertexCount; i++)
                this[i] = 2;                               //Every vertex hasn't god color yet
        }

    }
}
