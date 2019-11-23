using System;
using System.Text;

namespace StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            Console.WriteLine(algo.Compress("aabcccccaaa"));
        }
    }

    class Algorithm
    {
        public string Compress(string src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            if (src.Length < 3)
                return src;

            int compStart = 0, compEnd = 1;
            var sb = new StringBuilder();

            // Compress chunks
            for (; compEnd < src.Length; compEnd++)
            {
                if (src[compEnd] != src[compStart])
                {
                    MaybeCompress(src[compStart], sb, compEnd - compStart);
                    compStart = compEnd;
                }
            }

            // Compress Last chunk
            if (compStart != compEnd)
                MaybeCompress(src[compStart], sb, compEnd - compStart);

            return (src.Length == sb.Length) ? src : sb.ToString();
        }

        private static void MaybeCompress(char compChar, StringBuilder sb, int compressedLength)
        {
            sb.Append($"{compChar}{compressedLength}");
        }
    }
}
