using System;

namespace IsUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            Console.WriteLine(algo.IsUnique("ASShambala"));
        }
    }

    class Algorithm
    {
        public bool IsUnique(ReadOnlySpan<char> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            uint bitmask = 0;
            foreach (var c in source)
            {
                var minimized = 'a' - c;
                var testMask = (uint)(1 << minimized);

                if ((testMask & bitmask) > 0)
                    return false;

                bitmask = testMask | bitmask;
            }

            return true;
        }
    }
}
