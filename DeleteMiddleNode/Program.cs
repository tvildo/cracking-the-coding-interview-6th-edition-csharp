using LinkedListShared;
using System;

namespace DeleteMiddleNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();

            var test1 = new MyLinkedList<int>(new[] { 1, 2, 3, 4, 5, 6 });
            var nodeIndex = 2;
            var middleNode = test1.NodeAt(nodeIndex);
            Console.WriteLine(test1);
            Console.WriteLine($"Delete node {middleNode} at index {nodeIndex}");
            Console.WriteLine(algo.DeleteMiddleNode(test1, middleNode));
        }
    }

    class Algorithm
    {
        //This is solution answer
        public MyLinkedList<int> DeleteMiddleNode(MyLinkedList<int> input, MyLinkedListNode<int> node)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (node.Next == null)
                throw new ArgumentException("This method only can delete middle and not last element");

            node.Value = node.Next.Value;
            node.Next = node.Next.Next;

            return input;
        }
    }
}
