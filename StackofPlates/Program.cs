using System;

namespace StackofPlates
{
    class Program
    {
        static void Main(string[] args)
        {
            string push = "Push", pop = "Pop", peek = "Peek", popAt = "PopAt";
            var algo = new SetOfStacks<int>(2);
            var test = new[] 
            {
                (push, 1),
                (push, 2),
                (push, 3),
                (push, 4),
                (pop, 0),
                (popAt, 0),
                (peek,0)
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
                else if (item.Item1 == popAt)
                    Console.WriteLine($"{item.Item1}({item.Item2}) = {algo.PopAt(item.Item2)}");
                else if (item.Item1 == peek)
                    Console.WriteLine($"{item.Item1}() = {algo.Peek()}");

                Console.WriteLine(algo.PrintStackList());
                Console.WriteLine();
            }
        }
    }
}
