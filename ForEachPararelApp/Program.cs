using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        string pathPictures = "C:\\Users\\byblu\\Desktop\\Pictures";
        var files= Directory.GetFiles(pathPictures);
        Parallel.ForEach(files, file =>
        {
            Console.WriteLine("Çalışan Thread No: "+Thread.CurrentThread.ManagedThreadId);
            Image img = new Bitmap(file);
            var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
            thumbnail.Save(Path.Combine(pathPictures,"thumbnail",Path.GetFileName(file)));
        });
        Console.WriteLine("İşlem Bitti");
    }
}