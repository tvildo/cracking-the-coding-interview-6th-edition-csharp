using System;
using System.Linq;

namespace OneAway
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();

            var items = new[]
            {
                ("pale", "ple"),
                ("pales", "pale"),
                ("pale", "bale" ),
                ("pale", "bake" ),
            };

            foreach (var item in items)
                Console.WriteLine(algo.IsOneEditAway(item.Item1, item.Item2));
        }
    }

    class Algorithm
    {
        public bool IsOneEditAway(ReadOnlySpan<char> v1, ReadOnlySpan<char> v2)
        {
            if (v1 == null)
                throw new ArgumentNullException(nameof(v1));
            if (v2 == null)
                throw new ArgumentNullException(nameof(v2));

            if (v1 == v2)
                return true;

            if (v1.Length == v2.Length)
                return Replaced(v1, v2);

            if (v1.Length + 1 == v2.Length)
                return Added(v1, v2);

            if (v1.Length - 1 == v2.Length)
                return Removed(v1, v2);

            return false;
        }

        private bool Removed(ReadOnlySpan<char> v1, ReadOnlySpan<char> v2)
        {
            for (int i = 0; i < v2.Length; i++)
            {
                if (v1[i] != v2[i])
                    return v1.Slice(i + 1).SequenceEqual(v2.Slice(i));
            }

            return true;
        }

        private bool Added(ReadOnlySpan<char> v1, ReadOnlySpan<char> v2)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i])
                    return v1.Slice(i).SequenceEqual(v2.Slice(i + 1));
            }

            return true;
        }

        private bool Replaced(ReadOnlySpan<char> v1, ReadOnlySpan<char> v2)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i])
                    return v1.Slice(i + 1).SequenceEqual(v2.Slice(i + 1));
            }

            return true;
        }
    }
}
