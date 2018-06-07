using System;
using System.Collections;
using System.Collections.Generic;

namespace Task10
{
    class MyArrayList : ICollection<Member>
    {
        Point Beg { get; set; }
        int count, capacity;

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

        public void CopyTo(Member[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
            if (Contains(item))
            {
                bool ok = false;
                for (int i = 0; i < count && !ok; i++)
                    if (this[i] == item)
                    {
                        this[i] = null;
                        for (int k = i + 1; k < count; k++)
                            this[k - 1] = this[k];
                        DisposeLast();
                        ok = true;
                    }
                count--;
                return true;
            }
            else return false;
        }

        private void DisposeLast()
        {
            Point p = Beg;
            for (int i = 0; i < count - 1; i++)
                p = p.next;
            p.next = null;
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
            foreach (Member m in this)
                arr[k++] = m;
            return arr;
        }
        public void Sort()
        {
            Member[] arr = ToArray();
            Array.Sort(arr, new SortByPow());
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
