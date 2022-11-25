using static System.Net.WebRequestMethods;

public class Content
{
    public string Site { get; set; }
    public int Lenght { get; set; }
}
public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);

        List<string> urlList = new List<string>()
        {
            "https://www.google.com",
            "https://www.amazon.com",
            "https://www.microsoft.com"
        };
        List<Task<Content>> taskList = new List<Task<Content>>();
        urlList.ToList().ForEach(x =>
        {
            taskList.Add(GetContentAsync(x));
        });
        var contents = await Task.WhenAll(taskList.ToArray());
        contents.ToList().ForEach(x =>
        {
            Console.WriteLine($"{x.Site} boyut:{x.Lenght}");
        });
    }

    public static async Task <Content> GetContentAsync(string url)
    {
        Content content = new Content();
        var data =await new HttpClient().GetStringAsync(url);
        content.Site = url;
        content.Lenght = data.Length;
        Console.WriteLine("GetContentAsync Thread: " + Thread.CurrentThread.ManagedThreadId);
        return content;
    }
}