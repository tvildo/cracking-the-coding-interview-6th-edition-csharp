using LinkedListShared;
using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new[] {
                new MyLinkedList<int>(new[] { 1, 2, 1 }),
                new MyLinkedList<int>(new[] { 1, 2 })
            };
            var algo = new Algorithm();
            foreach (var t in tests) {
                Console.WriteLine(t);
                Console.WriteLine(algo.IsPalindrome(t));
            }
        }
    }

    class Algorithm
    {
        public bool IsPalindrome(MyLinkedList<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            var head1 = list.Head;
            bool isPalindromeFlag = true;

            void isPalindromeInternal(MyLinkedListNode<int> node)
            {
                //stop at the end
                if (node == null)
                    return;

                isPalindromeInternal(node.Next);

                //starting from last element check if back is equal last
                if (node.Value != head1.Value)
                {
                    isPalindromeFlag = false;
                }

                head1 = head1.Next;
            }

            isPalindromeInternal(list.Head);

            return isPalindromeFlag;
        }
    }
}
