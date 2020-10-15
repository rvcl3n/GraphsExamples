using System;
using System.Collections.Generic;

namespace GraphsExamples
{
    public class BellmanFord
    {
        public static void BellmanFordFunc(Graph graph, Node start)
        {
            //arrays init
            var nodesDistances = new Dictionary<Node, int>();
            int verticesCount = graph.NodesCount;
            int edgesCount = graph.edges.Count;

            foreach (var node in graph.nodes)
            {
                nodesDistances.Add(node, int.MaxValue); //max value set for each distance
            }

            nodesDistances[start] = 0;

            for (int i = 1; i <= verticesCount -1 ; ++i)
            {
                /*for (int j = 0; j < edgesCount; ++j)
                {
                    int u = graph.edge[j].Source;
                    int v = graph.edge[j].Destination;
                    int weight = graph.edge[j].Weight;

                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                        distance[v] = distance[u] + weight;
                }*/

                foreach (var edge in graph.edges)
                {
                    Node a = edge.NodeA;
                    Node b = edge.NodeB;
                    int weight = edge.Value;

                    if (nodesDistances[a] != int.MaxValue && nodesDistances[a] + weight < nodesDistances[b])
                        nodesDistances[b] = nodesDistances[a] + weight;

                    if (nodesDistances[b] != int.MaxValue && nodesDistances[b] + weight < nodesDistances[a])
                        nodesDistances[a] = nodesDistances[b] + weight;
                }
            }

            /*for (int i = 0; i < edgesCount; ++i)
            {
                int u = graph.edge[i].Source;
                int v = graph.edge[i].Destination;
                int weight = graph.edge[i].Weight;

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    Console.WriteLine("Graph contains negative weight cycle.");
            }*/

            foreach (var edge in graph.edges)
            {
                Node a = edge.NodeA;
                Node b = edge.NodeB;
                int weight = edge.Value;

                if (nodesDistances[a] != int.MaxValue && nodesDistances[a] + weight < nodesDistances[b])
                    Console.WriteLine("Graph contains negative weight cycle.");

                if (nodesDistances[b] != int.MaxValue && nodesDistances[b] + weight < nodesDistances[a])
                    Console.WriteLine("Graph contains negative weight cycle.");
            }

            Print(nodesDistances, start);
        }

        private static void Print(Dictionary<Node, int> nodeDistances, Node startNode)
        {
            foreach (var node in nodeDistances)
            {
                Console.WriteLine($"From {startNode.Name} to {node.Key.Name} - Distance: {node.Value}");
            }
        }
    }
}
