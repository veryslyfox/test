using System.Collections;
static class Enumerator
{
    public static IEnumerator GetEnumerator<T>(this IEnumerator enumerator)
    {
        return enumerator;
    }
}