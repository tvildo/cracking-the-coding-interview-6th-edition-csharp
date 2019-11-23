using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GraphShared
{
    public partial class GraphAlgorithms
    {
        public IDictionary<WeightedGraphNode<T>, long> Dijekstra<T>(Graph<WeightedGraphNode<T>> graph, WeightedGraphNode<T> start, Comparison<WeightedGraphNode<T>> nodeComparison)
        {
            var distances = new Dictionary<WeightedGraphNode<T>, long>(graph.AdjacencyList.Count);
            var visited = new HashSet<WeightedGraphNode<T>>();

            foreach (var n in graph.AdjacencyList)
                distances.Add(n.Key, long.MaxValue);

            distances[start] = 0;

            var minHeap = new SortedSet<WeightedGraphNode<T>>(
                comparer: Comparer<WeightedGraphNode<T>>.Create(nodeComparison)
                )
            {
                start
            };

            while (minHeap.Count > 0)
            {
                //Remove node with shortest path
                var current = minHeap.Min;
                minHeap.Remove(current);

                visited.Add(current);
                var currentDistance = distances[current];

                if (graph.AdjacencyList.TryGetValue(current, out var neighbours))
                {
                    foreach (var n in neighbours)
                    {
                        //Ignore all visited nodes
                        if (visited.TryGetValue(n, out var _))
                            continue;
                        minHeap.Add(n);

                        var shortest = distances[n];
                        var newDistance = currentDistance + n.Weight;
                        if (shortest > newDistance)
                        {
                            distances[n] = newDistance;
                        }
                    }
                }
            }

            return distances;
        }
    }
}
