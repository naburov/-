using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        //Произведение полиномов
        static void Main(string[] args)
        {
            MyArrayList first_polynom = Input("input1.txt");
            MyArrayList second_polynom = Input("input2.txt");

            MyArrayList result = new MyArrayList();

            first_polynom.Sort(new SortByPow());
            second_polynom.Sort(new SortByPow());

            foreach (Member m in first_polynom)
                MultiplyForOne(second_polynom, ref result, m);

            result.Sort(new SortByPow());

            for (int i = 0; i < result.Count - 2; i++)
            {
                if (result[i].Pow == result[i + 1].Pow)
                {
                    result[i].Koef += result[i + 1].Koef;
                    result.Remove(result[i + 1]);
                    i--;
                }
            }
            Output(result);
        }

        static MyArrayList Input(string filename)
        {
            MyArrayList inputData = new MyArrayList() ;
            FileStream f1 = new FileStream(filename, FileMode.Open);
            StreamReader str = new StreamReader(f1);
            string s = str.ReadToEnd();
            string[] numbers = s.Split(' ', '\n');
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                if (numbers[2 * i] != "0")
                {
                    Member m = new Member(Convert.ToInt32(numbers[2 * i]), Convert.ToInt32(numbers[2 * i + 1]));
                    inputData.Add(m);
                }
            }

            f1.Close();
            str.Close();
            return inputData;
        }

        static void Output(MyArrayList arr)
        {
            FileStream f = new FileStream("output.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            if (arr.Count == 0) sw.Write("0");
            else foreach (Member m in arr)
                    sw.WriteLine(m);                
            sw.Close();
            f.Close();

           
        }

        static void MultiplyForOne(MyArrayList list, ref MyArrayList result, Member m)
        {
            foreach (Member n in list)
                result.Add(new Member(n.Koef * m.Koef, m.Pow + n.Pow));
        }
    }

    class Member
    {
        public int Koef { get; set; }
        public int Pow { get; set; }
        public Member(int k, int p)
        {
            Koef = k;
            Pow = p;
        }
        
        public override bool Equals(object obj)
        {
            Member m = (Member)obj;
            return (Koef == m.Koef && Pow == m.Pow);
        }
        
        public int CompareTo(object obj)
        {
            Member m = (Member)obj;
            if (Pow > m.Pow) return 1;
            if (Pow < m.Pow) return -1;
            return 0;
        }
        
        public override string ToString()
        {
            return Koef.ToString() + " " + Pow.ToString();
        }
    }

    class SortByPow : IComparer
    {
        public int Compare(object x, object y)
        {
            if ((x as Member).Pow > (y as Member).Pow) return 1;
            if ((x as Member).Pow < (y as Member).Pow) return -1;
            return 0;
        }
    }
}
