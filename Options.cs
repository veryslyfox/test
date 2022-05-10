using System.Diagnostics;
enum TimeDiagnostics
{
    Ticks = 100000000,
    Milliseconds = 1000,
}
static class Options
{
    public static int Count<T>(T[]? array)
    {
        if (array is null)
        {
            return 0;
        }
        return array.Length;
    }
    public static long GetInvokeTime(Action action, TimeDiagnostics diagnostics)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        action.Invoke();
        if (diagnostics == TimeDiagnostics.Ticks)
        {
            return stopwatch.ElapsedMilliseconds;
        }
        return stopwatch.ElapsedTicks;
    }
    public static string? TypeString(object value)
    {
        var type = value.GetType();
        if (type == typeof(int))
        {
            return "int";
        }
        if (type == typeof(uint))
        {
            return "uint";
        }
        if (type == typeof(byte))
        {
            return "byte";
        }
        if (type == typeof(sbyte))
        {
            return "sbyte";
        }
        if (type == typeof(char))
        {
            return "char";
        }
        if (type == typeof(string))
        {
            return "string";
        }
        if (type == typeof(short))
        {
            return "short";
        }
        if (type == typeof(ushort))
        {
            return "ushort";
        }
        if (type == typeof(long))
        {
            return "long";
        }
        if (type == typeof(ulong))
        {
            return "ulong";
        }
        if (type == typeof(void))
        {
            return "void";
        }
        if (type == typeof(bool))
        {
            return "bool";
        }
        if (type == typeof(object))
        {
            return "object";
        }
        return type.Name;
    }
}