internal class Program
{
    private static void Main(string[] args)
    {
        int value=0;
        Parallel.ForEach(Enumerable.Range(1, 1000000).ToList(), (x) =>
        {
            value = x;
        });
        Console.WriteLine(value);
    }
}