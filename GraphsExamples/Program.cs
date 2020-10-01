namespace GraphsExamples
{
    class Program
    {
        static void Main()
        {
            int[,] graphArray = new int[,]  { { 0, 4, 5, 0, 0 },
                                              { 4, 0, 3, 0, 0 },
                                              { 5, 3, 0, 9, 0 },
                                              { 0, 9, 0, 0, 2 },
                                              { 0, 0, 0, 2, 0 } };

            var d = new Dijkstra();
            d.dijkstra(graphArray, 0);
        }
    }
}
