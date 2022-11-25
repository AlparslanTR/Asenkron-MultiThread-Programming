public class Program
{
    public static void Read(Task<string> data)
    {
        Console.WriteLine("Google Data Uzunluğu: " + data.Result.Length);
    }
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(Read);
        Console.WriteLine("Arada Yapılacak İşler");
        await myTask;
    }
}