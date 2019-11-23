using System;
using System.Linq;

namespace SortStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string push = "Push", pop = "Pop", peek = "Peek";
            var algo = new SortedStack<int>();
            var test = new[]
            {
                (push, 4),
                (push, 3),
                (push, 2),
                (push, 1),
                (pop, 0),
                (peek,0),
                (push, 0),
                (pop, 0),
                (pop, 0),
                (pop, 0),
            };

            foreach (var item in test)
            {
                if (item.Item1 == push)
                {
                    Console.WriteLine($"{item.Item1}({item.Item2})");
                    algo.Push(item.Item2);
                }
                else if (item.Item1 == pop)
                    Console.WriteLine($"{item.Item1}() = {algo.Pop()}");
                else if (item.Item1 == peek)
                    Console.WriteLine($"{item.Item1}() = {algo.Peek()}");

                Console.WriteLine(algo.PrintStackList());
                Console.WriteLine();
            }
        }
    }
}
