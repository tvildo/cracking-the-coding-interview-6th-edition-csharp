using System;
using System.Collections.Generic;
using System.Linq;

namespace SortStack
{
    /*
     * Sort Stack: Write a program to sort a stack such that the smallest items are on the top.
     * You can use an additional temporary stack, but you may not copy the elements into any other data structure (such as an array). 
     * The stack supports the following operations: push, pop, peek, and is Empty.
     */
    class SortedStack<T> where T : IComparable<T>
    {
        Stack<T> AlwaysSorted = new Stack<T>();

        public SortedStack()
        {

        }

        public SortedStack(Stack<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            while (source.Count > 0)
                AlwaysSorted.Push(source.Pop());
        }

        public void Push(T item)
        {
            if (AlwaysSorted.Count == 0)
            {
                AlwaysSorted.Push(item);
                return;
            }

            var tmp = new Stack<T>();
            while (item.CompareTo(AlwaysSorted.Peek()) > 0)
                tmp.Push(AlwaysSorted.Pop());

            AlwaysSorted.Push(item);
            while (tmp.Count > 0)
                AlwaysSorted.Push(tmp.Pop());
        }

        public T Pop()
        {
            return AlwaysSorted.Pop();
        }

        public T Peek()
        {
            return AlwaysSorted.Peek();
        }

        public bool Empty()
        {
            return AlwaysSorted.Count == 0;
        }

        internal string PrintStackList()
        {
            return $"[{string.Join(",", AlwaysSorted.Reverse())}]";
        }
    }
}
