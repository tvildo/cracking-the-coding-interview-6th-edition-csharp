using System;
using System.Collections.Generic;

namespace GraphShared
{
    public partial class GraphAlgorithms
    {
        private enum VisitedColor : short
        {
            VisitingChilds,
            Visited
        }

        public IEnumerable<T> TopSort<T>(Graph<T> graph)
        {
            var result = new LinkedList<T>();
            var visited = new Dictionary<T, VisitedColor>();
            var dfsQueue = new LinkedList<T>();

            void addItemToResult(LinkedListNode<T> item)
            {
                dfsQueue.Remove(item);
                result.AddFirst(item);
                visited[item.Value] = VisitedColor.Visited;
            }

            foreach (var node in graph.AdjacencyList)
            {
                if (visited.TryGetValue(node.Key, out var nVisitedColor) && nVisitedColor == VisitedColor.Visited)
                    continue;

                dfsQueue.AddFirst(node.Key);

                while (dfsQueue.Count > 0)
                {
                    var currentNode = dfsQueue.First;
                    var prevQueueCount = dfsQueue.Count;

                    if (visited.TryGetValue(currentNode.Value, out nVisitedColor))
                    {
                        if (nVisitedColor == VisitedColor.VisitingChilds)
                            addItemToResult(currentNode);
                        else
                            dfsQueue.Remove(currentNode);
                        continue;
                    }

                    visited.Add(currentNode.Value, VisitedColor.VisitingChilds);


                    if (graph.AdjacencyList.TryGetValue(currentNode.Value, out var neighbours))
                    {
                        foreach (var n in neighbours)
                        {
                            if (!visited.TryGetValue(n, out nVisitedColor))
                            {
                                dfsQueue.AddFirst(n);
                            }
                            else if (nVisitedColor == VisitedColor.VisitingChilds)
                            {
                                return null; //cycle
                            }
                        }
                    }

                    if (dfsQueue.Count == prevQueueCount)
                    {
                        addItemToResult(currentNode);
                    }
                }
            }

            return result;
        }
    }
}
