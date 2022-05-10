static partial class Program
{
    public static void FullFor<T>(Action<T> action, Func<T, bool> predicate, T value, Func<T, T> func)
    {
        for (T i = value; predicate(i); i = func(i))
        {
            action.Invoke(i);   
        }
    }
}