using System;
using System.Collections.Generic;

namespace CheckPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            Console.WriteLine(algo.IsPermutation("Aba", "abA"));
        }
    }

    class Algorithm
    {
        public bool IsPermutation(ReadOnlySpan<char> v1, ReadOnlySpan<char> v2)
        {
            if (v1 == null)
                throw new ArgumentNullException(nameof(v1));
            if (v2 == null)
                throw new ArgumentNullException(nameof(v2));

            if (v1.Length != v2.Length)
                return false;

            var map = new Dictionary<char, int>();

            foreach (var c in v1)
            {
                if (map.TryGetValue(c, out var item))
                    map[c] = item + 1;
                else
                    map.Add(c, 1);
            }

            foreach (var c in v2)
            {
                if (map.TryGetValue(c, out var item))
                {
                    var nextMapValue = item - 1;
                    if (nextMapValue == 0)
                        map.Remove(c);
                    else
                        map[c] = nextMapValue;
                }
                else
                    return false;
            }

            return map.Count == 0;
        }
    }
}
