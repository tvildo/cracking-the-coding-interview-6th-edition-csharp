using System;

namespace RotateMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new Algorithm();
            var tests = new int[][][]{
                new int[][]
                {
                    new []{ 1 }
                },
                new int[][]
                {
                    new []{ 1,2 },
                    new []{ 3,4 }
                },
                new int[][]
                {
                    new []{ 1,2,3 },
                    new []{ 4,5,6 },
                    new []{ 7,8,9 }
                },
                new int[][]
                {
                    new []{ 1,2,3, 4 },
                    new []{ 5,6,7,8 },
                    new []{ 9, 10, 11, 12 },
                    new []{ 13,14,15,16 }
                },
            };

            foreach (var test in tests)
            {
                algo.PrintMatrix(test);
                Console.WriteLine();

                algo.Rotate90Degree(test);
                algo.PrintMatrix(test);

                Console.WriteLine("..........");
            }
        }
    }

    class Algorithm
    {
        public void Rotate90Degree(int[][] input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Length == 1)
                return;

            var n = input.Length;
            if (n <= 3)
                RotateLayerByLayer(input, 1);
            else
                RotateLayerByLayer(input, n - 2);
        }

        private void RotateLayerByLayer(int[][] input, int howManyLayers)
        {
            var maxColumnIndex = input.Length - 1;
            //how many layers to rotate
            for (int i = 0; i < howManyLayers; i++)
            {
                //column
                for (int j = i; j < maxColumnIndex; j++)
                {
                    Swap(input, i, j, j, maxColumnIndex);
                    Swap(input, i, j, maxColumnIndex, maxColumnIndex - j);
                    Swap(input, i, j, maxColumnIndex - j, i);
                }
            }
        }

        private void Swap(int[][] input, int firstI, int firstJ, int secodI, int secondJ)
        {
            var tmp = input[firstI][firstJ];
            input[firstI][firstJ] = input[secodI][secondJ];
            input[secodI][secondJ] = tmp;
        }

        public void PrintMatrix(int[][] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                //column
                for (int j = 0; j < input[i].Length; j++)
                {
                    Console.Write(input[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
