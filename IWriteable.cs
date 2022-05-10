interface IWriteable
{
    public string WriteString();
}
static class Writeable
{
    public static void Write(this IWriteable write)
    {
        if (write != null)
        {
            Console.Write(write.WriteString());
        }
    }
    public static void WriteLine(this IWriteable write)
    {
        if (write != null)
        {
            Console.WriteLine(write.WriteString());
        }
    }
}