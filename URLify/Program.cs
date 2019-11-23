using System;

namespace URLify
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            var src = "Mr John Smith    ".ToCharArray();
            algo.UrliFyInplace(src);
            Console.WriteLine(src);
        }
    }

    class Algorithm
    {
        public void UrliFyInplace(Span<char> src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            if (src.Length == 0)
                return;

            int i, j;
            i = j = src.Length - 1;

            // first backward shift right
            for (; i >= 0; i--)
            {
                if (src[i] != ' ')
                {
                    src[j] = src[i];
                    j--;
                    i--;
                    break;
                }
            }

            for (; i >= 0; i--)
            {
                if (src[i] == ' ')
                {
                    j -= 3;
                    src[j + 1] = '%';
                    src[j + 2] = '2';
                    src[j + 3] = '0';
                }
                else
                {
                    src[j] = src[i];
                    j--;
                }
            }
        }
    }
}
