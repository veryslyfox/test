static partial class Program
{
    public static void For(Action<int> action, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            action.Invoke(i);
        }
    }   
}