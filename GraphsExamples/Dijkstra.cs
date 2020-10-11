using System;
using System.Collections.Generic;

namespace GraphsExamples
{
    class Dijkstra
    {
        int V = 0;
        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        void printSolution(int[] dist)
        {
            Console.Write("Vertex \t\t Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        public void dijkstra(int[,] graph, int src)
        {
            V = graph.GetLength(0);

            int[] dist = new int[V];
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(dist, sptSet);

                sptSet[u] = true;

                for (int v = 0; v < V; v++)
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            printSolution(dist);
        }

        public static void DijkstraFunc(Graph graph, Node start)
        {
            //arrays init
            //int[] distance = new int[graph.NodesCount];
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
            bool isConnected = false;

            foreach (var item in edges)
            {
                if((item.NodeA == a && item.NodeB == b) || (item.NodeA == b && item.NodeB == a))
                {
                    isConnected = true;
                }
            }
            return isConnected;
        }

        private static int GetDistance(List<Edge> edges, Node a, Node b)
        {
            int distance = 0;

            foreach (var item in edges)
            {
                if ((item.NodeA == a && item.NodeB == b) || (item.NodeA == b && item.NodeB == a))
                {
                    distance = item.Value;
                }
            }
            return distance;
        }

        private static void Print(Dictionary<Node, int> distance, Node startNode)
        {
            foreach (var node in distance)
            {
                Console.WriteLine($"From {startNode.Name} to {node.Key.Name} - Distance: {node.Value}");
            }
        }
    }
}
