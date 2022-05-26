interface IAsyncEquatable<T>
{
    Task<bool> GetEqualityTask(T other);
}
interface IAsyncComparable<T>
{
    Task<int> GetCompareTask(T other);
}
interface IAsyncEqualityComparer<T>
{
    Task<bool> GetEqualityTask(T first, T second);
}
interface IAsyncComparer<T>
{
    Task<int> GetCompareTask(T first, T second);
}
class Comparer : IAsyncComparer<int>
{
#pragma warning disable
    public async Task<int> GetCompareTask(int first, int second)
#pragma warning restore
    {
        return first.CompareTo(second);
    }
}