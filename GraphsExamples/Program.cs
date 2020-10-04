namespace GraphsExamples
{
    class Program
    {
        static void Main()
        {
            /*int[,] graphArray = new int[,]  { { 0, 4, 5, 0, 0 },
                                              { 4, 0, 3, 0, 0 },
                                              { 5, 3, 0, 9, 0 },
                                              { 0, 9, 0, 0, 2 },
                                              { 0, 0, 0, 2, 0 } };

            var d = new Dijkstra();
            d.dijkstra(graphArray, 0);*/

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
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
