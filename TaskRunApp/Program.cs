public class Status
{
    public int ThreadId { get; set; }
    public DateTime Date { get; set; }
}

public class Program
{
    private static async Task Main(string[] args)
    {
        var myTask = Task.Factory.StartNew((obj) =>
        {
            Console.WriteLine("Task Çalıştı");
            var status = obj as Status;
            status.ThreadId = Thread.CurrentThread.ManagedThreadId;
        }, new Status() { Date = DateTime.Now });
        await myTask;
        Status s = myTask.AsyncState as Status;
        Console.WriteLine(s.Date);
        Console.WriteLine(s.ThreadId);
    }
}