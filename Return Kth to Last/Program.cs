using LinkedListShared;
using System;
using System.Collections.Generic;

namespace Return_Kth_to_Last
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();

            var test1 = new MyLinkedList<int>(new[] { 1, 2, 3, 4, 5, 6 });
            Console.WriteLine(test1);
            var kthLast = 3;
            Console.WriteLine($"Return {kthLast} element from last");
            var answer = algo.KthElementFromEnd(test1, kthLast);
            Console.WriteLine($"Answer: {answer}");
        }
    }

    class Algorithm
    {
        public int KthElementFromEnd(MyLinkedList<int> input, int k)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var runner1 = input.Head;
            var runner2 = input.Head;

            for (int i = 0; i < k; i++)
            {
                if (runner1 == null)
                    throw new IndexOutOfRangeException(nameof(k));
                runner1 = runner1.Next;
            }

            while (runner1 != null)
            {
                runner1 = runner1.Next;
                runner2 = runner2.Next;
            }

            return runner2.Value;
        }
    }
}
