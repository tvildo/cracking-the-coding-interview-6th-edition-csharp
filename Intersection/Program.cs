using LinkedListShared;
using System;
using System.Linq;

namespace Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            var intersection = new MyLinkedList<int>(new[] { 222, 1, 6 });
            var a = new MyLinkedList<int>(new[] { 5, 9, 2, 2, 3, 4 }).Concat(intersection);
            var b = new MyLinkedList<int>(new[] { 7, 1, 6 }).Concat(intersection);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(algo.GetIntersectionNode(a, b));
        }
    }

    class Algorithm
    {
        public MyLinkedListNode<int> GetIntersectionNode(MyLinkedList<int> list1, MyLinkedList<int> list2)
        {
            if (list1 == null)
                throw new ArgumentNullException(nameof(list1));
            if (list2 == null)
                throw new ArgumentNullException(nameof(list2));

            var headA = list1.Head;
            var headB = list2.Head;

            var lenTailA = LengthAndTail(headA);
            var lenTailB = LengthAndTail(headB);

            if (lenTailA.tail != lenTailB.tail)
                return null;

            if (lenTailA.len > lenTailB.len)
            {
                Advance(ref headA, lenTailA.len - lenTailB.len);
            }
            else
            {
                Advance(ref headB, lenTailB.len - lenTailA.len);
            }

            while (headA != null)
            {
                if (headA == headB)
                    return headA;

                headA = headA.Next;
                headB = headB.Next;
            }

            return null; //maby ?
        }

        private void Advance(ref MyLinkedListNode<int> headA, int v)
        {
            for (int i = 0; i < v; i++)
            {
                headA = headA.Next;
            }
        }


        private (int len, MyLinkedListNode<int> tail) LengthAndTail(MyLinkedListNode<int> list)
        {
            var current = list;
            MyLinkedListNode<int> tail = list;
            var size = 0;
            while (current != null)
            {
                size++;
                tail = current;
                current = current.Next;
            }

            return (size, tail);
        }
    }
}
