static partial class Program
{
    static int Sum(ulong value)
    {
        var accumulator = 0;
        foreach (var item in Convert(value, 10))
        {
            accumulator += item;
        }
        return accumulator;
    }
}