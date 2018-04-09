using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
{
    //Suprised judges
    class Appearense : IComparable
    {
        int sportsmen { get; set; }
        int exercise { get; set; }
        public int CompareTo(object obj)
        {
            Appearense ap = (Appearense)obj;
            if (ap.exercise > exercise) return 1;
            if (ap.exercise == exercise) return 0;
            else return -1;
        }

        public Appearense(int sp, int ex)
        {
            this.exercise = ex;
            this.sportsmen = sp;
        }

        public override string ToString()
        {
            return String.Format("Спортсмен: {0}  Упражнение: {1}", sportsmen, exercise);
        }

        public static bool operator >(Appearense a1, Appearense a2)
        {
            if (a1.sportsmen > a2.sportsmen) return true;
            else return false;
        }
        public static bool operator <(Appearense a1, Appearense a2)
        {
            if (a1.sportsmen < a2.sportsmen) return true;
            else return false;
        }
    }

    public class SortByExersise : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Appearense obj1 = (Appearense)a;
            Appearense obj2 = (Appearense)b;
            return (obj1.CompareTo(obj2));
        }
    }


    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");

            string[] s = sr.ReadLine().Split();
            
            

            int count = 0;
            Appearense[] arr ={
                new Appearense(3,2),
                new Appearense(1,3),
                new Appearense(3,1),
                new Appearense(1,2)};
            

            Console.WriteLine();

            Array.Sort(arr);
            for(int i = 0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] < arr[j]) count++;

            Console.WriteLine(count);
            Console.ReadKey();


        }
    }
}
