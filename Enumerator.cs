static class Enumerator
{
    public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator)
    {
        return enumerator;
    }
}