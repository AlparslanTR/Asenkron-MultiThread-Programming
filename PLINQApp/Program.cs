internal class Program
{
    private static void Main(string[] args)
    {
        var array = Enumerable.Range(1, 100).ToList();
        var newArray= array.AsParallel().Where(x=>x %2== 0 && x>20); // 20 ' den 100 e kadar 2 ye bölümünden 0 kalanları getir.
        newArray.ToList().ForEach(x=>
        Console.WriteLine(x));
    }
}