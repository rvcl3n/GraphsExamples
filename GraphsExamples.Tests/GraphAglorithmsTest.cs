using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraphsExamples.Tests
{
    [TestClass]
    public class GraphAglorithmsTest
    {
        [TestMethod]
        public void BFSFunc_Graph_ReturnsAllGraphsNodes()
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
        public void DFSFunc_Graph_ReturnsAllGraphsNodes()
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

            HashSet<Node> dfsResult = DFS.DFSFunc(graph, nodeOne);

            //Assert

            Assert.AreEqual(true, HashSet<Node>.CreateSetComparer().Equals(dfsResult, graphsNodes));
        }
    }
}
