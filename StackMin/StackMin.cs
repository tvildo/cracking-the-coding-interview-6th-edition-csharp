using System;
using System.Collections.Generic;
using System.Linq;

namespace StackMin
{
    /*
     * Stack Min: How would you design a stack which, in addition to push and pop, 
     * has a function min which returns the minimum element? Push, pop and min should all operate in 0(1) time. 
     */
    class StackMin<T> where T : IComparable<T>
    {
        Stack<T> Stack1 = new Stack<T>();
        Stack<T> MinStack = new Stack<T>();

        public void Push(T item)
        {
            Stack1.Push(item);
            if (MinStack.Count == 0 || MinStack.Peek().CompareTo(item) >= 0)
            {
                MinStack.Push(item);
            }
        }

        public T Pop()
        {
            var top = Stack1.Pop();
            if (MinStack.Count > 0 && MinStack.Peek().CompareTo(top) == 0)
                MinStack.Pop();
            return top;
        }

        public T Min()
        {
            return MinStack.Peek();
        }

        public void PrintStackAndMin()
        {
            Console.WriteLine($"Min = {Min()}\nStack = [{string.Join(",", Stack1.Reverse())}]");
        }
    }
}
