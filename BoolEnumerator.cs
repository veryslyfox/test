static class BoolEnumerator
{
    public static bool And(this IEnumerable<bool> collection)
    {
        foreach (var item in collection)
        {
            if (!item) { return false; }
        }
        return true;
    }
    public static bool Or(this IEnumerable<bool> collection)
    {
        foreach (var item in collection)
        {
            if (item) { return true; }
        }
        return false;
    }
}