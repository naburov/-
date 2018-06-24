using System;
using System.Linq;
using System.IO;

namespace Task9
{
    class Program
    {
        static Random rnd = new Random();
        //Сортировки
        static void Main(string[] args)
        {

            int mergeCountCompare = 0;
            int insertCountCompare = 0;
            int mergeCountReplace = 0;
            int insertCountReplace = 0;
            StreamWriter str = new StreamWriter("output");
            for (int i = 100; i < 1000; i+=100)
            {
                str.WriteLine("Длина {0}:", i);
                int[] arr = new int[i];            //Случайный массив
                for (int j = 0; j < arr.Length; j++)               //Задание случайного массива
                    arr[j] = rnd.Next(0, 100);

                int[] sortedArr = (int[])arr.Clone();
                Array.Sort(sortedArr);                             //Сортировка хаотичного массива
                int[] resortedArr = sortedArr.Reverse().ToArray(); //Массив, упорядоченный в обратном порядке
                Console.WriteLine("Длина массива: {0}", arr.Length);

                Console.WriteLine("Упорядоченный массив: ");
                Show(sortedArr);

                Console.WriteLine("Упорядоченный в обратном порядке массив: ");
                Show(resortedArr);

                Console.WriteLine("Никак не упорядоченный массив:");
                Show(arr);


                int[] a = InsertionSort((int[])sortedArr.Clone(), ref insertCountCompare, ref insertCountReplace);
                Console.WriteLine("Результаты сортировки для упорядоченного массива:");
                Console.WriteLine("Сортировка простыми вставками ");
                Console.WriteLine("Сравнений: {0}, Перестановок: {1}\n", insertCountCompare, insertCountReplace);
                str.WriteLine("Вставки, прямой: {0}, {1}", insertCountCompare, insertCountReplace);

                insertCountCompare = 0; insertCountReplace = 0; 

                a = MergeSort((int[])sortedArr.Clone(), ref mergeCountCompare, ref mergeCountReplace);
                Console.WriteLine("Результаты сортировки для упорядоченного массива:");
                Console.WriteLine("Сортировка слияниями ");
                Console.WriteLine("Сравнений: {0}\n", mergeCountCompare, mergeCountReplace);
                str.WriteLine("Слияния, прямой: {0}, {1}", mergeCountCompare, mergeCountReplace);

                mergeCountCompare = 0; mergeCountReplace = 0; 

                a = InsertionSort((int[])resortedArr.Clone(), ref insertCountCompare, ref insertCountReplace);
                Console.WriteLine("Результаты сортировки для упорядоченного в обратном порядке массива:");
                Console.WriteLine("Сортировка простыми вставками ");
                Console.WriteLine("Сравнений: {0}, Перестановок: {1}\n", insertCountCompare, insertCountReplace);
                str.WriteLine("Вставки, обратный: {0}, {1}", insertCountCompare, insertCountReplace);

                insertCountCompare = 0; insertCountReplace = 0;

                a = MergeSort((int[])resortedArr.Clone(), ref mergeCountCompare, ref mergeCountReplace);
                Console.WriteLine("Результаты сортировки для упорядоченного в обратном порядке массива:");
                Console.WriteLine("Сортировка слияниями ");
                Console.WriteLine("Сравнений: {0}\n", mergeCountCompare, mergeCountReplace);
                str.WriteLine("Слияния, обратный: {0}, {1}", mergeCountCompare, mergeCountReplace);

                mergeCountCompare = 0; mergeCountReplace = 0;

                a = InsertionSort((int[])arr.Clone(), ref insertCountCompare, ref insertCountReplace);
                Console.WriteLine("Результаты сортировки для упорядоченного хаотично массива:");
                Console.WriteLine("Сортировка простыми вставками ");
                Console.WriteLine("Сравнений: {0}, Перестановок: {1}\n", insertCountCompare, insertCountReplace);
                str.WriteLine("Вставки, хаос: {0}, {1}", insertCountCompare, insertCountReplace);

                insertCountCompare = 0; insertCountReplace = 0;

                a = MergeSort((int[])arr.Clone(), ref mergeCountCompare, ref mergeCountReplace);
                Console.WriteLine("Результаты сортировки для упорядоченного хаотично массива:");
                Console.WriteLine("Сортировка слияниями ");
                Console.WriteLine("Сравнений: {0}\n", mergeCountCompare, mergeCountReplace);
                str.WriteLine("Слияния, хаос: {0}, {1}", mergeCountCompare, mergeCountReplace);

                mergeCountCompare = 0; mergeCountReplace = 0;

                str.WriteLine();
            }
            Console.WriteLine("Нажмите любую клавишу для завершения работы программы");
            str.Close();
            Console.ReadKey();
            

        }

        static void Show(int[] arr)
        {
            foreach (int a in arr)
                Console.Write(a + " ");
            Console.WriteLine();
        }


        public static int[] InsertionSort(int[] arr, ref int countCompare, ref int countReplace)
        {
            countCompare = 0;
            countReplace = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int x = arr[i];
                int j = i;
                countCompare++;
                while (j > 0 && x < arr[j - 1])
                {
                    countCompare++;
                    arr[j] = arr[j - 1];
                    countReplace++;
                    j--;
                }
                arr[j] = x;
            }
            return arr;
        }

        public static int[] MergeSort(int[] arr, ref int countCompare, ref int countReplace)
        {
            int[] merged = new int[arr.Length];

            if (arr.Length == 1) return arr;
            int middle = arr.Length / 2;

            int[] arr1 = new int[middle];
            int[] arr2 = new int[arr.Length - middle];
            Array.Copy(arr, 0, arr1, 0, arr1.Length);
            Array.Copy(arr, middle, arr2, 0, arr2.Length);

            arr1 = MergeSort(arr1, ref countCompare, ref countReplace);
            arr2 = MergeSort(arr2, ref countCompare, ref countReplace);

            int a = 0, b = 0;
            for (int i = 0; i < merged.Length; i++)
            {
                if (a < arr1.Length && b < arr2.Length)
                {
                    countCompare++;
                    if (arr1[a] < arr2[b])
                        merged[i] = arr1[a++];
                    else merged[i] = arr2[b++];
                }
                else
                    if (b < arr2.Length) merged[i] = arr2[b++];
                else merged[i] = arr1[a++];
            }
            return merged;
        }
    }
}
