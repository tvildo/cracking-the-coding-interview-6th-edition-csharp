using System;
using System.Linq;

namespace StackMin
{
    class Program
    {
        static void Main(string[] args)
        {
            string push = "Push", pop = "Pop";
            var algo = new StackMin<int>();
            var test = new[]
            {
                (push, -2),
                (push, 0),
                (push, -3),
                (push, -5),
                (pop, 0)
            };

            foreach(var item in test)
            {
                if (item.Item1 == push)
                {
                    Console.WriteLine($"{item.Item1}({item.Item2})");
                    algo.Push(item.Item2);
                }
                else if (item.Item1 == pop)
                    Console.WriteLine($"{item.Item1}() = {algo.Pop()}");

                algo.PrintStackAndMin();
                Console.WriteLine();
            }
        }
    }
}
