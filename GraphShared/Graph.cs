using System.Collections.Generic;

namespace GraphShared
{
    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList = new Dictionary<T, HashSet<T>>();

        public Graph()
        {

        }

        public Graph(IEnumerable<T> verteces, IEnumerable<(T, T)> edges)
        {
            foreach (var v in verteces)
                Addvertex(v);

            foreach (var v in edges)
                AddEgde(v.Item1, v.Item2);
        }

        public void Addvertex(T vertex)
        {
            AdjacencyList.Add(vertex, new HashSet<T>());
        }

        public void AddEgde(T vertex1, T vertex2)
        {
            AdjacencyList[vertex1].Add(vertex2);
        }
    }
}
