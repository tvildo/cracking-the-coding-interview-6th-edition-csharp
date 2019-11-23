using System;

namespace QueueviaStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            string add = "AddLast", remove = "RemoveFirst";
            var algo = new MyQueue<int>();
            var tests = new[]
            {
                (add, 1),
                (add, 2),
                (add, 3),
                (add, 4),
                (remove,0),
                (remove,0),
                (remove,0),
                (remove,0)
            };

            foreach (var test in tests)
            {
                if (test.Item1 == add)
                {
                    Console.WriteLine($"{test.Item1}({test.Item2})");
                    algo.AddLast(test.Item2);
                }
                else if (test.Item1 == remove)
                    Console.WriteLine($"{test.Item1} = {algo.RemoveFirst()}");

                Console.WriteLine(algo.PrintQueue());
                Console.WriteLine();
            }
        }
    }
}
