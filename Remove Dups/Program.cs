using LinkedListShared;
using System;
using System.Collections.Generic;

namespace Remove_Dups
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();

            var tests = new[] {
                new MyLinkedList<int>(new[] { 1, 2, 2, 3, 4, 4, 5, 6 }),
                new MyLinkedList<int>(new[] { 1, 2, 3, 4, 5, 6 })
                };

            foreach (var test in tests)
            {
                Console.WriteLine($"\nOriginal : {test}");
                Console.WriteLine("Removed  : " + algo.RemoveDublicates(test.Clone())); ;

                Console.WriteLine("RemovedS : " + algo.RemoveDublicatesWithoutAdditionalSpace(test.Clone()));
            }
        }
    }

    class Algorithm
    {
        public MyLinkedList<int> RemoveDublicates(MyLinkedList<int> input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var hset = new HashSet<int>();
            var top = input.Head;
            while (top != null)
            {
                if (hset.Contains(top.Value))
                {
                    var tmp = top;
                    top = top.Next;
                    //remove dublicate
                    input.Remove(tmp);
                    continue;
                }

                hset.Add(top.Value);
                top = top.Next;
            }

            return input;
        }

        public MyLinkedList<int> RemoveDublicatesWithoutAdditionalSpace(MyLinkedList<int> input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var firstPt = input.Head;
            while (firstPt != null)
            {
                var runner = firstPt.Next;
                if (runner == null)
                    break;

                while (runner != null)
                {
                    if (firstPt.Value == runner.Value)
                    {
                        var tmp = runner;
                        runner = runner.Next;
                        input.Remove(tmp);
                    }
                    runner = runner.Next;
                }

                firstPt = firstPt.Next;
            }

            return input;
        }
    }
}
