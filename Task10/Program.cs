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
        static void Main(string[] args)
        {
            List<Member> first_polynom = Input("input1.txt");
            List<Member> second_polynom = Input("input2.txt");

            List<Member> result = new List<Member>();

            first_polynom.Sort(new SortByPow());
            second_polynom.Sort(new SortByPow());

            foreach (Member m in first_polynom)
                MultiplyForOne(second_polynom, ref result, m);

            result.Sort(new SortByPow());

            Member [] resArr = result.ToArray();
            LinkedList<Member> list = new LinkedList<Member>(resArr);
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list.ElementAt(i).Pow == list.ElementAt(i+1).Pow)
                {
                    list.ElementAt(i).Koef += list.ElementAt(i + 1).Koef;
                    list.Remove(list.ElementAt(i + 1));
                    i--;
                }
            }

            Output(resArr);
        }

        static List<Member> Input(string filename)
        {
            List<Member> inputData = new List<Member>();
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

            f1.Dispose();
            str.Dispose();
            return inputData;
        }

        static void Output(Member[] arr)
        {
            FileStream f = new FileStream("output.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            foreach (Member m in arr)
                sw.WriteLine(m);
            sw.Dispose();
            f.Dispose();
        }

        static void MultiplyForOne(List<Member> list, ref List<Member> result, Member m)
        {
            foreach (Member n in list)
                result.Add(new Member(n.Koef * m.Koef, m.Pow + n.Pow));
        }
    }

    class Member : IComparable
    {
        public int Koef { get; set; }
        public int Pow { get; set; }
        public Member(int k, int p)
        {
            Koef = k;
            Pow = p;
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

    class SortByPow : IComparer<Member>
    {
        public int Compare(Member x, Member y)
        {
            if (x.Pow > y.Pow) return 1;
            if (x.Pow < y.Pow) return -1;
            return 0;
        }
    }
}
