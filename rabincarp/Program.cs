using System;

namespace rabincarp
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            var source = "The big fox";
            var pattern = " fox";

            Console.WriteLine(algo.RabinCarp(source, pattern));
        }
    }

    class Algorithm
    {
        public bool RabinCarp(ReadOnlySpan<char> source, ReadOnlySpan<char> pattern, long alphabetLength = 26)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            // Optimize
            if (source.Length == pattern.Length)
                return source.SequenceEqual(pattern);

            if (pattern.Length > source.Length)
                return false;

            // Algorithm
            var patternHash = RollingHash(pattern, alphabetLength);
            var windowHash = RollingHash(source.Slice(0, pattern.Length), alphabetLength);

            for (int j = 0; j < source.Length - pattern.Length + 1; j++)
            {
                if (patternHash == windowHash && pattern.SequenceEqual(source.Slice(j, pattern.Length)))
                    return true;

                if (j < source.Length - pattern.Length)
                    windowHash = Rehash(source, pattern, alphabetLength, windowHash, j);
            }

            return false;
        }

        private double Rehash(ReadOnlySpan<char> source, ReadOnlySpan<char> pattern, long alphabetLength, double windowHash, int j)
        {
            var frontHash = source[j] * Math.Pow(alphabetLength, pattern.Length - 1);
            var withoutFrontHash = windowHash - frontHash;
            var shiftleft = withoutFrontHash * alphabetLength;
            var lasthash = shiftleft + source[j + pattern.Length];
            return lasthash;
        }

        private double RollingHash(ReadOnlySpan<char> source, long alphabetLength)
        {
            double hash = 0;
            for (int i = 0; i < source.Length; i++)
            {
                var tmp = source[i] * (Math.Pow(alphabetLength, source.Length - i - 1));
                hash += tmp;
            }

            return hash;
        }
    }
}
