using System;

namespace GraphsExamples
{
    class Program
    {
        static void Main()
        {
            var graph = new Graph();

            var nodeOne = new Node("One");
            var nodeTwo = new Node("Two");
            var nodeThree = new Node("Three");
            var nodeFour = new Node("Four");
            var nodeFive = new Node("Five");
            var nodeSix = new Node("Six");
            var nodeSeven = new Node("Seven");


            graph.nodes.AddRange(new Node[] { nodeOne, nodeTwo, nodeThree, nodeFour, nodeFive, nodeSix, nodeSeven });

            graph.AddConnection(new Edge(nodeOne, nodeTwo, -3));
            graph.AddConnection(new Edge(nodeOne, nodeThree, 5));
            graph.AddConnection(new Edge(nodeTwo, nodeThree, 4));
            graph.AddConnection(new Edge(nodeTwo, nodeFour, 3));
            graph.AddConnection(new Edge(nodeThree, nodeFive, 2));
            graph.AddConnection(new Edge(nodeFour, nodeFive, 4));
            graph.AddConnection(new Edge(nodeOne, nodeSix, 13));
            graph.AddConnection(new Edge(nodeFive, nodeSix, 3));
            graph.AddConnection(new Edge(nodeSix, nodeSeven, 2));
            //graph.AddConnection(new Edge(nodeSeven, nodeSix, 2)); //inverse edge
            graph.AddConnection(new Edge(nodeFive, nodeSeven, -1));
            graph.AddConnection(new Edge(nodeTwo, nodeSeven, 10));


            graph.PrintGraph();

            Console.WriteLine("Dijkstra");
            Dijkstra.DijkstraFunc(graph, nodeOne);
            Console.WriteLine("BellmanFord");
            BellmanFord.BellmanFordFunc(graph, nodeOne);

            /*

            var graph = new Graph();

            var nodeOne = new Node("One");
            var nodeTwo = new Node("Two");
            var nodeThree = new Node("Three");
            var nodeFour = new Node("Four");
            var nodeFive = new Node("Five");

            graph.AddConnection(new Edge(nodeOne, nodeTwo));
            graph.AddConnection(new Edge(nodeOne, nodeThree));
            graph.AddConnection(new Edge(nodeTwo, nodeThree));
            graph.AddConnection(new Edge(nodeTwo, nodeFour));
            graph.AddConnection(new Edge(nodeThree, nodeFive));
            graph.AddConnection(new Edge(nodeFour, nodeFive));

            graph.PrintGraph();
            try
            {
                graph.AddConnection(new Edge(nodeFour, nodeFive));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("//BFS");
            var bfsResult = BFS.BFSFunc(graph, nodeOne);

            foreach (var item in bfsResult)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("//DFS");
            var dfsResult = DFS.DFSFunc(graph, nodeOne);

            foreach (var item in dfsResult)
            {
                Console.WriteLine(item.Name);
            }

            */

            Console.ReadKey();
        }
    }
}
