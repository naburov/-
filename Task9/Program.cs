using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 9, 4, 6, 3, 2, 7, 2, 24, 6, 48, 443, 2334 };
            arr = MergeSort(arr);

            Console.ReadKey();

        }


        public static void InsertionSort(ref int[] arr, out int count)
        {
            count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int x = arr[i];
                int j = i;
                while (j > 0 && x < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    count++;
                    j--;
                }
                arr[j] = x;
            }
        }

        public static int[] MergeSort(int[] arr)
        {
            int[] merged = new int[arr.Length];

            if (arr.Length == 1) return arr;
            int middle = arr.Length / 2;

            int[] arr1 = new int[middle];
            int[] arr2 = new int[arr.Length - middle];
            Array.Copy(arr, 0, arr1, 0, arr1.Length);
            Array.Copy(arr, middle, arr2, 0, arr2.Length);

            arr1 = MergeSort(arr1);
            arr2 = MergeSort(arr2);

            int a = 0, b = 0; 
            for (int i = 0; i<merged.Length; i++)
            {
                if (a < arr1.Length && b < arr2.Length)
                    if (arr1[a] < arr2[b])
                        merged[i] = arr1[a++];
                    else merged[i] = arr2[b++];
                else
                    if (b < arr2.Length) merged[i] = arr2[b++];
                else merged[i] = arr1[a++];
            }
            return merged;
        }
    }
}
