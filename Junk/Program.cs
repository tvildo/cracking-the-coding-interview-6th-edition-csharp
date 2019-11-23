using GraphShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Junk
{

    class Program
    {

        static void Main(string[] args)
        {
            var sln = new Solution();

            var input = @"10
[[3,4,4],[2,5,6],[4,7,10],[9,6,5],[7,4,4],[6,2,10],[6,8,6],[7,9,4],[1,5,4],[1,0,4],[9,7,3],[7,0,5],[6,5,8],[1,7,6],[4,0,9],[5,9,1],[8,7,3],[1,2,6],[4,1,5],[5,2,4],[1,9,1],[7,8,10],[0,4,2],[7,2,8]]
6
0
7
";

            var split = input.Split('\n');
            var n = int.Parse(split[0]);


            int[][] edges = (int[][])JsonSerializer.Deserialize(split[1], typeof(int[][]));

            var src = int.Parse(split[2]);
            var dst = int.Parse(split[3]);
            var k = int.Parse(split[4]);

            sln.FindCheapestPrice(n, edges, src, dst, k);
        }

    }

    public class Solution
    {

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var AdjacencyList = new List<(int index, int weight)>[n];

            for (int i = 0; i < AdjacencyList.Length; i++)
            {
                AdjacencyList[i] = new List<(int node, int weight)>();
            }

            for (int i = 0; i < flights.Length; i++)
            {
                var current = flights[i];
                AdjacencyList[current[0]].Add((current[1], current[2]));
            }

            //dijkstra...
            var priorityComparer = Comparer<(int index, int cost, int step)>.Create((x, y) =>
            {
                var cmp = x.cost - y.cost;
                if (cmp == 0)
                    return x.step - y.step;

                return cmp;
            });

            var sSet = new MinHeap<(int index, int cost, int step)>(priorityComparer);
            sSet.Add((src, 0, 0));

            while (sSet.Count > 0)
            {
                var current = sSet.RemoveRoot();

                if (current.index == dst)
                    return current.cost;

                if (current.step > K)
                    continue;

                foreach (var neighbour in AdjacencyList[current.index])
                    sSet.Add((neighbour.index, current.cost + neighbour.weight, current.step + 1));
            }

            return -1;
        }
    }
}