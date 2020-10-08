namespace GraphsExamples
{
    public class Node
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public Node(string name)
        {
            this.Name = name;
            this.Value = 0;
        }
    }
}
