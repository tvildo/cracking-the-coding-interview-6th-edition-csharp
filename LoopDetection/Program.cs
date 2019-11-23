using LinkedListShared;
using System;

namespace LoopDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            var test = new MyLinkedList<char>(new[] { 'A', 'B', 'C', 'D', 'E' });
            Console.WriteLine(test);

            Console.WriteLine(algo.PrintAnswer(algo.HasCycle(test)));


            //Make it looped
            var loopNode = test.NodeAt(2);
            Console.WriteLine($"\nNow make it loop at {loopNode}");
            test.AddLast(loopNode);
            Console.WriteLine(test);

            Console.WriteLine(algo.PrintAnswer(algo.HasCycle(test)));
        }
    }
    class Algorithm
    {
        public string PrintAnswer<T>(MyLinkedListNode<T> node)
        {
            if (node == null)
                return "Answer: list has no loops";
            else
                return $"Answer: list has loop at node {node}";
        }
        public MyLinkedListNode<T> HasCycle<T>(MyLinkedList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            //Floyd's Tortoise and Hare
            MyLinkedListNode<T> a = list.Head, b = list.Head;
            while (true)
            {
                a = a?.Next;
                b = b?.Next?.Next;

                //if end is reached by fast runner there is no loop
                if (b == null)
                    return null;

                if (a == b)
                    break;
            }

            //find where loop starts
            a = list.Head;
            while (true)
            {
                if (a == b)
                    return a;

                a = a.Next;
                b = b.Next;
            }
        }
    }
}
