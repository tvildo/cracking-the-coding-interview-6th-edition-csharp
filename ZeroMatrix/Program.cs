using System;
using System.Linq;
using System.Collections.Generic;

namespace ZeroMatrix
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
                    new []{ 0,4 }
                },
                new int[][]
                {
                    new []{ 1,2,0 },
                    new []{ 0,5,6 },
                    new []{ 7,8,9 }
                },
                new int[][]
                {
                    new []{ 1,2,0, 4 },
                    new []{ 5,6,7,8 },
                    new []{ 9, 10, 11, 12 },
                    new []{ 13,14,15,16 }
                },
            };

            foreach (var test in tests)
            {
                algo.PrintMatrix(test);
                Console.WriteLine();

                algo.ZeroMatrix(test);
                algo.PrintMatrix(test);

                Console.WriteLine("..........");
            }
        }
    }

    class Algorithm
    {
        public void ZeroMatrix(int[][] input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var columnIndexes = new HashSet<int>(Enumerable.Range(0, input[0].Length).ToList());

            for (int row = 0; row < input.Length; row++)
            {
                foreach (var column in columnIndexes)
                {
                    if (input[row][column] == 0)
                    {
                        FillWithZeros(input, row, column);
                        columnIndexes.Remove(column);
                        break;
                    }
                }
            }
        }

        private void FillWithZeros(int[][] input, int rowIndex, int columnIndex)
        {
            //row
            for (int i = 0; i < input[rowIndex].Length; i++)
            {
                input[rowIndex][i] = 0;
            }

            //column
            for (int i = 0; i < input.Length; i++)
            {
                input[i][columnIndex] = 0;
            }
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
