using System;

namespace StringRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            Console.WriteLine(algo.IsRotation("waterbottle", "erbottlewat"));
        }
    }

    class Algorithm
    {

        public bool IsRotation(string s1, string s2)
        {
            if (s1 == null)
                throw new ArgumentNullException(nameof(s1));
            if (s2 == null)
                throw new ArgumentNullException(nameof(s2));

            if (s1.Length == s2.Length && s1.Length > 0)
                return IsSubstring(s1 + s1, s2);

            return false;
        }

        private bool IsSubstring(ReadOnlySpan<char> s1, ReadOnlySpan<char> s2)
        {
            return s1.IndexOf(s2) != -1;
        }
    }
}
