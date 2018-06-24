using System;
using System.Collections;
using System.Collections.Generic;

namespace Task10
{
    class MyArrayList : IEnumerable
    {
        Point Beg { get; set; }
        int count;

        public int Count => count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Member item)
        {
            Point p = Beg;
            if (p.obj == null)
            {
                p.obj = item;
                count++;
                return;
            }
            if (p.next != null)
                do
                {
                    p = p.next;
                } while (p.next != null);

            Point newP = new Point(o: item);
            p.next = newP;
            count++;
        }

        public Member[] Values => ToArray();

        public void Clear()
        {
            for (int i = 0; i < count; i++)
                this[i] = null;
        }

        public Member this[int i]
        {
            get
            {
                if (i == 0) return Beg.obj;
                int k = 0;
                Point pointer = Beg;
                do
                {
                    pointer = pointer.next;
                    k++;
                } while (k != i);
                return pointer.obj;
            }
            set
            {
                int k = 0;
                if (i == 0) { Beg.obj = value; return; }
                Point p = Beg;
                do
                {
                    p = p.next;
                } while (++k != i);
                p.obj = value;
            }
        }

        public bool Contains(Member item)
        {
            foreach (Member m in this)
                if (m == item) return true;
            return false;
        }


        public IEnumerator<Member> GetEnumerator()
        {
            Point pointer = Beg;
            for (int i = 0; i < Count; i++)
            {
                yield return pointer.obj;
                if (i == Count - 1) break;
                pointer = pointer?.next;
            }
        }

        public bool Remove(Member item)
        {
            Point p = Beg;
            if (Beg.obj.Equals(item))
            {
                Beg = p.next;
                count--;
                return true;
            }
            do
            {
                p = p.next;
            } while (p.next.next!=null && !p.next.obj.Equals(item));
            if (p.next.obj.Equals(item))
            {
                count--;
                p.next = p.next.next;
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }

        public MyArrayList(int cap)
        {
            Beg = new Point();
            Point p = Beg;
            for (int i = 0; i < cap; i++)
            {
                Point newP = new Point();
                p.next = newP;
                p = p.next;
            }
        }

        public Member[] ToArray()
        {
            Member[] arr = new Member[count];
            int k = 0;
            Point p = Beg;
            while (p != null)
            {
                arr[k++] = p.obj;
                p = p.next;
            }
            return arr;
        }
        public void Sort(IComparer comparer)
        {
            Member[] arr = ToArray();
            Array.Sort(arr, comparer);
            MyArrayList list = new MyArrayList(arr);
            Beg = list.Beg;
        }

        public MyArrayList()
        {
            Beg = new Point();
        }

        public MyArrayList(Member[] arr)
        {
            Beg = new Point();
            foreach (Member m in arr)
                Add(m);
        }
    }

    class Point
    {
        public Member obj { get; set; }
        public Point next { get; set; }

        public Point(Point next = null, Member o = null)
        {
            obj = o;
            this.next = next;
        }
    }
}
