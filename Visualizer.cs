static class Visualizer
{
    public static void Write(object obj)
    {
        Console.Write("type :");
        Console.WriteLine(obj.GetType());
        Console.Write("text :");
        Console.WriteLine(obj.ToString());
        Console.Write("hash :");
        Console.WriteLine(obj.GetHashCode());
    }
    public static void Write<T>(T value, IStringProvider<T> stringProvider)
    {
        Console.WriteLine(stringProvider.ToString(value));
    }
    public static void Write(char value, int left, int top)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine(value);
    }
}