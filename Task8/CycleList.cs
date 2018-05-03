using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task8
{
    class CycleList
    {
        public Point Beg { get; set; }
        int Legnth { get; }

        public CycleList(int N)
        {
            Legnth = N;
            Point Beg = new Point(0, null);
            Point pointer = Beg;

            for (int i = 1; i < N; i++)
            {
                Point p = new Point(i, null);
                pointer.Next = p;
                pointer = p;

                if (i == N - 1) { pointer.Next = Beg;}
            }            
        }

        public override string ToString()
        {
            string str = "";
            Point p = Beg.Next;
            str += String.Format("{0} ", Beg.Value);
            do
            {               
                str += String.Format("{0} ", p.Value);
                p = p.Next;
            } while(p!=Beg);
            return str;
        }


    }

    class Point
    {
        public int Value { get; set; }
        public Point Next { get; set; }

        public Point(int value, Point next)
        {
            Value = value;
            Next = next;
        }
    }

}
