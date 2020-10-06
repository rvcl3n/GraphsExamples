using System.Collections.Generic;

namespace GraphsExamples
{
    class BFS
    {
        public static HashSet<Node> BFSFunc(Graph graph, Node start)
        {
            var visited = new HashSet<Node>();

            /*if (!graph.Contains(start))
                return visited;*/

            var queue = new Queue<Node>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.GetRelatedNodes(vertex))
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }
    }
}
