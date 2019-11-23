using LinkedListShared;
using System;

namespace Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new MyLinkedList<int>(new[] { 3, 5, 8, 5, 10, 2, 1 });
            var algo = new Algorithm();
            Console.WriteLine(test1);
            Console.WriteLine(algo.Partition(test1, 5));
        }
    }

    public class Algorithm
    {
        public MyLinkedList<int> Partition(MyLinkedList<int> list, int x)
        {
            if(list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var head = new MyLinkedListNode<int>(list.Head.Value);
            var tail = new MyLinkedListNode<int>(list.Head.Value);
            //Need to remember heads to preserve ordering
            var headFirst = head;
            var tailFirst = tail;

            var node = list.Head;

            while (node != null)
            {
                var next = node.Next;
                node.Next = null;

                if (node.Value < x)
                {
                    head.Next = node;
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }

                node = next;
            }

            head.Next = tailFirst.Next;
            return new MyLinkedList<int>(headFirst.Next);
        }
    }

}
