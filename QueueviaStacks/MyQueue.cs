using System;
using System.Collections.Generic;
using System.Linq;

namespace QueueviaStacks
{
    /*
     * Queue via Stacks: Implement a MyQueue class which implements a queue using two stacks. 
     */
    class MyQueue<T>
    {
        Stack<T> Stack1 = new Stack<T>();
        Stack<T> Stack2 = new Stack<T>();

        public void AddLast(T item)
        {
            Stack1.Push(item);
        }

        public T RemoveFirst()
        {
            if (Stack1.Count == 0)
                throw new InvalidOperationException("Can't remove item from empty queue");
            SwapAndReverse(Stack1, Stack2);
            var result = Stack2.Pop();
            SwapAndReverse(Stack2, Stack1);
            return result;
        }

        public string PrintQueue()
        {
            return $"[{string.Join(",", Stack1.Reverse())}]";
        }

        private void SwapAndReverse(Stack<T> a, Stack<T> b)
        {
            while (a.Count > 0)
                b.Push(a.Pop());
        }
    }
}
