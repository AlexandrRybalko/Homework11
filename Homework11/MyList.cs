using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework11
{
    public class MyList<T> : IEnumerable<T>
    {
        public delegate bool del(T value);
        public delegate void MyListHandler(T value);
        public event MyListHandler Notify;

        private Node Head { get; set; }

        public void Filter(del f)
        {
            foreach(T node in this)
            {
                if (!f(node))
                {
                    Remove(node);
                }
            }
        }
        
        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                GetLastNode().Next = new Node(value);
            }
        }

        private Node GetLastNode()
        {
            if (Head != null)
            {
                return this[Count() - 1];
            }

            throw new NullReferenceException();
        }

        public int Count()
        {
            int result = 0;
            if (Head != null)
            {
                result = 1;
                Node current = Head;
                while (current.Next != null)
                {
                    result++;
                    current = current.Next;
                }
            }

            return result;
        }

        public void Except(IEnumerable collection)
        {
            for (int i = 0; i < Count(); i++)
            {
                foreach (var element in collection)
                {
                    if (element.Equals(this[i].Value))
                    {
                        RemoveAll(this[i]);
                    }
                }
            }
        }

        public void RemoveNode(Node node)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (this[i].Value.Equals(node.Value))
                {
                    if (Count() == 1)
                    {
                        Head = null;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Head = Head.Next;
                        }
                        else if (i == Count() - 1)
                        {
                            this[i - 1].Next = null;
                        }
                        else
                        {
                            this[i - 1].Next = this[i + 1];
                        }
                    }
                    break;
                }
            }
            Notify?.Invoke(node.Value);
        }

        public void RemoveAll(Node node)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (this[i].Value.Equals(node.Value))
                {
                    if (Count() == 1)
                    {
                        Head = null;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Head = Head.Next;
                        }
                        else if (i == Count() - 1)
                        {
                            this[i - 1].Next = null;
                        }
                        else
                        {
                            this[i - 1].Next = this[i + 1];
                        }
                    }
                }
            }
            for (int i = 0; i < Count(); i++)
            {
                if (this[i].Value.Equals(node.Value))
                {
                    if (Count() == 1)
                    {
                        Head = null;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Head = Head.Next;
                        }
                        else if (i == Count() - 1)
                        {
                            this[i - 1].Next = null;
                        }
                        else
                        {
                            this[i - 1].Next = this[i + 1];
                        }
                    }
                }
            }
        }

        public void Remove(T value)
        {
            RemoveNode(new Node(value));
        }

        public Node this[int i]
        {
            get
            {
                if (i >= Count())
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int currentIndex = 0;
                    Node Current = Head;
                    while (currentIndex != i)
                    {
                        currentIndex++;
                        Current = Current.Next;
                    }

                    return Current;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }

        }
    }
}
