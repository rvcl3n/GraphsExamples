using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsExamples
{
    class DFS
    {
        public HashSet<Node> DFSFunc(Graph graph, Node start)
        {
            var visitedNodes = new HashSet<Node>();

            if (!graph.ContainsAndRelated(start))
                return visitedNodes;

            var stack = new Stack<Node>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (visitedNodes.Contains(node))
                    continue;

                visitedNodes.Add(node);

                foreach (var neighbor in graph.GetRelatedNodes(node))
                    if (!visitedNodes.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visitedNodes;
        }
    }
}
