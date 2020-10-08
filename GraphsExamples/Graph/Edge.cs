namespace GraphsExamples
{
    public class Edge
    {
        public Node NodeA { get; set; }

        public Node NodeB { get; set; }

        public int Value { get; set; }

        public Edge(Node nodeA, Node nodeB)
        {
            this.NodeA = nodeA;
            this.NodeB = nodeB;
            this.Value = 0;
        }

    }
}
