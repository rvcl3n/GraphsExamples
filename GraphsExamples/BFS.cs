using System.Collections.Generic;

namespace GraphsExamples
{
    class BFS
    {
        public static HashSet<Node> BFSFunc(Graph graph, Node start)
        {
            var visitedNodes = new HashSet<Node>();

            if (!graph.ContainsAndRelated(start))
                return visitedNodes;

            var queue = new Queue<Node>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (visitedNodes.Contains(node))
                    continue;

                visitedNodes.Add(node);

                foreach (var neighbor in graph.GetRelatedNodes(node))
                    if (!visitedNodes.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visitedNodes;
        }
    }
}
