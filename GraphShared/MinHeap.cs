using System;
using System.Collections.Generic;

namespace GraphShared
{
    public class MinHeap<T> where T : IComparable<T>
    {
        public IList<T> Items { get; private set; }
        IComparer<T> comparer;

        public MinHeap(IList<T> items, IComparer<T> comparer)
        {
            this.Items = items ?? throw new ArgumentNullException(nameof(items));
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            HeapSort();
        }

        public MinHeap(IList<T> items) : this(items, Comparer<T>.Default)
        {
        }

        public MinHeap() : this(new List<T>(), Comparer<T>.Default)
        {
        }

        public MinHeap(IComparer<T> comparer) : this(new List<T>(), comparer)
        {
        }

        public void HeapSort()
        {
            if (Items.Count < 2)
                return;

            var lastRootIndex = GetRoot(Items.Count - 1);
            for (int i = lastRootIndex; i >= 0; i--)
                Heapify(i, Items.Count);

            for (int i = Items.Count - 1; i > 0; i--)
            {
                Swap(0, i);
                Heapify(0, i);
            }
        }

        public void Heapify(int rootIndex, int length)
        {
            var largest = rootIndex;
            var leftIndex = GetLeft(rootIndex);
            var rightIndex = GetRight(rootIndex);

            if (leftIndex < length && comparer.Compare(Items[leftIndex], (Items[largest])) < 0)
                largest = leftIndex;

            if (rightIndex < length && comparer.Compare(Items[rightIndex], (Items[largest])) < 0)
                largest = rightIndex;

            if (largest != rootIndex)
            {
                Swap(largest, rootIndex);
                Heapify(largest, length);
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = Items[i];
            Items[i] = Items[j];
            Items[j] = tmp;
        }

        public T RemoveRoot()
        {
            var root = Items[0];
            var lastIndex = Items.Count - 1;
            Swap(0, lastIndex);
            Items.RemoveAt(lastIndex);
            if (Items.Count > 0)
                Heapify(0, Items.Count);

            return root;
        }

        private int GetRoot(int x) => (x - 1) / 2;
        private int GetLeft(int x) => 2 * x + 1;
        private int GetRight(int x) => 2 * x + 2;
        public int Count => Items.Count;
        public T Root => Items.Count > 0 ? Items[0] : throw new InvalidOperationException("Heap is empty");

        public void Add(T item)
        {
            Items.Add(item);
            var itemIndex = Items.Count - 1;

            while (true)
            {
                var parentIndex = GetRoot(itemIndex);
                if (itemIndex == 0 || comparer.Compare(Items[itemIndex], Items[parentIndex]) > 0)
                    break;

                Swap(itemIndex, parentIndex);
                itemIndex = parentIndex;
            }
        }
    }
}