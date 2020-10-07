using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsExamples
{
    class DFS
    {
        public HashSet<Node> DFSFunc(Graph graph, Node start)
        {
            var visited = new HashSet<Node>();

            if (!graph.Contains(start))
                return visited;

            var stack = new Stack<Node>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.GetRelatedNodes(vertex))
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }
}
