using System;

namespace ThreeinOne
{
    /*
     * Three in One: Describe how you could use a single array to implement three stacks. 
     */
    class ArrayStackN
    {
        private int[] StackArray { get; set; }
        private readonly uint NumberOfStacks;

        public ArrayStackN(uint numberOfStacks, uint minStackCapacity = 1)
        {
            if (numberOfStacks == 0)
                throw new ArgumentException("size should be greater than 0", nameof(numberOfStacks));

            if (minStackCapacity == 0)
                throw new ArgumentException("size should be greater than 0", nameof(minStackCapacity));

            NumberOfStacks = numberOfStacks;

            // we need two extra pointers to track start and length of stackN
            var totalSize = numberOfStacks * (2 + minStackCapacity);
            StackArray = new int[totalSize];

            for (uint i = 0, j = numberOfStacks * 2; i < numberOfStacks * 2; i += 2, j++)
            {
                StackArray[i] = (int)j;
            }
        }

        public void Push(int stackNumber, int number)
        {
            
           // var startIndex = stackNumber * 2
        }

    }
}

//1 0 1

//2 2 3
//3 4 5
//4 6 7
//5 8 9
//6 10 11