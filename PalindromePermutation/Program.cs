using System;
using System.Collections.Generic;

namespace PalindromePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            Console.WriteLine(algo.IsPermutationPalindrome("tactcoapapa"));
        }
    }

    class Algorithm
    {
        public bool IsPermutationPalindrome(ReadOnlySpan<char> v1)
        {
            if (v1 == null)
                throw new ArgumentNullException(nameof(v1));

            if (v1.Length == 0)
                return true;

            //Convert to lowercase
            Span<char> lowerCase = new char[v1.Length];
            v1.ToLowerInvariant(lowerCase);

            var hSet = new HashSet<char>();

            foreach (char c in lowerCase)
            {
                if (hSet.TryGetValue(c, out _))
                    hSet.Remove(c);
                else
                    hSet.Add(c);
            }

            return hSet.Count == 1;
        }
    }
}
