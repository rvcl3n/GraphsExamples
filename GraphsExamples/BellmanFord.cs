using System;
using System.Collections.Generic;

namespace GraphsExamples
{
    public class BellmanFord
    {
        public static int BellmanFordFunc(Graph graph, Node start)
        {
            //arrays init
            var nodesDistances = new Dictionary<Node, int>();
            int nodesCount = graph.NodesCount;

            foreach (var node in graph.nodes)
            {
                nodesDistances.Add(node, int.MaxValue); //max value set for each distance
            }

            nodesDistances[start] = 0;

            for (int i = 1; i <= nodesCount -1 ; ++i)
            {
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

            return SumUpDistances(nodesDistances);
        }

        private static void Print(Dictionary<Node, int> nodeDistances, Node startNode)
        {
            foreach (var node in nodeDistances)
            {
                Console.WriteLine($"From {startNode.Name} to {node.Key.Name} - Distance: {node.Value}");
            }
        }

        private static int SumUpDistances(Dictionary<Node, int> nodeDistances)
        {
            int sum = 0;

            foreach (var node in nodeDistances)
            {
                sum += node.Value;
            }

            return sum;
        }
    }
}
