using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphsExamples
{
    class Dijkstra
    {
        public static void DijkstraFunc(Graph graph, Node start)
        {
            //arrays init
            var nodesDistances = new Dictionary<Node, int>();
            var shortestPathTreeSet = new Dictionary<Node, bool>();

            foreach (var node in graph.nodes)
            {
                nodesDistances.Add(node, int.MaxValue); //max value set for each distance
                shortestPathTreeSet.Add(node, false); //false for each node
            }

            nodesDistances[start] = 0;

            foreach (var node in graph.nodes)
            {
                Node nearestNode = MinimalDistance(graph.nodes, nodesDistances, shortestPathTreeSet);
                shortestPathTreeSet[nearestNode] = true;

                foreach(var innerNode in graph.nodes)
                {
                    if (!shortestPathTreeSet[innerNode] && IsNodesConnected(graph.edges, innerNode, nearestNode) && nodesDistances[node] != int.MaxValue && nodesDistances[node] + GetDistance(graph.edges, innerNode, nearestNode) < nodesDistances[innerNode])
                    {
                        nodesDistances[innerNode] = nodesDistances[node] + GetDistance(graph.edges, innerNode, nearestNode);
                    }
                }
            }

            Print(nodesDistances, start);
        }

        private static Node MinimalDistance(List<Node> graphNodes, Dictionary<Node, int> distance, Dictionary<Node, bool> shortestPathTreeSet)
        {
            int min = int.MaxValue;
            Node nearestNode = null;

            foreach(var node in graphNodes)
            {
                if (shortestPathTreeSet[node] == false && distance[node] <= min)
                {
                    min = distance[node];
                    nearestNode = node;
                }
            }

            return nearestNode;
        }

        private static bool IsNodesConnected(List<Edge> edges, Node a, Node b)
        {
            return Convert.ToBoolean(edges.Where(i => (i.NodeA == a && i.NodeB == b) || (i.NodeA == b && i.NodeB == a)).Count());
        }

        private static int GetDistance(List<Edge> edges, Node a, Node b)
        {
            int distance = 0;

            foreach (var edge in edges)
            {
                if ((edge.NodeA == a && edge.NodeB == b) || (edge.NodeA == b && edge.NodeB == a))
                {
                    distance = edge.Value;
                }
            }

            return distance;
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
