#pragma warning disable
record Property<T>
{

    public Property(Func<T> get)
    {
        Get = get;
    }
    public Property(Func<T> get, Action<T> set)
    {
        Get = get;
        Set = set;
    }
    public Property(Action<T> set)
    {
        Set = set;
    }
    public Func<T>? Get { get; }
    public Action<T>? Set { get; }
    public T InvokeGet()
    {
        return Get();
    }
    public void InvokeSet(T value)
    {
        Set(value);
    }
    public (T, bool) TryInvokeGet()
    {
        return (Get(), Get is not null);
    }
    public bool TryInvokeSet(T value)
    {
        Set(value);
        return Set is not null;
    }
}
enum PropertyAutoCreateMode
{
    Get,
    GetOrSet
}
