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
        public Point Last { get; set; }
        public int Count { get; set; }

        public CycleList(int N)
        {
            Count = N;
            Beg = new Point(0, null);
            Point pointer = Beg;

            for (int i = 1; i < N; i++)
            {
                Point p = new Point(i, null);
                pointer.Next = p;
                p.Prev = pointer;
                pointer = p;

                if (i == N - 1)
                {
                    pointer.Next = Beg;
                    Beg.Prev = pointer;
                    Last = pointer;
                }
            }
        }


        public Point this[int i]
        {
            get
            {
                if (i > Count) throw new IndexOutOfRangeException();
                Point p = Beg;
                for (int k = 0; k < i && k < Count; k++)
                {
                    p = p.Next;
                }

                return p;
            }
            set
            {
                if (i > Count) throw new IndexOutOfRangeException();
                Point p = Beg;
                for (int k = 0; k < i; k++)
                {
                    p = p.Next;
                }

                p = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            Point pointer = Beg;
            for (int i = 0; i < Count; i++)
            {
                yield return pointer.Value;
                pointer = pointer.Next;
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
            } while (p != Beg);
            return str;
        }

        public void Add(object value)
        {
            Point New = new Point(Count);
            Count++;
            New.Prev = Last;
            New.Next = Beg;

            Beg.Prev = New;
            Last.Next = New;

            Last = New;
        }


        public void Clear()
        {
            Beg = new Point(0);
        }

        public void Remove(object value)
        {
            bool ok = false; int i = 0;
            do
            {
                i++;
                if (i > Count - 1) ok = true;
            } while (!this[i].Value.Equals(value) && !ok);

            if (!ok)
            {
                this[i].Next.Prev = this[i].Prev;
                this[i].Prev.Next = this[i].Next;
            }
            else Console.WriteLine("Удаляемого объекта нет в коллекции");
        }

    }

    class Point
    {
        public int Value { get; set; }
        public Point Next { get; set; }
        public Point Prev { get; set; }

        public Point(int value, Point next = null, Point prev = null)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }

}
