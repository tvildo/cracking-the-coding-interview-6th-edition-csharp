using LinkedListShared;
using System;

namespace SumLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyLinkedList<int>(new[] { 7, 1, 6 });
            var b = new MyLinkedList<int>(new[] { 5, 9, 2 });
            var algo = new Algorithm();
            Console.WriteLine(algo.SumList(a, b));
            Console.WriteLine(algo.SumListForwardWithRecursionUsingTwoRunner(a, b));
        }

        public class Algorithm
        {
            public MyLinkedList<int> SumList(MyLinkedList<int> list1, MyLinkedList<int> list2)
            {
                if (list1 == null)
                    throw new ArgumentNullException(nameof(list1));
                if (list2 == null)
                    throw new ArgumentNullException(nameof(list2));

                var head1 = list1.Head;
                var head2 = list2.Head;
                var reminder = 0;
                MyLinkedList<int> total = null;

                void AddToTotalLinkedList(int value)
                {
                    if (total == null)
                    {
                        total = new MyLinkedList<int>(new MyLinkedListNode<int>(value));
                    }
                    else
                    {
                        var node = new MyLinkedListNode<int>(value);
                        node.Next = total.Head;
                        total.Head = node;
                    }
                }
                
                while (true)
                {
                    int sum;
                    if (head1 == null && head2 == null)
                    {
                        if (reminder > 0)
                            AddToTotalLinkedList(reminder);
                        break;
                    }
                    else if (head1 == null)
                        sum = head2.Value += reminder;
                    else if (head2 == null)
                        sum = head1.Value += reminder;
                    else
                        sum = head1.Value + head2.Value + reminder;

                    if (sum >= 10)
                    {
                        reminder = 1;
                        AddToTotalLinkedList(sum - 10);
                    }
                    else
                    {
                        reminder = 0;
                        AddToTotalLinkedList(sum);
                    }

                    head1 = head1?.Next;
                    head2 = head2?.Next;
                }

                return total;
            }

            public MyLinkedList<int> SumListForwardWithRecursionUsingTwoRunner(MyLinkedList<int> l1, MyLinkedList<int> l2)
            {
                if (l1 == null)
                    throw new ArgumentNullException(nameof(l1));
                if (l2 == null)
                    throw new ArgumentNullException(nameof(l2));

                return new MyLinkedList<int>(SumListForwardWithRecursionUsingTwoRunnerInternal(l1.Head, l2.Head));
            }

            public MyLinkedListNode<int> SumListForwardWithRecursionUsingTwoRunnerInternal(MyLinkedListNode<int> l1, MyLinkedListNode<int> l2)
            {
                MyLinkedListNode<int> p1 = l1;
                MyLinkedListNode<int> p2 = l2;
                MyLinkedListNode<int> p11;
                MyLinkedListNode<int> p12;

                //following algorithm is detecting if numbers are equal in length and if not
                //small one should be aligned to sum them backwards...
                while (true)
                {
                    if (p1 == null && p2 == null)
                    {
                        var result = CalculateNormal(l1, l2);
                        if (result.remainder > 0)
                        {
                            return new MyLinkedListNode<int>(result.remainder)
                            {
                                Next = result.node
                            };
                        }
                        return result.node;
                    }

                    // l1 is larger than l2
                    if (p2 == null)
                    {
                        p11 = l1;

                        while (p1 != null)
                        {
                            p1 = p1.Next;
                            p11 = p11.Next;
                        }

                        return CalculateLarger(l1, p11, l2);
                    }

                    // l2 is largar than l1
                    if (p1 == null)
                    {
                        p12 = l2;

                        while (p2 != null)
                        {
                            p2 = p2.Next;
                            p12 = p12.Next;
                        }

                        return CalculateLarger(l2, p12, l1);
                    }

                    p1 = p1.Next;
                    p2 = p2.Next;
                }
            }

            private MyLinkedListNode<int> CalculateLarger(MyLinkedListNode<int> start1, MyLinkedListNode<int> end1, MyLinkedListNode<int> start2)
            {
                var lastPeace = CalculateNormal(end1, start2);
                CalculateUntil(start1, end1, ref lastPeace.remainder, ref lastPeace.node);
                if (lastPeace.remainder > 0)
                {
                    return new MyLinkedListNode<int>(lastPeace.remainder)
                    {
                        Next = lastPeace.node
                    };
                }
                return lastPeace.node;
            }

            private void CalculateUntil(MyLinkedListNode<int> start1, MyLinkedListNode<int> end1, ref int remainder, ref MyLinkedListNode<int> node)
            {
                if (start1 == end1)
                    return;

                CalculateUntil(start1.Next, end1, ref remainder, ref node);

                node = new MyLinkedListNode<int>(0)
                {
                    Next = node
                };

                var sum = start1.Value + remainder;
                if (sum >= 10)
                {
                    remainder = 1;
                    node.Value = sum - 10;
                }
                else
                {
                    remainder = 0;
                    node.Value = sum;
                }
            }

            private (MyLinkedListNode<int> node, int remainder) CalculateNormal(MyLinkedListNode<int> l1, MyLinkedListNode<int> l2)
            {
                if (l1 == null && l2 == null)
                {
                    return (null, 0);
                }

                var result = CalculateNormal(l1.Next, l2.Next);

                var sum = l1.Value + l2.Value + result.remainder;

                var node = new MyLinkedListNode<int>(0)
                {
                    Next = result.node
                };

                if (sum >= 10)
                {
                    node.Value = sum - 10;
                    return (node, 1);
                }
                else
                {
                    node.Value = sum;
                    return (node, 0);
                }
            }
        }
    }
}
