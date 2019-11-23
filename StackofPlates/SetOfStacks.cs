using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackofPlates
{
    /*
     * Stack of Plates: Imagine a (literal) stack of plates. 
     * If  the stack gets too high, it might topple. Therefore, 
     * in real life, we would likely start a new stack when the previous stack exceeds some threshold. 
     * Implement a data structure SetOfStacks that mimics this. 
     * SetO-fStacks should be composed of several stacks and 
     * should create a new stack once the previous one exceeds capacity. 
     * SetOfStacks. push() and SetOfStacks. pop() should behave identically to a 
     * single stack (that is, pop () should return the same values as it would if there were just a single stack). 
     * FOLLOW UP Implement a function popAt ( int  index) which performs a pop operation on a specific sub-stack. 
     */
    class SetOfStacks<T>
    {
        List<Stack<T>> StackList = new List<Stack<T>>();
        int MaxCapacity;

        public SetOfStacks(int maxCapacity)
        {
            this.MaxCapacity = maxCapacity;
        }

        public void Push(T item)
        {
            if (StackList.Count == 0)
                StackList.Add(new Stack<T>());

            var lastStack = StackList[LastIndex];
            if (lastStack.Count == MaxCapacity)
            {
                lastStack = new Stack<T>();
                StackList.Add(lastStack);
            }

            lastStack.Push(item);
        }

        public T Peek()
        {
            if (StackList.Count == 0)
                throw new ArgumentException("Can's peek empty stack");

            return StackList[LastIndex].Peek();
        }

        public T Pop()
        {
            if (StackList.Count == 0)
                throw new ArgumentException("Can's pop empty stack");

            var lastStack = StackList[LastIndex];
            var result = lastStack.Pop();
            if (lastStack.Count == 0)
                StackList.RemoveAt(LastIndex);

            return result;
        }

        public T PopAt(int index)
        {
            if (index >= StackList.Count)
                throw new IndexOutOfRangeException();

            return ShiftLeft(index, true);
        }

        private T ShiftLeft(int index, bool removeTop)
        {
            if (index > LastIndex)
                return default(T);

            var stackAtIndex = StackList[index];
            T removedItem;
            if (removeTop)
                removedItem = stackAtIndex.Pop();
            else
                removedItem = RemoveStackBottom(stackAtIndex);

            if (stackAtIndex.Count == 0)
                StackList.RemoveAt(index);
            else if (index + 1 == LastIndex)
                stackAtIndex.Push(ShiftLeft(index + 1, false));

            return removedItem;
        }

        private T RemoveStackBottom(Stack<T> item)
        {
            var tmp = new Stack<T>(item);
            var result = tmp.Pop();
            item.Clear();

            while (tmp.Count > 0)
                item.Push(tmp.Pop());

            return result;
        }

        private int LastIndex => StackList.Count - 1;

        public string PrintStackList()
        {
            var sb = new StringBuilder("Stack = ");
            foreach (var stack in StackList)
            {
                sb.Append($"[{string.Join(",", stack.Reverse())}]");
            }

            return sb.ToString();
        }
    }
}
