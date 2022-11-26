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
        //var contents = await Task.WhenAll(taskList.ToArray()); // Burada bütün siteler geliyor.
        //contents.ToList().ForEach(x =>
        //{
        //    Console.WriteLine($"{x.Site} boyut:{x.Lenght}");
        //});

        /*var firstData= await Task.WhenAny(taskList);*/ // Herhangi 1 site geliyor.
        Console.WriteLine("Wait All Methodundan Önce");
        bool result= Task.WaitAll(taskList.ToArray(),3000); // 3 Saniye Bekletiyor.
        Console.WriteLine("3 Saniye Çalışıyor mu: "+result);
        Console.WriteLine("Wait All Methodundan Sonra 5 Saniye Bekle");
        await Task.Delay(5000); // 5 Saniye Sonra İşlemin Gerçekleşmesini Sağlar.
        Console.WriteLine($"{taskList.First().Result.Site} - {taskList.First().Result.Lenght}");

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