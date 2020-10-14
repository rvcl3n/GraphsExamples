using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraphsExamples.Tests
{
    [TestClass]
    public class GraphAglorithmsTest
    {
        [TestMethod]
        public void BFSFunc_EqualGraphs_ReturnsAllGraphsNodes()
        {
            //Graph init

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

            //Check collection init

            var graphsNodes = new HashSet<Node>();

            graphsNodes.Add(nodeOne);
            graphsNodes.Add(nodeTwo);
            graphsNodes.Add(nodeThree);
            graphsNodes.Add(nodeFour);
            graphsNodes.Add(nodeFive);

            //BFS check

            HashSet<Node> bfsResult = BFS.BFSFunc(graph, nodeOne);

            //Assert

            Assert.AreEqual(true, HashSet<Node>.CreateSetComparer().Equals(bfsResult, graphsNodes));
        }

        [TestMethod]
        public void BFSFunc_NotEqualGraphs_ReturnsAllGraphsNodes()
        {
            //Graph init

            var graph = new Graph();

            var nodeOne = new Node("One");
            var nodeTwo = new Node("Two");
            var nodeThree = new Node("Three");
            var nodeFour = new Node("Four");
            var nodeFive = new Node("Five");
            var nodeSix = new Node("Six"); //Extra node

            graph.AddConnection(new Edge(nodeOne, nodeTwo));
            graph.AddConnection(new Edge(nodeOne, nodeThree));
            graph.AddConnection(new Edge(nodeTwo, nodeThree));
            graph.AddConnection(new Edge(nodeTwo, nodeFour));
            graph.AddConnection(new Edge(nodeThree, nodeFive));
            graph.AddConnection(new Edge(nodeFour, nodeFive));

            //Check collection init

            var graphsNodes = new HashSet<Node>();

            graphsNodes.Add(nodeOne);
            graphsNodes.Add(nodeTwo);
            graphsNodes.Add(nodeThree);
            graphsNodes.Add(nodeFour);
            graphsNodes.Add(nodeFive);
            graphsNodes.Add(nodeSix); //Adding extra node

            //BFS check

            HashSet<Node> bfsResult = BFS.BFSFunc(graph, nodeOne);

            //Assert

            Assert.AreEqual(false, HashSet<Node>.CreateSetComparer().Equals(bfsResult, graphsNodes));
        }

        [TestMethod]
        public void DFSFunc_EqualGraphs_ReturnsAllGraphsNodes()
        {
            //Graph init

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

            //Check collection init

            var graphsNodes = new HashSet<Node>();

            graphsNodes.Add(nodeOne);
            graphsNodes.Add(nodeTwo);
            graphsNodes.Add(nodeThree);
            graphsNodes.Add(nodeFour);
            graphsNodes.Add(nodeFive);

            //DFS check

            HashSet<Node> dfsResult = DFS.DFSFunc(graph, nodeOne);

            //Assert

            Assert.AreEqual(true, HashSet<Node>.CreateSetComparer().Equals(dfsResult, graphsNodes));
        }

        [TestMethod]
        public void DFSFunc_NotEqualGraphs_ReturnsAllGraphsNodes()
        {
            //Graph init

            var graph = new Graph();

            var nodeOne = new Node("One");
            var nodeTwo = new Node("Two");
            var nodeThree = new Node("Three");
            var nodeFour = new Node("Four");
            var nodeFive = new Node("Five");
            var nodeSix = new Node("Six"); //Extra node

            graph.AddConnection(new Edge(nodeOne, nodeTwo));
            graph.AddConnection(new Edge(nodeOne, nodeThree));
            graph.AddConnection(new Edge(nodeTwo, nodeThree));
            graph.AddConnection(new Edge(nodeTwo, nodeFour));
            graph.AddConnection(new Edge(nodeThree, nodeFive));
            graph.AddConnection(new Edge(nodeFour, nodeFive));

            //Check collection init

            var graphsNodes = new HashSet<Node>();

            graphsNodes.Add(nodeOne);
            graphsNodes.Add(nodeTwo);
            graphsNodes.Add(nodeThree);
            graphsNodes.Add(nodeFour);
            graphsNodes.Add(nodeFive);
            graphsNodes.Add(nodeSix); //Adding extra node

            //DFS check

            HashSet<Node> dfsResult = DFS.DFSFunc(graph, nodeOne);

            //Assert

            Assert.AreEqual(false, HashSet<Node>.CreateSetComparer().Equals(dfsResult, graphsNodes));
        }

        [TestMethod]
        public void DijkstraFunc_EqualGraphsDistancesSums_ReturnsCorrectDistancesSum()
        {
            //Graph init

            var graph = new Graph();

            var nodeOne = new Node("One");
            var nodeTwo = new Node("Two");
            var nodeThree = new Node("Three");
            var nodeFour = new Node("Four");
            var nodeFive = new Node("Five");
            var nodeSix = new Node("Six");
            var nodeSeven = new Node("Seven");


            graph.nodes.AddRange(new Node[] { nodeOne, nodeTwo, nodeThree, nodeFour, nodeFive, nodeSix, nodeSeven });

            graph.AddConnection(new Edge(nodeOne, nodeTwo, 3));
            graph.AddConnection(new Edge(nodeOne, nodeThree, 5));
            graph.AddConnection(new Edge(nodeTwo, nodeThree, 4));
            graph.AddConnection(new Edge(nodeTwo, nodeFour, 3));
            graph.AddConnection(new Edge(nodeThree, nodeFive, 2));
            graph.AddConnection(new Edge(nodeFour, nodeFive, 4));
            graph.AddConnection(new Edge(nodeOne, nodeSix, 13));
            graph.AddConnection(new Edge(nodeFive, nodeSix, 3));
            graph.AddConnection(new Edge(nodeSix, nodeSeven, 2));
            graph.AddConnection(new Edge(nodeFive, nodeSeven, 1));
            graph.AddConnection(new Edge(nodeTwo, nodeSeven, 4));

            //Expected sum init

            int sumExpected = 37;

            //Dijkstra check

            int sumActual = Dijkstra.DijkstraFunc(graph, nodeOne);

            //Assert

            Assert.AreEqual(sumExpected, sumActual);
        }

        [TestMethod]
        public void DijkstraFunc_EqualGraphsDistancesSums_ReturnsIncorrectDistancesSum()
        {
            //Graph init

            var graph = new Graph();

            var nodeOne = new Node("One");
            var nodeTwo = new Node("Two");
            var nodeThree = new Node("Three");
            var nodeFour = new Node("Four");
            var nodeFive = new Node("Five");
            var nodeSix = new Node("Six");
            var nodeSeven = new Node("Seven");


            graph.nodes.AddRange(new Node[] { nodeOne, nodeTwo, nodeThree, nodeFour, nodeFive, nodeSix, nodeSeven });

            graph.AddConnection(new Edge(nodeOne, nodeTwo, 3));
            graph.AddConnection(new Edge(nodeOne, nodeThree, 5));
            graph.AddConnection(new Edge(nodeTwo, nodeThree, 4));
            graph.AddConnection(new Edge(nodeTwo, nodeFour, 3));
            graph.AddConnection(new Edge(nodeThree, nodeFive, 2));
            graph.AddConnection(new Edge(nodeFour, nodeFive, 4));
            graph.AddConnection(new Edge(nodeOne, nodeSix, 13));
            graph.AddConnection(new Edge(nodeFive, nodeSix, 3));
            graph.AddConnection(new Edge(nodeSix, nodeSeven, 2));
            graph.AddConnection(new Edge(nodeFive, nodeSeven, 1));
            //graph.AddConnection(new Edge(nodeTwo, nodeSeven, 4)); // Commented one Edge for testing

            //Expected sum init

            int sumExpected = 37;

            //Dijkstra check

            int sumActual = Dijkstra.DijkstraFunc(graph, nodeOne);

            //Assert

            Assert.AreNotEqual(sumExpected, sumActual);
        }
    }
}
