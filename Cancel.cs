#pragma warning disable 
static class Cancel
{
    public static IDisposable[] Disposables { get; set; }
    public static char Char { get; set; }
    public static void Receive()
    {
        if (Console.ReadKey(true).KeyChar == Char)
        {
            foreach (var item in Disposables)
            {
                item.Dispose();
            }
        }
    }
}
