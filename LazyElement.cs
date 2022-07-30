struct LazyElement<T>
{
    public bool HasValue { get; private set; }
    public T Value { get; set; }
    public void Add(T value)
    {
        if (!HasValue)
        {
            Value = value;
        }
    }
}